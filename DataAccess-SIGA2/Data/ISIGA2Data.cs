using DataAccess_SIGA2.Models;

namespace DataAccess_SIGA2.Data;

public interface ISIGA2Data {
    Task<IEnumerable<SIGA2Model.Response.Producto>> ListarProductos();
    Task<IEnumerable<SIGA2Model.Response.Proveedor>> ListarProveedores();
    Task<IEnumerable<SIGA2Model.Response.CabeceraOC>> ObtenerCabeceraOC( SIGA2Model.Request.CabeceraOC cabeceraOC );
    Task<IEnumerable<SIGA2Model.Response.CabeceraNEA>> ObtenerCabeceraNEA( SIGA2Model.Request.CabeceraNEA cabeceraNEA );
    Task<IEnumerable<SIGA2Model.Response.DetalleOC>> ObtenerDetalleOC( SIGA2Model.Request.DetalleOC detalleOC );
    Task<IEnumerable<SIGA2Model.Response.DetalleNEA>> ObtenerDetalleNEA( SIGA2Model.Request.DetalleNEA detalleNEA );

    Task InsertarRecepcionCabecera( SIGA2Model.Request.RecepcionCabecera recepcionCabecera );

    Task<IEnumerable<SIGA2Model.Response.Contrato>> BuscarContratos(SIGA2Model.Request.BuscarContratos  filtroContratos);
    //exec [SP_WMS_CONSULTA_CONTRATOS] 2022,'9-2022-CENARES/MINSA'

    Task<IEnumerable<SIGA2Model.Response.Orden>> BuscarOrdenesPorNumContrato(SIGA2Model.Request.BuscarOrdenes filtroOrdenes);
    //exec [dbo].[SP_WMS_CONSULTA_CONTRATO_ORDENES] 2022,'9-2022-CENARES/MINSA'
    
}
