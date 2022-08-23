using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core3.Utilities.Results
{
    //IResult implement etmemizin nedeni mesajları burda da kullanmak istediğimiz için
    public interface IDataResult<T>:IResult
    {
        T Data { get;}
    }
}
