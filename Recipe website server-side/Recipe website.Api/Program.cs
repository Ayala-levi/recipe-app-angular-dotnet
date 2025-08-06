using Recipe_website.Core.Repositories_Interface;
using Recipe_website.Core.Services_Interface;
using Recipe_website.Data;
using Recipe_website.Data.Entities;
using Recipe_website.Data.Repositories;
using Recipe_website.Service.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//������ ������
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//����� DbContext
builder.Services.AddDbContext<DataContext>();

//����� ������ ��������
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

//����� ������ ��������
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<IRecipeService, RecipeService>();

//����� ������ �������
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IIngredientService, IngredientService>();

//����� ������ ������� ������
builder.Services.AddScoped<IRecipeIngredientRepository, RecipeIngredientRepository>();
builder.Services.AddScoped<IRecipeIngredientService, RecipeIngredientService>();

//�������� �������� ����

builder.Services.AddCors(Option =>
Option.AddPolicy("AllowAll", policy =>
policy.AllowAnyOrigin()
.AllowAnyHeader()
.AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//������ ������ �������-�������
app.UseStaticFiles();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
