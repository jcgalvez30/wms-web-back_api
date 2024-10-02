using DataAccess_ProgramacionIngreso.DbAccess;
using DataAccess_ProgramacionIngreso.Models;

namespace DataAccess_ProgramacionIngreso.Data;

public class EvaluacionProductoData : IEvaluacionProductoData {
    private readonly ISqlDataAccess _db;

    public EvaluacionProductoData( ISqlDataAccess db ) {
        _db = db;
    }

    public Task<IEnumerable<EvaluacionProductoModel>> GetProgramacionIngreso() =>
        _db.LoadData<EvaluacionProductoModel, dynamic>("dbo.listarProgramacionIngreso", new { });

    public async Task<EvaluacionProductoModel?> GetProgramacionIngreso( int id ) {
        var result = await _db.LoadData<EvaluacionProductoModel, dynamic>(
            "dbo.obtenerProgramacionIngreso", new { Id = id });
        return result.FirstOrDefault();
    }

    public Task InsertProgramacionIngreso( EvaluacionProductoModel programacionIngreso ) =>
        _db.SaveData("dbo.insertarProgramacionIngreso", new { programacionIngreso.Nombre, 
            programacionIngreso.Edad, programacionIngreso.usuario_modificacion });

    public Task UpdateProgramacionIngreso( EvaluacionProductoModel programacionIngreso ) =>
        _db.SaveData("dbo.actualizarProgramacionIngreso", programacionIngreso);

    public Task DeleteProgramacionIngreso( int id ) =>
        _db.SaveData("dbo.eliminarProgramacionIngreso", new { Id = id });


}