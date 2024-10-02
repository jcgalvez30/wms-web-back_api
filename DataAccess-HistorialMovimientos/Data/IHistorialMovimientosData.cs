using DataAccess_HistorialMovimientos.Models;

namespace DataAccess_HistorialMovimientos.Data;

public interface IHistorialMovimientosData {
    Task<HistorialMovimientosModel.Response.Filtros> filtros();
    Task<IEnumerable<HistorialMovimientosModel.Response.Consulta>> ObtenerData( HistorialMovimientosModel.Request.Filtros filtros);
    Task<HistorialMovimientosModel.Response.FiltrosConsultaProducto> filtrosConsultaProducto();
    Task<IEnumerable<HistorialMovimientosModel.Response.ConsultaProducto>> ObtenerDataProductos( HistorialMovimientosModel.Request.FiltrosConsultaProducto filtros );
}
