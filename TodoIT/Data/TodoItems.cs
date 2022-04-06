
using System;
using System.Collections.Generic;
using System.Text;
using TodoIT.Model;
namespace TodoIT.Data
{
    class TodoItems
    {
        private static Todo[] todos = new Todo[0];
        public int Size()
        {
            return todos.Length;
        }
        public Todo[] FindAll()
        {
            return todos;
        }
        public Todo FindByID(int todoID)
        {
            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].TodoID == todoID)
                {
                    return todos[i];
                }
            }
            return null;
        }
        public Todo AddTodo(string desc)
        {
            Todo todo = new Todo(TodoSequencer.nextTodoId(), desc);
            Array.Resize(ref todos, todos.Length + 1);
            todos[todos.Length - 1] = todo;
            return todo;
        }
        public void Clear()
        {
            for (int i = 0; i < todos.Length; i++)
            {
                todos[i] = null;
            }
            Array.Resize(ref todos, 0);
            TodoSequencer.reset();
        }
    }
}

