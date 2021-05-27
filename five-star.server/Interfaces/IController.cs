using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace five_star.server.Interfaces
{
    public interface IController<T>
    {
        ActionResult<List<T>> GetAll();
        ActionResult<T> GetById(int id);
        Task<ActionResult<T>> Create(T data);
        Task<ActionResult<T>> Update(T data, int id);
        Task<ActionResult<string>> Delete(int id);

    }
}