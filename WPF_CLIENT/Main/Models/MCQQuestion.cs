using System;
using System.Collections.Generic;
using System.Text;

namespace Main.Models
{
    public class MCQQuestion: QuestionBase
    {
        public  List<QuestionOption> Options { get; set; }
        public QuestionOption Answer { get; set; }
        public MCQQuestion(MCQQuestion m)
        {
            this.QuestionId = m.QuestionId;
            this.QuestionText = m.QuestionText;
            this.Options = m.Options;
            this.Answer = m.Answer;
        }
        public MCQQuestion()
        {

        }
    }
   
}
