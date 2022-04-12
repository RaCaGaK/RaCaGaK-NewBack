using System.Text;
using AutoMapper;
using Data.Context;
using Data.Repository;
using Data.Repository.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Domain.Models.PostReactions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Service.Services;

namespace Application
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
               
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidAudience = Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:3000")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            services.AddControllers();

            services.AddDbContext<RaCaGakContext>(opt =>
                   opt.UseSqlServer("Server=localhost\\MSSQLSERVER02;Database=RaKaGaK;TrustServerCertificate=True;User Id=sa;Password=P@ssw0rdsenac;")
            //opt.UseSqlServer(
            //    "Server=localhost\\MSSQLSERVER1;Database=RaKaGaK;TrustServerCertificate=True;User Id=sa;Password=P@ssw0rdsenac;")
            );

            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            services.AddScoped<IBaseService<User>, BaseService<User>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBaseRepository<Template>, BaseRepository<Template>>();
            services.AddScoped<IBaseService<Template>, BaseService<Template>>();

            services.AddScoped<IBaseRepository<Comment>, BaseRepository<Comment>>();
            services.AddScoped<IBaseService<Comment>, BaseService<Comment>>();

            services.AddScoped<IBaseRepository<Post>, BaseRepository<Post>>();
            services.AddScoped<IBaseService<Post>, BaseService<Post>>();

            services.AddScoped<IBaseRepository<PostReaction>, BaseRepository<PostReaction>>();
            services.AddScoped<IBaseService<PostReaction>, BaseService<PostReaction>>();

            services.AddScoped<IBaseRepository<Msg>, BaseRepository<Msg>>();
            services.AddScoped<IBaseService<Msg>, BaseService<Msg>>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<CreateUserModel, User>();
                config.CreateMap<UpdateUserModel, User>();
                config.CreateMap<User, UserModel>();

                config.CreateMap<CreateTemplateModel, Template>();
                config.CreateMap<UpdateTemplateModel, Template>();
                config.CreateMap<Template, TemplateModel>();

                config.CreateMap<CreateCommentModel, Comment>();
                config.CreateMap<UpdateCommentModel, Comment>();
                config.CreateMap<Comment, CommentModel>();

                config.CreateMap<CreatePostModel, Post>();
                config.CreateMap<UpdatePostModel, Post>();
                config.CreateMap<Post, PostModel>();

                config.CreateMap<CreatePostReactionsModel, PostReaction>();
                config.CreateMap<UpdatePostReactionsModel, PostReaction>();
                config.CreateMap<PostReaction, PostReactionsModel>();

                config.CreateMap<CreateMsgsModel, Msg>();
                config.CreateMap<UpdateMsgsModel, Msg>();
                config.CreateMap<Msg, MsgsModel>();
            }).CreateMapper());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseCors("MyPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}