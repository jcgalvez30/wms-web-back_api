namespace DataAccess_Seguridad.Models;

public class SeguridadModel {

    public class Request {
        public class ValidarLogin {
            public string? sNombreUsuario { get; set; }
            public int iSistema { get; set; }
        }
        public class PermisoModulo {
            public string? sUsuario { get; set; }
        }
        public class Login {
            public string? sUsuario { get; set; }
            public string? sPassword { get; set; }
            public int iSistema { get; set; }
            public string? sToken { get; set; }
            public string? sDevice { get; set; }
            public string? sIP { get; set; }
        }
        public class Logout {
            public string? sUsuario { get; set; }
            public string? sToken { get; set; }
        }
        public class EstadoSesion {
            public string? sToken { get; set; }
        }
        public class User {
            public class InsertCabecera {
                public string? sUsuario { get; set; }
                public string? sEmail { get; set; }
                public string? sNombres { get; set; }
                public string? sApellidos { get; set; }
                public string? sCelular { get; set; }
                public string? sArea { get; set; }
                public List<InsertDetalle?> oDetalle { get; set; }
            }
            public class UpdateCabecera {
                public int idUsuario { get; set; }
                public string? sEmail { get; set; }
                public string? sNombres { get; set; }
                public string? sApellidos { get; set; }
                public string? sCelular { get; set; }
                public string? sArea { get; set; }
                public List<InsertDetalle?> oDetalle { get; set; }
            }
            public class InsertDetalle {
                public int idUsuario { get; set; }
                public int idRol { get; set; }
                public int idSistema { get; set; }
            }
        }
        public class CambiarPassword {
            public string? sUsuario { get; set; }
            public string? sOldPassword { get; set; }
            public string? sNewPassword { get; set; }
        }
        public class ResetearPassword {
            public string? sUsuario { get; set; }
            public string? sNewPassword { get; set; }
        }
    }

    public class Response {
        //public class ValidarLogin {
        //    public int idUsuario { get; set; }
        //    public string? sNombreUsuario { get; set; }
        //    public string? sNombreCompleto { get; set; }
        //}

        public class ValidarLogin
        {
            public int idUsuario { get; set; }
            public string? sNombreUsuario { get; set; }
            public string? sNombreCompleto { get; set; }
            public string? sEmail { get; set; }
            public string? sNombres { get; set; }
            public string? sApellidos { get; set; }
            public string? sCelular { get; set; }
            public string? idRolWeb { get; set; }
        }

        public class ObtenerRoles {
            public int idRol { get; set; }
            public string? sRol { get; set; }
        }
        public class PermisoModulo {
            public int idRol { get; set; }
            public int idMenu { get; set; }
            public int idMenuPadre { get; set; }
            public int iNivel { get; set; }
            public int iOrden { get; set; }
            public string? sNombre { get; set; }
            public string? sURL { get; set; }
        }
        public class Roles {
            public int idRol { get; set; }
            public string? sRol { get; set; }
        }
        public class Usuario {
            public string? sUsuario { get; set; }
            public string? sToken { get; set; }
            public string? sNombreCompleto { get; set; }
            public string? sEmail { get; set; }
        }
        public class EstadoSesion {
            public bool bActivo { get; set; }
            public string? sUsuario { get; set; }
        }

    }
}


