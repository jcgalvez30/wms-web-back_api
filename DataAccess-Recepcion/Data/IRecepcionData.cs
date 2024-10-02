using DataAccess_Recepcion.Models;

namespace DataAccess_Recepcion.Data;

public interface IRecepcionData {
    Task<IEnumerable<ParametrosConsultaModel>> GetParametrosConsulta();
    Task<IEnumerable<RecepcionModel.SelectCabecera>> GetRecepcion();
    Task<IEnumerable<RecepcionModel.SelectDetalle>> GetDetalleRecepcion( string sNumeroDocumento );
}
