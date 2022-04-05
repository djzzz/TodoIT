using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIT.Data
{
    class TodoSequencer
    {
        private static int todoID = 0;
        public static int nextTodoId()
        {
            todoID++;
            return todoID;
        }
        public static void reset()
        {
            todoID = 0;
        }
    }
}
