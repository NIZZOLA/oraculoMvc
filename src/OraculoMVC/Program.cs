using OraculoApi;
using OraculoApi.Interfaces;
using OraculoApi.Services;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
builder.Services.Configure<OpenAIConfig>(configuration.GetSection("OpenAIConfig"));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<OpenAITextService>();
builder.Services.AddScoped<IOpenAITextService, OpenAITextService>();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
