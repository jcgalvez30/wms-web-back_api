
using DataAccess_RecibirStock.Models;

namespace DataAccess_RecibirStock.Data;

public interface IRecibirStockData {
    Task DeleteRecibirStock( int id );
    Task<IEnumerable<RecibirStockModel>> GetRecibirStock();
    Task<RecibirStockModel?> GetRecibirStock( int id );
    Task InsertRecibirStock( RecibirStockModel recibirStock );
    Task UpdateRecibirStock( RecibirStockModel recibirStock );
}