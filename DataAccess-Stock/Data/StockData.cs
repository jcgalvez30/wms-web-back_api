using DataAccess_Stock.DbAccess;
using DataAccess_Stock.Models;

namespace DataAccess_Stock.Data;

public class StockData : IStockData {
    private readonly ISqlDataAccess _db;

    public StockData( ISqlDataAccess db ) {
        _db = db;
    }

    public Task<IEnumerable<StockModel.listaConsulta>> GetStock() =>
        _db.LoadData<StockModel.listaConsulta, dynamic>("Negocio.ListarStock", new { });

    public Task<IEnumerable<StockModel.listaConsulta>> GetStockFiltrado( StockModel.parametrosConsulta parametrosConsulta ) =>
        _db.LoadData<StockModel.listaConsulta, dynamic>( "Negocio.ListarStockFiltrado", 
            new { sCodigoProducto = parametrosConsulta.idProducto,
                            sNombreProducto = parametrosConsulta.sProducto});
   
}
