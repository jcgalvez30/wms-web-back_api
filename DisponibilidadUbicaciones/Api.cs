namespace DisponibilidadUbicaciones;

public static class Api {
    public static void ConfigureApi( this WebApplication app ) {
        app.MapGet("/ObtenerFiltros", ObtenerFiltros).AllowAnonymous();
        app.MapPost("/ListarDisponibilidadUbicaciones", ListarDisponibilidadUbicaciones).AllowAnonymous();
        app.MapPost("/ExportarExcel", ExportarExcel).AllowAnonymous();
    }

    private static async Task<IResult> ObtenerFiltros( IDisponibilidadUbicacionesData data ) {
        try {
            var results = await data.Filtros();
            if (results == null) return Results.NotFound();
                return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ListarDisponibilidadUbicaciones( DisponibilidadUbicacionesModel.Request.Filtros filtros, IDisponibilidadUbicacionesData data ) {
        try {
            var results = await data.ObtenerData(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ExportarExcel( DisponibilidadUbicacionesModel.Request.Filtros filtros, IDisponibilidadUbicacionesData data ) {
        try {
            var results = await data.ObtenerData(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
}

