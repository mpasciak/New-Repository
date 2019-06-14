using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Window_Chrome_Demo.src.entity
{
    /// <summary>
    /// klasa result - odpowiada za przechowywanie i zapisywanie danych o wynikach z egzaminu do bazy
    /// sklada sie z wyniku czyli liczby uzyskanych punktow i liczby maxymalnych punktow do uzyskania
    /// </summary>
    class Result
    {
        private Int16 score;

        private Int16 maxScore;

        /// <summary>
        /// konstruktor klasy result odwolujacy sie do skladnikow klasy
        /// przypisujac im wartosci przekazane przez parametry wypisane ponizej
        /// </summary>
        /// <param name="score"></param>
        /// <param name="maxScore"></param>
        public Result(Int16 score, Int16 maxScore)
        {
            this.score = score;
            this.maxScore = maxScore;
        }

        /// <summary>
        /// geter - zwraca wynik
        /// </summary>
        public Int16 Score
        {
            get { return score; }
        }
        /// <summary>
        /// geter - zwraca maksymalny wynik
        /// </summary>
        public Int16 MaxScore
        {
            get { return maxScore; }
        }
    }
}
