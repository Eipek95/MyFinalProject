using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {    // autofac configure ayarları webapi prgram.cs içinde
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();//biri senden  ıproduct isterse sen ona productmanager newleyip ver.add.singleton işini yapar.SingleInstance tek bir instance oluşturur herkes kullanır
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
        }
    }
}
