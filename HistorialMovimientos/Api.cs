namespace HistorialMovimientos;

public static class Api {
    public static void ConfigureApi( this WebApplication app ) {
        app.MapGet("/ObtenerFiltros", ObtenerFiltros).AllowAnonymous();
        app.MapGet("/ObtenerFiltrosProductos", ObtenerFiltrosProductos).AllowAnonymous();
        app.MapPost("/ListarReporteInventario", ListarReporteInventario).AllowAnonymous();
        app.MapPost("/ExportarExcel", ExportarExcel).AllowAnonymous();
        app.MapPost("/ListarProductos", ListarProductos).AllowAnonymous();
    }

    private static async Task<IResult> ObtenerFiltros( IHistorialMovimientosData data ) {
        try {
            var results = await data.filtros();
            if (results == null) return Results.NotFound();
                return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarReporteInventario( HistorialMovimientosModel.Request.Filtros filtros, IHistorialMovimientosData data ) {
        try {
            var results = await data.ObtenerData( filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ExportarExcel( HistorialMovimientosModel.Request.Filtros filtros, IHistorialMovimientosData data ) {
        try {
            var results = await data.ObtenerData(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ObtenerFiltrosProductos( IHistorialMovimientosData data ) {
        try {
            var results = await data.filtrosConsultaProducto();
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarProductos( HistorialMovimientosModel.Request.FiltrosConsultaProducto filtros , IHistorialMovimientosData data ) {
        try {
            var results = await data.ObtenerDataProductos(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
}

