using System.Net;
using System.Text;

namespace DataAccess_ReporteInventario.Models;

public class ReporteInventarioModel
{

    public class Request
    {
        public class Filtros
        {
            public string? itemCode { get; set; }
            public string? sUbicacionOrigen { get; set; }
            public string? sUbicacionDestino { get; set; }
            public string? sLote { get; set; }
            public string? sPasillo { get; set; }
            public int idCentro { get; set; }
            public int idWarehouse { get; set; }
            public int idEstrategia { get; set; }
            public int idEstado { get; set; }
        }
        public class FiltrosConsultaProducto
        {
            public int idEstrategia { get; set; }
            public string? sDescripcion { get; set; }
        }

        public class FiltrosCentro
        {
            public string? User { get; set; }
        }

        public class FiltrosPrioridad
        {
            //public string? User { get; set; }
            public string? Objeto { get; set; }
            public string? Tipo { get; set; }
            public string? Idioma { get; set; }
        }
        public class FiltrosTipoFecha
        {
            public string? User { get; set; }
        }
        public class FiltrosEstado
        {
            //public string? User { get; set; }
            public string? Objeto { get; set; }
            public string? Tipo { get; set; }
            public string? Idioma { get; set; }
        }

        public class FiltrosPedidoFiltroBuscar
        {
            public string? User { get; set; }
        }
        public class FiltrosAlmacen
        {
            public string? User { get; set; }
            public string? Center { get; set; }
        }
        public class FiltrosEstrategia
        {
            public string? TipoAtributo { get; set; }
            public string? ValorAtributo { get; set; }
        }
        public class FiltrosProducto
        {
            public string? IdAlmacen { get; set; }
            public string? NumeroItem { get; set; }
            public string? Descripcion { get; set; }
        }
        public class FiltrosInventario
        {
            public string? IdAlmacen { get; set; }
            public string? NumeroItem { get; set; }
            public string? NombreItem { get; set; }
            public string? IdUbicacion { get; set; }
            public string? IdUbicacionD { get; set; }
            public string? NumeroLote { get; set; }
            public string? AtributoEstado { get; set; }
            public string? AtributoEstrategia { get; set; }
            public string? Upc { get; set; }
            public string? Tipo { get; set; }
        }
        public class FiltrosTransaccion
        {
            public string? User { get; set; }
            public string? Action { get; set; }
        }

        public class FiltrosMovimiento
        {
            public string? IdAlmacen { get; set; }
            public string? NumeroItem { get; set; }
            public string? NumeroControl { get; set; }
            public string? FechaInicial { get; set; }
            public string? FechaFinal { get; set; }
            public string? NumeroLote { get; set; }
            public string? TipoTransaccion { get; set; }
        }

        public class FiltrosPedido
        {
            public string? IdPedido { get; set; }
            public string? Pedido { get; set; }
            public string? FechaInicial { get; set; }
            public string? FechaFinal { get; set; }
            public string? IdTipFecha { get; set; }
            public string? IdCentro { get; set; }
            public string? IdAlmacen { get; set; }
            public string? IdPrioridad { get; set; }
            public string? IdEstrategia { get; set; }
            public string? IdEstado { get; set; }
            public string? PorcentajeAvanceDesde { get; set; }
            public string? PorcentajeAvanceHasta { get; set; }
        }

        public class FiltrosTareaInterna
        {
            public string? IdAlmacen { get; set; }
            public string? FechaInicial { get; set; }
            public string? FechaFinal { get; set; }
        }
        public class FiltrosUbicacion
        {
            public string? IdAlmacen { get; set; }
            public string? IdUbicacion { get; set; }
        }

        public class FiltrosTiposUbicacion
        {
            public string? User { get; set; }
        }

