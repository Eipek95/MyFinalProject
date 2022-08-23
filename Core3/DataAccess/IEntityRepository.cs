using Core3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core3.DataAccess
{
    //generic constraint generic kısıtlama
    //class:referans tip olabilir anlamına gelir
    //T ya IEntity olabilir yada IEntity'den implemente olan nesne olabilir
    //new : newlenebilir olmalı.yani IEntity olamaz IEntityden implemente olan olabilir
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {
        //filtre vermek zorunlu değil null demek null olursa bütün verileri getir demek
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
