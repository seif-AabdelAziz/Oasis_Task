
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using ToDo.BL;
using ToDo.DAL;

namespace ToDo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Defaults
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion


            #region DataBase

            builder.Services.AddDbContext<ToDoContext>(
                option => option.UseSqlServer(builder.Configuration.GetConnectionString("OasisDB")));
            #endregion

            #region Repos Injection

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IToDoRepo, ToDoRepo>();

            #endregion

            #region Managers Injection

            builder.Services.AddScoped<IToDoManager, ToDoManager>();
            builder.Services.AddScoped<ISecurityManager, SecurityManager>();

            #endregion

            #region Identity

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;

                options.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<ToDoContext>();

            #endregion

            #region Authentication

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "Def";
                options.DefaultChallengeScheme = "Def";
            }).AddJwtBearer("Def", options =>
            {
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("SecretKey")));
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    IssuerSigningKey = key
                };
            });
            #endregion

            #region Authorization

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("ForAdmin", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "Admin");
                });

            });

            #endregion


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}