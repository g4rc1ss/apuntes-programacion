WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder
    .Services.AddAuthentication("Cookies")
    .AddCookie(option =>
        option.Cookie = new CookieBuilder
        {
            Name = "Authentication",
            HttpOnly = true,
            SecurePolicy = CookieSecurePolicy.Always,
            SameSite = SameSiteMode.Strict,
            IsEssential = true,
            Path = "/",
        }
    );

IMvcBuilder? razorPages = builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment())
{
    razorPages.AddRazorRuntimeCompilation();
}

WebApplication? app = builder.Build();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
