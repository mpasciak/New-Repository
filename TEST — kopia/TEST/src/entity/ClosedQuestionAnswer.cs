using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Window_Chrome_Demo.src
{
    class ClosedQuestionAnswer
    {
        private Int16 id;
        private String answer;
        private Boolean isCorrect;
        private Boolean isChecked;

        public ClosedQuestionAnswer(Int16 id, String answer)
        {
            this.id = id;
            this.answer = answer;
            this.isChecked = false;
        }

        public Int16 Id
        {
            get { return id; }
        }

        public String Answer
        {
            get { return answer; }
        }

        public Boolean IsChecked
        {
            get { return isChecked; }
            set { isChecked = value; }
        }

        public Boolean IsCorrect
        {
            get { return isCorrect; }
            set { isCorrect = value; }
        }

    }
}
