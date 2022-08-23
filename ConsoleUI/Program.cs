using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMermory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    //SOLID
    //OPEN CLOSED PRINCIPLE:Yaptığın yazılıma yeni bir özellik ekliyorsan mevcuttaki hiç bir koduna dokunamazsın
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
            //ProductDetailsDtoTest();
            ProductTest2();
        }

        private static void ProductTest2()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();

            if (result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ProductDetailsDtoTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var product in productManager.GetProductDetails().Data)
            {
                Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            }


            foreach (var c in productManager.GetAll().Data)
            {

            }
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            foreach (var item in productManager.GetAllByUnitPrice(50, 100).Data)
            {
                Console.WriteLine(item.ProductName);
            }



            //Console.WriteLine("2 Nolu Kategoriye ait ürünleri getir");
            //if (productManager.GetABC(0).Count>0)
            //{
            //    foreach (var catPro in productManager.GetABC(0))
            //    {
            //        Console.WriteLine(catPro.ProductName);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Kategori bulunamadı");

            //}
        }
    }
}
