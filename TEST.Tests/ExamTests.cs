using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Custom_Window_Chrome_Demo.src.entity;


namespace TEST.Tests
{
    public class ExamTests
    {
        [Test]
        public void Is_given_id_set_correctly([Random(1, 10000, 50)] Int16 example_id)
        {
            var example = new Exam(example_id, "test", 1, 1);

            Assert.AreEqual(example_id, example.Id);

        }
        [Test]
        public void Is_given_time_set_correctly([Random(1, 10000, 50)] Int16 example_time)
        {
            var example = new Exam(1, "test", example_time, 1);

            Assert.AreEqual(example_time, example.Time);

        }

        [TestCase("Test 1")]
        [TestCase("Test 2")]
        [TestCase("Test 3")]
        [TestCase("Test 4")]
        [TestCase("Test 5")]
        [TestCase("Test 6")]
        [TestCase("Test 7")]
        public void Is_given_name_set_correctly(string example_string)
        {
            var example = new Exam(1, example_string, 1, 1);

            Assert.AreEqual(example_string, example.Name);

        }

        public void Is_given_closedQuantity_set_correctly([Random(1, 10000, 50)]Int16 example_int)
        {
            var example = new Exam(1, "test", 1, example_int);

            Assert.AreEqual(example_int, example.ClosedQuestion);

        }
        public void Is_ClosedQuestion_object_created_correctly()
        {
            var example = new Exam(1, "test", 1, 1);

            Assert.IsNotNull(example);

        }
    }
}
