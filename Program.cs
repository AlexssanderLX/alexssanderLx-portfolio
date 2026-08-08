using System.IO.Compression;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
});

builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Fastest;
});

builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Fastest;
});

builder.Services.AddControllersWithViews();
builder.Services.AddOutputCache();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    var headers = context.Response.Headers;
    var isCtfReportPdf = context.Request.Path.StartsWithSegments("/reports/ctf") &&
                         context.Request.Path.Value?.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) == true;

    headers["Content-Security-Policy"] = isCtfReportPdf
        ? "default-src 'self'; base-uri 'self'; object-src 'none'; frame-ancestors 'self'"
        : "default-src 'self'; base-uri 'self'; object-src 'none'; frame-ancestors 'none'; form-action 'self'; img-src 'self' data:; script-src 'self'; style-src 'self'; font-src 'self' data:; connect-src 'self'";
    headers["Permissions-Policy"] = "camera=(), geolocation=(), microphone=(), payment=(), usb=()";
    headers["Referrer-Policy"] = "strict-origin-when-cross-origin";
    headers["X-Content-Type-Options"] = "nosniff";
    headers["X-Frame-Options"] = isCtfReportPdf ? "SAMEORIGIN" : "DENY";
    headers["Cross-Origin-Opener-Policy"] = "same-origin";

    await next();
});

app.UseHttpsRedirection();
app.UseResponseCompression();
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = context =>
    {
        var hasVersionQuery = context.Context.Request.Query.ContainsKey("v");
        var isCtfReportPdf = context.Context.Request.Path.StartsWithSegments("/reports/ctf") &&
                             context.Context.Request.Path.Value?.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase) == true;

        if (isCtfReportPdf)
        {
            context.Context.Response.Headers.ContentDisposition = "inline";
        }

        context.Context.Response.Headers.CacheControl = hasVersionQuery
            ? "public,max-age=31536000,immutable"
            : "public,max-age=3600";
    }
});

app.UseRouting();
app.UseOutputCache();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
