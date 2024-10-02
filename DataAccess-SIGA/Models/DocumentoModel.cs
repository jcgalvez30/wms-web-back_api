namespace DataAccess_SIGA.Models;

public class DocumentoModel {
    public int idProcedencia { get; set; }
    public string? sProcedencia { get; set; }
    public int idAlmacen { get; set; }
    public string? sAlmacen { get; set; }
    public int idIngreso { get; set; }
    public string? sIngreso { get; set; }
    public int idPropietario { get; set; }
    public string? sPropietario { get; set; }
    public int idProveedor { get; set; }
    public string? sProveedor { get; set; }
    public string? oProductos { get; set; }
}

