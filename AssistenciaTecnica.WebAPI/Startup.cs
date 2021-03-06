﻿using System.Text;
using AssistenciaTecnica.Domain.Identity;
using AssistenciaTecnica.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace AssistenciaTecnica.WebAPI
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
            services.AddDbContext<AssistenciaTecnicaContext>(x => x.UseSqlServer(Configuration.GetConnectionString("SQLConnection")));

            // IdentityBuilder builder = services.AddIdentityCore<User>(options => 
            // {
            //     options.Password.RequireDigit = false;
            //     options.Password.RequireNonAlphanumeric = false;
            //     options.Password.RequireLowercase = false;
            //     options.Password.RequireUppercase = false;
            //     options.Password.RequiredLength = 4;
            // });

            // builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            // builder.AddEntityFrameworkStores<AssistenciaTecnicaContext>();
            // builder.AddRoleValidator<RoleValidator<Role>>();
            // builder.AddRoleManager<RoleManager<Role>>();
            // builder.AddSignInManager<SignInManager<User>>(); 

            // // Configuração JWT
            // services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            // .AddJwtBearer(options => 
            //     {
            //         options.TokenValidationParameters = new TokenValidationParameters
            //         {
            //             ValidateIssuerSigningKey = true,
            //             IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
            //                 .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
            //             ValidateIssuer = false,
            //             ValidateAudience = false
            //         };

            // });

            services.AddAutoMapper();

            services.AddMvc(options => {
                    var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();

                    // options.Filters.Add(new AuthorizeFilter(policy)); // Toda vez que alguém chamar uma rota, será requerido que o usuário esteja autenticado
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;  // https://pt.stackoverflow.com/questions/364558/web-api-n%C3%A3o-retorna-dados-relacionados
                });;

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseCors( x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
