using DataAccess_SIGA.Models;

namespace DataAccess_SIGA.Data;

public interface ISIGAData {
    Task<IEnumerable<ContratoModel.listar>> GetContratosSIGA( String contrato );
    Task<IEnumerable<ContratoModel.documentos>> GetDocumentosContratoSIGA( int idContrato );
    Task<IEnumerable<DocumentoModel>> GetDataDocumentoSIGA( int idDocumento );
}