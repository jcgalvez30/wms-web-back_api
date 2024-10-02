namespace DataAccess_SIGA.Models;

public class ContratoModel {

    public class listar {
        public int idContrato { get; set; }
        public string? sContrato { get; set; }
    }

    public class documentos {
        public int idDocumento { get; set; }
        public string? sDocumento { get; set; }
        public DateTime? dtFechaDocumento { get; set; }
        public string? sTipoDocumento { get; set; }
        public int idProveedor { get; set; }
        public string? sProveedor { get; set; }
    }
}

