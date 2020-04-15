using roleDemo.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace roleDemo.Repositories
{
    public class TodoRepo
    {
        ApplicationDbContext _context;

        public TodoRepo(ApplicationDbContext context)
        {
            this._context = context;
        }
        public List<Todo> GetAllTodos(string userName)
        {
            var todos = _context.Todos;
            List<Todo> todoList = new List<Todo>();

            foreach (var item in todos)
            {
                if (item.UserName == userName) { 
                todoList.Add(new Todo() { ID = item.ID, UserName = item.UserName, Description = item.Description, IsComplete = item.IsComplete });
                }
            }
            return todoList;
        }

        public Todo GetTodo(int ID, string userName)
        {
            var todo = _context.Todos.Where(t => t.ID == ID && t.UserName== userName).FirstOrDefault();
            if (todo != null)
            {
                return new Todo() { ID = todo.ID, UserName = todo.UserName, Description = todo.Description, IsComplete = todo.IsComplete };
            }
            return null;
        }

        public bool CreateTodo(string userName, string description, string isComplete)
        {
            //var todo = GetTodo(ID,userName);
            //if (todo != null)
            //{
            //    return false;
            //}
            _context.Todos.Add(new Todo
            {
                //ID = ID,
                UserName = userName,
                Description = description,
                IsComplete = isComplete
            });
            _context.SaveChanges();
            return true;
        }

        public bool Update(int ID, string userName, string description, string isComplete)
        {
            Todo todo = _context.Todos
                .FirstOrDefault(t => t.ID == ID);
            // Remember you can't update the primary key without 
            // causing trouble.  Just update the first and last names
            // for now.
            todo.UserName = userName;
            todo.Description = description;
            todo.IsComplete = isComplete;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int ID, string userName)
        {
            Todo todo = GetTodo(ID, userName);
            if (todo != null) { 
            _context.Todos.Remove(todo);
            _context.SaveChangesAsync();
            return true;
            }
            else
            {
                return false;
            }
        }
    }
}
