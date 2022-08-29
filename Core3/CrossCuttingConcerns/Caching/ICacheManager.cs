using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core3.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key,object value,int duration);
        bool isAdd(string key);//cache de var mı?yoksa  db getir varsa cacheten getir
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
