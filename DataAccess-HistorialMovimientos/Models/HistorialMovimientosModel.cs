namespace DataAccess_HistorialMovimientos.Models;

public class HistorialMovimientosModel {

    public class Request {
        public class Filtros {
            public string? itemCode { get; set; }
            public string? sDocumento { get; set; }
            public DateTime sFechaDesde { get; set; }
            public DateTime sFechaHasta { get; set; }
            public string? sLote { get; set; }
            public int idCentro { get; set; }
            public int idWarehouse { get; set; }
            public int idTipoTransaccion { get; set; }
        }
        public class FiltrosConsultaProducto {
            public int idEstrategia { get; set;}
            public string? sDescripcion { get; set; }
        }
    }

    public class Response {    
        public class Filtros {
            public string? oCentro { get; set; }
            public string? oWarehouse { get; set; }
            public string? oTipoTransaccion { get; set; }
        }
        public class Consulta {
            public string? sNroTransaccion { get; set; } 
            public string? sItemCode { get; set; }
            public string? sDescripcion { get; set; }
            public DateTime sFechaTransaccion { get; set; }
            public string? sHoraTransaccion { get; set; }
            public string? sTipoMovimiento { get; set; }
            public string? sTipoTransaccion { get; set; }
            public int iNroMovimiento { get; set; }
            public string? sAlmacen { get; set; }
            public string? sNombreAlmacen { get; set; }
            public string? sUbicacion { get; set; }
            public string? sEstrategia { get; set; }
            public string? sEstadoInventario { get; set; }
            public string? sLote { get; set; }
            public string? sMarca { get; set; }
            public int iIngreso { get; set; }
            public int iSalida { get; set; }
            public DateTime sFechaExpiracion { get; set; }
            public string? sDocumento { get; set; }
            public DateTime sFechaDocumento { get; set; }
            public string? sSolicitudProveedor { get; set; }
            public string? sComentario { get; set; }
            public string? sCodDe { get; set; }
            public string? sNombreDe { get; set; }
            public string? sUsuarioTransaccion { get; set; }
        }
        public class FiltrosConsultaProducto {
            public string? oEstrategia { get; set; }
        }
        public class ConsultaProducto {
            public string? sItemCode { get;set; }
            public string? sDescripcion { get; set; }
            public string? sEstrategia { get; set; }
            public string? sUnidadMedida { get; set; }
        }
    }
}