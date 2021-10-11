using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    public class QuestionOption
    {
        public string OptionText { get; set; }
        public int OptionId { get; set; }
        public QuestionOption(string optionText, int optionId)
        {
            this.OptionText = optionText;
            this.OptionId = optionId;
        }
        public QuestionOption()
        {

        }
    }
}
