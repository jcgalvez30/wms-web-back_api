namespace SIGA2;

public static class Api {
    public static void ConfigureApi( this WebApplication app ) {
        app.MapGet("/ListarProductos", ListarProductos).AllowAnonymous();
        app.MapGet("/listarProveedores", ListarProveedores).AllowAnonymous();
        app.MapPost("/obtenerCabeceraOC", ObtenerCabeceraOC).AllowAnonymous();
        app.MapPost("/obtenerCabeceraNEA", ObtenerCabeceraNEA).AllowAnonymous();
        app.MapPost("/obtenerDetalleOC", ObtenerDetalleOC).AllowAnonymous();
        app.MapPost("/obtenerDetalleNEA", ObtenerDetalleNEA).AllowAnonymous();
        app.MapPost("/insertarRecepcionCabecera", InsertarRecepcionCabecera).AllowAnonymous();
        app.MapPost("/buscarContratos", BuscarContratos).AllowAnonymous();
        app.MapPost("/buscarOrdenesPorNumContrato", BuscarOrdenesPorNumContrato).AllowAnonymous();
    }

    private static async Task<IResult> ListarProductos( ISIGA2Data data ) {
        try {
            var results = await data.ListarProductos();
            if (results == null) return Results.NotFound();
                return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarProveedores( ISIGA2Data data ) {
        try {
            var results = await data.ListarProveedores();
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ObtenerCabeceraOC( SIGA2Model.Request.CabeceraOC cabeceraOC, ISIGA2Data data ) {
        try {
            var results = await data.ObtenerCabeceraOC(cabeceraOC);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ObtenerCabeceraNEA( SIGA2Model.Request.CabeceraNEA cabeceraNEA, ISIGA2Data data ) {
        try {
            var results = await data.ObtenerCabeceraNEA(cabeceraNEA);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ObtenerDetalleOC( SIGA2Model.Request.DetalleOC detalleOC, ISIGA2Data data ) {
        try {
            var results = await data.ObtenerDetalleOC(detalleOC);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ObtenerDetalleNEA( SIGA2Model.Request.DetalleNEA detalleNEA, ISIGA2Data data ) {
        try {
            var results = await data.ObtenerDetalleNEA(detalleNEA);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> InsertarRecepcionCabecera( SIGA2Model.Request.RecepcionCabecera recepcionCabecera, ISIGA2Data data ) {
        try {
            await data.InsertarRecepcionCabecera(recepcionCabecera);
            return Results.Ok();
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> BuscarContratos(SIGA2Model.Request.BuscarContratos filtroContratos, ISIGA2Data data)
    {
        try
        {
            var results = await data.BuscarContratos(filtroContratos);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> BuscarOrdenesPorNumContrato(SIGA2Model.Request.BuscarOrdenes filtroOrdenes, ISIGA2Data data)
    {
        try
        {
            var results = await data.BuscarOrdenesPorNumContrato(filtroOrdenes);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}

