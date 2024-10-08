using GestaoDeProjetoWeb.Servico;
using GestaoDeSquadWeb.Servico;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
//builder.Services.AddSingleton<WeatherForecastService>();



builder.Services.AddScoped<IProjetoServico, ProjetoServico>();
builder.Services.AddScoped<ISquadServico, SquadServico>();
builder.Services.AddScoped<IProjetoSquadServico, ProjetoSquadServico>();
builder.Services.AddScoped<IUsuarioServico, UsuarioServico>();
builder.Services.AddScoped<ISquadUsuarioServico, SquadUsuarioServico>();
builder.Services.AddScoped<ITarefaServico, TarefaServico>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
