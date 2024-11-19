using Servico;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner.
builder.Services.AddControllers();

// Configurar pol�ticas de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Registrar seus servi�os com o cont�iner de DI
builder.Services.AddScoped<ServicoEstado>();
builder.Services.AddScoped<ServicoCidade>();
builder.Services.AddScoped<ServicoCliente>();
builder.Services.AddScoped<ServicoPessoaFisica>();
builder.Services.AddScoped<ServicoPessoaJuridica>();
builder.Services.AddScoped<ServicoFuncionario>();
builder.Services.AddScoped<ServicoFrete>();

// Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar o pipeline de requisi��o HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplicar a pol�tica de CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
