namespace Stock;

public static class Api {
    public static void ConfigureApi( this WebApplication app ) {
        app.MapGet("/ListarStock", ListarStock);
        app.MapPost("/ListarStock", ListarFiltradoStock);
    }
    private static async Task<IResult> ListarStock( IStockData data ) {
        try {
            return Results.Ok(await data.GetStock());
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarFiltradoStock( StockModel.parametrosConsulta parametrosConsulta, IStockData data ) {
        try {
            return Results.Ok(await data.GetStockFiltrado(parametrosConsulta));
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
}

