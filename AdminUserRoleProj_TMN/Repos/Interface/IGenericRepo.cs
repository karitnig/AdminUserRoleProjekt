using AdminUserRoleProj_TMN.Models.ModelDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminUserRoleProj_TMN.Repos.Interface
{
    public interface IGenericRepo<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int? id);
        void Add(T t);
        void Remove(T t);
        void Update(T t);
    }
}
