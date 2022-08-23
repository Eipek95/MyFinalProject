using Core3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    //IEntity den implement edilemez çünkü tekbaşına bir veritabanı tablosu değil ---ProductDetailDto
    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short  UnitsInStock { get; set; }
    }
}
