using GenderNeutralizer.App.Client.Pages;
using GenderNeutralizer.App.Components;
using GenderNeutralizer.App.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// Register Http service
builder.Services.AddHttpClient();

builder.Services.AddTransient<ILocalDriveService, LocalDriveService>();
builder.Services.AddTransient<ITextExtractionService, TextExtractionService>(); 
builder.Services.AddTransient<ITextNeutralizerService, TextNeutralizerService>();   

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
