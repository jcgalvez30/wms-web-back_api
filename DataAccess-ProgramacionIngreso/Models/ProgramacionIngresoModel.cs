namespace DataAccess_ProgramacionIngreso.Models;


public class ProgramacionIngresoModel
{

    public class Request
    {
        
        public class Filtros
        {
            public int IdProveedor { get; set; }
            public string? ContratoInicio { get; set; }
            public string? ContratoFin { get; set; }
            public string? Documento { get; set; }
        }

        public class FiltrosTipoDocumento
        {
            public string? A { get; set; }
            public string? B { get; set; }
            public string? C { get; set; }
        }
    }

    public class Insert
    {
        public string? sContrato { get; set; }
        public string? sDocumento { get; set; }
        public int idTipoDocumento { get; set; }
        public int idProcedencia { get; set; }
        public int idAlmacen { get; set; }
        public int iPeriodo { get; set; }
        public int idIngreso { get; set; }
        public int iNumeroEntrega { get; set; }
        public int iMesNominal { get; set; }
        public int iPlazoEntrega { get; set; }
        public DateTime dtFechaNotificacion { get; set; }
        public DateTime dtFechaCita { get; set; }
        public int idPropietario { get; set; }
        public string sProveedor { get; set; }
        public int idProveedor { get; set; }
        public string? sComentario { get; set; }
        public string? sRuc { get; set; }
        public string? sAlmacen { get; set; }
        public string? sSecAlmacen { get; set; }
        public string? sNombreAlmacen { get; set; }
        public string? sUsuarioModificacion { get; set; }
        public List<InsertDetalle>? detalleMovil { get; set; }
    }

    public class InsertDetalle
    {
        public string sDocumento { get; set; }
        public int lineNumber { get; set; }
        public string itemNumber { get; set; }
        public int qty { get; set; }
        public string orderUOM { get; set; }
        public double unitPrice { get; set; }
    }
    

    public class Update
    {
        public int idProgramacionIngreso { get; set; }
        public int idAlmacen { get; set; }
        public int iPeriodo { get; set; }
        public int idIngreso { get; set; }
        public int iNumeroEntrega { get; set; }
        public int iMesNominal { get; set; }
        public int iPlazoEntrega { get; set; }
        public DateTime dtFechaNotificacion { get; set; }
        public DateTime dtFechaCita { get; set; }
        public int idPropietario { get; set; }
        public int idProveedor { get; set; }
        public string? sComentario { get; set; }
        public string? sUsuarioModificacion { get; set; }
    }

    public class SelectFormulario
    {
        public int idProgramacionIngreso { get; set; }
        public int idContrato { get; set; }
        public string? sContrato { get; set; }
        public int idDocumento { get; set; }
        public int idTipoDocumento { get; set; }
        public string? sNumeroDocumento { get; set; }
        public DateTime dtFechaEmision { get; set; }
        public int idProcedencia { get; set; }
        public int idAlmacen { get; set; }
        public int iPeriodo { get; set; }
        public int idIngreso { get; set; }
        public int iNumeroEntrega { get; set; }
        public int iMesNominal { get; set; }
        public int iPlazoEntrega { get; set; }
        public DateTime dtFechaNotificacion { get; set; }
        public DateTime dtFechaCita { get; set; }
        public int idPropietario { get; set; }
        public int idProveedor { get; set; }
        public string? sComentario { get; set; }
        public string? oProductos { get; set; }
    }

    public class SelectGrilla
    {
        public int idProgramacionIngreso { get; set; }
        public int iPeriodo { get; set; }
        public string? sDocumento { get; set; }
        public DateTime dtCreacion{ get; set; }
        public DateTime dtFechaCita { get; set; }
        public string? sProcedencia { get; set; }
        public string? sAlmacen { get; set; }
        public string? sMesNominal { get; set; }
        public string? sPropietario { get; set; }
        public string? sProveedor { get; set; }
        public string? sContrato { get; set; }
        public string? sDespacho { get; set; }
        public string? iOC { get; set; }
        public string? sComentario { get; set; }
        public int iPlazoEntrega { get; set; }
        public int idTipoDocumento { get; set; }
        public string? vTipoDocumento { get; set; }
    }

    public class FiltrosGrilla
    {
        public int iProveedor { get; set; }
        public string? sContrato { get; set; }
        public string? sDocumento { get; set; }
    }

    public class Response
    {
        public class Insert
        {
            public string iCod { get; set; }
            public string sDocumento { get; set; }
            public string vDesc { get; set; }
        }
        public class Item
        {
            public string? value { get; set; }
            public string? display { get; set; }
        }

    }

}