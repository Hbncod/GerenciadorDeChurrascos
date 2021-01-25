using System;
using System.IO;
using System.Reflection;
using GerenciadorDeChurrascos.Api.Contexts;
using GerenciadorDeChurrascos.Api.Interfaces;
using GerenciadorDeChurrascos.Api.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace GerenciadorDeChurrascos.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // requires using Microsoft.Extensions.Options
            services.Configure<ChurrascostoreDatabaseSettings>(
                Configuration.GetSection(nameof(ChurrascostoreDatabaseSettings)));

            services.AddSingleton<IChurrascostoreDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ChurrascostoreDatabaseSettings>>().Value);
            services.AddSingleton<IChurrascoRepository, ChurrascoRepository>();
            services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
            services.AddControllers();
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })

                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //Quem está solicitando 
                        ValidateIssuer = true,

                        //Quem está validando
                        ValidateAudience = true,

                        //Tempo de expiração 
                        ValidateLifetime = true,

                        //Forma de criptografia 
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Churrasco-chave-autenticacao")),

                        //Tempo de expiração do token 
                        ClockSkew = TimeSpan.FromMinutes(30),

                        //Nome da Issuer, de onde está vindo 
                        ValidIssuer = "ChurrascoApi",

                        //Nome da audience, de onde está vindo 
                        ValidAudience = "ChurrascoApi"
                    };

                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChurrascoApi", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChurrascoApi");
                c.RoutePrefix = string.Empty;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
