using DataAccess_DisponibilidadUbicaciones.Models;

namespace DataAccess_DisponibilidadUbicaciones.Data;

public interface IDisponibilidadUbicacionesData {
    Task<DisponibilidadUbicacionesModel.Response.Filtros> Filtros();
    Task<IEnumerable<DisponibilidadUbicacionesModel.Response.Consulta>> ObtenerData( DisponibilidadUbicacionesModel.Request.Filtros filtros );
}
