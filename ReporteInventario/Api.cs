using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static DataAccess_ReporteInventario.Models.ReporteInventarioModel.Response;

namespace ReporteInventario;

public static class Api
{
    public static void ConfigureApi(this WebApplication app)
    {
        app.MapGet("/ObtenerFiltros", ObtenerFiltros).AllowAnonymous();
        app.MapGet("/ObtenerFiltrosProductos", ObtenerFiltrosProductos).AllowAnonymous();
        app.MapPost("/ListarReporteInventario", ListarReporteInventario).AllowAnonymous();
        app.MapPost("/ExportarExcel", ExportarExcel).AllowAnonymous();
        app.MapPost("/ListarProductos", ListarProductos).AllowAnonymous();

        app.MapPost("/ListarCentros", ListarCentros).AllowAnonymous();
        app.MapPost("/ListarAlmacenesPorCentro", ListarAlmacenesPorCentro).AllowAnonymous();
        app.MapPost("/ListarEstrategias", ListarEstrategias).AllowAnonymous();
        app.MapPost("/ListarProductosMaster", ListarProductosMaster).AllowAnonymous();
        app.MapGet("/ListarItemsInventario", ListarItemsInventario).AllowAnonymous();
        app.MapPost("/ListarTransacciones", ListarTransacciones).AllowAnonymous();
        app.MapGet("/ListarMovimientos", ListarMovimientos).AllowAnonymous();
        app.MapGet("/ListarTareasInternas", ListarTareasInternas).AllowAnonymous();
        app.MapGet("/ListarUbicaciones", ListarUbicaciones).AllowAnonymous();
        app.MapGet("/ListarTiposUbicacion", ListarTiposUbicacion).AllowAnonymous();

        app.MapGet("/ListarPrioridad", ListarPrioridad).AllowAnonymous(); //v20220923_1058
        app.MapGet("/ListarTipoFecha", ListarTipoFecha).AllowAnonymous();
        app.MapGet("/ListarEstado", ListarEstado).AllowAnonymous();
        app.MapGet("/ListarPedidoFiltroBuscar", ListarPedidoFiltroBuscar).AllowAnonymous();
        app.MapGet("/ListarPedido", ListarPedido).AllowAnonymous();
        app.MapPost("/MantenimientoOrdenDePedido", MantenimientoOrdenDePedido).AllowAnonymous();
        app.MapPost("/StatusPedido", StatusPedido).AllowAnonymous();
        app.MapGet("/DetallePedido", DetallePedido).AllowAnonymous();
        app.MapGet("/ListadoPecosas", ListadoPecosas).AllowAnonymous();
        app.MapGet("/ListadoPecosasDetalle", ListadoPecosasDetalle).AllowAnonymous();
        app.MapGet("/ListadoDespachoPedido", ListadoDespachoPedido).AllowAnonymous();

        app.MapGet("/ListarFiltroOCNEA", ListarFiltroOCNEA).AllowAnonymous(); //v20220923_1058
        app.MapGet("/ListarFiltroModalidad", ListarFiltroModalidad).AllowAnonymous(); //v20220923_1058
        app.MapGet("/ListarFiltroEstadoOCNEA", ListarFiltroEstadoOCNEA).AllowAnonymous(); //v20220923_1058
        app.MapGet("/ListarOCNEA", ListarOCNEA).AllowAnonymous(); //v20220923_1058
        app.MapPost("/ActualizarFichaActas", ActualizarFichaActas).AllowAnonymous(); //v20220923_1058
        app.MapPost("/detalleOCNEA", DetalleOCNEA).AllowAnonymous(); //v20220923_1058
        app.MapPost("/EntregasAlmacen", EntregasAlmacen).AllowAnonymous();
        app.MapGet("/ListarFichaActas", ListarFichaActas).AllowAnonymous();

    }

