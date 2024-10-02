using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using static DataAccess_Seguridad.Models.SeguridadModel.Request;
using static DataAccess_Seguridad.Models.SeguridadModel.Request.User;
using static DataAccess_Seguridad.Models.SeguridadModel.Response;

namespace Seguridad;

public static class Api {
    public static void ConfigureApi( this WebApplication app ) {
        app.MapPost("/CrearUsuario", CrearUsuario).AllowAnonymous();
        app.MapPut("/ActualizarUsuario", ActualizarUsuarioDatosGenerales).AllowAnonymous();
        app.MapPost("/Login", Login).AllowAnonymous();
        app.MapPost("/CambiarPassword", CambiarPassword).AllowAnonymous();
        app.MapPost("/ResetearPassword", ResetPassword).AllowAnonymous();
        app.MapPost("/ConsultarUsuario", ConsultarUsuario).AllowAnonymous();
        app.MapGet("/ObtenerRoles", ListarRoles).AllowAnonymous();
        app.MapPost("/logout", Logout).AllowAnonymous();
        app.MapPost("/EstadoSesion", EstadoSesion).AllowAnonymous();
        app.MapPost("/ValidarLink/", ValidarLink).AllowAnonymous();
        app.MapPost("/ReactivarLink", ReactivarLink).AllowAnonymous();
        app.MapGet("/ListarUsuarios", ListarUsuarios).AllowAnonymous();
        app.MapGet("/EnviarCorreo/{usuario}", EnvioCorreo).AllowAnonymous();
        app.MapGet("/menu/{usuario}", GetMenu).AllowAnonymous();
    }

    private static async Task<IResult> CrearUsuario( SeguridadModel.Request.User.InsertCabecera insertCabecera, ISeguridadData data) {
        try {
            ActiveDirectory AD = new ActiveDirectory();
            GeneradorPassword GP = new GeneradorPassword();
            EnviarCorreo EC = new EnviarCorreo();

            var pass = GP.GenerarPassword();

            var msg = AD.CrearUsuario(insertCabecera.sUsuario, pass);
            dynamic stuff = JObject.Parse(JsonConvert.SerializeObject(msg.Value));
            var message = stuff["message"].ToString();
            var valid = stuff["valid"].ToString();

            if (valid == true.ToString()) {
                await data.InsertUsuarioCabecera(insertCabecera);
                int _idUsuario = await data.ObtenerIdUsuario(insertCabecera.sUsuario);
                foreach (var item in insertCabecera.oDetalle) {
                    item.idUsuario = _idUsuario;
                    await data.InsertUsuarioDetalle(item);
                }

                await data.CreaLink(pass, insertCabecera.sUsuario);

                string sBody = EC.BodyNuevoUsuario(insertCabecera.sUsuario, pass, insertCabecera.sNombres, insertCabecera.sApellidos);
                string sAsunto = "Creación de Usuario WMS";
                EC.Email(insertCabecera.sEmail, sBody, sAsunto);
            }
            return Results.Ok(new { message = "Se creo correctamente el usuario", valid = valid });
        } catch (Exception ex) {
            return Results.Ok(new {message = ex.Message, valid = false.ToString()});
        }
    }

    private static async Task<IResult> ActualizarUsuarioDatosGenerales( SeguridadModel.Request.User.UpdateCabecera updateCabecera, ISeguridadData data ) {
        try {
            await data.ActualizarUsuarioCabecera(updateCabecera);
            await data.EliminarUsuarioDetalle(updateCabecera.idUsuario);
            foreach (var item in updateCabecera.oDetalle) {
                await data.InsertUsuarioDetalle(item);
            }
            return Results.Ok(new { message = "Se actualizo correctamente el usuario", valid = true.ToString() });
        } catch (Exception ex) {
            return Results.Ok(new { message = ex.Message, valid = false.ToString() });
        }
    }

