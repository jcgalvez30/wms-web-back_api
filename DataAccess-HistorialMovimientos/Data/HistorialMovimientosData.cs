using DataAccess_HistorialMovimientos.DbAccess;
using DataAccess_HistorialMovimientos.Models;

namespace DataAccess_HistorialMovimientos.Data;

public class HistorialMovimientosData : IHistorialMovimientosData {
    private readonly ISqlDataAccess _db;

    public HistorialMovimientosData( ISqlDataAccess db ) {
        _db = db;
    }

    public async Task<HistorialMovimientosModel.Response.Filtros> filtros() {
        var result = await _db.LoadData<HistorialMovimientosModel.Response.Filtros, dynamic>(
    "HistorialMovimientos_FiltrosConsulta", new {});
        return result.FirstOrDefault();
    }
    public async Task<HistorialMovimientosModel.Response.FiltrosConsultaProducto> filtrosConsultaProducto() {
        var result = await _db.LoadData<HistorialMovimientosModel.Response.FiltrosConsultaProducto, dynamic>(
    "HistorialMovimientos_FiltrosConsultaProductos", new { });
        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<HistorialMovimientosModel.Response.Consulta>> ObtenerData( HistorialMovimientosModel.Request.Filtros filtros ) {
        var result = await _db.LoadData<HistorialMovimientosModel.Response.Consulta, dynamic>(
        "HistorialMovimientos_ObtenerData", new {
            itemCode = filtros.itemCode,
            sDocumento = filtros.sDocumento,
            sFechaDesde = filtros.sFechaDesde,
            sFechaHasta = filtros.sFechaHasta,
            sLote = filtros.sLote,
            idCentro = filtros.idCentro,
            idWarehouse = filtros.idWarehouse,
            idTipoTransaccion = filtros.idTipoTransaccion
        });
        return result;
    }
    public async Task<IEnumerable<HistorialMovimientosModel.Response.ConsultaProducto>> ObtenerDataProductos( HistorialMovimientosModel.Request.FiltrosConsultaProducto filtros ) {
        var result = await _db.LoadData<HistorialMovimientosModel.Response.ConsultaProducto, dynamic>(
        "HistorialMovimientos_ObtenerDataProductos", new {
            idEstrategia = filtros.idEstrategia,
            sDescripcion = filtros.sDescripcion 
        });
        return result;
    }
}