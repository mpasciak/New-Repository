using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Custom_Window_Chrome_Demo.src


{
    /// <summary>
    /// Klasa ClosedQuestionAnswer - klasa odpowiadajaca za przechowywanie pytan
    /// </summary>
    public class ClosedQuestion
    {
        private Int16 id;
        private String question;
        private List<ClosedQuestionAnswer> closedQuestionAnswerList;
        private Int16 points;

        /// <summary>
        /// Konstruktor klasy ClosedQuestion odwolujacy sie do skladnikow klasy
        /// przypisujac im wartosc przekazana przez parametry wypisane ponizej. 
        /// Tworzy rowniez nowa liste odpowiedzialna za liste odpowiedzi do naszych pytan.
        /// </summary>
        /// <param name="id"> - Parametr id, przechowuje wartosc bedaca identyfikatorem pytania </param>
        /// <param name="question"> - Parametr question, przechowuje wartosc bedaca trescia pytania</param>
        /// <param name="points"> - Parametr points, przechowuje wartosc bedaca liczba punktow do uzyskania za dane pytanie</param>

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
        /// <param name="id"> - arametr id, przechowuje wartosc bedaca identyfikatorem odpowiedzi do pytania </param>
        /// <param name="answer"> - Prametr answer, przechowuje wartosc bedaca trescia odpowiedzi do pytania </param>
        public void addAnswer(Int16 id, String answer)
        {
            if (this.closedQuestionAnswerList.Count == 4) throw new Exception();
            this.closedQuestionAnswerList.Add(new ClosedQuestionAnswer(id, answer));
        }
        /// <summary>
        /// geter
        /// </summary>
        /// <returns>
        /// zwraca id pytania
        /// </returns>
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
        /// Metoda zlicza liczbe punktow za pytanie
        /// </summary>
        /// <returns>
        /// Jesli ktorakolwiek z odpowiedzi nie zostanie zaznaczona 
        /// to metoda zwraca 0 czyli punkty nie zostana przyznane, 
        /// metoda rowniez zwraca 0 wtedy gdy uzytkownik zaznaczy zla odpowiedz
        /// albo zla odpowiedz i dobra
        /// </returns>
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
