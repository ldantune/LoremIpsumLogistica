using LoremIpsumLogistica.API.AutoMapper;
using LoremIpsumLogistica.API.Context;
using LoremIpsumLogistica.API.Converters;
using LoremIpsumLogistica.API.Filters;
using LoremIpsumLogistica.API.Interface;
using LoremIpsumLogistica.API.Repositories;
using LoremIpsumLogistica.API.UseCase.Cadastro;
using LoremIpsumLogistica.API.UseCase.Endereco;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Adiciona o suporte ao CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:4200")  // Permite o acesso a partir do Angular
               .AllowAnyMethod()                      // Permite qualquer método HTTP
               .AllowAnyHeader();                     // Permite qualquer cabeçalho
    });
});

builder.Services.AddControllers();

builder.Services.AddScoped(option => new AutoMapper.MapperConfiguration(autoMapperOptions =>
{
    autoMapperOptions.AddProfile(new AutoMapping());
}).CreateMapper());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddDbContext<LoremIpsumLogisticaDBContext>(
    context => context.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

// Repositories
builder.Services.AddScoped<ICadastroRepository, CadastroRepository>();
builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();


//UseCase Cadastro
builder.Services.AddScoped<IBuscarTodosUseCase, BuscarTodosUseCase>();
builder.Services.AddScoped<ICadastroByIdUseCase, CadastroByIdUseCase>();
builder.Services.AddScoped<ISalvarCadastroUseCase, SalvarCadastroUseCase>();
builder.Services.AddScoped<IAtualizarUseCase, AtualizarUseCase>();
builder.Services.AddScoped<IExcluirCadastroUseCase, ExcluirCadastroUseCase>();

//UseCase Endereco
builder.Services.AddScoped<IBuscaByIdCadastroUseCase, BuscaByIdCadastroUseCase>();
builder.Services.AddScoped<ISalvarEnderecoUseCase, SalvarEnderecoUseCase>();
builder.Services.AddScoped<IAtualizarEnderecoUseCase, AtualizarEnderecoUseCase>();
builder.Services.AddScoped<IExcluirEnderecoUseCase, ExcluirEnderecoUseCase>();
builder.Services.AddScoped<IEnderecoByIdUseCase, EnderecoByIdUseCase>();

builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();

public partial class Program
{
    protected Program() { }
}