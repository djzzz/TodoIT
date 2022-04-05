using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIT.Model
{
    class Todo
    {
        private int todoID;
        private string description;
        private bool done = false;
        private Person assignee;
        public int TodoID { get { return todoID; } }
        public string Description { get { return description; }}
        public bool Done { get { return done; } set { done = value; } }
        public Person Assignee { get { return assignee; } set { assignee = value; } }

        public Todo(int todoID, string desc)
        {
            this.todoID = todoID;
            this.description = desc;
        }

    }
}
