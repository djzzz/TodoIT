
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
        public Todo[] FindByDoneStatus(bool doneStatus)
        {
            Todo[] DoneArray = new Todo[0];
            for(int i = 0; i < todos.Length; i++)
            {
                if(todos[i].Done == doneStatus)
                {
                    Array.Resize(ref DoneArray, DoneArray.Length + 1);
                    DoneArray[DoneArray.Length - 1] = todos[i];
                }
            }
            return DoneArray;
        }
        public Todo[] FindByAssigneeID(int personID)
        {
            Todo[] AssignArray = new Todo[0];
            for(int i = 0; i < todos.Length; i++)
            {
                if(todos[i].Assignee != null)
                {
                    if (todos[i].Assignee.PersonID == personID)
                    {
                        Array.Resize(ref AssignArray, AssignArray.Length + 1);
                        AssignArray[AssignArray.Length - 1] = todos[i];
                    }
                }
                
            }
            return AssignArray;
        }
        public Todo[] FindByAssigneePerson(Person assignee)
        {
            Todo[] AssignArray = new Todo[0];
            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].Assignee == assignee)
                {
                    Array.Resize(ref AssignArray, AssignArray.Length + 1);
                    AssignArray[AssignArray.Length - 1] = todos[i];
                }
            }
            return AssignArray;
        }
        public Todo[] FindUnassignedTodoItems()
        {
            Todo[] AssignArray = new Todo[0];
            for (int i = 0; i < todos.Length; i++)
            {
                if (todos[i].Assignee == null)
                {
                    Array.Resize(ref AssignArray, AssignArray.Length + 1);
                    AssignArray[AssignArray.Length - 1] = todos[i];
                }
            }
            return AssignArray;
        }
    }
}

