using BitbargBackendTest.Data;
using BitbargBackendTest.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BitbargBackendTest.Services
{
    public class ToDoService : IToDoService
    {
        private readonly ApplicationDbContext _context;

        public ToDoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(ToDo toDo)
        {
            if (toDo == null)
                throw new ArgumentNullException(nameof(toDo));

            _context.ToDos.Remove(toDo);
            _context.SaveChanges();
        }

        public IList<ToDo> GetAll()
        {
            return _context.ToDos.ToList();
        }

        public ToDo GetById(int toDoId)
        {
            if (toDoId == 0)
                return null;

            return _context.ToDos.FirstOrDefault(c => c.Id == toDoId);
        }

        public IList<ToDo> GetEarlierToDos()
        {
            var from = DateTime.Now.AddMinutes(29);
            var to = DateTime.Now.AddMinutes(31);
            return _context.ToDos.Where(c => c.TimeToDo > from && c.TimeToDo < to).ToList();
        }

        public IList<ToDo> GetToDosByUserId(int userId)
        {
            if (userId == 0)
                return new List<ToDo>();

            return _context.ToDos.Where(c => c.UserId == userId).ToList();
        }

        public void Insert(ToDo toDo)
        {
            if (toDo == null)
                throw new ArgumentNullException(nameof(toDo));

            _context.ToDos.Add(toDo);
            _context.SaveChanges();
        }

        public void Update(ToDo toDo)
        {
            if (toDo == null)
                throw new ArgumentNullException(nameof(toDo));

            _context.ToDos.Update(toDo);
            _context.SaveChanges();
        }
    }
}
