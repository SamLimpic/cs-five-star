using System.Collections.Generic;

namespace five_star.server.Interfaces
{
    public interface IService<T>
    {
        List<T> GetAll();
        T GetById(int id);
        T Create(T data);
        T Update(T data, string creatorId);
        void Delete(int id, string creatorId);
    }
}