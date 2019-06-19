using System;
using System.Collections.Generic;
using System.Data;
using Custom_Window_Chrome_Demo.src.entity;

namespace Custom_Window_Chrome_Demo.src.service

 
{
    class CheckExam
    {
        /// <summary>
        /// Na poczatku pobieramy pytania z egzaminu
        /// nastepnie dla kazdego pytania pobieramy zestaw odpowiedzi
        /// kolejno sprawdzamy czy operujemy na poprawnej odpowiedzi jesli tak to przypisujemy wartosc true / false do pola isCorrect
        /// nastepnie petla zlicza maksymalna liczbe punktow do uzyskania i liczbe punktow ktora uzyskal uzytkownik 
        /// na koncu zapisuje do bazy danych wynik
        /// </summary>
        /// <param name="exam"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        public static Result Check(Exam exam, Login login)
        {
            List<ClosedQuestion> closedQuestionList = exam.ClosedQuestionList;

            for (int i = 0; i < closedQuestionList.Count; i++)
            {
                ClosedQuestion closedQuestion = closedQuestionList[i];

                DataRowCollection closedQuestionAnswerRow = Repository.findAnswerWithIsCorrectByQuestionId(closedQuestion.getId());

                for (int j = 0; j < closedQuestionAnswerRow.Count; j++)
                {
                    for (int k = 0; k < closedQuestion.ClosedQuestionAnswerList.Count; k++)
                    {
                        if (Int16.Parse(closedQuestionAnswerRow[j]["id"].ToString()) ==
                            closedQuestion.ClosedQuestionAnswerList[k].Id)
                        {
                            String t = closedQuestionAnswerRow[j]["is_correct"].ToString();
                            closedQuestion.ClosedQuestionAnswerList[k].IsCorrect = t == Boolean.TrueString ? true : false;
                        }
                            
                    }
                }
            }

            Int16 score = 0;
            Int16 maxScore = 0;

            for (int i = 0; i < closedQuestionList.Count; i++)
            {
                score += closedQuestionList[i].countPoints();
                maxScore += closedQuestionList[i].Points;
            }

            Result result = new Result(score, maxScore);

            Repository.SaveResult(exam.Id, login.Id, result.Score, result.MaxScore, DateTime.Now);

            return result;
        }
    }
}
