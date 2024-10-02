using DataAccess_SIGA2.DbAccess;
using DataAccess_SIGA2.Models;

namespace DataAccess_SIGA2.Data;

public class SIGA2Data : ISIGA2Data {
    private readonly ISqlDataAccess _db;

    public SIGA2Data( ISqlDataAccess db ) {
        _db = db;
    }

    public Task<IEnumerable<SIGA2Model.Response.Producto>> ListarProductos() =>
        _db.LoadData<SIGA2Model.Response.Producto, dynamic>("dbo.SP_WMS_CATALOGO_BIENES_Y_SERVICIOS", new { I_SEC_EJEC = 1345 });

    public Task<IEnumerable<SIGA2Model.Response.Proveedor>> ListarProveedores() =>
        _db.LoadData<SIGA2Model.Response.Proveedor, dynamic>("dbo.SP_WMS_PROVEEDOR", new { ESTADO = "P" });

    public async Task<IEnumerable<SIGA2Model.Response.CabeceraOC>> ObtenerCabeceraOC( SIGA2Model.Request.CabeceraOC cabeceraOC) {
        var result = await _db.LoadData<SIGA2Model.Response.CabeceraOC, dynamic>(
            "dbo.SP_WMS_CONSULTA_ORDEN_COMPRA", new {
                I_ANO_EJE = cabeceraOC.I_ANO_EJE,
                I_SEC_EJEC = 1345,
                I_NRO_ORDEN = cabeceraOC.I_NRO_ORDEN
            });
        return result;
    }
    public async Task<IEnumerable<SIGA2Model.Response.CabeceraNEA>> ObtenerCabeceraNEA( SIGA2Model.Request.CabeceraNEA cabeceraNEA ) {
        var result = await _db.LoadData<SIGA2Model.Response.CabeceraNEA, dynamic>(
            "dbo.SP_WMS_CONSULTA_NEA", new {
                I_ANO_EJE = cabeceraNEA.I_ANO_EJE,
                I_SEC_EJEC = 1345,
                I_TIPO_TRANSAC = cabeceraNEA.I_TIPO_TRANSAC,
                I_NRO_REQUERIM = cabeceraNEA.I_NRO_REQUERIM
            });
        return result;
    }
    public async Task<IEnumerable<SIGA2Model.Response.DetalleOC>> ObtenerDetalleOC( SIGA2Model.Request.DetalleOC detalleOC ) {
        var result = await _db.LoadData<SIGA2Model.Response.DetalleOC, dynamic>(
            "dbo.SP_WMS_CONSULTA_ORDENES_COMPRA_DETALLE_X_ITEM", new {
                I_ANO_EJE = detalleOC.I_ANO_EJE,
                I_SEC_EJEC = 1345,
                I_NRO_ORDEN = detalleOC.I_NRO_ORDEN
            });
        return result;
    }
    public async Task<IEnumerable<SIGA2Model.Response.DetalleNEA>> ObtenerDetalleNEA( SIGA2Model.Request.DetalleNEA detalleNEA ) {
        var result = await _db.LoadData<SIGA2Model.Response.DetalleNEA, dynamic>(
            "dbo.SP_WMS_CONSULTA_NEA_DETALLE", new {
                I_ANO_EJE = detalleNEA.I_ANO_EJE,
                I_SEC_EJEC = 1345,
                I_NRO_REQUERIM = detalleNEA.I_NRO_REQUERIM
            });
        return result;
    }
    public Task InsertarRecepcionCabecera( SIGA2Model.Request.RecepcionCabecera recepcionCabecera ) =>
    _db.SaveData("DBO.SP_INSERTAR_RECEPCION_ORDEN", new {
        ANO_EJE = recepcionCabecera.ANO_EJE,
        SEC_EJEC = 1345,
        NRO_ORDEN = recepcionCabecera.NRO_ORDEN,
        OBSERVACION = recepcionCabecera.OBSERVACION,
        FECHA_MOVIMTO = recepcionCabecera.FECHA_MOVIMTO,
        NRO_GUIA = recepcionCabecera.NRO_GUIA,
        MES_MOVIMTO = recepcionCabecera.MES_MOVIMTO,
        FECHA_REG = recepcionCabecera.FECHA_REG,
        CUSER_ID = recepcionCabecera.CUSER_ID,
        EQUIPO_REG = recepcionCabecera.EQUIPO_REG,
        TIPO_MOVIMTO = recepcionCabecera.TIPO_MOVIMTO,
        TIPO_TRANSAC = recepcionCabecera.TIPO_TRANSAC
    });

    public async Task<IEnumerable<SIGA2Model.Response.Contrato>> BuscarContratos(SIGA2Model.Request.BuscarContratos filtroContratos)
    {
        var result = await _db.LoadData<SIGA2Model.Response.Contrato, dynamic>(
            "dbo.SP_WMS_CONSULTA_CONTRATOS", new
            {
                I_ANO_EJE = filtroContratos.I_ANO_EJE,
                I_NRO_CONTRATO = filtroContratos.texto
            });
        return result;
    }
    public async Task<IEnumerable<SIGA2Model.Response.Orden>> BuscarOrdenesPorNumContrato(SIGA2Model.Request.BuscarOrdenes filtroOrdenes)
    {
        var result = await _db.LoadData<SIGA2Model.Response.Orden, dynamic>(
            "dbo.SP_WMS_CONSULTA_CONTRATO_ORDENES", new
            {
                I_ANO_EJE = filtroOrdenes.i_ANO_EJE,
                I_NRO_CONTRATO = filtroOrdenes.contrato
            });
        return result;
    }
}