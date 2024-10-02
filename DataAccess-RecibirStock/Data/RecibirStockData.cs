using DataAccess_RecibirStock.DbAccess;
using DataAccess_RecibirStock.Models;

namespace DataAccess_RecibirStock.Data;

public class RecibirStockData : IRecibirStockData {
    private readonly ISqlDataAccess _db;

    public RecibirStockData( ISqlDataAccess db ) {
        _db = db;
    }

    public Task<IEnumerable<RecibirStockModel>> GetRecibirStock() =>
        _db.LoadData<RecibirStockModel, dynamic>("dbo.listarRecibirStock", new { });

    public async Task<RecibirStockModel?> GetRecibirStock( int id ) {
        var result = await _db.LoadData<RecibirStockModel, dynamic>(
            "dbo.obtenerRecibirStock", new { Id = id });
        return result.FirstOrDefault();
    }

    public Task InsertRecibirStock( RecibirStockModel recibirStock ) =>
        _db.SaveData("dbo.insertarRecibirStock", new { recibirStock.Nombre, recibirStock.Edad, recibirStock.usuario_modificacion });

    public Task UpdateRecibirStock( RecibirStockModel recibirStock ) =>
        _db.SaveData("dbo.actualizarRecibirStock", recibirStock);

    public Task DeleteRecibirStock( int id ) =>
        _db.SaveData("dbo.eliminarRecibirStock", new { Id = id });


}