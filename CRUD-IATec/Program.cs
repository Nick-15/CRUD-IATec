using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;
using CRUD_IATec.Application;
using CRUD_IATec.Infrastructure;
using CRUD_IATec.ModelBinders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    // Adiciona o Model Binder customizado para decimal
    options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
});

// Adiciona as camadas da Arquitetura Onion
builder.Services.AddApplication();      // Camada de Aplicação
builder.Services.AddInfrastructure(builder.Configuration);  // Camada de Infraestrutura

// Define cultura padrão pt-BR
var cultureInfo = new CultureInfo("pt-BR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Configuração da localização (para formatação e parsing)
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture(cultureInfo);
    options.SupportedCultures = new[] { cultureInfo };
    options.SupportedUICultures = new[] { cultureInfo };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Aplique a cultura AQUI (depois do UseRouting, antes dos controllers)
var localizationOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value;
app.UseRequestLocalization(localizationOptions);

app.UseAuthorization();

// Rotas padrão
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();