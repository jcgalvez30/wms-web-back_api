using DataAccess_ReporteTareaInterna.Models;

namespace DataAccess_ReporteTareaInterna.Data;

public interface IReporteTareaInternaData {
    Task<ReporteTareaInternaModel.Response.Filtros> Filtros();
    Task<IEnumerable<ReporteTareaInternaModel.Response.Consulta>> ObtenerData( ReporteTareaInternaModel.Request.Filtros filtros);
}
