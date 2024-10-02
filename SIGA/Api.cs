namespace SIGA;

public static class Api {
    public static void ConfigureApi( this WebApplication app ) {
        app.MapGet("/ListarContratos/{contrato}", ListarContratosSIGA);
        app.MapGet("/ListarDocumentosContrato/{idContrato}", ListarDocumentosContratoSIGA);
        app.MapGet("/ObtenerDataDocumento/{idDocumento}", ObtenerDataDocumentoSIGA);
    }

    private static async Task<IResult> ListarContratosSIGA( string contrato, ISIGAData data ) {
        try {
            var results = await data.GetContratosSIGA(contrato);
            if (results == null) return Results.NotFound();
                return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ListarDocumentosContratoSIGA( int idContrato, ISIGAData data ) {
        try {
            var results = await data.GetDocumentosContratoSIGA(idContrato);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ObtenerDataDocumentoSIGA( int idDocumento, ISIGAData data ) {
        try {
            var results = await data.GetDataDocumentoSIGA(idDocumento);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
}

