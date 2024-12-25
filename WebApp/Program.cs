using FluentMigrator.Runner;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Migrations;
using Infrastructure.Services.AuthorService;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<DataContext>();
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI V1"); });

}

builder.Services.AddScoped<DataContext>(db =>
    new NpgsqlConnection(builder.Configuration.GetConnectionString("Default")));

// 1)
builder.Services.AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddPostgres()
        .WithGlobalConnectionString(builder.Configuration.GetConnectionString("Default"))
        .ScanIn(typeof(CreateAuthorTable).Assembly).For.Migrations());




app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();