using Microsoft.Net.Http.Headers;
using WebApplication1.rpc;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorPages();
// Configure CORS for development- Configure CORS if the client is on a different domain.
builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientAppPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:3000") // Replace with your client URL
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});


var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
// Use CORS middleware 
app.UseCors("ClientAppPolicy");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseResponseCaching();

app.Use(async (context, next) =>
    {
        context.Response.Headers.Add("X-Frame-Options", "DENY");
        context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
        context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
        context.Response.Headers.Add("Referrer-Policy", "no-referrer");
        context.Response.Headers.Add("Permissions-Policy", "geolocation=(), microphone=(), camera=(), fullscreen=(self), payment=()");
        context.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
        context.Response.Headers.Add("Pragma", "no-cache");
        context.Response.Headers.Add("Expires", "0");
        context.Response.GetTypedHeaders().CacheControl = new Microsoft.Net.Http.Headers.CacheControlHeaderValue
        {
            //NoCache = true,
            //NoStore = true,
            //MustRevalidate = true
            Public = true,
            MaxAge = TimeSpan.FromSeconds(60) // Set a max age for caching
        };
        context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; script-src 'self' 'unsafe-inline'; style-src 'self' 'unsafe-inline'; img-src 'self' data:; font-src 'self'; frame-ancestors 'none'; base-uri 'self'; form-action 'self';");
        context.Response.Headers.Add("Cross-Origin-Embedder-Policy", "require-corp");
        context.Response.Headers.Add("Cross-Origin-Opener-Policy", "same-origin");
        context.Response.Headers[HeaderNames.Vary] = "Accept-Encoding";
        await next();
    });

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<NotificationHub>("/chatHub"); // Map the hub to the "/chatHub" endpoint ,Map the hub to a specific URL path.

app.Run();
