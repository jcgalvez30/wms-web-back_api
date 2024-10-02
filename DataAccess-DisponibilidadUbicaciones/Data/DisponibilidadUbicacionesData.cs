using DataAccess_DisponibilidadUbicaciones.DbAccess;
using DataAccess_DisponibilidadUbicaciones.Models;

namespace DataAccess_DisponibilidadUbicaciones.Data;

public class DisponibilidadUbicacionesData : IDisponibilidadUbicacionesData {
    private readonly ISqlDataAccess _db;

    public DisponibilidadUbicacionesData( ISqlDataAccess db ) {
        _db = db;
    }

    public async Task<DisponibilidadUbicacionesModel.Response.Filtros> Filtros() {
        var result = await _db.LoadData<DisponibilidadUbicacionesModel.Response.Filtros, dynamic>(
    "DisponibilidadUbicaciones_FiltrosConsulta", new {});
        return result.FirstOrDefault();
    }
    public async Task<IEnumerable<DisponibilidadUbicacionesModel.Response.Consulta>> ObtenerData( DisponibilidadUbicacionesModel.Request.Filtros filtros ) {
        var result = await _db.LoadData<DisponibilidadUbicacionesModel.Response.Consulta, dynamic>(
        "DisponibilidadUbicaciones_ObtenerData", new {
            sPasillo = filtros.sPasillo,
            idCentro = filtros.idCentro,
            idWarehouse = filtros.idWarehouse
        });
        return result;
    }

}
