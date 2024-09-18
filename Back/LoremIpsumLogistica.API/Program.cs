using LoremIpsumLogistica.API.AutoMapper;
using LoremIpsumLogistica.API.Context;
using LoremIpsumLogistica.API.Converters;
using LoremIpsumLogistica.API.Filters;
using LoremIpsumLogistica.API.Interface;
using LoremIpsumLogistica.API.Repositories;
using LoremIpsumLogistica.API.UseCase.Cadastro;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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


//UseCase
builder.Services.AddScoped<IBuscarTodosUseCase, BuscarTodosUseCase>();
builder.Services.AddScoped<ICadastroByIdUseCase, CadastroByIdUseCase>();
builder.Services.AddScoped<ISalvarCadastroUseCase, SalvarCadastroUseCase>();
builder.Services.AddScoped<IAtualizarUseCase, AtualizarUseCase>();
builder.Services.AddScoped<IExcluirCadastroUseCase, ExcluirCadastroUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
    protected Program() { }
}