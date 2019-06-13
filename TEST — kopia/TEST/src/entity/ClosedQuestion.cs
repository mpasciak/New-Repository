using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
/// Klasa dotycząca pytań zamkniętych. Odpowiadająca tabeli w bazie która zawiera owe pytania. Podobnie w kodzie jak i w bazie składowe to id, tresc pytania, oraz z ilosci punktów do uzyskania za dane pytanie. 
/// Niezbędnym składnikiem jest również lista z odpowiedzmai do zadanych pytan
/// </summary>
namespace Custom_Window_Chrome_Demo.src
{
    class ClosedQuestion
    {
        private Int16 id;
        private String question;
        private List<ClosedQuestionAnswer> closedQuestionAnswerList;
        private Int16 points;

        public ClosedQuestion(Int16 id, String question, Int16 points)
        {
            this.id = id;
            this.question = question;
            this.closedQuestionAnswerList = new List<ClosedQuestionAnswer>();
            this.points = points;
        }

        public void addAnswer(Int16 id, String answer)
        {
            if (this.closedQuestionAnswerList.Count == 4) throw new Exception();
            this.closedQuestionAnswerList.Add(new ClosedQuestionAnswer(id, answer));
        }

        public int getId()
        {
            return this.id;
        }

        public String Question
        {
            get { return question; }
        }

        public List<ClosedQuestionAnswer> ClosedQuestionAnswerList
        {
            get { return closedQuestionAnswerList; }
        }

        public Int16 Points
        {
            get { return points; }
        }

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
