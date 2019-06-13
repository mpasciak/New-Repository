using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Custom_Window_Chrome_Demo.src.entity;

namespace Custom_Window_Chrome_Demo.src.service
{
    class DownloadExamService
    {
        public Exam Download(String id, Int16 loginId)
        {
            DataRow examRow = Repository.findExamByIdAndLoginId(id, loginId);

            if (examRow == null) return null;

            Exam exam = new Exam(Int16.Parse(id), examRow["name"].ToString(), Int16.Parse(examRow["time"].ToString()), Int16.Parse(examRow["closed_quantity"].ToString()));

            List<ClosedQuestion> closedQuestionList = new List<ClosedQuestion>();
            
            DataRowCollection questionCollection = Repository.findQuestionByExamId(exam.Id, exam.ClosedQuestion);

            for(int i = 0; i < questionCollection.Count; i++)
            {
                DataRow questionRow = questionCollection[i];

                ClosedQuestion closedQuestion = new ClosedQuestion(Int16.Parse(questionRow["id"].ToString()), questionRow["question"].ToString(), Int16.Parse(questionRow["points"].ToString()));

                DataRowCollection questionAnswerCollection = Repository.findAnswerByQuestionId(closedQuestion.getId());

                for(int j = 0; j < questionAnswerCollection.Count; j++)
                {
                    DataRow answerRow = questionAnswerCollection[j];

                    closedQuestion.addAnswer(Int16.Parse(answerRow["id"].ToString()), answerRow["answer"].ToString());
                }

                closedQuestionList.Add(closedQuestion);
            }

            exam.ClosedQuestionList = closedQuestionList;

            return exam;
        }
    }
}