    private static async Task<IResult> Login( SeguridadModel.Request.Login login, ISeguridadData data ) {
        try {
            //--- reviso si hay sesion activa para el token
            EnviarCorreo EC = new EnviarCorreo();
            if (login.sToken == "") {
                //--- Validar login contra AD, Si se loguea correctamente devuelve status = 200 y en message regresa el Token generado
                ActiveDirectory AD = new ActiveDirectory();
                var token = AD.Login(login.sUsuario, login.sPassword);
                dynamic stuff = JObject.Parse(JsonConvert.SerializeObject(token.Value));
                var status = stuff["StatusCode"].ToString();
                var message = stuff["message"].ToString();
                //--- si status = 200, se procede a realizar las validaciones contra la BD del WMS
                if (status == "200") {
                    login.sToken = message;
                    var primerLogin = await data.PrimerLogin(login);
                    if (primerLogin) {
                        string tokenPrimerLogin = await data.TokenPrimerLogueo(login);
                        if (tokenPrimerLogin == "") {
                            return Results.Ok(new {
                                PrimerLogin = primerLogin,
                                valid = 0,
                                message = "Vencio el acceso al link"
                            }); ;
                        } else {
                            return Results.Ok(new {
                                PrimerLogin = primerLogin,
                                valid = 1,
                                Redirect = "http://DESKTOP-QE80JJK/login/" + tokenPrimerLogin
                            });
                        }
                    } else {
                        //--- lleno objeto validarLogin con parametros que llegan del login y el token
                        SeguridadModel.Request.ValidarLogin validarLogin = new SeguridadModel.Request.ValidarLogin();
                        validarLogin.iSistema = login.iSistema;
                        validarLogin.sNombreUsuario = login.sUsuario;
                        SeguridadModel.Response.ValidarLogin resultsUsuario = await data.GetUsuario(validarLogin);
                        SeguridadModel.Request.PermisoModulo permisoModulo = new SeguridadModel.Request.PermisoModulo();
                        permisoModulo.sUsuario = login.sUsuario.ToString();
                        IEnumerable<SeguridadModel.Response.PermisoModulo> resultPermisos = await data.GetPermisoModulos(permisoModulo);
                        IEnumerable<SeguridadModel.Response.ObtenerRoles> roles = await data.GetRoles(validarLogin);
                        await data.Login(login);
                        return Results.Ok(new {
                            valid = 1,
                            PrimerLogin = primerLogin,
                            Token = message,
                            Usuario = resultsUsuario,
                            Permisos = resultPermisos,
                            Rol = roles,
                            tokenPrueba = login.sToken
                        });
                    }
                } else {
                    return Results.Ok(new { message = message, valid = false.ToString() });
                }
            } else {
                SeguridadModel.Request.EstadoSesion estadoSesion = new SeguridadModel.Request.EstadoSesion();
                estadoSesion.sToken = login.sToken;
                var activa = await data.EstadoSesion(estadoSesion);
                if (activa.bActivo) {
                    //--- lleno objeto validarLogin con parametros que llegan del login y el token
                    SeguridadModel.Request.ValidarLogin validarLogin = new SeguridadModel.Request.ValidarLogin();
                    validarLogin.iSistema = login.iSistema;
                    validarLogin.sNombreUsuario = login.sUsuario;
                    SeguridadModel.Response.ValidarLogin resultsUsuario = await data.GetUsuario(validarLogin);
                    SeguridadModel.Request.PermisoModulo permisoModulo = new SeguridadModel.Request.PermisoModulo();
                    permisoModulo.sUsuario = login.sUsuario.ToString();
                    IEnumerable<SeguridadModel.Response.PermisoModulo> resultPermisos = await data.GetPermisoModulos(permisoModulo);
                    IEnumerable<SeguridadModel.Response.ObtenerRoles> roles = await data.GetRoles(validarLogin);
                    await data.Login(login);
                    return Results.Ok(new {
                        valid = 1,
                        Token = estadoSesion.sToken,
                        Usuario = resultsUsuario,
                        Permisos = resultPermisos,
                        Roles = roles
                    });
                } else {
                    //--- Validar login contra AD, Si se loguea correctamente devuelve status = 200 y en message regresa el Token generado
                    ActiveDirectory AD = new ActiveDirectory();
                    var token = AD.Login(login.sUsuario, login.sPassword);
                    dynamic stuff = JObject.Parse(JsonConvert.SerializeObject(token.Value));
                    var status = stuff["StatusCode"].ToString();
                    var message = stuff["message"].ToString();
                    //--- si status = 200, se procede a realizar las validaciones contra la BD del WMS
                    if (status == "200") {
                        //--- lleno objeto validarLogin con parametros que llegan del login y el token
                        SeguridadModel.Request.ValidarLogin validarLogin = new SeguridadModel.Request.ValidarLogin();
                        validarLogin.iSistema = login.iSistema;
                        validarLogin.sNombreUsuario = login.sUsuario;
                        SeguridadModel.Response.ValidarLogin resultsUsuario = await data.GetUsuario(validarLogin);
                        SeguridadModel.Request.PermisoModulo permisoModulo = new SeguridadModel.Request.PermisoModulo();
                        permisoModulo.sUsuario = login.sUsuario.ToString();
                        IEnumerable<SeguridadModel.Response.PermisoModulo> resultPermisos = await data.GetPermisoModulos(permisoModulo);
                        IEnumerable<SeguridadModel.Response.ObtenerRoles> roles = await data.GetRoles(validarLogin);
                        await data.Login(login);
                        return Results.Ok(new {
                            valid = 1,
                            Token = message,
                            Usuario = resultsUsuario,
                            Permisos = resultPermisos,
                            Roles = roles
                        });
                    } else {
                        return Results.Ok(new { message = message, valid = 0 });
                    }
                }
            }
        } catch (Exception ex) {
            return Results.Ok(new { message = ex.Message, valid = false.ToString() });
        }
    }
    private static async Task<IResult> GetMenu (string usuario, ISeguridadData data ) {
        SeguridadModel.Request.PermisoModulo permisoModulo = new SeguridadModel.Request.PermisoModulo();
        permisoModulo.sUsuario = usuario;
        IEnumerable<SeguridadModel.Response.PermisoModulo> resultPermisos = await data.GetPermisoModulos(permisoModulo);
        return Results.Ok(new { });

    }
    private static async Task<IResult> CambiarPassword( SeguridadModel.Request.CambiarPassword cambiarPassword) {
        try {
            ActiveDirectory AD = new ActiveDirectory();

            var token = AD.Login(cambiarPassword.sUsuario, cambiarPassword.sOldPassword);
            dynamic stuff = JObject.Parse(JsonConvert.SerializeObject(token.Value));
            var status = stuff["StatusCode"].ToString();
            var message = stuff["message"].ToString();

            if (status == "200") {
                SeguridadModel.Request.ResetearPassword reset = new ResetearPassword();
                reset.sUsuario = cambiarPassword.sUsuario;
                reset.sNewPassword = cambiarPassword.sNewPassword;
                var msg = AD.ResetearPassword(reset.sUsuario, reset.sNewPassword);
                dynamic stuff2 = JObject.Parse(JsonConvert.SerializeObject(msg.Value));
                var message2 = stuff["message"].ToString();
                var valid2 = stuff["valid"].ToString();
                return Results.Ok(new { message = message, valid = valid2 });
            } else {
                return Results.Ok(new {message = "Usuario o Contraseña invalidos", valid = 0});
            }
        } catch (Exception ex) {
            return Results.Ok(new { message = "entro al catch principal" + ex.Message, valid = false.ToString() });
        }
    }
    private static async Task<IResult> ResetPassword( SeguridadModel.Request.ResetearPassword resetearPassword ) {
        ActiveDirectory AD = new ActiveDirectory();
        var msg = AD.ResetearPassword(resetearPassword.sUsuario, resetearPassword.sNewPassword);
        dynamic stuff = JObject.Parse(JsonConvert.SerializeObject(msg.Value));
        var message = stuff["message"].ToString();
        var valid = stuff["valid"].ToString();
        return Results.Ok(new { message = message, valid = valid });
    }
    private static async Task<IResult> ConsultarUsuario(string sUsuario ) {
        try {
            ActiveDirectory AD = new ActiveDirectory();
            var msg = AD.ExisteUsuario(sUsuario);
            dynamic stuff = JObject.Parse(JsonConvert.SerializeObject(msg.Value));
            var message = stuff["message"].ToString();
            var valid = stuff["valid"].ToString();
            return Results.Ok(new { message = stuff, valid = valid });
        } catch (Exception ex) {
            return Results.Ok(new { message = ex.Message, valid = false.ToString() });
        }
    }
    private static async Task<IResult> ListarRoles( ISeguridadData data) {
        try {
            IEnumerable<SeguridadModel.Response.Roles> resultRoles = await data.ListarRoles();
            return Results.Ok(new {roles = resultRoles, valid = true.ToString()});
        } catch (Exception ex) {
            return Results.Ok(new { message = ex.Message, valid = false.ToString() });
        }
    }
    private static async Task<IResult> Logout (SeguridadModel.Request.Logout logout, ISeguridadData data) {
        try {
            await data.Logout(logout);
            return Results.Ok(new { message = "Se Cerro Sesión correctamente", valid = 1 });
        } catch (Exception ex) {
            return Results.Ok(new { message = ex.Message, valid = 0 });
        }
    }

