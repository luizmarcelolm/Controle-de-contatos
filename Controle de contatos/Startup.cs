using Controle_de_contatos.Data;
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
            services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
