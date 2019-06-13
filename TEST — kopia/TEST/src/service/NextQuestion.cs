using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Window_Chrome_Demo.src.service
{
    class NextQuestion
    {

        public static ClosedQuestion NextClosedQuestion(List<ClosedQuestion> closedQuestionList, ClosedQuestion currentClosedQuestion)
        {
            if(closedQuestionList.Count == 0) throw new Exception();
            if (currentClosedQuestion == null) return closedQuestionList[0];
            else
            {
                int currentClosedQuestionIndex = closedQuestionList.IndexOf(currentClosedQuestion);
                int nextClosedQuestionIndex = currentClosedQuestionIndex + 1;
                if(closedQuestionList.Count - 1 < nextClosedQuestionIndex) throw new Exception();
                return closedQuestionList[nextClosedQuestionIndex];
            }
        }

    }
}
