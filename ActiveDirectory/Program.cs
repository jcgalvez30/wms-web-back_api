var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();


app.MapPost("/ValidarUsuario", ( Todo todo ) => {
    var activeDirectory = new DataAccess_ActiveDirectory.ActiveDirectory(
        "192.168.10.190",
        "cenaresdc",
        "/OU=Usuarios,DC=cenaresdc,DC=local",
        "chpwd",
        "ABCabc123");
    var result = activeDirectory.validarCuentaUsuario(todo.Usuario, todo.password);
    return result.Tables[0].Rows[0].ItemArray[2];
});

app.MapPost("/ValidarCuentaUsuario", ( Todo todo ) => {
    var activeDirectory = new DataAccess_ActiveDirectory.ActiveDirectory(
        "192.168.10.191",
        "cenaresdc",
        "/OU=Cenares,DC=cenares,DC=gob,DC=pe",
        "chpwd",
        "ABCabc123");
    var result = activeDirectory.validarCuentaUsuario(todo.Usuario);
    return result.Tables[0].Rows[0].ItemArray[2];
});

app.MapPost("/CambiarContraseña", (Todo todo) => {
    var activeDirectory = new DataAccess_ActiveDirectory.ActiveDirectory(
        "192.168.10.191", 
        "cenares", 
        "/OU=Cenares,DC=cenares,DC=gob,DC=pe", 
        "chpwd", 
        "ABCabc123");
    var result = activeDirectory.editarContrasenya(todo.Usuario, todo.password, true);
    return result.Tables[0].Rows[0].ItemArray[2];
});
app.MapGet("/ListarUsuarios", () => {
    var activeDirectory = new DataAccess_ActiveDirectory.ActiveDirectory(
        "192.168.10.190",
        "cenaresdc.local",
        "/OU=Usuarios,DC=cenaresdc,DC=local",
        "chpwd",
        "ABCabc123");
    var result = activeDirectory.ConsultarUsuarios();
    return result;
});

app.Run();

class Todo {
    public string Usuario { get; set; }
    public string password { get; set; }
}

//"192.168.10.190", 
//"cenaresdc.local", 
//"/OU=Usuarios,DC=cenaresdc,DC=local", 
//"chpwd", 
//"ABCabc123");

//"192.168.10.191", 
//"cenares", 
//"/OU=Cenares,DC=cenares,DC=gob,DC=pe", 
//"chpwd", 
//"ABCabc123");