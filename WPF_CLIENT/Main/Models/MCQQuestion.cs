using System;
using System.Collections.Generic;
using System.Text;

namespace Main.Models
{
    public class MCQQuestion: QuestionBase
    {
        public  List<QuestionOption> Options { get; set; }
        public QuestionOption Answer { get; set; }
    }
}