        public class OrdenDePedido //cabecera del JSON - SIGA
        {
            public string accion { get; set; }
            public string? id_almacen { get; set; }
            public string? numero_orden { get; set; }
            public string? numero_pedido_siga { get; set; }
            public int tipo { get; set; }
            public string? id_cliente { get; set; }
            public string? urgencia { get; set; }
            public string? prioridad { get; set; }
            public DateTime fecha_pedido { get; set; }
            public string? indicador_pedido_parcial { get; set; }
            public DateTime fecha_inicial_despacho { get; set; }
            public DateTime fecha_final_despacho { get; set; }
            public DateTime fecha_inicial_entrega { get; set; }
            public DateTime fecha_final_entrega { get; set; }
            public string? envio_direccion1 { get; set; }
            public string? envio_direccion2 { get; set; }
            public string? envio_direccion3 { get; set; }
            public string? envio_ciudad { get; set; }
            public string? envio_postal { get; set; }
            public List<OrdenDetalle> OrdenDetalle { get; set; }
        }
        public class OrdenDetalle //Detalle del JSON - SIGA
        {
            public string? numero_linea { get; set; }
            public string? numero_item { get; set; }
            public string? descripcion_item { get; set; }
            public float cantidad { get; set; }
            public string? unidad_medida { get; set; }
            public string? numero_lote { get; set; }
            public string? numero_serie { get; set; }
            public string? atributo_estrategia { get; set; }
            public string? atributo_estado { get; set; }

        }
        public class StatusPedido
        {
            public string? numero_orden { get; set; }
            public string? statusOrden { get; set; }
        }
        public class DetallePedido
        {
            public string? numero_orden { get; set; }
        }

        public class ListadoPecosas
        {
            public string? IdPedido { get; set; }
            public string? Pedido { get; set; }
        }

        public class ListadoPecosasDetalle
        {
            public string? IdPedido { get; set; }
            public string? Pedido { get; set; }
        }
        public class ListadoDespachoPedido
        {
            public string? IdPedido { get; set; }
            public string? Pedido { get; set; }
        }
        public class ListarOCNEA
        {
            public string? IdFiltro { get; set; }
            public string? OCNEA { get; set; }
            public string? FechaInicial { get; set; }
            public string? FechaFinal { get; set; }
            public string? IdEstado { get; set; }
            public string? IdModalidad { get; set; }
            public string? IdTipoDoc { get; set; } 
             
        }
        public class FichasActas
        {
            public string? numero_orden_compra { get; set; }
            //public string? estado { get; set; }
            public string? FichaEvalTecnica { get; set; }
            public string? ActaValidacion { get; set; }
            public string? ActaObservacion { get; set; } 
        }
        public class OCNEA
        {
            public string? numero_orden_compra { get; set; }
        }

    }

    public class Response
    {
        public class Filtros
        {
            public string? oCentro { get; set; }
            public string? oWarehouse { get; set; }
            public string? oEstrategia { get; set; }
            public string? oEstado { get; set; }
        }
        public class Consulta
        {
            public string? sItemCode { get; set; }
            public string? sDescripcion { get; set; }
            public string? sUnidad { get; set; }
            public string? sAlmacen { get; set; }
            public string? sNombreAlmacen { get; set; }
            public string? sUbicacion { get; set; }
            public string? sPasillo { get; set; }
            public string? sLote { get; set; }
            public string? sEstrategia { get; set; }
            public int sStockFisico { get; set; }
            public string? sEstadoInventario { get; set; }
            public DateTime sFechaIngreso { get; set; }
            public DateTime sFechaVencimiento { get; set; }
        }
        public class FiltrosConsultaProducto
        {
            public string? oEstrategia { get; set; }
        }
        public class ConsultaProducto
        {
            public string? sItemCode { get; set; }
            public string? sDescripcion { get; set; }
            public string? sEstrategia { get; set; }
            public string? sUnidadMedida { get; set; }
        }

