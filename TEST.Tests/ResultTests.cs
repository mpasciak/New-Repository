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
    class ResultTests
    {
        [Test]
        public void Is_given_score_set_correctly([Random(1, 10000, 50)] Int16 example_score)
        {
            var example = new Result(example_score, 1);

            Assert.AreEqual(example_score, example.Score);

        }
        [Test]
        public void Is_given_maxScore_set_correctly([Random(1, 10000, 50)] Int16 example_maxScore)
        {
            var example = new Result(1, example_maxScore);

            Assert.AreEqual(example_maxScore, example.MaxScore);

        }
        [Test]
        public void Is_result_object_created_correctly()
        {
            var example = new Result(1, 1);

            Assert.IsNotNull(example);

        }
    }
}
