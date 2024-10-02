using DataAccess_Stock.Models;

namespace DataAccess_Stock.Data;

public interface IStockData {
    Task<IEnumerable<StockModel.listaConsulta>> GetStock();
    Task<IEnumerable<StockModel.listaConsulta>> GetStockFiltrado( StockModel.parametrosConsulta parametrosConsulta );
}
