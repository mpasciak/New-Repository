using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Window_Chrome_Demo.src.service
{
    class PreviousQuestion
    {

        public static ClosedQuestion PreviousClosedQuestion(List<ClosedQuestion> closedQuestionList, ClosedQuestion currentClosedQuestion)
        {
            if(closedQuestionList.Count == 0) throw new Exception();
            if (currentClosedQuestion == null) return closedQuestionList[0];
            else
            {
                int currentClosedQuestionIndex = closedQuestionList.IndexOf(currentClosedQuestion);
                int nextClosedQuestionIndex = currentClosedQuestionIndex - 1;
                if(nextClosedQuestionIndex < 0) throw new Exception();
                return closedQuestionList[nextClosedQuestionIndex];
            }
        }

    }
}
