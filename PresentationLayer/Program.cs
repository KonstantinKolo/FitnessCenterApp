using DataLayer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<FitnessDbContext>(options =>
    options.UseMySQL("Server=192.168.100.6;Database=FitnessDb;Uid=root;Pwd=root;"));

builder.Services.AddScoped<EmployeeContext>();
builder.Services.AddScoped<FitnessCenterContext>();
builder.Services.AddScoped<MemberContext>();
builder.Services.AddScoped<MembershipContext>();
builder.Services.AddScoped<PaymentContext>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
