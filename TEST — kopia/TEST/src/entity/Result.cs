using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Window_Chrome_Demo.src.entity
{
    class Result
    {
        private Int16 score;

        private Int16 maxScore;

        public Result(Int16 score, Int16 maxScore)
        {
            this.score = score;
            this.maxScore = maxScore;
        }

        public Int16 Score
        {
            get { return score; }
        }

        public Int16 MaxScore
        {
            get { return maxScore; }
        }
    }
}
