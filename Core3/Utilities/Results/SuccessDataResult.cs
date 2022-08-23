using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core3.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }
        public SuccessDataResult(T data) : base(data, true)
        {

        }


        //sadece mesaj geçer.data vermez default halini dönderir true döner.
        ///default--->dataya karşılık gelir.mesela return tipi inttir  ama biz bişey döndermek istemiyoruz int tipinin default dönsün.sıfır döner yani.string default olursa null vs
        public SuccessDataResult(string message) : base(default, true, message)
        {

        }

        //hiçbir şey vermek istemyorum default data ve true verdim
        public SuccessDataResult() : base(default, true)
        {
        }
    }
}
