using DataAccess_ProgramacionIngreso.Models;

namespace DataAccess_ProgramacionIngreso.Data;

public interface IEvaluacionProductoData {
    Task DeleteProgramacionIngreso( int id );
    Task<EvaluacionProductoModel?> GetProgramacionIngreso( int id );
    Task<IEnumerable<EvaluacionProductoModel>> GetProgramacionIngreso();
    Task InsertProgramacionIngreso( EvaluacionProductoModel programacionIngreso );
    Task UpdateProgramacionIngreso( EvaluacionProductoModel programacionIngreso );
}