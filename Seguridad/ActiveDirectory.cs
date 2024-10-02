using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Security.Principal;

namespace Seguridad;

public class ActiveDirectory {
    public JsonResult Login( string UserName, string Password ) {
        bool isValid = false;
        var resultOK = new JsonResult(new { token = "" });
        var resultERROR = new JsonResult(new { message = "", StatusCode = 0 });
        try {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "cenaresdc", @"chpwd", "ABCabc123")) {
                isValid = pc.ValidateCredentials(UserName, Password);
                if (isValid) {
                    var _token = TokenService.GenerateToken(UserName);
                    resultOK.Value = new { message = _token, StatusCode = 200 };
                    return resultOK;
                } else {
                    resultERROR.Value = new { message = "Credenciales incorrectas o Usuario no existe en AD", StatusCode = 401 };
                    return resultERROR;
                }
            }
        } catch (Exception ex) {
            resultERROR.Value = new { message = "Dominio o DNS del Servidor no válido para las credenciales ingresadas: " + ex.Message, StatusCode = 400 };
            return resultERROR;
        }
    }

    public JsonResult ResetearPassword( string UserName, string Password ) {
        var result = new JsonResult(new { });
        bool isValid = false;
        try {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "cenaresdc", @"chpwd", "ABCabc123")) {
               // isValid = pc.ValidateCredentials(UserName, Password);
                UserPrincipal user = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, UserName);
                user.SetPassword(Password);
                //user.ExpirePasswordNow(); // fuerza cambiar contraseña en el proximo login
                user.Save();
            }
            result.Value = new { message = "Se cambio correctamente la contraseña", valid = 1 };
            return result;
        } catch (Exception ex) {
            result.Value = new { message = ex.Message, valid = 0 };
            return result;
        }
    }

    public JsonResult CrearUsuario( string UserName, string Password ) {
        var result = new JsonResult(new { });
        try {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "cenaresdc", @"chpwd", "ABCabc123")) {
                UserPrincipal up = new UserPrincipal(pc);
                up.SamAccountName = UserName;
                up.SetPassword(Password);
                up.Enabled = true;
                up.PasswordNeverExpires = true;
                up.UserCannotChangePassword = true;
                up.Save();
                // up.ExpirePasswordNow();
            }
            result.Value = new { message = "Se creo correctamente el usuario", valid = true.ToString() };
            return result;
        } catch (Exception ex) {
            result.Value = new { message = ex.Message, valid = false.ToString() };
            return result;
        }
    }

    public JsonResult CambiarPassword( string UserName, string OldPassword, string NewPassword ) {
        var result = new JsonResult(new { });
        var temp = "";
        try {
            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "cenaresdc", @"chpwd", "ABCabc123")) {
                temp = temp + " 1";
                UserPrincipal user = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, UserName);
                temp = temp + " 2";
                user.ChangePassword(OldPassword, NewPassword);
                temp = temp + " 3";
                user.Save();
                temp = temp + " 4";
            }
            result.Value = new { message = "Se cambio correctamente la contraseña", valid = true.ToString() };
            temp = temp + " 5";
            return result;
        } catch (Exception ex) {
            var parametros = string.Concat(UserName, ' ', OldPassword, ' ', NewPassword);
            result.Value = new { message = ex.Message + ' ' + parametros, valid = false.ToString() };
            return result;
        }
    }

    public JsonResult ExisteUsuario( string UserName ) {
        var result = new JsonResult(new { });
        try {
            //using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "cenaresdc")) {
            //    UserPrincipal user = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName, UserName);
            //    result.Value = new { message = user, valid = true.ToString() };
            //}

            //AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            //WindowsPrincipal principal = (WindowsPrincipal)Thread.CurrentPrincipal;
            //String adDomainUserName = principal.Identity.Name;

            using (PrincipalContext pc = new PrincipalContext(ContextType.Domain)) {
                UserPrincipal up = UserPrincipal.FindByIdentity(pc, IdentityType.UserPrincipalName, UserName);
                result.Value = new {
                    message=up, 
                    valid=true.ToString()};
            }

            return result;
        } catch (Exception ex) {
            result.Value = new { message = ex.Message, valid = false.ToString() };
            return result;
        }
    }

}