using DataAccess_ReporteInventario.Models;

namespace DataAccess_ReporteInventario.Data;

public interface IReporteInventarioData {
    Task<ReporteInventarioModel.Response.Filtros> filtros();
    Task<IEnumerable<ReporteInventarioModel.Response.Consulta>> ObtenerData( ReporteInventarioModel.Request.Filtros filtros);
    Task<ReporteInventarioModel.Response.FiltrosConsultaProducto> filtrosConsultaProducto();
    Task<IEnumerable<ReporteInventarioModel.Response.ConsultaProducto>> ObtenerDataProductos( ReporteInventarioModel.Request.FiltrosConsultaProducto filtros );

    Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarCentros(ReporteInventarioModel.Request.FiltrosCentro filtros);
    Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarAlmacenesPorCentro(ReporteInventarioModel.Request.FiltrosAlmacen filtros);
    Task<IEnumerable<ReporteInventarioModel.Response.Estrategia>> listarEstrategias(ReporteInventarioModel.Request.FiltrosEstrategia filtros);
    Task<IEnumerable<ReporteInventarioModel.Response.Producto>> listarProductos(ReporteInventarioModel.Request.FiltrosProducto filtros);
    Task<IEnumerable<ReporteInventarioModel.Response.ItemInventario>> listarItemsInventario(ReporteInventarioModel.Request.FiltrosInventario filtros);
    Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarTransacciones(ReporteInventarioModel.Request.FiltrosTransaccion filtros);

    Task<IEnumerable<ReporteInventarioModel.Response.Movimiento>> listarMovimientos(ReporteInventarioModel.Request.FiltrosMovimiento filtros);
    Task<IEnumerable<ReporteInventarioModel.Response.TareaInterna>> listarTareasInternas(ReporteInventarioModel.Request.FiltrosTareaInterna filtros);
    Task<IEnumerable<ReporteInventarioModel.Response.Ubicacion>> listarUbicaciones(ReporteInventarioModel.Request.FiltrosUbicacion filtros);
    Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarTiposUbicacion(ReporteInventarioModel.Request.FiltrosTiposUbicacion filtros);


    Task<IEnumerable<ReporteInventarioModel.Response.Prioridad>> listarPrioridad(ReporteInventarioModel.Request.FiltrosPrioridad filtros);
    Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarTipoFecha(ReporteInventarioModel.Request.FiltrosTipoFecha filtros);
    Task<IEnumerable<ReporteInventarioModel.Response.Estado>> listarEstado(ReporteInventarioModel.Request.FiltrosEstado filtros);
    Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarPedidoFiltroBuscar(ReporteInventarioModel.Request.FiltrosPedidoFiltroBuscar filtros);
    Task<IEnumerable<ReporteInventarioModel.Response.Pedido>> listarPedido(ReporteInventarioModel.Request.FiltrosPedido filtros);
    Task<ReporteInventarioModel.Response.OrdenDePedidoResponse> mantenimientoOrdenDePedido(ReporteInventarioModel.Request.OrdenDePedido OrdenDePedido);
    Task<IEnumerable<ReporteInventarioModel.Response.Status>> statusPedido(IEnumerable<ReporteInventarioModel.Request.StatusPedido> StatusPedido);
    Task<ReporteInventarioModel.Response.OrdenDePedido> detallePedido(ReporteInventarioModel.Request.DetallePedido detallePedido);
    Task<IEnumerable<ReporteInventarioModel.Response.ListadoPecosas>> listadoPecosas(ReporteInventarioModel.Request.ListadoPecosas Pecosas);
    Task<IEnumerable<ReporteInventarioModel.Response.ListadoPecosasDetalle>> listadoPecosasDetalle(ReporteInventarioModel.Request.ListadoPecosasDetalle PecosasDetalle);
    Task<IEnumerable<ReporteInventarioModel.Response.ListadoDespachoPedido>> listadoDespachoPedido(ReporteInventarioModel.Request.ListadoDespachoPedido DespachoPedido);

    Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarFiltroOCNEA();
    Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarFiltroModalidad();
    Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarFiltroEstadoOCNEA();
    Task<IEnumerable<ReporteInventarioModel.Response.ListarOCNEA>> listarOCNEA(ReporteInventarioModel.Request.ListarOCNEA ListarOCNEA);
    Task<IEnumerable<ReporteInventarioModel.Response.FichasActas>> actualizarFichaActas(IEnumerable<ReporteInventarioModel.Request.FichasActas> FichasActas);
    Task<ReporteInventarioModel.Response.OCNEA> detalleOCNEA(ReporteInventarioModel.Request.OCNEA OCNEA);
    Task<ReporteInventarioModel.Response.OrdenDeCompraResponse> entregasAlmacen(ReporteInventarioModel.Request.OCNEA ordenCompra);
    Task<ReporteInventarioModel.Response.FichasActasReponse> listarFichaActas(ReporteInventarioModel.Request.OCNEA OCNEA);
    
}
