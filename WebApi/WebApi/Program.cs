using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using WebApi.Data;
using WebApi.MiddleWare;
using WebApi.Repositories;

using WebApi.Service.Models;
using WebApi.Service.Services;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));




var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<PostRepo>();
builder.Services.AddScoped<QuizRepo>();
builder.Services.AddScoped<BookmarkRepo>();
builder.Services.AddScoped<ReviewRepo>();
builder.Services.AddScoped<ReportRepo>();
builder.Services.AddScoped<InterestRepo>();

//builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();

builder.Services.AddIdentityApiEndpoints<ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// F�r email - reset Denna rad �r f�r hur l�nge l�nken/ token ska g�lla efter du f�tt den p� mail. 

builder.Services.Configure<DataProtectionTokenProviderOptions>(opts => opts.TokenLifespan = TimeSpan.FromHours(10));



builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.Name = "MyAuthCookie";
    options.ExpireTimeSpan = TimeSpan.FromDays(1);

});

//L�gg till Email configurations 

var emailConfig = builder.Configuration.GetSection("EmailConfiguration").Get<EmailConfigurations>();

builder.Services.AddSingleton(emailConfig);

builder.Services.AddScoped<IEmailService, EmailService>();


builder.Services.AddAuthorization();

builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





var app = builder.Build();

app.UseCors(x => x.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials());




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<FileAccessMiddleware>();


app.MapIdentityApi<ApplicationUser>();
app.MapControllers();



app.Run();