        public class ItemLista //para metodo ListarFiltroOCNEA
        {
            public string? ValueMember { get; set; }
            public string? DisplayMember { get; set; }
        }
        public class Estrategia
        {
            public string? id_atributo { get; set; }
            public string? tipo_atributo { get; set; }
            public string? descripcion { get; set; }
            public string? valor_atributo { get; set; }
        }
        public class Producto
        {
            public string? id_item { get; set; }
            public string? numero_item { get; set; }
            public string? descripcion { get; set; }
            public string? unidad_medida { get; set; }
            public string? tipo_inventario { get; set; }
            public string? duracion { get; set; }
            public string? numero_item_alterno { get; set; }
            public string? precio { get; set; }
            public string? control_serie { get; set; }
            public string? control_lote { get; set; }
            public string? id_almacen { get; set; }
            public string? ultima_fecha_conteo { get; set; }
            public string? id_clase { get; set; }
            public string? upc { get; set; }
            public string? unidad_peso_item { get; set; }
            public string? unidad_volumen_item { get; set; }
            public string? id_pick_put { get; set; }
            public string? disposicion_sugerida { get; set; }
            public string? largo { get; set; }
            public string? ancho { get; set; }
            public string? alto { get; set; }
            public string? id_coleccion_atributo { get; set; }
            public string? visual_numero_item { get; set; }
            public string? id_cliente { get; set; }
        }
        public class ItemInventario
        {
            public string? id_inventario_item { get; set; }
            public string? numero_item { get; set; }
            public string? descripcion { get; set; }
            public string? cantidad_actual { get; set; }
            public string? cantidad_nodisponible { get; set; }
            public string? estado { get; set; }
            public string? id_almacen { get; set; }
            public string? id_ubicacion { get; set; }
            public string? numero_lote { get; set; }
            public string? unidad_medida { get; set; }
            public string? fecha_expiracion { get; set; }
            public string? fecha_fifo { get; set; }
            public string? numero_serie { get; set; }
            public string? tipo { get; set; }
            public string? id_atributo_almacenado { get; set; }
            public string? id_lp { get; set; }
            public string? condicion { get; set; }
        }

        public class Movimiento
        {
            public string? id_atributo_almacenado { get; set; }
            public string? id_transaccion_log { get; set; }
            public string? tipo_transaccion { get; set; }
            public string? tiempo_transaccion { get; set; }
            public string? descripcion { get; set; }
            public string? inicio_fecha_transaccion { get; set; }
            public string? fin_fecha_transaccion { get; set; }
            public string? id_empleado { get; set; }
            public string? numero_control { get; set; }
            public string? numero_control_2 { get; set; }
            public string? numero_linea { get; set; }
            public string? numero_secuencia { get; set; }
            public string? id_almacen { get; set; }
            public string? nombre { get; set; }
            public string? id_ubicacion { get; set; }
            public string? atributo_generico_1 { get; set; }
            public string? atributo_generico_2 { get; set; }
            public string? numero_lote { get; set; }
            public string? comentario { get; set; }
            public string? numero_item { get; set; }
        }
        public class TareaInterna
        {
            public string? id_atributo_almacenado { get; set; }
            public string? numero_orden_transfer { get; set; }
            public string? id_tipo { get; set; }
            public string? fecha_creacion { get; set; }
            public string? estado { get; set; }
            public string? usuario_creacion { get; set; }
            public string? ultima_transaccion { get; set; }
            public string? Forklift { get; set; }

        }
        public class Ubicacion
        {
            public string? id_atributo_almacenado { get; set; }
            public string? id_almacen { get; set; }
            public string? id_ubicacion { get; set; }
            public string? descripcion { get; set; }
            public string? estado { get; set; }
            public string? zona { get; set; }
            public string? secuencia_picking { get; set; }
            public string? capacidad_unidad_medida { get; set; }
            public string? capacidad_cantidad { get; set; }
            public string? cantidad_almacenada { get; set; }
            public string? tipo { get; set; }
            public string? fecha_fifo { get; set; }
            public string? ultima_fecha_conteo { get; set; }
            public string? capacidad_volumen { get; set; }
            public string? largo { get; set; }
            public string? ancho { get; set; }
            public string? alto { get; set; }
            public string? area_picking { get; set; }
            public string? indicador_lp { get; set; }
            public string? indicador_item { get; set; }
            public string? indicador_lote { get; set; }
            public string? Disponible { get; set; }
            public string? nombre { get; set; }
            public string? Grupo1 { get; set; }
            public string? Grupo2 { get; set; }
            public string? Grupo3 { get; set; }
        }

