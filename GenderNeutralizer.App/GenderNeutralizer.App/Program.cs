using GenderNeutralizer.App.Client.Pages;
using GenderNeutralizer.App.Components;
using GenderNeutralizer.App.Database;
using GenderNeutralizer.App.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Register Http service
builder.Services.AddHttpClient();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sql => sql.CommandTimeout(60) // Timeout in seconds
    ));


builder.Services.AddScoped<ILocalDriveService, LocalDriveService>();
builder.Services.AddScoped<ITextExtractionService, TextExtractionService>(); 
builder.Services.AddScoped<ITextNeutralizerService, TextNeutralizerService>();
builder.Services.AddScoped<ICandidateService, CandidateServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(GenderNeutralizer.App.Client._Imports).Assembly);

app.Run();
