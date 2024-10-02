namespace Recepcion;

public static class Api {
    public static void ConfigureApi( this WebApplication app ) {
        app.MapGet("/ParametrosConsulta", obtenerParametrosConsultaRecepcion);
        app.MapGet("/ConsultarRecepcion", ListarRecepcion);
        app.MapGet("/ConsultarDetalleRecepcion/{sNumeroDocumento}", ListarDetalleRecepcion);
    }
    private static async Task<IResult> obtenerParametrosConsultaRecepcion( IRecepcionData data ) {
        try {
            return Results.Ok(await data.GetParametrosConsulta());
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarRecepcion( IRecepcionData data ) {
        try {
            return Results.Ok(await data.GetRecepcion());
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarDetalleRecepcion( string sNumeroDocumento, IRecepcionData data ) {
        try {
            return Results.Ok(await data.GetDetalleRecepcion(sNumeroDocumento));
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
}

