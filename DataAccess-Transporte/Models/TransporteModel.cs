namespace DataAccess_Transporte.Models;


public class TransporteModel {

    public class Insert {
        public int idProgramacionIngreso { get; set; }
        public int idPuerta { get; set; }
        public int idEspacioTemporal { get; set; }
        public string? sHoraInicio { get; set; }
        public string? sHoraFin { get; set; }
        public string? sNumeroDocumento { get; set; }
        public DateTime dtFechaLlegada { get; set; }
        public int idTipoDoi { get; set; }
        public string? sDocumentoIdentidad { get; set; }
        public string? sNombreChofer { get; set; }
        public string? sVehiculo { get; set; }
        public string? sPlaca { get; set; }
        public int bAutorizado { get; set; }
        public int idTipoMotivo { get; set; }
        public string? sMotivo { get; set; }
        public string? sUsuarioModificacion { get; set; }
    }

    public class Update {
        public int idTransporte { get; set; }
        public int idProgramacionIngreso { get; set; }
        public int idPuerta { get; set; }
        public int idEspacioTemporal { get; set; }
        public string? sHoraInicio { get; set; }
        public string? sHoraFin { get; set; }
        public string? sNumeroDocumento { get; set; }
        public DateTime dtFechaLlegada { get; set; }
        public int idTipoDoi { get; set; }
        public string? sDocumentoIdentidad { get; set; }
        public string? sNombreChofer { get; set; }
        public string? sVehiculo { get; set; }
        public string? sPlaca { get; set; }
        public int bAutorizado { get; set; }
        public int idTipoMotivo { get; set; }
        public string? sMotivo { get; set; }
        public string? sUsuarioModificacion { get; set; }
    }

    public class SelectFormulario {
        public int idTransporte { get; set; }
        public int idProgramacionIngreso { get; set; }
        public int idPuerta { get; set; }
        public int idEspacioTemporal { get; set; }
        public string? sHoraInicio { get; set; }
        public string? sHoraFin { get; set; }
        public string? sNumeroDocumento { get; set; }
        public DateTime dtFechaLlegada { get; set; }
        public int idTipoDoi { get; set; }
        public string? sDocumentoIdentidad { get; set; }
        public string? sNombreChofer { get; set; }
        public string? sVehiculo { get; set; }
        public string? sPlaca { get; set; }
        public int bAutorizado { get; set; }
        public int idTipoMotivo { get; set; }
        public string? sMotivo { get; set; }
    }

}