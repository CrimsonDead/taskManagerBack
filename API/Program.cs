using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using DBL.Repositories;
using DBL.Contexts;
using Microsoft.AspNetCore.HttpOverrides;
using DBL.Models.Server;

var AllowSpecificOrigins = "allowedSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("http://crimssondead-001-site1.ftempurl.com/taskmanager")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddControllers();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(connectionString);
});

//builder.Services.AddAuthentication(o =>
//{
//    o.DefaultScheme = IdentityConstants.ApplicationScheme;
//    o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
//})
//.AddIdentityCookies(o => { });

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidIssuer = AuthOptions.ISSUER,
//            ValidateAudience = true,
//            ValidAudience = AuthOptions.AUDIENCE,
//            ValidateLifetime = true,
//            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
//            ValidateIssuerSigningKey = true,
//        };
//    });

builder.Services.AddIdentity<User, Role>(o =>
{
    o.Password.RequireDigit = true;
    o.Stores.MaxLengthForKeys = 128;
    o.SignIn.RequireConfirmedAccount = true;
})
.AddDefaultTokenProviders()
.AddEntityFrameworkStores<ApplicationContext>();

builder.Services.AddAuthorization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IEntityRepository<Job, string>, JobRepository>();
builder.Services.AddScoped<IEntityRepository<Project, string>, ProjectRepository>();
builder.Services.AddScoped<IRelationEntityRepository<UserJob, string, string>, UserJobRepository>();
builder.Services.AddScoped<IRelationEntityRepository<UserProject, string, string>, UserProjectRepository>();

var app = builder.Build();

app.UseForwardedHeaders();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.Map("/here", () => { return $"I'm here"; });
app.MapControllers();

app.UseCors(AllowSpecificOrigins);

app.UseAuthentication();
app.UseAuthorization();

app.Run();