    private static async Task<IResult> EstadoSesion ( SeguridadModel.Request.EstadoSesion estadoSesion, ISeguridadData data ) {
        try {
            SeguridadModel.Response.EstadoSesion result = await data.EstadoSesion(estadoSesion);
            if (result.bActivo) {
                SeguridadModel.Request.ValidarLogin validarLogin = new SeguridadModel.Request.ValidarLogin();
                validarLogin.sNombreUsuario = result.sUsuario;
                validarLogin.iSistema = 1;
                SeguridadModel.Response.ValidarLogin resultsUsuario = await data.GetUsuario(validarLogin);
                SeguridadModel.Request.PermisoModulo permisoModulo = new SeguridadModel.Request.PermisoModulo();
                permisoModulo.sUsuario = result.sUsuario;
                IEnumerable<SeguridadModel.Response.PermisoModulo> resultPermisos = await data.GetPermisoModulos(permisoModulo);
                IEnumerable<SeguridadModel.Response.ObtenerRoles> roles = await data.GetRoles(validarLogin);

                return Results.Ok(new { 
                    message = "Sesion Activa", 
                    valid = 1,
                    Token = estadoSesion,
                    Usuario = resultsUsuario,
                    Permisos = resultPermisos,
                    Roles = roles
                });
            } else { return Results.Ok(new { message = "Sesion Inactiva", valid = 0 }); }
        } catch (Exception ex) {
            return Results.Ok(new { message = ex.Message, valid = 0 });
        }
    }

