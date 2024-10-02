namespace DataAccess_Recepcion.Models;


public class RecepcionModel {

    public class SelectCabecera {
        public string? sDocumento { get; set; }
        public string? sProveedor { get; set; }
        public float nCantidad { get; set; }
        public DateTime dtFechaCita { get; set; }
        public float nCantidadTotal { get; set; }   
    }

    public class SelectDetalle {
        public string? idProducto { get; set; }
        public string? sProducto { get; set; }
        public string? sUnidadMedida { get; set; }
        public decimal nCantidad { get; set; }
    }
}