using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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

            services.AddControllers();
            ///Autofac,Ninject,CastleWindsor,StructureMap,LightInject,DryInject ---> Ioc Container yokken bu adamlar bu mimariyi bize yapard�.

            //AOP---->Bir metodun �n�nde sonunda veya hata verdi�inde �al��an kod par�ac�klar�d�r.�rne�in [HTTPGET] [httppost] gibi operasyonlar� ger�ekle�tirir.Business i�in business yaz�l�r.AUTOFAC bize �ok iyi sunar bu imkan�.Biz .net in kendi IOC Containerina biz AUTOFAC i enjekte edecez

            //// productmanager------>Iproductservice
            ///efproductdal ------>�productdal
            services.AddSingleton<IProductService, ProductManager>();
            //IProductService isterse ona arka planda productmanager olu�tur ona onu ver.
            //e�er sen bir ba��ml�l�k g�r�rsen bu tipte kar��l��� virg�lden sonras� ver.
            //singleton t�m bellekte bir tane productmanager olu�turuyor ve her gelen cliente ayn� instence verir.
            //signletoni i�inde data tutuyorsak kullan�l�r.signleton her yerde kullan�l�r web desktop uyglamas� vs.
            //singleton --->k�saca biri ctorda Iproductservice isterse ona arka planda productmanager newle.
            services.AddSingleton<IProductDal,EfProductDal>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
