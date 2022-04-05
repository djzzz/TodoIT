using System;
using System.Collections.Generic;
using System.Text;

namespace TodoIT.Data
{
    class PersonSequencer
    {
        private static int personID = 0;
        public static int nextPersonId()
        {
            personID++;
            return personID;
        }
        public static void reset()
        {
            personID = 0;
        }
    }
}
