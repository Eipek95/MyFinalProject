using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core3.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message):base(true,message)//base in iki paramtreli olanını çalıştır.message ver.default true gönderir ama message da verir
        {

        }
        public SuccessResult():base(true)//base in tek paramtreli olanını çalıştır.Message yok.true gönderir default olarak
        {

        }
    }
}
