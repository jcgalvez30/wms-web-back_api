using DataAccess_ReporteTareaInterna.DbAccess;
using DataAccess_ReporteTareaInterna.Models;

namespace DataAccess_ReporteTareaInterna.Data;

public class ReporteTareaInternaData : IReporteTareaInternaData {
    private readonly ISqlDataAccess _db;

    public ReporteTareaInternaData( ISqlDataAccess db ) {
        _db = db;
    }

    public async Task<ReporteTareaInternaModel.Response.Filtros> Filtros() {
        var result = await _db.LoadData<ReporteTareaInternaModel.Response.Filtros, dynamic>(
    "ReporteTareasInternas_FiltrosConsulta", new {});
        return result.FirstOrDefault();
    }
    public async Task<IEnumerable<ReporteTareaInternaModel.Response.Consulta>> ObtenerData( ReporteTareaInternaModel.Request.Filtros filtros ) {
        var result = await _db.LoadData<ReporteTareaInternaModel.Response.Consulta, dynamic>(
        "ReporteTareasInternas_ObtenerData", new {
            idCentro = filtros.idCentro,
            idWarehouse = filtros.idWarehouse,
            sFechaDesde = filtros.sFechaDesde,
            sFechaHasta = filtros.sFechaHasta
        });
        return result;
    }

}
