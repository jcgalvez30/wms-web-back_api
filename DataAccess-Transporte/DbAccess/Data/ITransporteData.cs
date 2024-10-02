using DataAccess_Transporte.Models;

namespace DataAccess_Transporte.Data;

public interface ITransporteData {
    Task<IEnumerable<ParametrosFormularioModel>> GetParametrosFormulario();
    Task<IEnumerable<TransporteModel.SelectFormulario>> GetTransporte( int idProgramacionIngreso );
    Task InsertTransporte( TransporteModel.Insert Transporte );
    Task UpdateTransporte( TransporteModel.Update Transporte );
}