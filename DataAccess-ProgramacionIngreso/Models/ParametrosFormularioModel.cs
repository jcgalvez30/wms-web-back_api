namespace DataAccess_ProgramacionIngreso.Models;

public class ParametrosFormularioModel {
    public string? TipoDocumento { get; set; }
    public string? Procedencia { get; set; }
    public string? Almacen { get; set; }
    public string? Ingreso { get; set; }
    public string? Propietario { get; set; }
    public string? Proveedor { get; set; }
}

public class ProgramacionIngreso {
    public class response {
        public class TipoDocumento {
            public int iTipoTransaccion { get;set; }
            public string? sDescripcion { get; set; }
            public string? sAbrev { get; set; }
        }
    }
}

