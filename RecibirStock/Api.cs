namespace RecibirStock;

public static class Api {
    public static void ConfigureApi( this WebApplication app ) {
        app.MapGet("/RecibirStock", ListarRecibirStock);
        app.MapGet("/RecibirStock/parametros", ListarRecibirStock);
        app.MapGet("/RecibirStock/{id}", ObtenerRecibirStock);
        app.MapPost("/RecibirStock", InsertarRecibirStock);
        app.MapPut("/RecibirStock", ActualizarRecibirStock);
        app.MapDelete("/RecibirStock", EliminarRecibirStock);
    }
    private static async Task<IResult> ListarRecibirStock( IRecibirStockData data ) {
        try {
            return Results.Ok(await data.GetRecibirStock());
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ObtenerRecibirStock( int id, IRecibirStockData data ) {
        try {
            var results = await data.GetRecibirStock(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> InsertarRecibirStock( RecibirStockModel RecibirStock, IRecibirStockData data ) {
        try {
            await data.InsertRecibirStock(RecibirStock);
            return Results.Ok();
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ActualizarRecibirStock( RecibirStockModel RecibirStock, IRecibirStockData data ) {
        try {
            await data.UpdateRecibirStock(RecibirStock);
            return Results.Ok();
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> EliminarRecibirStock( int id, IRecibirStockData data ) {
        try {
            await data.DeleteRecibirStock(id);
            return Results.Ok();
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
}

