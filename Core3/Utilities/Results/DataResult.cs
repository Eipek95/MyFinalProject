using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core3.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        //base---->implement edilen classın içindeki methodu çalıştırır
        //base yerine this--->implement edilen classın kendi içindeki kendi metodunu çalıştırr
        public DataResult(T data,bool success,string message):base(success,message)
        {
            Data = data;
        }
        public DataResult(T data,bool success):base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
