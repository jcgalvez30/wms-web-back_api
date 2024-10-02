var builder = WebApplication.CreateBuilder(args);

//-----------------------------------------------------------------------------
//JC
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddCors();
//builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
//builder.Services.AddSingleton<ITransporteData, TransporteData>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<ITransporteData, TransporteData>();
//-----------------------------------------------------------------------------

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.ConfigureApi();


app.Run();