using DataAccess_ProgramacionIngreso.Models;

namespace DataAccess_ProgramacionIngreso.Data;

public interface IProgramacionIngresoData {
    Task<IEnumerable<ParametrosConsultaModel>> GetParametrosConsulta();
    Task<IEnumerable<ProgramacionIngreso.response.TipoDocumento>> ListarTiposDocumentos();
    Task<IEnumerable<ParametrosFormularioModel>> GetParametrosFormulario();

    Task<IEnumerable<ProgramacionIngresoModel.SelectGrilla>> ListarFiltradoProgramacionIngreso( ProgramacionIngresoModel.FiltrosGrilla programacionIngresoInsert );
    Task<ProgramacionIngresoModel.SelectFormulario?> GetProgramacionIngreso( int id );
    Task<IEnumerable<ProgramacionIngresoModel.SelectGrilla>> GetProgramacionIngreso(ProgramacionIngresoModel.Request.Filtros filtros);

    Task<ProgramacionIngresoModel.Response.Insert> InsertProgramacionIngreso( ProgramacionIngresoModel.Insert programacionIngresoInsert );
    Task InsertDetProgramacionIngreso(ProgramacionIngresoModel.InsertDetalle programacionIngresoInsertDet);
    Task UpdateProgramacionIngreso( ProgramacionIngresoModel.Update programacionIngresoUpdate );
    Task DeleteProgramacionIngreso( int id );


    Task<SeguridadModel.Response.ValidarLogin> GetUsuario( SeguridadModel.Request.ValidarLogin validarLogin );
    Task<IEnumerable<SeguridadModel.Response.PermisoModulo>> GetPermisoModulos( SeguridadModel.Request.PermisoModulo permisoModulorequest );

    Task<IEnumerable<ProgramacionIngresoModel.Response.Item>> ListarTiposDocumentos2(ProgramacionIngresoModel.Request.FiltrosTipoDocumento filtrosTipoDocumento);

    //FiltrarTiposDocumento
    //exec SP_WMS_GET_LISTA_ATRIBUTO_OBJETO 'T_C_ORDEN_COMPRA','TYPE','ES'
    //@A = string
    //@B = string
    //@C = string
    //return Value, Display




}