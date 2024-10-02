var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DataAccess_Recepcion.DbAccess.ISqlDataAccess, DataAccess_Recepcion.DbAccess.SqlDataAccess>();
builder.Services.AddSingleton<IRecepcionData, RecepcionData>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.ConfigureApi();

app.Run();