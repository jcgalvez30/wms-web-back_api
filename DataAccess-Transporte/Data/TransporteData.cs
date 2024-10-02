using DataAccess_Transporte.DbAccess;
using DataAccess_Transporte.Models;

namespace DataAccess_Transporte.Data;

public class TransporteData : ITransporteData {
    private readonly ISqlDataAccess _db;

    public TransporteData( ISqlDataAccess db ) {
        _db = db;
    }

    public Task<IEnumerable<ParametrosFormularioModel>> GetParametrosFormulario() =>
        _db.LoadData<ParametrosFormularioModel, dynamic>("Maestra.obtenerParametrosFormularioTransporte", new { });

    public Task<IEnumerable<TransporteModel.SelectFormulario>> GetTransporte( int idProgramacionIngreso ) =>
         _db.LoadData<TransporteModel.SelectFormulario, dynamic>("Negocio.obtenerTransporte", new { idProgramacionIngreso = idProgramacionIngreso });

    public Task InsertTransporte( TransporteModel.Insert Transporte ) =>
        _db.SaveData("Negocio.insertarTransporte", new {
            Transporte.idProgramacionIngreso,
            Transporte.idPuerta,
            Transporte.idEspacioTemporal,
            Transporte.sHoraInicio,
            Transporte.sHoraFin,
            Transporte.sNumeroDocumento,
            Transporte.dtFechaLlegada,
            Transporte.idTipoDoi,
            Transporte.sDocumentoIdentidad,
            Transporte.sNombreChofer,
            Transporte.sVehiculo,
            Transporte.sPlaca,
            Transporte.bAutorizado,
            Transporte.idTipoMotivo,
            Transporte.sMotivo,
            Transporte.sUsuarioModificacion
        });

    public Task UpdateTransporte( TransporteModel.Update Transporte ) =>
        _db.SaveData("Negocio.actualizarTransporte", Transporte);


}