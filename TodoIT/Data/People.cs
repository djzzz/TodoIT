using System;
using System.Collections.Generic;
using System.Text;
using TodoIT.Model;
namespace TodoIT.Data
{
    class People
    {
        private static Person[] person = new Person[0];
        public int Size()
        {
            return person.Length;
        }
        public Person[] FindAll()
        {
            return person;
        }
        public Person FindByID(int personId)
        {
            for (int i = 0; i < person.Length; i++)
            {
                if (person[i].PersonID == personId)
                {
                    return person[i];
                }
            }
            return null;
        }
        public Person AddPerson()
        {
            Person per = new Person(PersonSequencer.nextPersonId());
            Array.Resize(ref person, person.Length + 1);
            person[person.Length - 1] = per;
            return per;
        }
        public void Clear()
        {
            for (int i = 0; i < person.Length; i++)
            {
                person[i] = null;
            }
            Array.Resize(ref person, 0);
            PersonSequencer.reset();
        }
    }
}