using System;
using Xunit;
using TodoIT;
using TodoIT.Model;
using TodoIT.Data;
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
        [Fact]
        public void testTodoConstuctor()
        {
            int testID = 1;
            string testDesc = "test";
            Todo todo = new Todo(testID, testDesc);

            Assert.Equal(testID, todo.TodoID);
            Assert.Equal(testDesc, todo.Description);
        }
        [Fact]
        public void testTodoDone()
        {
            int testID = 1;
            string testDesc = "test";
            Todo todo = new Todo(testID, testDesc);
            Assert.True(!todo.Done);
            todo.Done = true;
            Assert.True(todo.Done);
        }
        [Fact]
        public void testTodoAssign()
        {
            Person person = new Person(1);
            int testID = 1;
            string testDesc = "test";
            Todo todo = new Todo(testID, testDesc);
            todo.Assignee = person;
            Assert.Equal(person, todo.Assignee);
        }
        [Fact]
        public void testPersonSequencerIncrement()
        {
            int id = PersonSequencer.nextPersonId();
            Assert.Equal(1, id);
        }
        [Fact]
        public void testPersonSequencerReset()
        {
            PersonSequencer.nextPersonId();
            PersonSequencer.nextPersonId();
            PersonSequencer.reset();
            PersonSequencer.nextPersonId();
            int id = PersonSequencer.nextPersonId();
            Assert.Equal(2, id);
        }


    }
}
