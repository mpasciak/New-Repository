using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Custom_Window_Chrome_Demo.src


{
    /// <summary>
    /// Klasa odpowaidajaca za przechowywanie pytan. Sklada sie z identyfikatora
    /// tresci pytania oraz listy odpowiedzi do tych pytan i punktow mozliwych do uzyskania
    /// za dane pytanie
    /// </summary>
    class ClosedQuestion
    {
        private Int16 id;
        private String question;
        private List<ClosedQuestionAnswer> closedQuestionAnswerList;
        private Int16 points;

    /// <summary>
    /// Konstruktor klasy ClosedQuestion odwolujacy sie do skladnikow klasy
    /// przypisujac im wartosc przekazana przez parametry wypisane ponizej. Tworzy nowa liste 
    /// odpowiedzialna za liste odpowiedzi do naszych pytan
    /// </summary>
    /// <param name="id"></param>
    /// <param name="question"></param>
    /// <param name="points"></param>
        public ClosedQuestion(Int16 id, String question, Int16 points)
        {
            this.id = id;
            this.question = question;
            this.closedQuestionAnswerList = new List<ClosedQuestionAnswer>();
            this.points = points;
        }
        /// <summary>
        /// metoda dodajaca odpowiedz do danego pytania, jezeli maksymalna ilosc odpowiedzi
        /// zostanie przekroczona (4) to wystapi blad
        /// </summary>
        /// <param name="id"></param>
        /// <param name="answer"></param>
        public void addAnswer(Int16 id, String answer)
        {
            if (this.closedQuestionAnswerList.Count == 4) throw new Exception();
            this.closedQuestionAnswerList.Add(new ClosedQuestionAnswer(id, answer));
        }
        /// <summary>
        /// geter - zwraca id pytania
        /// </summary>
        /// <returns></returns>
        public int getId()
        {
            return this.id;
        }
        /// <summary>
        /// zwraca tresc pytania
        /// </summary>
        public String Question
        {
            get { return question; }
        }

        /// <summary>
        /// Zwraca liste odpowiedzi do pytan
        /// </summary>
        public List<ClosedQuestionAnswer> ClosedQuestionAnswerList
        {
            get { return closedQuestionAnswerList; }
        }

        /// <summary>
        /// zwraca ilosc punktow do uzyskania za dane pytanie
        /// </summary>
        
        public Int16 Points
        {
            get { return points; }
        }

        /// <summary>
        /// metoda zwraca liczbe punktow za pytanie jesli ktorakolwiek z odpowiedzi nie zostanie zaznaczona 
        /// to metoda zwraca 0 czyli punkty nie zostana przyznane
        /// </summary>
        /// <returns></returns>
        public Int16 countPoints()
        {
            for (int i = 0; i < closedQuestionAnswerList.Count; i++)
            {
                if (closedQuestionAnswerList[i].IsChecked != closedQuestionAnswerList[i].IsCorrect) return 0;
            }

            return points;
        }
    }
}
