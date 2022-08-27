using Core3.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core3.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        //sisteme giriirken çalışacak kısım
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
    }
}