    private static async Task<IResult> ObtenerFiltros(IReporteInventarioData data)
    {
        try
        {
            var results = await data.filtros();
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarReporteInventario(ReporteInventarioModel.Request.Filtros filtros, IReporteInventarioData data)
    {
        try
        {
            var results = await data.ObtenerData(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ExportarExcel(ReporteInventarioModel.Request.Filtros filtros, IReporteInventarioData data)
    {
        try
        {
            var results = await data.ObtenerData(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ObtenerFiltrosProductos(IReporteInventarioData data)
    {
        try
        {
            var results = await data.filtrosConsultaProducto();
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarProductos(ReporteInventarioModel.Request.FiltrosConsultaProducto filtros, IReporteInventarioData data)
    {
        try
        {
            var results = await data.ObtenerDataProductos(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ListarCentros(ReporteInventarioModel.Request.FiltrosCentro filtros, IReporteInventarioData data)
    {
        try
        {
            var results = await data.listarCentros(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarAlmacenesPorCentro(ReporteInventarioModel.Request.FiltrosAlmacen filtros, IReporteInventarioData data)
    {
        try
        {
            var results = await data.listarAlmacenesPorCentro(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarEstrategias(ReporteInventarioModel.Request.FiltrosEstrategia filtros, IReporteInventarioData data)
    {
        try
        {
            var results = await data.listarEstrategias(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarProductosMaster(ReporteInventarioModel.Request.FiltrosProducto filtros, IReporteInventarioData data)
    {
        try
        {
            var results = await data.listarProductos(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarItemsInventario(IReporteInventarioData data, string IdAlmacen = "01", string NumeroItem = "", string NombreItem = "", string IdUbicacion = "", string IdUbicacionD = "", string NumeroLote = "", string AtributoEstado = "", string AtributoEstrategia = "", string Upc = "", string Tipo="")
    {
        try
        {
            ReporteInventarioModel.Request.FiltrosInventario filtros = new ReporteInventarioModel.Request.FiltrosInventario
            {
                IdAlmacen = IdAlmacen,
                NumeroItem = NumeroItem,
                NombreItem = NombreItem,
                IdUbicacion = IdUbicacion,
                IdUbicacionD = IdUbicacionD,
                NumeroLote = NumeroLote,
                AtributoEstado = AtributoEstado,
                AtributoEstrategia = AtributoEstrategia,
                Upc = Upc,
                Tipo = Tipo
            };
            var results = await data.listarItemsInventario(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    //async = Es un metodo ASINCRONO
    private static async Task<IResult> ListarTransacciones(ReporteInventarioModel.Request.FiltrosTransaccion filtros, IReporteInventarioData data)
    {
        try
        {
            var results = await data.listarTransacciones(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ListarMovimientos(IReporteInventarioData data, string IdAlmacen = "", string TipoTransaccion = "", string NumeroLote = "", string NumeroItem = "", string NumeroControl = "", string FechaInicial = "", string FechaFinal = "")
    {
        try
        {
            ReporteInventarioModel.Request.FiltrosMovimiento filtros = new ReporteInventarioModel.Request.FiltrosMovimiento
            {
                IdAlmacen = IdAlmacen,
                TipoTransaccion = TipoTransaccion,
                NumeroLote = NumeroLote,
                NumeroItem = NumeroItem,
                NumeroControl = NumeroControl,
                FechaInicial = FechaInicial,
                FechaFinal = FechaFinal
            };
            var results = await data.listarMovimientos(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ListarTareasInternas(IReporteInventarioData data, string IdAlmacen = "", string FechaInicial = "", string FechaFinal = "")
    {
        try
        {
            ReporteInventarioModel.Request.FiltrosTareaInterna filtros = new ReporteInventarioModel.Request.FiltrosTareaInterna
            {
                IdAlmacen = IdAlmacen,
                FechaInicial = FechaInicial,
                FechaFinal = FechaFinal
            };

            var results = await data.listarTareasInternas(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ListarUbicaciones(IReporteInventarioData data, string IdAlmacen = "", string IdUbicacion = "")
    {
        try
        {
            ReporteInventarioModel.Request.FiltrosUbicacion filtros = new ReporteInventarioModel.Request.FiltrosUbicacion
            {
                IdAlmacen = IdAlmacen,
                IdUbicacion = IdUbicacion
            };
            var results = await data.listarUbicaciones(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ListarTiposUbicacion(IReporteInventarioData data, string User = "USER")
    {
        try
        {
            ReporteInventarioModel.Request.FiltrosTiposUbicacion filtros = new ReporteInventarioModel.Request.FiltrosTiposUbicacion
            {
                User = User
            };
            var results = await data.listarTiposUbicacion(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    //private static async Task<IResult> ListarPrioridad( IReporteInventarioData data)
    //{
    //    try
    //    {
    //        ReporteInventarioModel.Request.FiltrosPrioridad filtros = new ReporteInventarioModel.Request.FiltrosPrioridad();
    //        var results = await data.listarPrioridad(filtros);
    //        if (results == null) return Results.NotFound();
    //        return Results.Ok(results);
    //    }
    //    catch (Exception ex)
    //    {
    //        return Results.Problem(ex.Message);
    //    }
    //}

    private static async Task<IResult> ListarPrioridad(IReporteInventarioData data, string Objeto = "", string Tipo = "",
        string Idioma = "")
    {
        try
        {
            ReporteInventarioModel.Request.FiltrosPrioridad filtros = new ReporteInventarioModel.Request.FiltrosPrioridad
            {
                Objeto = Objeto,
                Tipo = Tipo,
                Idioma = Idioma,
            };
            var results = await data.listarPrioridad(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ListarTipoFecha( IReporteInventarioData data)
    {
        try
        {
            ReporteInventarioModel.Request.FiltrosTipoFecha filtros=new ReporteInventarioModel.Request.FiltrosTipoFecha();
            var results = await data.listarTipoFecha(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarEstado( IReporteInventarioData data, string Objeto = "", string Tipo = "",
        string Idioma = "")
    {
        try
        {
            ReporteInventarioModel.Request.FiltrosEstado filtros = new ReporteInventarioModel.Request.FiltrosEstado
            {
                Objeto = Objeto,
                Tipo = Tipo,
                Idioma = Idioma,
            };
            var results = await data.listarEstado(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    //private static async Task<IResult> ListarEstado(IReporteInventarioData data)
    //{
    //    try
    //    {
    //        ReporteInventarioModel.Request.FiltrosEstado filtros = new ReporteInventarioModel.Request.FiltrosEstado();
    //        var results = await data.listarEstado(filtros);
    //        if (results == null) return Results.NotFound();
    //        return Results.Ok(results);
    //    }
    //    catch (Exception ex)
    //    {
    //        return Results.Problem(ex.Message);
    //    }
    //}
    private static async Task<IResult> ListarPedidoFiltroBuscar( IReporteInventarioData data)
    {
        try
        {
            ReporteInventarioModel.Request.FiltrosPedidoFiltroBuscar filtros=new ReporteInventarioModel.Request.FiltrosPedidoFiltroBuscar();    
            var results = await data.listarPedidoFiltroBuscar(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ListarPedido(IReporteInventarioData data, string IdPedido = "", string Pedido = "", string FechaInicial = "",
        string FechaFinal = "", string IdTipFecha = "", string IdCentro = "", string IdAlmacen = "", string IdPrioridad = "",
         string IdEstrategia = "", string IdEstado = "", string PorcentajeAvanceDesde = "", string PorcentajeAvanceHasta = "")
    {
        try
        {
            ReporteInventarioModel.Request.FiltrosPedido filtros = new ReporteInventarioModel.Request.FiltrosPedido
            {
                IdPedido = IdPedido,
                Pedido = Pedido,
                FechaInicial = FechaInicial,
                FechaFinal = FechaFinal,
                IdTipFecha = IdTipFecha,
                IdCentro = IdCentro,
                IdAlmacen = IdAlmacen,
                IdPrioridad = IdPrioridad,
                IdEstrategia = IdEstrategia,
                IdEstado = IdEstado,
                PorcentajeAvanceDesde = PorcentajeAvanceDesde,
                PorcentajeAvanceHasta = PorcentajeAvanceHasta,
            };
            var results = await data.listarPedido(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> MantenimientoOrdenDePedido(ReporteInventarioModel.Request.OrdenDePedido OrdenDePedido, IReporteInventarioData data)
    {
        try
        {
            var results = await data.mantenimientoOrdenDePedido(OrdenDePedido);
            if (results == null) return Results.NotFound();
            return Results.Ok(results.OrdenDePedidoError==null? results.OrdenDePedidoCorrecto: results.OrdenDePedidoError);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }



    private static async Task<IResult> StatusPedido(List<ReporteInventarioModel.Request.StatusPedido> StatusPedido, IReporteInventarioData data)
    {
        try
        {
            var result= await data.statusPedido(StatusPedido);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DetallePedido(IReporteInventarioData data, string numero_orden = "")
    {
        try
        {
            ReporteInventarioModel.Request.DetallePedido DetallePedido = new ReporteInventarioModel.Request.DetallePedido
            {
                numero_orden = numero_orden
            };
            var results = await data.detallePedido(DetallePedido);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListadoPecosas(IReporteInventarioData data, string IdPedido = "", string Pedido = "")
    {
        try
        {
            ReporteInventarioModel.Request.ListadoPecosas Pecosas = new ReporteInventarioModel.Request.ListadoPecosas
            {
                IdPedido = IdPedido,
                Pedido = Pedido
            };
            var results = await data.listadoPecosas(Pecosas);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ListadoPecosasDetalle(IReporteInventarioData data, string IdPedido = "", string Pedido = "")
    {
        try
        {
            ReporteInventarioModel.Request.ListadoPecosasDetalle PecosasDetalle = new ReporteInventarioModel.Request.ListadoPecosasDetalle
            {
                IdPedido = IdPedido,
                Pedido = Pedido
            };
            var results = await data.listadoPecosasDetalle(PecosasDetalle);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListadoDespachoPedido(IReporteInventarioData data, string IdPedido = "", string Pedido = "")
    {
        try
        {
            ReporteInventarioModel.Request.ListadoDespachoPedido DespachoPedido = new ReporteInventarioModel.Request.ListadoDespachoPedido
            {
                IdPedido = IdPedido,
                Pedido = Pedido
            };
            var results = await data.listadoDespachoPedido(DespachoPedido);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }


    //CONTROL DE CALIDAD
    private static async Task<IResult> ListarFiltroOCNEA(IReporteInventarioData data)
    {
        try
        {
            var results = await data.listarFiltroOCNEA();
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarFiltroModalidad(IReporteInventarioData data)
    {
        try
        {
            var results = await data.listarFiltroModalidad();
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ListarFiltroEstadoOCNEA(IReporteInventarioData data)
    {
        try
        {
            var results = await data.listarFiltroEstadoOCNEA();
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ListarOCNEA(IReporteInventarioData data, string IdFiltro = "", string OCNEA = "",
        string FechaInicial = "", string FechaFinal = "", string IdEstado = "", string IdModalidad = "", string IdTipoDoc = "")
    {
        try
        {
            ReporteInventarioModel.Request.ListarOCNEA filtros = new ReporteInventarioModel.Request.ListarOCNEA
            {
                IdFiltro = IdFiltro,
                OCNEA = OCNEA,
                FechaInicial = FechaInicial,
                FechaFinal = FechaFinal,
                IdEstado = IdEstado,
                IdModalidad = IdModalidad,
                IdTipoDoc = IdTipoDoc
            };
            var results = await data.listarOCNEA(filtros);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    private static async Task<IResult> ActualizarFichaActas(List<ReporteInventarioModel.Request.FichasActas> FichasActas, IReporteInventarioData data)
    {
        try
        {
            var result= await data.actualizarFichaActas(FichasActas);
            return Results.Ok(result);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DetalleOCNEA(IReporteInventarioData data, string numero_orden_compra = "")
    {
        try
        {
            ReporteInventarioModel.Request.OCNEA OCNEA = new ReporteInventarioModel.Request.OCNEA
            {
                numero_orden_compra = numero_orden_compra
            };
            var results = await data.detalleOCNEA(OCNEA);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> EntregasAlmacen(ReporteInventarioModel.Request.OCNEA ordenCompra, IReporteInventarioData data)
    {
        try
        {
            var results = await data.entregasAlmacen(ordenCompra);
            if (results == null) return Results.NotFound();
            return Results.Ok(results.OrdenDeCompraError == null ? results.OrdenDeCompraCorrecto : results.OrdenDeCompraError);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> ListarFichaActas(IReporteInventarioData data, string numero_orden_compra = "")
    {
        try
        {
            ReporteInventarioModel.Request.OCNEA OCNEA = new ReporteInventarioModel.Request.OCNEA
            {
                numero_orden_compra = numero_orden_compra
            };
            var results = await data.listarFichaActas(OCNEA);
            if (results == null) return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    
}

