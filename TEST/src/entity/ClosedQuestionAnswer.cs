using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Window_Chrome_Demo.src
{
    /// <summary>
    /// Klasa ClosedQuestionAnswer - odpowiada za przechowywanie odpowiedzi do pytan
    /// </summary>

   public class ClosedQuestionAnswer
    {
      
        private Int16 id;
        private String answer;
        private Boolean isCorrect;
        private Boolean isChecked;

        /// <summary>
        /// Konstruktor klasy closedquestionanswer odwolujacy sie do skladnikow klasy
        /// przypisujac im wartosc przekazana przez parametry wypisane ponizej
        /// </summary>
        /// <param name="id"> - Parametr id, przechowuje wartosc bedaca identyfikatorem odpowiedzi do pytania </param>
        /// <param name="answer"> - Prametr answer, przechowuje wartosc bedaca trescia odpowiedzi do pytania </param>
        public ClosedQuestionAnswer(Int16 id, String answer)
        {
         
            this.id = id;
            this.answer = answer;
            this.isChecked = false;
        }
        /// <summary>
        /// zwraca id odpowiedzi do pytan
        /// </summary>
        public Int16 Id
        {
            get { return id; }
        }
        /// <summary>
        /// geter - zwraca odpowiedzi
        /// </summary>
        public String Answer
        {
            get { return answer; }
        }
        /// <summary>
        /// geter/seter typu boolean czyli prawda / falsz - zwraca wynik w zaleznosci
        /// od tego czy dana odpowiedz jest zaznaczona czy nie
        /// </summary>
        public Boolean IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }

        /// <summary>
        /// geter/seter typu boolean czyli prawda / falsz - zwraca wynik w zaleznosci
        /// od tego czy dana odpowiedz jest poprawna czy nie
        /// </summary>
        public Boolean IsCorrect
        {
            get { return isCorrect; }
            set { isCorrect = value; }
        }

    }
}
