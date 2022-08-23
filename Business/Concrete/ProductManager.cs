using Business.Abstract;
using Business.Constants;
using Core3.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new Result(true,"Ürün Eklendi");
        }

        public IDataResult<List<Product>> GetAll()
        {
            //MaintenanceTime: bakım zamanı.21 den 22ye kadar sürer
            if (DateTime.Now.Hour==21)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            //dataresult çalışıyorum dönderdiğim tip list-dönderdiğim data-dönderdiğim state-dönderdiğim mesaj
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x=>x.CategoryId==id));
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.UnitPrice >= min && x.UnitPrice <= max));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x=>x.ProductId==productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {

            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        //public void Add(Product product)
        //{
        //    _productDal.Add(product);
        //}
        //public List<Product> GetABC(int categoryid)//Kategori idye göre ürürn getirme
        //{
        //    return _productDal.GetAllByCategory(categoryid);
        //}

    }
}
