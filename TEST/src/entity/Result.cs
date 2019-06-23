using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Window_Chrome_Demo.src.entity
{
    /// <summary>
    /// Klasa Result - Klasa w której zawieraja się metody do  przechowywania i zapisywania danych o wynikach z egzaminu do bazy
    /// </summary>
   public class Result
    {
        private Int16 score;
        private Int16 maxScore;
        /// <summary>
        /// konstruktor klasy result odwolujacy sie do skladnikow klasy
        /// przypisujac im wartosci przekazane przez parametry wypisane ponizej
        /// sklada sie z wyniku czyli liczby uzyskanych punktow i liczby maxymalnych punktow do uzyskania
        /// </summary>
        /// <param name="score"> - Parametr score, przechowuje wartosc bedaca wynikiem / iloscia zdobytych punktow przez uzytkownika</param>
        /// <param name="maxScore"> - Parametr maxScore, przechowuje wartosc bedaca maksymalna iloscia punktow do zdobycia </param>
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
