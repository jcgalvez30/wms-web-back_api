using DataAccess_Recepcion.DbAccess;
using DataAccess_Recepcion.Models;

namespace DataAccess_Recepcion.Data;

public class RecepcionData : IRecepcionData {
    private readonly ISqlDataAccess _db;

    public RecepcionData( ISqlDataAccess db ) {
        _db = db;
    }

    public Task<IEnumerable<ParametrosConsultaModel>> GetParametrosConsulta() =>
        _db.LoadData<ParametrosConsultaModel, dynamic>("Maestra.obtenerParametrosConsultaRecepcion", new { });
  
    public Task<IEnumerable<RecepcionModel.SelectCabecera>> GetRecepcion() =>
        _db.LoadData<RecepcionModel.SelectCabecera, dynamic>("Negocio.ListarRecepcionCabecera", new { });

    public Task<IEnumerable<RecepcionModel.SelectDetalle>> GetDetalleRecepcion( string sNumeroDocumento ) =>
        _db.LoadData<RecepcionModel.SelectDetalle, dynamic>( "Negocio.ListarRecepcionDetalle", new { sNumeroDocumento = sNumeroDocumento });
   
}
