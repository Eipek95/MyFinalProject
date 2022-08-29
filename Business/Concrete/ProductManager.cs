using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core3.Aspects.Autofac.Caching;
using Core3.Aspects.Autofac.Transaction;
using Core3.Aspects.Autofac.Validation;
using Core3.Business;
using Core3.CrossCuttingConcerns.Validation;
using Core3.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;//sistem içinde sistem kullanılabilir.başka dal kullanılamaz sadece servise.yani bu class içinde category tablosuna ulaşmak istersek service kullanırız
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        [SecuredOperation("product.add,admin")]//yetkilendirme kontrolü yapar--->ya product.add claimi yada admin claimi olması gerekir
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]//add olunca bellekteki IProductService.Get cachelerini sil
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(CheckICategoryProductCountOfCategoryCorrect(product.CategoryId), CheckIfProductNameExists(product), CheckICategoryLimitExceded());
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

        }
        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            //MaintenanceTime: bakım zamanı.1 den 2ye kadar sürer
            if (DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            //dataresult çalışıyorum dönderdiğim tip list-dönderdiğim data-dönderdiğim state-dönderdiğim mesaj
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.CategoryId == id));
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(x => x.UnitPrice >= min && x.UnitPrice <= max));
        }
        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(x => x.ProductId == productId));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {

            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]//update olunca IProductService.Get'in cacheteki tüm değerlerini sil.eğer sadece get yazsaydık bütün get methoduna sahip olan cacheleri silerdi.Category get,customer get vs..
        public IResult Update(Product product)
        {
            if (CheckICategoryProductCountOfCategoryCorrect(product.CategoryId).Success && CheckIfProductNameExists(product).Success)
            {
                _productDal.Update(product);
                return new Result(true, "Ürün Güncellendi");
            }
            return new ErrorResult(Messages.ProductNameInvalid);

        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            Add(product);//ürünü ekler
            if (product.UnitPrice<10)//şartı kontrol eder
            {
                throw new Exception("");
            }
            Add(product);//eğer şart sağlanmamışsa veya işlem kesintiye uğrayıp gerçekleşmemişse olayları geri alır
            return new SuccessResult(Messages.ProductAdded);
        }
        //public void Add(Product product)
        //{
        //    _productDal.Add(product);
        //}
        //public List<Product> GetABC(int categoryid)//Kategori idye göre ürürn getirme
        //{
        //    return _productDal.GetAllByCategory(categoryid);
        //}

        private IResult CheckICategoryProductCountOfCategoryCorrect(int categoryId)
        {
            //select count(*) from products where categoryId=1
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(Product product)
        {
            var result = _productDal.GetAll(x => x.ProductName == product.ProductName).Any();//isim var mı
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);

            }
            return new SuccessResult();
        }


        private IResult CheckICategoryLimitExceded()
        {

            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();

        }


    }
}
