using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Window_Chrome_Demo.src
{
    /// <summary>
    /// klasa closedquestionaswer - odpowiada za przechowywanie odpowiedzi do pytan
    /// Sklada sie z identyfikatora, tresci odpowiedzi oraz 2 parametrow
    /// sprawdzajacych poprawnosc odpowiedzi oracz czy zostaly one zaznaczone w programie
    /// </summary>
    class ClosedQuestionAnswer
    {
      
        private Int16 id;
        private String answer;
        private Boolean isCorrect;
        private Boolean isChecked;

        /// <summary>
        /// Konstruktor klasy closedquestionanswer odwolujacy sie do skladnikow klasy
        /// przypisujac im wartosc przekazana przez parametry wypisane ponizej
        /// this.isChecked = false; poniewaz na samym poczatku wszystkie odpwoedzi nie sa zaznaczone
        /// </summary>
        /// <param name="id"></param>
        /// <param name="answer"></param>
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
