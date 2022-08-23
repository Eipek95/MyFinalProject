using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core3.Utilities.Results
{
    public class Result : IResult
    {

        //this içinde çalıştığı classı gösterir.ctor a iki paramtre gönderirsek otomatik olarak aşagıdaki ctor yani tek parametreli overloadingi de çalışır
        public Result(bool success, string message):this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        //readonly ler ctor içinde set edilebilir.readonly amacı standardize etmektir kodu
        public bool Success { get; }

        public string Message { get; }
    }
}
