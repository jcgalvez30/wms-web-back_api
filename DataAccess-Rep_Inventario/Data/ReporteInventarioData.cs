using DataAccess_ReporteInventario.DbAccess;
using DataAccess_ReporteInventario.Models;
using System.Linq;
using System.Text.Json;
using static DataAccess_ReporteInventario.Models.ReporteInventarioModel.Response;

namespace DataAccess_ReporteInventario.Data;

public class ReporteInventarioData : IReporteInventarioData
{
    private readonly ISqlDataAccess _db;

    public ReporteInventarioData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<ReporteInventarioModel.Response.Filtros> filtros()
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.Filtros, dynamic>(
    "ReporteInventario_FiltrosConsulta", new { });
        return result.FirstOrDefault();
    }
    public async Task<ReporteInventarioModel.Response.FiltrosConsultaProducto> filtrosConsultaProducto()
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.FiltrosConsultaProducto, dynamic>(
    "ReporteInventario_FiltrosConsultaProductos", new { });
        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<ReporteInventarioModel.Response.Consulta>> ObtenerData(ReporteInventarioModel.Request.Filtros filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.Consulta, dynamic>(
        "ReporteInventario_ObtenerData", new
        {
            itemCode = filtros.itemCode,
            sUbicacionOrigen = filtros.sUbicacionOrigen,
            sUbicacionDestino = filtros.sUbicacionDestino,
            sLote = filtros.sLote,
            sPasillo = filtros.sPasillo,
            idCentro = filtros.idCentro,
            idWarehouse = filtros.idWarehouse,
            idEstrategia = filtros.idEstrategia,
            idEstado = filtros.idEstado
        });
        return result;
    }
    public async Task<IEnumerable<ReporteInventarioModel.Response.ConsultaProducto>> ObtenerDataProductos(ReporteInventarioModel.Request.FiltrosConsultaProducto filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.ConsultaProducto, dynamic>(
        "ReporteInventario_ObtenerDataProductos", new
        {
            idEstrategia = filtros.idEstrategia,
            sDescripcion = filtros.sDescripcion
        });
        return result;
    }

    public async Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarCentros(ReporteInventarioModel.Request.FiltrosCentro filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.ItemLista, dynamic>(
        "SP_WMS_GET_LIST_CENTER", new
        {
            USER = filtros.User,
        }, "WMS_MOVIL");
        return result;
    }
    public async Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarAlmacenesPorCentro(ReporteInventarioModel.Request.FiltrosAlmacen filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.ItemLista, dynamic>(
        "SP_WMS_GET_LIST_WHS", new
        {
            USER = filtros.User,
            CENTER = filtros.Center,
        }, "WMS_MOVIL");
        return result;
    }
    public async Task<IEnumerable<ReporteInventarioModel.Response.Estrategia>> listarEstrategias(ReporteInventarioModel.Request.FiltrosEstrategia filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.Estrategia, dynamic>(
        "SP_WMS_LISTAR_ATRIBUTO", new
        {
            TIPO_ATRIBUTO = filtros.TipoAtributo,
            VALOR_ATRIBUTO = filtros.ValorAtributo,
        }, "WMS_MOVIL");
        return result;
    }
    public async Task<IEnumerable<ReporteInventarioModel.Response.Producto>> listarProductos(ReporteInventarioModel.Request.FiltrosProducto filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.Producto, dynamic>(
        "SP_GET_ITEM_MASTERv3", new
        {
            id_almacen = filtros.IdAlmacen,
            numero_item = filtros.NumeroItem,
            descripcion = filtros.Descripcion,
        }, "WMS_MOVIL");
        return result;
    }
    public async Task<IEnumerable<ReporteInventarioModel.Response.ItemInventario>> listarItemsInventario(ReporteInventarioModel.Request.FiltrosInventario filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.ItemInventario, dynamic>(
        "SP_WMS_WEB_GETSTOCK", new
        {
            id_almacen = filtros.IdAlmacen,
            numero_item = filtros.NumeroItem,
            nombre_item = filtros.NombreItem,
            id_ubicacion = filtros.IdUbicacion,
            id_ubicacionD = filtros.IdUbicacionD,
            numero_lote = filtros.NumeroLote,
            atributo_estado = filtros.AtributoEstado,
            atributo_estrategia = filtros.AtributoEstrategia,
            upc = filtros.Upc,
            tipo = filtros.Tipo
        }, "WMS_MOVIL");
        return result;
    }
    public async Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarTransacciones(ReporteInventarioModel.Request.FiltrosTransaccion filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.ItemLista, dynamic>(
        "SP_WMS_GET_LIST_TRANSACTION", new
        {
            USER = filtros.User,
            ACTION = filtros.Action,
        }, "WMS_MOVIL");
        return result;
    }
    public async Task<IEnumerable<ReporteInventarioModel.Response.Movimiento>> listarMovimientos(ReporteInventarioModel.Request.FiltrosMovimiento filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.Movimiento, dynamic>(
        "SP_WMS_GET_LIST_TRANSACTION_LOG", new
        {
            id_almacen = filtros.IdAlmacen,
            numero_item = filtros.NumeroItem,
            numero_control = filtros.NumeroControl,
            fecha_inicial = filtros.FechaInicial,
            fechafinal = filtros.FechaFinal,
            numero_lote = filtros.NumeroLote,
            tipo_transaccion = filtros.TipoTransaccion
        }, "WMS_MOVIL");
        return result;
    }
    public async Task<IEnumerable<ReporteInventarioModel.Response.TareaInterna>> listarTareasInternas(ReporteInventarioModel.Request.FiltrosTareaInterna filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.TareaInterna, dynamic>(
        "SP_WMS_HH_GET_TRANSFER_ORDERV2", new
        {
            id_almacen = filtros.IdAlmacen,
            fecha_inicial = filtros.FechaInicial,
            fechafinal = filtros.FechaFinal
        }, "WMS_MOVIL");
        return result;
    }
    public async Task<IEnumerable<ReporteInventarioModel.Response.Ubicacion>> listarUbicaciones(ReporteInventarioModel.Request.FiltrosUbicacion filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.Ubicacion, dynamic>(
        "SP_GET_LOCATIONV2", new
        {
            id_almacen = filtros.IdAlmacen,
            id_ubicacion = filtros.IdUbicacion
        }, "WMS_MOVIL");
        return result;
    }

    public async Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarTiposUbicacion(ReporteInventarioModel.Request.FiltrosTiposUbicacion filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.ItemLista, dynamic>(
        "SP_WMS_GET_LIST_TIPO_LOCATION", new
        {
            USER = filtros.User,
        }, "WMS_MOVIL");
        return result;
    }

    //public async Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarPrioridad(ReporteInventarioModel.Request.FiltrosPrioridad filtros)
    //{
    //    var result = await _db.LoadData<ReporteInventarioModel.Response.ItemLista, dynamic>(
    //    "SP_WMS_GET_LIST_PRIORIDAD", new
    //    {
    //        USER = filtros.User,
    //    }, "WMS_MOVIL");
    //    return result;
    //}

    public async Task<IEnumerable<ReporteInventarioModel.Response.Prioridad>> listarPrioridad(ReporteInventarioModel.Request.FiltrosPrioridad filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.Prioridad, dynamic>(
        "SP_WMS_GET_LISTA_ATRIBUTO_OBJETO", new
        {
            objeto = filtros.Objeto,
            tipo = filtros.Tipo,
            idioma = filtros.Idioma,
        }, "WMS_MOVIL");
        return result;
    }

    public async Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarTipoFecha(ReporteInventarioModel.Request.FiltrosTipoFecha filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.ItemLista, dynamic>(
        "SP_WMS_GET_LIST_TIPO_FECHA", new
        {
            USER = filtros.User,
        }, "WMS_MOVIL");
        return result;
    }
    //public async Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarEstado(ReporteInventarioModel.Request.FiltrosEstado filtros)
    //{
    //    var result = await _db.LoadData<ReporteInventarioModel.Response.ItemLista, dynamic>(
    //    "SP_WMS_GET_LIST_ESTADO", new
    //    {
    //        USER = filtros.User,
    //    }, "WMS_MOVIL");
    //    return result;
    //}
    public async Task<IEnumerable<ReporteInventarioModel.Response.Estado>> listarEstado(ReporteInventarioModel.Request.FiltrosEstado filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.Estado, dynamic>(
        "SP_WMS_GET_LISTA_ATRIBUTO_OBJETO", new
        {
            objeto = filtros.Objeto,
            tipo = filtros.Tipo,
            idioma = filtros.Idioma,
        }, "WMS_MOVIL");
        return result;
    }
    public async Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarPedidoFiltroBuscar(ReporteInventarioModel.Request.FiltrosPedidoFiltroBuscar filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.ItemLista, dynamic>(
        "SP_WMS_GET_LIST_PEDIDO_FILTRO_BUSCAR", new
        {
            USER = filtros.User,
        }, "WMS_MOVIL");
        return result;
    }

    public async Task<IEnumerable<ReporteInventarioModel.Response.Pedido>> listarPedido(ReporteInventarioModel.Request.FiltrosPedido filtros)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.Pedido, dynamic>(
        "SP_WMS_WEB_PEDIDO", new
        {
            //Actualizar y verificar los parametros del spcampos que corresponderian, segun la tabla y la grilla
            IdPedido = filtros.IdPedido,  //01(Por Pedido), 02(Por PECOSA), 03(Por Solicitante)
            Pedido = filtros.Pedido,  //001, 002, 003 --[{Pedido:"001"},{Pedido:"002"},{Pedido:"003"}]

            FechaInicial = filtros.FechaInicial,
            FechaFinal = filtros.FechaFinal,
            IdTipFecha = filtros.IdTipFecha,
            IdCentro = filtros.IdCentro,
            IdAlmacen = filtros.IdAlmacen,
            IdPrioridad = filtros.IdPrioridad,
            IdEstrategia = filtros.IdEstrategia,
            IdEstado = filtros.IdEstado,
            PorcentajeAvanceDesde = filtros.PorcentajeAvanceDesde,
            PorcentajeAvanceHasta = filtros.PorcentajeAvanceHasta,
        }, "WMS_MOVIL");

        return result;
    }

    public async Task<ReporteInventarioModel.Response.OrdenDePedidoResponse> mantenimientoOrdenDePedido(ReporteInventarioModel.Request.OrdenDePedido OrdenDePedido)
    {

        var OrdenPedido = new
        {
            OrdenDePedido.id_almacen,
            OrdenDePedido.numero_orden,
            OrdenDePedido.numero_pedido_siga,
            OrdenDePedido.tipo,
            OrdenDePedido.id_cliente,
            OrdenDePedido.urgencia,
            OrdenDePedido.prioridad,
            OrdenDePedido.fecha_pedido,
            OrdenDePedido.indicador_pedido_parcial,
            OrdenDePedido.fecha_inicial_despacho,
            OrdenDePedido.fecha_final_despacho,
            OrdenDePedido.fecha_inicial_entrega,
            OrdenDePedido.fecha_final_entrega,
            OrdenDePedido.envio_direccion1,
            OrdenDePedido.envio_direccion2,
            OrdenDePedido.envio_direccion3,
            envio_ciudad = OrdenDePedido.envio_ciudad,
            envio_postal = OrdenDePedido.envio_postal,
            OrdenDetalle = JsonSerializer.Serialize(OrdenDePedido.OrdenDetalle)
        };
        string procedure = "";
        switch (OrdenDePedido.accion.ToUpper())
        {
            //case "D": procedure = "Negocio.insertarProgramacionIngresoD"; break;
            //case "U": procedure = "Negocio.insertarProgramacionIngresoU"; break;
            case "N": procedure = "insertarDataSIGA"; break;//nuevo
            default: break;
        }
        var response = new ReporteInventarioModel.Response.OrdenDePedidoResponse();
        try
        {
            //ReporteInventarioModel.Response.OrdenDePedidoResponse
            var result = await _db.LoadData<ReporteInventarioModel.Response.OrdenDePedidoCorrecto, dynamic>(procedure, OrdenPedido, "WMS_MOVIL");

            if (result.FirstOrDefault() != null)
            {
                response.OrdenDePedidoCorrecto = result.FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            response.OrdenDePedidoError = new ReporteInventarioModel.Response.OrdenDePedidoError();
            response.OrdenDePedidoError.Fecha_hora = DateTime.Now;
            //response.OrdenDePedidoError.Mensaje = "Mensaje de Error";
            
            //response.OrdenDePedidoError.NumPecosa = int.Parse(OrdenDePedido.numero_orden);
            response.OrdenDePedidoError.NumPecosa = OrdenDePedido.numero_orden;
            
            response.OrdenDePedidoError.Estado = 3;
            var mensaje = ex.Message.Substring(0, 130);
            if (mensaje.Length > 0)
            {
                response.OrdenDePedidoError.Mensaje = string.Format("Mensaje de Error ->{0}", mensaje);
            }

        }
        return response;
    }

    public async Task<IEnumerable<ReporteInventarioModel.Response.Status>> statusPedido(IEnumerable<ReporteInventarioModel.Request.StatusPedido> StatusPedido)
    {
        List<ReporteInventarioModel.Response.Status> result = new List<ReporteInventarioModel.Response.Status>();
        foreach (var item in StatusPedido)
        {

            var resp = new ReporteInventarioModel.Response.Status();
            try
            {
                var respl = await _db.LoadData<ReporteInventarioModel.Response.Status, dynamic>("DBO.SP_UPDATE_STATUS_PEDIDO", new
                {
                    numero_orden = item.numero_orden,
                    statusOrden = item.statusOrden //
                }, "WMS_MOVIL");
                if (respl.FirstOrDefault() != null)
                {
                    resp = respl.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                resp.numero_orden = item.numero_orden;
                var mens = resp.mensaje.Split('.');
                if (mens.Length > 0)
                {
                    resp.mensaje = ex.Message;
                }
            }
            result.Add(resp);
        }
        return result.AsEnumerable<ReporteInventarioModel.Response.Status>();
    }
    public async Task<ReporteInventarioModel.Response.OrdenDePedido> detallePedido(ReporteInventarioModel.Request.DetallePedido detallePedido)
    {
        //traera la cabecera
        var result = await _db.LoadData<ReporteInventarioModel.Response.OrdenDePedido, dynamic>(
        "SP_WMS_ORDEN_PEDIDO", new

        {
            //Actualizar y verificar los parametors del spcampos que corresponderian, segun la tabla y la grilla
            numero_orden = detallePedido.numero_orden
        }, "WMS_MOVIL");

        //traera el detalle
        var detalle = await _db.LoadData<ReporteInventarioModel.Response.OrdenDetalle, dynamic>(
        "SP_WMS_ORDEN_PEDIDO_DETALLE", new

        {
            //Actualizar y verificar los parametors del spcampos que corresponderian, segun la tabla y la grilla
            numero_orden = detallePedido.numero_orden
        }, "WMS_MOVIL");

        //Poniendo la cabecera y el detalle
        ReporteInventarioModel.Response.OrdenDePedido item = result.FirstOrDefault();
        if (item != null && detalle.Count() > 0)
        {
            item.OrdenDetalle = detalle.ToList();
        }
        return item;
    }
    public async Task<IEnumerable<ReporteInventarioModel.Response.ListadoPecosas>> listadoPecosas(ReporteInventarioModel.Request.ListadoPecosas pecosas)
    {

        var result = await _db.LoadData<ReporteInventarioModel.Response.ListadoPecosas, dynamic>(
        "SP_WMS_WEB_LISTADOPECOSAS", new
        {
            //Actualizar y verificar los parametros del spcampos que corresponderian, segun la tabla y la grilla
            IdPedido = pecosas.IdPedido,  //01(Por Pedido), 02(Por PECOSA), 03(Por Solicitante)
            Pedido = pecosas.Pedido,  //001, 002, 003 - 
        }, "WMS_MOVIL");

        return result;
    }

    public async Task<IEnumerable<ReporteInventarioModel.Response.ListadoPecosasDetalle>> listadoPecosasDetalle(ReporteInventarioModel.Request.ListadoPecosasDetalle PecosasDetalle)
    {


        var result = await _db.LoadData<ReporteInventarioModel.Response.ListadoPecosasDetalle, dynamic>(
        "SP_WMS_WEB_LISTADOPECOSASDETALLE_PACKING", new
        {
            //Actualizar y verificar los parametros del spcampos que corresponderian, segun la tabla y la grilla
            IdPedido = PecosasDetalle.IdPedido,  //01(Por Pedido), 02(Por PECOSA), 03(Por Solicitante)
            Pedido = PecosasDetalle.Pedido,  //001, 002, 003 - 
        }, "WMS_MOVIL");

        return result;
    }
    public async Task<IEnumerable<ReporteInventarioModel.Response.ListadoDespachoPedido>> listadoDespachoPedido(ReporteInventarioModel.Request.ListadoDespachoPedido DespachoPedido)
    {

        var result = await _db.LoadData<ReporteInventarioModel.Response.ListadoDespachoPedido, dynamic>(
        "SP_WMS_WEB_DESPACHOPEDIDO", new
        {
            //Actualizar y verificar los parametros del spcampos que corresponderian, segun la tabla y la grilla
            IdPedido = DespachoPedido.IdPedido,  //01(Por Pedido), 02(Por PECOSA), 03(Por Solicitante)
            Pedido = DespachoPedido.Pedido,  //001, 002, 003 - 
        }, "WMS_MOVIL");

        return result;
    }
    public async Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarFiltroOCNEA()
    {

        var result = await _db.LoadData<ReporteInventarioModel.Response.ItemLista, dynamic>(
        "SP_WMS_GET_LIST_OCNEA_FILTRO_BUSCAR", new { }, "WMS_MOVIL");

        return result;
    }
    public async Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarFiltroModalidad()
    {

        var result = await _db.LoadData<ReporteInventarioModel.Response.ItemLista, dynamic>(
        "SP_WMS_GET_LIST_OCNEA_FILTRO_MODALIDAD", new { }, "WMS_MOVIL");

        return result;
    }
    public async Task<IEnumerable<ReporteInventarioModel.Response.ItemLista>> listarFiltroEstadoOCNEA()
    {

        var result = await _db.LoadData<ReporteInventarioModel.Response.ItemLista, dynamic>(
        "SP_WMS_GET_LIST_OCNEA_FILTRO_ESTADO", new { }, "WMS_MOVIL");

        return result;
    }
    public async Task<IEnumerable<ReporteInventarioModel.Response.ListarOCNEA>> listarOCNEA(ReporteInventarioModel.Request.ListarOCNEA ListarOCNEA)
    {
        var result = await _db.LoadData<ReporteInventarioModel.Response.ListarOCNEA, dynamic>(
            "SP_WMS_WEB_LISTA_OCNEA", new
            {
                //Actualizar y verificar los parametros del spcampos que corresponderian, segun la tabla y la grilla
                IdFiltro = ListarOCNEA.IdFiltro,  //01(Por Pedido), 02(Por PECOSA), 03(Por Solicitante)
                OCNEA = ListarOCNEA.OCNEA,  //001, 002, 003 - 
                FechaInicial = ListarOCNEA.FechaInicial,
                FechaFinal = ListarOCNEA.FechaFinal,
                IdEstado = ListarOCNEA.IdEstado,
                IdModalidad = ListarOCNEA.IdModalidad,
                IdTipoDoc = ListarOCNEA.IdTipoDoc
            }, "WMS_MOVIL");

        return result;
    }

    public async Task<IEnumerable<ReporteInventarioModel.Response.FichasActas>> actualizarFichaActas(IEnumerable<ReporteInventarioModel.Request.FichasActas> FichasActas)
    {
        List<ReporteInventarioModel.Response.FichasActas> result = new List<ReporteInventarioModel.Response.FichasActas>();
        foreach (var item in FichasActas)
        {

            var resp = new ReporteInventarioModel.Response.FichasActas();
            try
            {
                var respl = await _db.LoadData<ReporteInventarioModel.Response.FichasActas, dynamic>("DBO.SP_UPDATE_FICHA_ACTAS", item, "WMS_MOVIL");
                if (respl.FirstOrDefault() != null)
                {
                    resp = respl.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                resp.numero_orden_compra = item.numero_orden_compra;
                var mens = resp.mensaje.Split('.');
                if (mens.Length > 0)
                {
                    resp.mensaje = ex.Message;
                }
            }
            result.Add(resp);
        }
        return result.AsEnumerable<ReporteInventarioModel.Response.FichasActas>();
    }

    public async Task<ReporteInventarioModel.Response.OCNEA> detalleOCNEA(ReporteInventarioModel.Request.OCNEA OCNEA)
    {
        //traera la cabecera
        var result = await _db.LoadData<ReporteInventarioModel.Response.OCNEA, dynamic>(
        "SP_WMS_OCNEA", OCNEA , "WMS_MOVIL");

        //traera el detalle
        var detalle = await _db.LoadData<ReporteInventarioModel.Response.DetalleOCNEA, dynamic>(
        "SP_WMS_OCNEA_DETALLE", OCNEA, "WMS_MOVIL");

        //Poniendo la cabecera y el detalle
        ReporteInventarioModel.Response.OCNEA item = result.FirstOrDefault();
        if (item != null && detalle.Count() > 0)
        {
            item.DetalleOCNEA = detalle.ToList();
        }
        return item;
    }

    public async Task<ReporteInventarioModel.Response.OrdenDeCompraResponse> entregasAlmacen(ReporteInventarioModel.Request.OCNEA ordenCompra)
    {

        var ordenCompraestado = new
        {
            numero_orden_compra = ordenCompra.numero_orden_compra
        };
        string procedure = "Usp_EntregasAlmacen";

        var response = new ReporteInventarioModel.Response.OrdenDeCompraResponse();
        try
        {
            //ReporteInventarioModel.Response.OrdenDePedidoResponse
            var result = await _db.LoadData<ReporteInventarioModel.Response.OrdenDeCompraCorrecto, dynamic>(procedure, ordenCompraestado, "WMS_MOVIL");

            if (result.FirstOrDefault() != null)
            {
                response.OrdenDeCompraCorrecto = result.FirstOrDefault();
            }
        }
        catch (Exception ex)
        {
            response.OrdenDeCompraError = new ReporteInventarioModel.Response.OrdenDeCompraError();
            response.OrdenDeCompraError.Fecha_hora = DateTime.Now;
            //response.OrdenDePedidoError.Mensaje = "Mensaje de Error";
            response.OrdenDeCompraError.numero_orden_compra = (ordenCompraestado.numero_orden_compra);
            response.OrdenDeCompraError.Estado = 3;
            var mensaje = ex.Message.Substring(0, 130);
            if (mensaje.Length > 0)
            {
                response.OrdenDeCompraError.Mensaje = string.Format("Mensaje de Error ->{0}", mensaje);
            }

        }
        return response;
    }

    public async Task<ReporteInventarioModel.Response.FichasActasReponse> listarFichaActas(ReporteInventarioModel.Request.OCNEA OCNEA)
    {

        var resp = new ReporteInventarioModel.Response.FichasActasReponse();
        var respl = await _db.LoadData<ReporteInventarioModel.Response.FichasActasReponse, dynamic>("DBO.SP_LIST_FICHAS_ACTAS", OCNEA, "WMS_MOVIL");
        if (respl.FirstOrDefault() != null)
        {
            resp = respl.FirstOrDefault();
        }
        return resp;
    }
     
}
