using JNogueira.Logger.Discord;
using TesteMVCcep.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IApiService, ApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();


using (var scope = app.Services.CreateScope())
{
    var httpContext = scope.ServiceProvider.GetRequiredService<IHttpContextAccessor>();

    var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>(); // <-- Obtemos uma inst�ncia de LoggerFactory para adicionar o provider do Discord.

    // Adiciona o logger provider para o Discord.
    loggerFactory.AddDiscord(new DiscordLoggerOptions(app.Configuration["DiscordWebhookUrl"]) // <-- URL do webhook do Discord por onde as mensagens ser�o enviadas
    {
        ApplicationName = "LogandoNoDiscord", // <-- Nome da nossa aplica��o
        EnvironmentName = app.Environment.EnvironmentName, // <-- Ambiente em qual a aplica��o est� sendo executada
        UserName = "bot" // <-- Nome do usu�rio respons�vel pelo envio da mensagem no canal do Discord (pode ser qualquer nome).
    }, httpContext);
}
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
