namespace DataAccess_ProgramacionIngreso.Models;

public class SeguridadModel {

    public class Request {
        public class ActualizarUsuarioDatosGenerales {
            public int idUsuario { get; set; }
            public string? sNombres { get; set; }
            public string? sApellidos { get; set; }
            public string? sEmail { get; set; }
            public string? sUsuarioModificacion { get; set; }
            public string? sArea { get; set; }
            public int idRolWeb { get; set; }
            public int idRolHandheld { get; set; }
            public int bWeb { get; set; }
            public int bHandheld { get; set; }
        }
        public class ValidarLogin {
            public string? sNombreUsuario { get; set; }
            public string? idAD { get; set; }
            public int iSistema { get; set; }
        }
        public class PermisoModulo {
            public int idRol { get; set; }
        }
    }

    public class Response {
        public class ValidarLogin {
            public int idUsuario { get; set; }
            public string? idAD { get; set; }
            public string? sNombreUsuario { get; set; }
            public string? sNombres { get; set; }
            public string? sApellidos { get; set; }
            public string? sEmail { get; set; }
            public string? sCelular { get; set; }
            public string? sArea { get; set; }
            public int idRolWeb { get; set; }
            public string? sRol { get; set; }
        }
        public class PermisoModulo {
            public int idPermiso { get; set; }
            public string? sPermiso { get; set; }
            public int idModulo { get; set; }
            public string? sModulo { get; set; }
        }

       
    }
}


