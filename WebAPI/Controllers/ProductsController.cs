using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;

namespace WebAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]//attribute? bir class ile ilgili bilgi verir
    public class ProductsController : ControllerBase
    {
        //Ioc Container: Inversion Of Control.WebAPI/Startup.cs içine yazılır.çünkü controller içine soyut nesne tanınır ama somut nesne tanınmaz ve tanımadığı için somut nesneleri(new productdal efproductdal) tanımlamak içim   gibi startup içinde singleton kullanırız
        IProductService _productService; //default --->private

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        
        [HttpGet("getall")]//(alias yöntemi)overload ile ayrılması olayı için getall ismini verdik.overload getbyid ismini verdik.bu olay routing yöntemi ilede çözülebilir
        public IActionResult GetAll() 
        {
            Thread.Sleep(5000);//angular tarafında post işleni yapılırken asenkron durum oludğu için burda beş sn beklet verileri öyle getir diyoruz.vs code içindeki product.component.html içindeki spinner çalışması 
            var result= _productService.GetAll();
            if (result.Success)
            {
                return  Ok(result);//ok--->status 200 return successfull 200'DE Data ver mesajda verebilirdi ben data versin istedim
            }
            else
            {
                return BadRequest(result.Message);//kullanıcı bilgilendirmesi yapar.swagger dökümantasyonua bak.400 de data
            }
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        //update ve delete için post olur aşağıdakilerde
        // [HttpPut]---->update 
        // [HttpDelete]----->sil
    }
}
