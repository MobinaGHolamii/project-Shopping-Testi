using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Shop.Data;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ShopDb");
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Blog API",
        Version = "v1"
    });
});
builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShopDb")));


builder.Services.AddControllersWithViews();

var app = builder.Build();
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API V1");
    });
}
else
{
    // Configure Swagger for production if needed



    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ShopDbContext>();

        // بررسی اتصال
        if (context.Database.CanConnect())
        {
            Console.WriteLine("✅ اتصال به دیتابیس موفقیت‌آمیز بود!");
        }
        else
        {
            Console.WriteLine("⚠️  نمی‌تواند متصل شود، سعی در ایجاد دیتابیس...");
            context.Database.EnsureCreated();
            Console.WriteLine("✅ دیتابیس ایجاد شد!");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ خطا در اتصال به دیتابیس: {ex.Message}");
        Console.WriteLine("⚠️  رشته اتصال را بررسی کنید:");
        Console.WriteLine(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
}
app.Run();
