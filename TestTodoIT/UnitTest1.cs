using System;
using TodoIT.Data;
using TodoIT.Model;
using Xunit;
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
            PersonSequencer.reset();
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
        [Fact]
        public void testTodoSequencerIncrement()
        {
            TodoSequencer.reset();
            int id = TodoSequencer.nextTodoId();
            Assert.Equal(1, id);
        }
        [Fact]
        public void testTodoSequencerReset()
        {

            TodoSequencer.nextTodoId();
            TodoSequencer.nextTodoId();
            TodoSequencer.reset();
            TodoSequencer.nextTodoId();
            int id = TodoSequencer.nextTodoId();
            Assert.Equal(2, id);

        }
        [Fact]
        public void testPeopleClear()
        {
            People people = new People();
            people.Clear();
            Person person = people.AddPerson();

            Assert.Equal(1, person.PersonID);
        }
        [Fact]
        public void testPeopleGetALL()
        {
            People people = new People();
            people.Clear();
            Person[] persons = people.FindAll();
            Assert.Empty(persons);
        }
        [Fact]
        public void testPeopleFindByID()
        {

            People people = new People();
            people.Clear();
            Person person = people.AddPerson();
            person.FirstName = "Carl";
            person.LastName = "gustavsson";
            Person Found = people.FindByID(1);

            Assert.Equal("Carl", Found.FirstName);
        }
        [Fact]
        public void testTodoClear()
        {
            TodoItems todos = new TodoItems();
            Todo todo1 = todos.AddTodo("Todo my thng");
            todos.Clear();
            Todo todo2 = todos.AddTodo("Todo my thng");

            Assert.Equal(1, todos.Size());
        }
        [Fact]
        public void testTodoGetALL()
        {
            TodoItems todos = new TodoItems();
            todos.Clear();
            Todo todo = todos.AddTodo("my thingy");
            Assert.Equal(1, todo.TodoID);
            Todo[] todoItems = todos.FindAll();
            Assert.Single(todoItems);
        }
        [Fact]
        public void testTodoFindByID()
        {
            TodoItems todos = new TodoItems();
            todos.Clear();
            Todo todo = todos.AddTodo("Something");
            todo.Done = true;
            Todo Found = todos.FindByID(1);

            Assert.True(Found.Done);
        }
        [Fact]
        public void testTodoFindByDoneStatus()
        {

            TodoItems todos = new TodoItems();
            todos.Clear();
            Todo todo = todos.AddTodo("Im done");
            todo.Done = true;
            Todo[] Found = todos.FindByDoneStatus(true);

            Assert.Equal("Im done", Found[0].Description);
        }
        [Fact]
        public void testTodoFindByAssigneeID()
        {

            TodoItems todos = new TodoItems();
            todos.Clear();
            Todo todo = todos.AddTodo("Im with a person");
            Person person = new Person(PersonSequencer.nextPersonId());
            person.FirstName = "gustav";
            todo.Assignee = person;
            Todo[] Found = todos.FindByAssigneeID(todo.Assignee.PersonID);

            Assert.Equal(person.PersonID, Found[0].Assignee.PersonID);
        }
        [Fact]
        public void testTodoFindByAssignePerson()
        {

            TodoItems todos = new TodoItems();
            todos.Clear();
            People people = new People();
            people.Clear();
            Todo todo = todos.AddTodo("Im with a person called gustav");
            Person person = people.AddPerson();
            person.FirstName = "gustav";
            todo.Assignee = person;
            Todo[] Found = todos.FindByAssigneePerson(person);

            Assert.Equal("Im with a person called gustav", Found[0].Description);
        }
        [Fact]
        public void testTodoFindByUnassigned()
        {

            TodoItems todos = new TodoItems();
            todos.Clear();
            todos.AddTodo("Im alone");
            Todo[] Found = todos.FindUnassignedTodoItems();

            Assert.Equal(("Im alone"), Found[0].Description);
        }
        [Fact]
        public void testPeopleRemove()
        {
            People people = new People();
            people.Clear();
            Person person1 = people.AddPerson();
            person1.FirstName = "carl";
            Person person2 = people.AddPerson();
            person2.FirstName = "gustav";
            Person[] removed = people.RemovePerson(person1.PersonID);
            Assert.Equal("gustav", removed[0].FirstName);
        }
        [Fact]
        public void testTodoRemove()
        {
            TodoItems todos = new TodoItems();
            todos.Clear();
            Todo todo1 = todos.AddTodo("Im first");
            Todo todo2 = todos.AddTodo("Im secound");
            Todo[] removed = todos.RemoveTodo(todo1.TodoID);
            Assert.Equal("Im secound", removed[0].Description);
        }
    }
}
