using DataAccess_SIGA.DbAccess;
using DataAccess_SIGA.Models;

namespace DataAccess_SIGA.Data;

public class SIGAData : ISIGAData {
    private readonly ISqlDataAccess _db;

    public SIGAData( ISqlDataAccess db ) {
        _db = db;
    }

    public Task<IEnumerable<ContratoModel.listar>> GetContratosSIGA( String contrato ) =>
         _db.LoadData<ContratoModel.listar, dynamic>("SIGA.listarContratos", new { contrato = contrato });

    public Task<IEnumerable<ContratoModel.documentos>> GetDocumentosContratoSIGA( int idContrato ) =>
         _db.LoadData<ContratoModel.documentos, dynamic>( "SIGA.listarDocumentosContrato", new { idContrato = idContrato });

    public Task<IEnumerable<DocumentoModel>> GetDataDocumentoSIGA( int idDocumento ) =>
        _db.LoadData<DocumentoModel, dynamic>("SIGA.obtenerDataDocumento", new { idDocumento = idDocumento });
}