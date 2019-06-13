using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Window_Chrome_Demo.src.entity
{
    class Exam
    {
        private Int16 id;
        private String name;
        private Int16 time;
        private Int16 closedQuantity;
        private List<ClosedQuestion> closedQuestionList;

        public Exam(Int16 id, String name, Int16 time, Int16 closedQuantity)
        {
            this.id = id;
            this.name = name;
            this.time = time;
            this.closedQuantity = closedQuantity;
            this.closedQuestionList = new List<ClosedQuestion>();
        }

        public Int16 Id
        {
            get { return id; }
        }

        public String Name
        {
            get { return name; }
        }

        public Int16 Time
        {
            get { return time; }
        }

        public Int16 ClosedQuestion
        {
            get { return closedQuantity; }
        }

        public List<ClosedQuestion> ClosedQuestionList
        {
            get { return closedQuestionList;}
            set { closedQuestionList = value; }
        }

    }
}