        public class Prioridad
        {
            public string? id { get; set; }
            public string? Value { get; set; }
            public string? Display { get; set; }
        }

        public class Estado
        {
            public string? id { get; set; }
            public string? Value { get; set; }
            public string? Display { get; set; }
        }
        public class Pedido
        {
            //Actualizar los campos de la tabla del modelo
            public string? Num_Pedido { get; set; }
            public string? NRO_Pec { get; set; }
            public string? Prior { get; set; }
            public string? Fecha_Pedido { get; set; }
            public string? Hora_Pedido { get; set; }
            public string? Fecha_Liberacion { get; set; }
            public string? Hora_Liberacion { get; set; }
            public string? NRO_Li { get; set; }
            public string? CoS { get; set; }
            public string? Cor_De { get; set; }
            public string? POR_Av { get; set; }
            public string? Solici { get; set; }
            public string? Centro { get; set; }
            public string? Almacen { get; set; }
            public string? Estrategia { get; set; }
            public string? Estado { get; set; }
            public string? Inf_Aten { get; set; }
            public string? Fecha_Fin_Pedido { get; set; }
            public string? Hora_Fin_Pedido { get; set; }
            public string? Fec_Cierre { get; set; }
            public string? Hor_Cierre { get; set; }
            public string? Fecha_Despl { get; set; }
            public string? Hora_Despl { get; set; }
            public string? Fecha_Anul { get; set; }
            public string? Hora_Anul { get; set; }
        }
        public class OrdenDePedidoResponse
        {
            public OrdenDePedidoCorrecto? OrdenDePedidoCorrecto { get; set; }
            public OrdenDePedidoError? OrdenDePedidoError { get; set; }
        }
        public class OrdenDePedidoCorrecto
        {
            public string? Mensaje { get; set; }
            public string? NumPecosa { get; set; }
            public DateTime? Fecha_hora { get; set; }
            public int? Estado { get; set; }
        }
        public class OrdenDePedidoError
        {
            public string? Mensaje { get; set; }
            public string? NumPecosa { get; set; }
            public DateTime? Fecha_hora { get; set; }
            public int? Estado { get; set; }
            //public string? DescripcionError { get; set; }
        }
        public class Status
        {
            public string? numero_orden { get; set; }
            public string? mensaje { get; set; }
        }
        public class OrdenDePedido
        {
            public string? id_almacen { get; set; }
            public string? numero_orden { get; set; }
            public string? numero_pedido_siga { get; set; }
            public int tipo { get; set; }
            public string? id_cliente { get; set; }
            public string? urgencia { get; set; }
            public string? prioridad { get; set; }
            public DateTime fecha_pedido { get; set; }
            public string? indicador_pedido_parcial { get; set; }
            public DateTime fecha_inicial_despacho { get; set; }
            public DateTime fecha_final_despacho { get; set; }
            public DateTime fecha_inicial_entrega { get; set; }
            public DateTime fecha_final_entrega { get; set; }
            public string? envio_direccion1 { get; set; }
            public string? envio_direccion2 { get; set; }
            public string? envio_direccion3 { get; set; }
            public string? envio_ciudad { get; set; }
            public string? envio_postal { get; set; }
            public List<OrdenDetalle> OrdenDetalle { get; set; }
        }
        public class OrdenDetalle
        {
            public string? numero_linea { get; set; }
            public string? numero_item { get; set; }
            public string? descripcion_item { get; set; }
            public float cantidad { get; set; }
            public float cantidad_picada { get; set; }
            public string? unidad_medida { get; set; }
            public string? numero_lote { get; set; }
            public string? numero_serie { get; set; }
            public string? atributo_estrategia { get; set; }
            public string? atributo_estado { get; set; }

        }
        public class ListadoPecosas
        {
            public string? NRO_Pec { get; set; }
            public string? Num_Pedido { get; set; }
            public string? Fecha_Pedido { get; set; }
            public string? Destino { get; set; }
            public string? Unidad { get; set; }
            public string? Cantidad { get; set; }
            public string? Packing { get; set; }
        }

