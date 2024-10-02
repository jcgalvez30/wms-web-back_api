namespace ReporteTareaInterna;

public static class Api {
    public static void ConfigureApi( this WebApplication app ) {
        app.MapGet("/ObtenerFiltros", ObtenerFiltros).AllowAnonymous();
        app.MapPost("/ListarReporteTareasInternas", ListarReporteTareasInternas).AllowAnonymous();
        app.MapPost("/ExportarExcel", ExportarExcel).AllowAnonymous();
    }

    private static async Task<IResult> ObtenerFiltros( IReporteTareaInternaData data ) {
        try {
            var results = await data.Filtros();
            if (results == null) return Results.NotFound();
                return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ListarReporteTareasInternas( ReporteTareaInternaModel.Request.Filtros filtros, IReporteTareaInternaData data ) {
        try {
            var results = await data.ObtenerData(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ExportarExcel( ReporteTareaInternaModel.Request.Filtros filtros, IReporteTareaInternaData data ) {
        try {
            var results = await data.ObtenerData(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
}

