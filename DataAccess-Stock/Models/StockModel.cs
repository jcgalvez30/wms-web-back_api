namespace DataAccess_Stock.Models;

public class StockModel {

    public class parametrosConsulta {
        public string? idProducto { get; set; }
        public string? sProducto { get; set; }
    }

    public class listaConsulta {
        public string? idProducto { get; set; }
        public string? sProducto { get; set; }
        public string? sUnidadMedida { get; set; }
        public float nCantidad { get; set; }
    }

}


