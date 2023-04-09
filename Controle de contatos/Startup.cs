using Controle_de_contatos.Data;
using Controle_de_contatos.Helper;
using Controle_de_contatos.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace Controle_de_contatos
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigurationServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DataBase")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();  
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
            services.AddScoped<ISessao, Sessao>();

            services.AddSession(o  =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });
        }

        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");
        }
    }
}
