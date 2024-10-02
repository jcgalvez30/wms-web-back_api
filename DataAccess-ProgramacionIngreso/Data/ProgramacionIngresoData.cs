using DataAccess_ProgramacionIngreso.DbAccess;
using DataAccess_ProgramacionIngreso.Models;

namespace DataAccess_ProgramacionIngreso.Data;

public class ProgramacionIngresoData : IProgramacionIngresoData {
    private readonly ISqlDataAccess _db;

    public ProgramacionIngresoData( ISqlDataAccess db ) {
        _db = db;
    }

    public Task<IEnumerable<ParametrosConsultaModel>> GetParametrosConsulta() =>
        _db.LoadData<ParametrosConsultaModel, dynamic>("Maestra.obtenerParametrosConsultaProgramacionIngreso", new { });

    public Task<IEnumerable<ProgramacionIngreso.response.TipoDocumento>> ListarTiposDocumentos() =>
        _db.LoadData<ProgramacionIngreso.response.TipoDocumento, dynamic>("Maestra.ListarTiposDocumentos", new { });

    public Task<IEnumerable<ParametrosFormularioModel>> GetParametrosFormulario() =>
        _db.LoadData<ParametrosFormularioModel, dynamic>("Maestra.obtenerParametrosFormularioProgramacionIngreso", new { });

    public Task<IEnumerable<ProgramacionIngresoModel.SelectGrilla>> GetProgramacionIngreso(ProgramacionIngresoModel.Request.Filtros filtros) =>
        _db.LoadData<ProgramacionIngresoModel.SelectGrilla, dynamic>("Negocio.listarProgramacionIngreso",
            new
            {
                iProveedor = filtros.IdProveedor,
                sContratoInicio = filtros.ContratoInicio,
                sContratoFin = filtros.ContratoFin,
                sDocumento = filtros.Documento,
            });

    public async Task<ProgramacionIngresoModel.SelectFormulario?> GetProgramacionIngreso( int id ) {
        var result = await _db.LoadData<ProgramacionIngresoModel.SelectFormulario, dynamic>(
            "Negocio.obtenerProgramacionIngreso", new { Id = id });
        return result.FirstOrDefault();
    }

    public Task InsertDetProgramacionIngreso(ProgramacionIngresoModel.InsertDetalle programacionIngresoInsertDet) =>
   _db.SaveData("Negocio.insertarDetalleMovil", programacionIngresoInsertDet);

    
    public async Task<ProgramacionIngresoModel.Response.Insert> InsertProgramacionIngreso(ProgramacionIngresoModel.Insert programacionIngresoInsert)
    {
        var result = await _db.LoadData<ProgramacionIngresoModel.Response.Insert,dynamic>("Negocio.insertarProgramacionIngreso", new
        {
            programacionIngresoInsert.sContrato,
            programacionIngresoInsert.sDocumento,
            programacionIngresoInsert.idTipoDocumento,
            programacionIngresoInsert.idProcedencia,
            programacionIngresoInsert.idAlmacen,
            programacionIngresoInsert.iPeriodo,
            programacionIngresoInsert.idIngreso,
            programacionIngresoInsert.iNumeroEntrega,
            programacionIngresoInsert.iMesNominal,
            programacionIngresoInsert.iPlazoEntrega,
            programacionIngresoInsert.dtFechaNotificacion,
            programacionIngresoInsert.dtFechaCita,
            programacionIngresoInsert.idPropietario,
            programacionIngresoInsert.idProveedor,
            programacionIngresoInsert.sComentario,
            programacionIngresoInsert.sUsuarioModificacion,
            programacionIngresoInsert.sProveedor,
            programacionIngresoInsert.sRuc,
            programacionIngresoInsert.sAlmacen,
            programacionIngresoInsert.sSecAlmacen,
            programacionIngresoInsert.sNombreAlmacen,
        });
        
        var response =result.FirstOrDefault();
        if (response != null && response.iCod == "1" && programacionIngresoInsert.detalleMovil != null)
            foreach (var item in programacionIngresoInsert.detalleMovil)
            {
                item.sDocumento = response.sDocumento;
                await InsertDetProgramacionIngreso(item);
            }
        
        return response;
    }
   
    public Task<IEnumerable<ProgramacionIngresoModel.SelectGrilla>> ListarFiltradoProgramacionIngreso( ProgramacionIngresoModel.FiltrosGrilla programacionIngresoListarFiltro ) =>
        _db.LoadData<ProgramacionIngresoModel.SelectGrilla, dynamic>("Negocio.listarProgramacionIngresoFiltrado", new {
            programacionIngresoListarFiltro.iProveedor,
            programacionIngresoListarFiltro.sContrato,
            programacionIngresoListarFiltro.sDocumento
        });

    public Task UpdateProgramacionIngreso( ProgramacionIngresoModel.Update programacionIngresoUpdate ) =>
        _db.SaveData("Negocio.actualizarProgramacionIngreso", programacionIngresoUpdate);

    public Task DeleteProgramacionIngreso( int id ) =>
        _db.SaveData("Negocio.eliminarProgramacionIngreso", new { Id = id });

    public async Task<SeguridadModel.Response.ValidarLogin> GetUsuario( SeguridadModel.Request.ValidarLogin validarLogin ) {
        var result = await _db.LoadData<SeguridadModel.Response.ValidarLogin, dynamic>(
            "Seguridad.ValidarUsuario", new {
                sNombreUsuario = validarLogin.sNombreUsuario,
                idAD = validarLogin.idAD,
                iSistema = validarLogin.iSistema,
            });
        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<SeguridadModel.Response.PermisoModulo>> GetPermisoModulos( SeguridadModel.Request.PermisoModulo permisoModulo ) {
        var result = await _db.LoadData<SeguridadModel.Response.PermisoModulo, dynamic>(
            "seguridad.ObtenerModuloPermiso", new { idRol = permisoModulo.idRol });
        return result;
    }


    public Task<IEnumerable<ProgramacionIngresoModel.Response.Item>> ListarTiposDocumentos2(ProgramacionIngresoModel.Request.FiltrosTipoDocumento filtrosTipoDocumento) =>
    _db.LoadData<ProgramacionIngresoModel.Response.Item, dynamic>("dbo.SP_WMS_GET_LISTA_ATRIBUTO_OBJETO", new
    {
        filtrosTipoDocumento.A,
        filtrosTipoDocumento.B,
        filtrosTipoDocumento.C
    });



}