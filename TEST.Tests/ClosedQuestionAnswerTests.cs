using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Custom_Window_Chrome_Demo.src;
namespace TEST.Tests
{
    // [TestFixture] - wymagany atrybut do testowania klasy
    [TestFixture]
    public class ClosedQuestionAnswerTests
    {
    // [Test] - atrybut oznaczajacy ze to jest metoda testowa (test0
        [Test] 
    // Nazwa metody (mowi co testuje) Atrybut Random (od, do, ile razy ma sie wykonac)
        public void Is_given_id_set_correctly([Random(1, 10000, 50)] Int16 example_id)
        {
    // Utworzenie obiektu do testu
            var example = new ClosedQuestionAnswer(example_id, "test");
    // Klasa w ktorej sa metody z ktorej korzystamy do testowania(wartosci w nawiasie sa porownywane do siebie)
            Assert.AreEqual(example_id, example.Id);

        }
    // Wartosci ktore beda przekazywane do argumentow w kolejnym tescie
        [TestCase("Test 1")]
        [TestCase("Test 2")]
        [TestCase("Test 3")]
        [TestCase("Test 4")]
        [TestCase("Test 5")]
        [TestCase("Test 6")]
        [TestCase("Test 7")]
        public void Is_given_answer_set_correctly(string example_string)
        {
            var example = new ClosedQuestionAnswer(1, example_string);

            Assert.AreEqual(example_string, example.Answer);

        }
    // Argument true/false
        [TestCase(true)]
        [TestCase(false)]
        public void Id_answer_checked_correctly(bool test_value)
        {
            var example = new ClosedQuestionAnswer(1, "Test");

            example.IsChecked = test_value;

            Assert.AreEqual(test_value, example.IsChecked);

        }

        [TestCase(true)]
        [TestCase(false)]
        public void Id_answer_correct_set_correctly(bool test_value)
        {
            var example = new ClosedQuestionAnswer(1, "Test");

            example.IsCorrect = test_value;

            Assert.AreEqual(test_value, example.IsCorrect);

        }
        public void Is_ClosedQuestionAnswer_object_created_correctly()
        {
            var example = new ClosedQuestionAnswer(1, "Test");
     // tworzymy obiekt i sprawdzamy czy jest czy go niema
            Assert.IsNotNull(example);

        }

    }
}
