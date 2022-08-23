using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core3.Utilities.Results
{
    //temel voidler için başlangıç
    public interface IResult
    {
        bool Success { get; }//sadece-okunabilir.
        string Message { get; }//sonucu kullanıcıya bildirecek mesaj ?başarılı:başarısız
    }
}