        public class ListadoPecosasDetalle{
            public string? Codigo_SIGA { get; set; }
            public string? Descripcion { get; set; }
            public string? Unidad { get; set; }
            public string? Cantidad { get; set; }
            public string? Qty_Check { get; set; }
        }
        public class ListadoDespachoPedido
        {
            public string? NRO_Pec { get; set; }
            public string? Num_Pedido { get; set; }
            public string? Prior { get; set; }
            public string? Fecha_Pedido { get; set; }
            public string? Hora_Pedido { get; set; }
            public string? Fecha_Fin_Pic { get; set; }
            public string? Hora_Fin_Pic { get; set; }
            public string? NRO_Li { get; set; }
            public string? CoS { get; set; }
            public string? Cor_De { get; set; }
            public string? POR_Av { get; set; }
            public string? Solici { get; set; }
            public string? Estrategia { get; set; }
            public string? Estado { get; set; }
            public string? Inf_Aten { get; set; }
        }
        public class ListarOCNEA
        {
            public string? id_tipo { get; set; }
            public string? FechaCita { get; set; }
            public string? FechaRegistro { get; set; }
            public string? FechaNotificacion { get; set; }
            public string? Plazo { get; set; }
            public string? TipoIngreso { get; set; }
            public string? Modalidad { get; set; }
            public string? NumDocumento { get; set; }
            public string? TipoDocumento { get; set; }
            public string? Proveedor { get; set; }
            public string? FichasActas { get; set; }
            public string? Estado { get; set; }
            public string? InfAdicional { get; set; }
        }
        public class FichasActas
        {
            public string? numero_orden_compra { get; set; }
            public string? mensaje { get; set; }

        }
        public class FichasActasReponse
        {
            public string? FichaEvalTecnica { get; set; }
            public string? ActaValidacion { get; set; }
            public string? ActaObservacion { get; set; }

        }
        
        public class OCNEA //CABECERA DE INFORMACION ADICIONAL
        {
            public string? SUB_ALMACEN_SIGA { get; set; }
            public string? PROCEDENCIA { get; set; }
            public string? PROPIETARIO { get; set; } 
            public List<DetalleOCNEA> DetalleOCNEA { get; set; }
        }

        public class DetalleOCNEA //DETALLE DE INGRESO
        {
            public string? CODIGO_SIGA { get; set; }
            public string? PRODUCTO { get; set; }
            public string? CANTIDAD { get; set; }
            public string? PRECIO { get; set; }
            public string? MONTO { get; set; }
            public string? UNIDAD { get; set; }
            public string? LOTE { get; set; }
            public string? FECHA_VENCIMIENTO { get; set; }
        }
        public class OrdenDeCompraResponse
        {
            public OrdenDeCompraCorrecto? OrdenDeCompraCorrecto { get; set; }
            public OrdenDeCompraError? OrdenDeCompraError { get; set; }
        }
        public class OrdenDeCompraCorrecto
        {
            public string? Mensaje { get; set; }
            public string? numero_orden_compra { get; set; }
            public DateTime? Fecha_hora { get; set; }
            public int? Estado { get; set; }
        }
        public class OrdenDeCompraError
        {
            public string? Mensaje { get; set; }
            public string? numero_orden_compra { get; set; }
            public DateTime? Fecha_hora { get; set; }
            public int? Estado { get; set; }
            //public string? DescripcionError { get; set; }
        }
        /*
        public class _SUNATResponse
        {
            public string? numero_linea { get; set; }
            public string? numero_item { get; set; }
            public string? descripcion_item { get; set; }
            public float cantidad { get; set; }
            public float cantidad_picada { get; set; }
            public string? unidad_medida { get; set; }
            public string? numero_lote { get; set; }
            public string? numero_serie { get; set; }
            public string? atributo_estrategia { get; set; }
            public string? atributo_estado { get; set; }

        }*/
    }


}