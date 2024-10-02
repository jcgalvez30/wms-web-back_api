namespace Transporte;

public static class Api {
    public static void ConfigureApi( this WebApplication app ) {
        app.MapGet("/ParametrosFormulario", obtenerParametrosFormularioTransporte);
        app.MapGet("/Obtener/{idProgramacionIngreso}", ObtenerTransporte);
        app.MapPost("/Insertar", InsertarTransporte);
        app.MapPut("/Actualizar", ActualizarTransporte);
    }
    private static async Task<IResult> obtenerParametrosFormularioTransporte( ITransporteData data ) {
        try {
            return Results.Ok(await data.GetParametrosFormulario());
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ObtenerTransporte( int idProgramacionIngreso, ITransporteData data ) {
        try {
            return Results.Ok(await data.GetTransporte(idProgramacionIngreso));
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> InsertarTransporte( TransporteModel.Insert Transporte, ITransporteData data ) {
        try {
            await data.InsertTransporte(Transporte);
            return Results.Ok();
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ActualizarTransporte( TransporteModel.Update Transporte, ITransporteData data ) {
        try {
            await data.UpdateTransporte(Transporte);
            return Results.Ok();
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
}

