﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Window_Chrome_Demo.src.service
{
    class NextQuestion
    {
    /// <summary>
    /// Metoda sluzaca do obslugi przycisku nastepny
    /// Na poczatku jest sprawdzane czy w egzaminie jest jakas pula pytan jesli niema to nastapi blad
    /// nastepnie sprawdzamy czy mamy wybrane jakiekolwiek pytanie jesli niema to wybieramy pierwszy element z listy pytan
    /// jesli jakies pytanie jest wybrane to sprawdzamy miejsce w tablicy danego pytania i wybieramy nastepne
    /// </summary>
    /// <param name="closedQuestionList"></param>
    /// <param name="currentClosedQuestion"></param>
    /// <returns></returns>
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
