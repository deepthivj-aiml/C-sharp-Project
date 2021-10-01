using System;
using System.Collections.Generic;
using System.Text;

namespace Main.Models
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
