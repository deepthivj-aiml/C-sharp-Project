using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    public class MCQQuestion: QuestionBase
    {
        public List<QuestionOption> Options { get; set; }
        public QuestionOption Answer { get; set; }
    }
}
