using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API teste para um CRUD",
        Description = "Um exemplo de CRUD para API",
        Contact = new OpenApiContact { Name = "Felipe Gabriel Cabral", Email = "fgcabral88@outlook.com" },
        License = new OpenApiLicense { Name = "MIT License", Url = new Uri("https://opensource.org/licenses/MIT")}
    });
    options.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "CRUDSwaggerAnnotation.xml"));
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
