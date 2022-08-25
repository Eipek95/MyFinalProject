using Core3.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        //void olan metod----> mesaj ve durum bildireceği için ıresult türünde oldu
        IResult Add(Product product);
        IResult Update(Product product);


        
        //Product dönderen metod---->mesaj,durum ve product dönderir.böyle yaptık çünkü bir metod yalnız bir değer dönderir biz böylelikle üc deger döndermiş olduk
        IDataResult<Product> GetById(int productId);


        //List dönderen metod---->mesaj,durum ve liste dönderir.böyle yaptık çünkü bir metod yalnız bir değer dönderir biz böylelikle üc deger döndermiş olduk
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetAllByUnitPrice(decimal min,decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        //void Add(Product product);
        //List<Product> GetABC(int categoryid); //GetAllByCategoryId
    }
}
