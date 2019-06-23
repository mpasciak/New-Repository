using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Custom_Window_Chrome_Demo.src;
namespace TEST.Tests
{
    [TestFixture]
    public class ClosedQuestionTests
    {
        [Test]
        public void Is_given_id_set_correctly([Random(1, 10000, 50)] Int16 example_id)
        {
            var example = new ClosedQuestion(example_id, "test", 1);

            Assert.AreEqual(example_id, example.getId());

        }

        [TestCase("Test 1")]
        [TestCase("Test 2")]
        [TestCase("Test 3")]
        [TestCase("Test 4")]
        [TestCase("Test 5")]
        [TestCase("Test 6")]
        [TestCase("Test 7")]
        public void Is_given_question_set_correctly(string example_string)
        {
            var example = new ClosedQuestion(1, example_string, 1);

            Assert.AreEqual(example_string, example.Question);

        }

        public void Are_given_points_set_correctly([Random(1, 10000, 50)]Int16 example_points)
        {
            var example = new ClosedQuestion(1, "Test", example_points);

            Assert.AreEqual(example_points, example.Points);

        }
        public void Is_ClosedQuestion_object_created_correctly()
        {
            var example = new ClosedQuestion(1, "Test", 1);

            Assert.IsNotNull(example);

        }


    }
}
