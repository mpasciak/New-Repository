using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Custom_Window_Chrome_Demo.src.entity;

namespace TEST.Tests
{
    [TestFixture]
    class LoginTests
    {
        [Test]
        public void Is_given_id_set_correctly([Random(1, 10000, 50)] Int16 example_id)
        {
            var example = new Login(example_id, "test", "test", "1");

            Assert.AreEqual(example_id, example.Id);

        }
        [TestCase("Test 1")]
        [TestCase("Test 2")]
        [TestCase("Test 3")]
        [TestCase("Test 4")]
        [TestCase("Test 5")]
        [TestCase("Test 6")]
        [TestCase("Test 7")]
        public void Is_given_firstName_set_correctly(String firstName)
        {
            var example = new Login(1, firstName, "test", "1");
            Assert.AreEqual(firstName, example.FirstName);

        }

        [TestCase("Test 1")]
        [TestCase("Test 2")]
        [TestCase("Test 3")]
        [TestCase("Test 4")]
        [TestCase("Test 5")]
        [TestCase("Test 6")]
        [TestCase("Test 7")]
        public void Is_given_lastName_set_correctly(String lastName)
        {
            var example = new Login(1, "test", lastName, "1");

            Assert.AreEqual(lastName, example.LastName);

        }

    
        public void Is_login_object_created_correctly()
        {
            var example = new Login(1, "test", "test", "1");

            Assert.IsNotNull(example);

        }
    }
}
