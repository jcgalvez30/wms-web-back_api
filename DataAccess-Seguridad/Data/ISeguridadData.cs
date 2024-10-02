using DataAccess_Seguridad.DbAccess;
using DataAccess_Seguridad.Models;

using static DataAccess_Seguridad.Models.SeguridadModel.Request;

namespace DataAccess_Seguridad.Data;

public interface ISeguridadData {
    Task<SeguridadModel.Response.ValidarLogin> GetUsuario( SeguridadModel.Request.ValidarLogin validarLogin );
    Task<IEnumerable<SeguridadModel.Response.PermisoModulo>> GetPermisoModulos( SeguridadModel.Request.PermisoModulo permisoModulorequest );

    Task<IEnumerable<SeguridadModel.Response.ObtenerRoles>> GetRoles( SeguridadModel.Request.ValidarLogin validarLogin );

    Task InsertUsuarioCabecera( SeguridadModel.Request.User.InsertCabecera insert );

    Task<int> ObtenerIdUsuario( string sUsuario );

    Task InsertUsuarioDetalle( SeguridadModel.Request.User.InsertDetalle insert );

    Task EliminarUsuarioDetalle( int idUsuario );

    Task ActualizarUsuarioCabecera( SeguridadModel.Request.User.UpdateCabecera update );

    Task<IEnumerable<SeguridadModel.Response.Roles>> ListarRoles();

    Task Logout(SeguridadModel.Request.Logout logout ); 

    Task<SeguridadModel.Response.EstadoSesion> EstadoSesion(SeguridadModel.Request.EstadoSesion estadoSesion );

    Task Login(SeguridadModel.Request.Login login );

    Task<bool> PrimerLogin( SeguridadModel.Request.Login login );

    Task<string> TokenPrimerLogueo( SeguridadModel.Request.Login login );

    Task<int> ValidarLink( string token );

    Task CreaLink( string token, string usuario );

    Task<SeguridadModel.Response.Usuario> ReactivarLink( string usuario );

    //Task<SeguridadModel.Response.>
}
