namespace DataAccess_SIGA2.DbAccess;

public interface ISqlDataAccess {
    Task<IEnumerable<T>> LoadData<T, U>( string storedProcedure, U parameters, string connectionId = "SIGA" );
    Task SaveData<T>( string storedProcedure, T parameters, string connectionId = "WMS" );
}