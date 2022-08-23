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
            ///Autofac,Ninject,CastleWindsor,StructureMap,LightInject,DryInject ---> Ioc Container yokken bu adamlar bu mimariyi bize yapardý.

            //AOP---->Bir metodun önünde sonunda veya hata verdiðinde çalýþan kod parçacýklarýdýr.örneðin [HTTPGET] [httppost] gibi operasyonlarý gerçekleþtirir.Business için business yazýlýr.AUTOFAC bize çok iyi sunar bu imkaný.Biz .net in kendi IOC Containerina biz AUTOFAC i enjekte edecez

            //// productmanager------>Iproductservice
            ///efproductdal ------>ýproductdal
            services.AddSingleton<IProductService, ProductManager>();
            //IProductService isterse ona arka planda productmanager oluþtur ona onu ver.
            //eðer sen bir baðýmlýlýk görürsen bu tipte karþýlýðý virgülden sonrasý ver.
            //singleton tüm bellekte bir tane productmanager oluþturuyor ve her gelen cliente ayný instence verir.
            //signletoni içinde data tutuyorsak kullanýlýr.signleton her yerde kullanýlýr web desktop uyglamasý vs.
            //singleton --->kýsaca biri ctorda Iproductservice isterse ona arka planda productmanager newle.
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
