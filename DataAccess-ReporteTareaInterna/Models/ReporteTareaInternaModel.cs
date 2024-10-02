namespace DataAccess_ReporteTareaInterna.Models;

public class ReporteTareaInternaModel {

    public class Request {
        public class Filtros {
            public string? sFechaDesde { get; set; }
            public string? sFechaHasta { get; set; }
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
            public string? sNroOrden { get; set; }
            public string? sFechaInicio { get; set; }
            public string? sHoraInicio { get; set; }
            public string? sFechaFin { get; set; }
            public string? sHoraFin { get; set; }
            public string? sOperario { get; set; }
            public string? sUbicacionTransito { get; set; }
        }
    }
}