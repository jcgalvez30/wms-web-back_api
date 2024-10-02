namespace DataAccess_DisponibilidadUbicaciones.Models;

public class DisponibilidadUbicacionesModel {

    public class Request {
        public class Filtros {
            public string? sPasillo { get; set; }
            public int idCentro { get; set; }
            public int idWarehouse { get; set; }
        }
    }

    public class Response {
        public class Filtros {
            public string? oCentro { get; set; }
            public string? oWarehouse { get; set; }
        }
        public class Consulta {
            public string? sUbicacion { get; set; }
            public string? sAlmacen { get; set; }
            public string? sNombreAlmacen { get; set; }
            public string? sPasillo { get; set; }
            public decimal dVolumen { get; set; } 
            public string? sGrupo { get; set; }
            public string? sTipoUbicacion { get; set; }
            public string? sDisponible { get; set; }
            public string? sEstado { get; set; }
        }
    }
}