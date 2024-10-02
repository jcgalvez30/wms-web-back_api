using Microsoft.AspNetCore.Mvc;

namespace ProgramacionIngreso;

public static class Api {
    public static void ConfigureApi( this WebApplication app ) {
        app.MapGet("/listarTiposDocumentos", ListarTiposDocumentos).AllowAnonymous();
        app.MapGet("/ParametrosConsulta", obtenerParametrosConsultaProgramacionIngreso).AllowAnonymous();
        app.MapGet("/ParametrosFormulario", obtenerParametrosFormularioProgramacionIngreso).AllowAnonymous();
        app.MapGet("/Listar", ListarProgramacionIngreso).AllowAnonymous();
        app.MapGet("/Obtener/{id}", ObtenerProgramacionIngreso).AllowAnonymous();
        app.MapPost("/Insertar", InsertarProgramacionIngreso).AllowAnonymous();
        app.MapPost("/ListarFiltrado", ListarFiltradoProgramacionIngreso).AllowAnonymous();
        app.MapPut("/Actualizar", ActualizarProgramacionIngreso).AllowAnonymous();
        app.MapDelete("/Eliminar", EliminarProgramacionIngreso).AllowAnonymous();

        app.MapPost("/ListarTiposDocumento2", ListarTiposDocumentos2).AllowAnonymous();
        
        //app.MapPost("/obtenerCabeceraOC", ObtenerCabeceraOC).AllowAnonymous();
        //app.MapPost("/obtenerCabeceraNEA", ObtenerCabeceraNEA).AllowAnonymous();
        //app.MapPost("/obtenerDetalleOC", ObtenerDetalleOC).AllowAnonymous();
        //app.MapPost("/obtenerDetalleNEA", ObtenerDetalleNEA).AllowAnonymous();
        //app.MapPost("/insertarRecepcionCabecera", InsertarRecepcionCabecera).AllowAnonymous();

    }

    private static async Task<IResult> ListarTiposDocumentos( IProgramacionIngresoData data ) {
        try {
            var results = await data.ListarTiposDocumentos();
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> obtenerParametrosConsultaProgramacionIngreso( IProgramacionIngresoData data ) {
        try {
            return Results.Ok(await data.GetParametrosConsulta());
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> obtenerParametrosFormularioProgramacionIngreso( IProgramacionIngresoData data ) {
        try {
            return Results.Ok(await data.GetParametrosFormulario());
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarProgramacionIngreso(IProgramacionIngresoData data, int IdProveedor=0, string ContratoInicio="0", string ContratoFin= "0", string Documento="") {
        try {
            ProgramacionIngresoModel.Request.Filtros filtros = new ProgramacionIngresoModel.Request.Filtros {
                IdProveedor= IdProveedor,
                ContratoInicio = ContratoInicio,
                ContratoFin = ContratoFin, Documento= Documento
            };
            return Results.Ok(await data.GetProgramacionIngreso(filtros));
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ObtenerProgramacionIngreso( int id, IProgramacionIngresoData data ) {
        try {
            var results = await data.GetProgramacionIngreso(id);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> InsertarProgramacionIngreso( ProgramacionIngresoModel.Insert ProgramacionIngreso, IProgramacionIngresoData data ) {
        try {
            return Results.Ok(await data.InsertProgramacionIngreso(ProgramacionIngreso));
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarFiltradoProgramacionIngreso( ProgramacionIngresoModel.FiltrosGrilla ProgramacionIngreso, IProgramacionIngresoData data ) {
        try {
            return Results.Ok(await data.ListarFiltradoProgramacionIngreso(ProgramacionIngreso));
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ActualizarProgramacionIngreso( ProgramacionIngresoModel.Update ProgramacionIngreso, IProgramacionIngresoData data ) {
        try {
            await data.UpdateProgramacionIngreso(ProgramacionIngreso);
            return Results.Ok();
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> EliminarProgramacionIngreso( int id, IProgramacionIngresoData data ) {
        try {
            await data.DeleteProgramacionIngreso(id);
            return Results.Ok();
        } catch (Exception ex) {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ListarTiposDocumentos2(ProgramacionIngresoModel.Request.FiltrosTipoDocumento filtrosTipoDocumento, IProgramacionIngresoData data)
    {
        try
        {
            var results = await data.ListarTiposDocumentos2(filtrosTipoDocumento);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    //private static async Task<IResult> ObtenerCabeceraOC( SIGA2Model.Request.CabeceraOC cabeceraOC) {
    //    try {
    //        //var results = await data.ObtenerCabeceraOC(cabeceraOC);
    //        //if (results == null) return Results.NotFound();
    //        return Results.Ok();// results);
    //    } catch (Exception ex) {
    //        return Results.Problem(ex.Message);
    //    }
    //}
    //private static async Task<IResult> ObtenerCabeceraNEA( SIGA2Model.Request.CabeceraNEA cabeceraNEA) {
    //    try {
    //        //var results = await data.ObtenerCabeceraNEA(cabeceraNEA);
    //        //if (results == null) return Results.NotFound();
    //        return Results.Ok();// results);
    //    } catch (Exception ex) {
    //        return Results.Problem(ex.Message);
    //    }
    //}
    //private static async Task<IResult> ObtenerDetalleOC( SIGA2Model.Request.DetalleOC detalleOC) {
    //    try {
    //        //var results = await data.ObtenerDetalleOC(detalleOC);
    //        //if (results == null) return Results.NotFound();
    //        return Results.Ok();// results);
    //    } catch (Exception ex) {
    //        return Results.Problem(ex.Message);
    //    }
    //}
    //private static async Task<IResult> ObtenerDetalleNEA( SIGA2Model.Request.DetalleNEA detalleNEA) {
    //    try {
    //        //var results = await data.ObtenerDetalleNEA(detalleNEA);
    //        //if (results == null) return Results.NotFound();
    //        return Results.Ok();// results);
    //    } catch (Exception ex) {
    //        return Results.Problem(ex.Message);
    //    }
    //}
    //private static async Task<IResult> InsertarRecepcionCabecera( SIGA2Model.Request.RecepcionCabecera recepcionCabecera) {
    //    try {
    //       // await data.InsertarRecepcionCabecera(recepcionCabecera);
    //        return Results.Ok();
    //    } catch (Exception ex) {
    //        return Results.Problem(ex.Message);
    //    }
    //}
}

