using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
[assembly: InternalsVisibleTo("TestTodoIT")]
namespace TodoIT.Model
{
    class Person
    {
        private int personID;
        private string firstName;
        private string lastName;
        public int PersonID {get { return personID; } }
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value != null && value != "")
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentException("Cant be empty or null", "firstName");
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value != null && value != "")
                {
                    lastName = value;
                }
                else
                {
                    throw new ArgumentException("Cant be empty or null", "lastName");
                }
            }
        }
        public Person(int id)
        {
            this.personID = id;

        }
    }
}
