using BitbargBackendTest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitbargBackendTest.Services
{
    public interface IToDoService
    {
        IList<ToDo> GetToDosByUserId(int userId);

        ToDo GetById(int toDoId);

        void Insert(ToDo toDo);

        void Update(ToDo toDo);

        void Delete(ToDo toDo);

        IList<ToDo> GetAll();

        IList<ToDo> GetEarlierToDos();
    }
}