    private static async Task<IResult> EnvioCorreo(string usuario, ISeguridadData data) {
        EnviarCorreo EC = new EnviarCorreo();
        var _token = TokenService.GenerateToken(usuario);
        await data.CreaLink(_token, usuario);
        var _usuario = await data.ReactivarLink(usuario);
        string sBody = EC.BodyReestablecerPassword(_usuario.sUsuario, _usuario.sToken, _usuario.sNombreCompleto);
        string sAsunto = "Reestablecer Contraseña de Usuario WMS";
        EC.Email(_usuario.sEmail, sBody, sAsunto);
        return Results.Ok(new { message = "Envio satisfactorio", valid = 1 });
    }

    private static async Task<IResult> ValidarLink(string Token, ISeguridadData data ) {
        try {
            var linkActivo = await data.ValidarLink(Token);
            return Results.Ok(new {
                Activo = linkActivo
            });
        } catch (Exception ex) {
            return Results.Ok(new {
                Activo = 0,
                message = ex.Message
            });
        }
    }

    private static async Task<IResult> ReactivarLink(string Usuario, ISeguridadData data ) {
        try {
            EnviarCorreo EC = new EnviarCorreo();
            var _usuario = await data.ReactivarLink(Usuario);
            string sBody = EC.BodyReactivarLink(_usuario.sUsuario, _usuario.sToken, _usuario.sNombreCompleto);
            string sAsunto = "Reactivacion de Link de Activacion de Usuario WMS";
            EC.Email(_usuario.sEmail, sBody, sAsunto);
            return Results.Ok(new {
                Activo = 1,
                message = "Se reactivo el Link"
            });
        } catch (Exception ex) {
            return Results.Ok(new {
                Activo = 0,
                message = ex.Message
            });
        }
    }

    private static async Task<IResult> ListarUsuarios(ISeguridadData data ) {
        try {

        } catch (Exception ex) {

            throw;
        }
        return Results.Ok(new { });
    }
}
