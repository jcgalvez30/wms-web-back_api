namespace DataAccess_SIGA2.Models;

public class SIGA2Model {

    public class Request {
        public class CabeceraOC {
            public int I_ANO_EJE { get; set; }
            public int I_NRO_ORDEN { get; set; }
        }
        public class CabeceraNEA { 
            public int I_ANO_EJE { get; set; }
            public int I_TIPO_TRANSAC { get; set; }
            public int I_NRO_REQUERIM { get; set; }
        }
        public class DetalleOC {
            public int I_ANO_EJE { get; set; }
            public int I_NRO_ORDEN { get; set; }
        }
        public class DetalleNEA {
            public int I_ANO_EJE { get; set; }
            public int I_NRO_REQUERIM { get; set; }
        }
        public class RecepcionCabecera {
            public int ANO_EJE { get; set; }
            public int NRO_ORDEN { get; set; }
            public string? OBSERVACION { get; set; }
            public DateTime? FECHA_MOVIMTO { get; set; }
            public string? NRO_GUIA { get; set; }
            public string? MES_MOVIMTO { get; set; }
            public DateTime FECHA_REG { get; set; }
            public string? CUSER_ID { get; set; }
            public string? EQUIPO_REG { get; set; }
            public string? TIPO_MOVIMTO { get; set; }
            public int TIPO_TRANSAC { get; set; }
        }

        public class BuscarContratos
        {
            public int I_ANO_EJE { get; set; }
            public string? texto { get; set; }
        }
        
        public class BuscarOrdenes
        {
            public int i_ANO_EJE { get; set; }
            public string? contrato { get; set; }
        }
       
    }

    public class Response {
        public class Producto {
            public string? TIPO_BIEN { get; set; }
            public string? CODIGO_ITEM { get; set; }
            public string? DESCRIPCION { get; set; }
            public string? GRUPO_BIEN { get; set; }
            public string? NOMBRE_GRUPO { get; set; }
            public string? ALCANCE_GRUPO { get; set; }
            public string? CLASE_BIEN { get; set; }
            public string? NOMBRE_CLASE { get; set; }
            public string? ALCANCE_CLASE { get; set; }
            public string? FAMILIA_BIEN { get; set; }
            public string? NOMBRE_FAM { get; set; }
            public string? ALCANCE_FAM { get; set; }
            public string? ITEM_BIEN { get; set; }
            public string? NOMBRE_ITEM { get; set; }
            public string? ESTADO { get; set; }
        }
        public class Proveedor {
            public string? PROVEEDOR { get; set; }
            public string? NRO_RUC { get; set; }
            public string? GIRO_GENERAL { get; set; }
            public string? NOMBRE_PROV { get; set; }
            public string? TELEFONOS { get; set; }
            public string? DIRECCION { get; set; }
            public string? PAIS { get; set; }
            public string? NOMBRE { get; set; }
            public string? NACIONALIDAD { get; set; }
        }
        public class CabeceraOC {
            public string? NACIONALIDAD { get; set; }
            public string? DES_TIPO_PROCESO { get; set; }
            public string? ANO_CONTRATO { get; set; }
            public string? NRO_CONTRATO { get; set; }
            public string? FECHA_CONTRATO { get; set; }
            public string? PROVEEDOR { get; set; }
            public string? NOMBRE_PROV { get; set; }
            public int ALMACEN { get; set; }
            public string? NOMBRE_ALM { get; set; }
            public string? SEC_ALMACEN { get; set; }
            public string? DESCRIPCION { get; set; }
            public string? NOMBRE_SEDE { get; set; }
            public string? tipo_proceso { get; set; }
            public string? tipo_cambio { get; set; }
            public string? total_fact_moneda { get; set; }
            public string? ano_ejec { get; set; }
            public string? pais { get; set; }
            public string? desc_pais { get; set; }
            public string? nro_ruc { get; set; }
        }
        public class CabeceraNEA {
            public int ANO_EJE { get; set; }
            public int NRO_REQUERIM { get; set; }
            public DateTime FECHA_REQUERIM { get; set; }
            public string? proveedor { get; set; }
            public string? NOMBRE_PROVEEDOR { get; set; }
            public string? pais { get; set; }
            public string? desc_pais { get; set; }
            public string? nro_ruc { get; set; }
            public string? ind_lote { get; set; }
        }
        public class DetalleOC {
            public int ANO_EJE { get; set; }
            public int NRO_ORDEN { get; set; }
            public int SEC_ITEM { get; set; }
            public string? ITEM_CODE { get; set; }
            public string? sProducto { get; set; }
            public int CANT_ITEM { get; set; }
            public string UNIDAD_MEDIDA { get; set; }
            public string? DES_UNIDAD_MEDIDA { get; set; }
            public float PREC_UNIT_MONEDA { get; set; }
            public string? MONEDA { get; set; }
            public float TIPO_CAMBIO { get; set; }
            public float PRECIO_TOT_SOLES { get; set; }
        }
        public class DetalleNEA {
            public int ANO_EJE { get; set; }
            public int NRO_REQUERIM { get; set; }
            public int SEC_REQUERIM { get; set; }
            public string? ITEM_CODE { get; set; }
            public string? sProducto { get; set; }
            public string? UNIDAD_MEDIDA { get; set; }
            public int CANT_ARTICULO { get; set; }
            public float PRECIO_UNIT { get; set; }
            public float VALOR_TOTAL { get; set; }
        }

        public class Contrato
        {
            public string? ANO_EJE {get; set;}
            public string? NRO_ORDEN {get; set;}
            public string? ANO_CONTRATO {get; set;}
            public string? NRO_CONTRATO {get; set;}
            public string? FECHA_CONTRATO {get; set;}      
        }

        public class Orden
        {
            public string? ANO_EJE { get; set; }
            public string? NRO_ORDEN { get; set; }
            public string? NRO_CONTRATO { get; set; }
        }
    }
}


