using System;
using Xunit;
using TodoIT;
using TodoIT.Model;

namespace TestTodoIT
{
    public class UnitTest1
    {
        [Fact]
        public void testFirstnameSet()
        {
            
            Person person = new Person(1);

            person.FirstName = "carl";

            Assert.Equal("carl", person.FirstName);
        }
        [Fact]
        public void testLastnameSet()
        {

            Person person = new Person(1);

            person.LastName = "olofsson";

            Assert.Equal("olofsson", person.LastName);
        }
        [Fact]
        public void testID()
        {

            Person person = new Person(1);

            Assert.Equal(1, person.PersonID);
        }
        [Fact]
        public void testEmptyStringFirstname()
        {

            Person person = new Person(1);
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                return person.FirstName = "";
            });
            Assert.Equal("Cant be empty or null (Parameter 'firstName')", ex.Message);
        }
        [Fact]
        public void testEmptyStringLastname()
        {

            Person person = new Person(1);
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                return person.LastName = "";
            });
            Assert.Equal("Cant be empty or null (Parameter 'lastName')", ex.Message);
        }
        [Fact]
        public void testEmptyNullFirstname()
        {

            Person person = new Person(1);
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                return person.FirstName = null;
            });
            Assert.Equal("Cant be empty or null (Parameter 'firstName')", ex.Message);
        }
        [Fact]
        public void testEmptyNullLastname()
        {

            Person person = new Person(1);
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                return person.LastName = null;
            });
            Assert.Equal("Cant be empty or null (Parameter 'lastName')", ex.Message);
        }
    }
}
