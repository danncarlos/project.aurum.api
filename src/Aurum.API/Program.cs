using Aurum.API.Config;
using Aurum.Application.Handlers;
using Aurum.Infra.Data;
using Aurum.Infra.IoC;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Xml.Linq;

var baseCorsPolicy = "_basePolicy";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(opt => {
    opt.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {
        Description = "Simple Product CRUD Operations with MediatorR and CQRS",
        Version = "v1",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact {
            Email = "danncarlos@outlook.com.br",
            Url = new Uri("https://github.com/danncarlos")
        }
    });
    opt.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "ApiDocs.xml"));
    //opt.UseInlineDefinitionsForEnums();
});

//- CORS
builder.Services.AddCors(opt => {
    opt.AddPolicy(name: baseCorsPolicy, policy => {
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
        policy.WithOrigins(["http://localhost:4200", "http://localhost:*", "https://localhost/*"]);
    });
});

//-- Register
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
DependencyInjectionCommandMediator.AddDependency(builder.Services); //MediatorR
DependencyInjectionCommandValidators.AddDependency(builder.Services);
DependencyInjectionValidators.AddDependency(builder.Services);
DependencyInjectionRepositories.AddDependency(builder.Services);

//DB
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BaseAppDbContext>(opt => opt.UseSqlServer(connectionString));

var app = builder.Build();

// Aplicar migrações e criar banco de dados
using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<BaseAppDbContext>();
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseCors(baseCorsPolicy);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
