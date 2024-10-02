using DataAccess_Seguridad.DbAccess;
using DataAccess_Seguridad.Models;

using static DataAccess_Seguridad.Models.SeguridadModel.Request;

namespace DataAccess_Seguridad.Data;

public class SeguridadData : ISeguridadData {
    private readonly ISqlDataAccess _db;

    public SeguridadData( ISqlDataAccess db ) {
        _db = db;
    }


    public async Task<SeguridadModel.Response.ValidarLogin> GetUsuario( SeguridadModel.Request.ValidarLogin validarLogin ) {
        var result = await _db.LoadData<SeguridadModel.Response.ValidarLogin, dynamic>(
            "Seguridad.ValidarUsuario", new {
                sNombreUsuario = validarLogin.sNombreUsuario,
                iSistema = validarLogin.iSistema,
            });
        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<SeguridadModel.Response.ObtenerRoles>> GetRoles( SeguridadModel.Request.ValidarLogin validarLogin ) {
        var result = await _db.LoadData<SeguridadModel.Response.ObtenerRoles, dynamic>(
            "seguridad.ObtenerRoles", new {
                sNombreUsuario = validarLogin.sNombreUsuario,
                iSistema = validarLogin.iSistema
            });
        return result;
    }

    public async Task<IEnumerable<SeguridadModel.Response.PermisoModulo>> GetPermisoModulos( SeguridadModel.Request.PermisoModulo permisoModulo ) {
        var result = await _db.LoadData<SeguridadModel.Response.PermisoModulo, dynamic>(
            "seguridad.ObtenerModuloPermiso", new { sUsuario = permisoModulo.sUsuario });
        return result;
    }

    public Task InsertUsuarioCabecera( SeguridadModel.Request.User.InsertCabecera insert ) =>
        _db.SaveData("Seguridad.CrearUsuarioCabecera",
            new { insert.sUsuario, insert.sEmail, insert.sNombres, insert.sApellidos, insert.sCelular, insert.sArea });

    public async Task<int> ObtenerIdUsuario( string sUsuario ) {
        var result = await _db.LoadData<int, dynamic>("Seguridad.ObtenerIdUsuario",
            new { sUsuario });
        return result.FirstOrDefault();
    }

    public Task InsertUsuarioDetalle( SeguridadModel.Request.User.InsertDetalle insert ) =>
        _db.SaveData("Seguridad.CrearUsuarioDetalle",
            new { insert.idUsuario, insert.idRol, insert.idSistema });

    public Task EliminarUsuarioDetalle( int idUsuario ) =>
        _db.SaveData("Seguridad.EliminarUsuarioDetalle",
            new { idUsuario });

    public Task ActualizarUsuarioCabecera( SeguridadModel.Request.User.UpdateCabecera update ) =>
        _db.SaveData("Seguridad.ActualizarUsuarioCabecera",
            new { update.idUsuario, update.sEmail, update.sNombres, update.sApellidos, update.sCelular, update.sArea });

    public Task<IEnumerable<SeguridadModel.Response.Roles>> ListarRoles() =>
        _db.LoadData<SeguridadModel.Response.Roles, dynamic>("Seguridad.ListarRoles", new { });

    public Task Logout( SeguridadModel.Request.Logout logout ) =>
        _db.SaveData("Seguridad.Logout", new { logout.sUsuario, logout.sToken });

    public async Task<SeguridadModel.Response.EstadoSesion> EstadoSesion( SeguridadModel.Request.EstadoSesion estadoSesion ) {
        var result = await _db.LoadData<SeguridadModel.Response.EstadoSesion, dynamic>("Seguridad.EstadoSesion",
            new { estadoSesion.sToken });
        return result.FirstOrDefault();
    }

    public async Task<bool> PrimerLogin( SeguridadModel.Request.Login login ) {
        var result = await _db.LoadData<bool, dynamic>("Seguridad.PrimerLogin",
            new { login.sUsuario });
        return result.FirstOrDefault();
    }

    public Task Login( SeguridadModel.Request.Login login ) =>
        _db.SaveData("Seguridad.Login", new { login.sToken, login.sUsuario, login.sDevice, login.sIP });


    public async Task<string> TokenPrimerLogueo( SeguridadModel.Request.Login login ) {
        var result = await _db.LoadData<string, dynamic>("Seguridad.TokenPrimerLogueo",
            new { login.sUsuario });
        return result.FirstOrDefault();
    }

    public async Task<int> ValidarLink( string token ) {
        var result = await _db.LoadData<int, dynamic>("Seguridad.ValidarLink",
            new { sToken = token });
        return result.FirstOrDefault();
    }

    public Task CreaLink( string token, string usuario ) =>
        _db.SaveData("Seguridad.CrearLink", new { sToken = token, sUsuario = usuario });

    public async Task<SeguridadModel.Response.Usuario> ReactivarLink(string usuario ) {
        var result = await _db.LoadData<SeguridadModel.Response.Usuario, dynamic>("Seguridad.ReactivarLink",
            new { sUsuario = usuario});
        return result.FirstOrDefault();
    }

}