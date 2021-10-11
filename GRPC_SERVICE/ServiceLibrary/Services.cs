using System;
using System.Collections.Generic;
using System.Text;


namespace ServiceLibrary
{

    public class Services
    {

        public List<MCQQuestion> questionsForProduct = new List<MCQQuestion>();
        public MCQQuestion questionForProduct;
        public MCQQuestion questionForProduct1;
        public MCQQuestion questionForProduct2;
        public MCQQuestion questionForProduct3;
        public MCQQuestion questionForProduct4;
        public QuestionOption questionOption1;
        public QuestionOption questionOption2;
        public QuestionOption questionOptionSreenSize1;
        public QuestionOption questionOptionSreenSize2;
        public QuestionOption questionOptionSreenSize3;
        public QuestionOption questionOptionSreenSize4;
        public List<QuestionOption> questionOptionList;
        public List<QuestionOption> questionOptionListScreenSize;
        public string YourProduct;
        public MCQQuestion getMCQQuestionForProduct(Int32 questionId)
        {
            questionForProduct1 = new MCQQuestion();
            questionForProduct2 = new MCQQuestion();
            questionForProduct3 = new MCQQuestion();
            questionForProduct4 = new MCQQuestion();
            questionOption1 = new QuestionOption();
            questionOption2 = new QuestionOption();
            questionOptionSreenSize1 = new QuestionOption();
            questionOptionSreenSize2 = new QuestionOption();
            questionOptionSreenSize3 = new QuestionOption();
            questionOptionSreenSize4 = new QuestionOption();
            questionOptionList = new List<QuestionOption>();
            questionOptionListScreenSize = new List<QuestionOption>();
            questionOption1.OptionId = 1;
            questionOption1.OptionText = "YES";
            questionOptionList.Add(questionOption1);
            questionOption2.OptionId = 2;
            questionOption2.OptionText = "NO";
            questionOptionList.Add(questionOption2);
            questionForProduct1.QuestionText = "CHAT BOT:  Do you want TouchScreen ? (Please provide the option number that you want)";
            questionForProduct1.QuestionId = 1;
            questionForProduct1.Options = questionOptionList;
            questionsForProduct.Add(questionForProduct1);
            questionForProduct2.QuestionText = "CHAT BOT:  Do you want WearableMonitor  ? (Please provide the option number that you want)";
            questionForProduct2.QuestionId = 2;
            questionForProduct2.Options = questionOptionList;
            questionsForProduct.Add(questionForProduct2);
            questionForProduct3.QuestionText = "CHAT BOT:  Do you want AlarmManagement   ? (Please provide the option number that you want)";
            questionForProduct3.QuestionId = 3;
            questionForProduct3.Options = questionOptionList;
            questionsForProduct.Add(questionForProduct3);
            questionForProduct4.QuestionText = "CHAT BOT:  Do you want ScreenSize    ? (Please provide the option number that you want)";
            questionForProduct4.QuestionId = 4;
            questionOptionSreenSize1.OptionId = 1;
            questionOptionSreenSize1.OptionText = "15.5";
            questionOptionListScreenSize.Add(questionOptionSreenSize1);
            questionOptionSreenSize2.OptionId = 2;
            questionOptionSreenSize2.OptionText = "30.5";
            questionOptionListScreenSize.Add(questionOptionSreenSize2);
            questionOptionSreenSize3.OptionId = 3;
            questionOptionSreenSize3.OptionText = "30.48";
            questionOptionListScreenSize.Add(questionOptionSreenSize3);
            questionOptionSreenSize4.OptionId = 4;
            questionOptionSreenSize4.OptionText = "30.734";
            questionOptionListScreenSize.Add(questionOptionSreenSize4);
            questionForProduct4.Options = questionOptionListScreenSize;
            questionsForProduct.Add(questionForProduct4);
            questionForProduct = questionsForProduct.Find(q => (q.QuestionId == questionId));
            return questionForProduct;
        }

        public string FindProduct(Products product)
        {
            Products IntellivueMX40 = new Products()
            {
                ProductName = "Intellivue",
                ProductNumber = "MX40",
                TouchScreen = "YES",
                WearableMonitor = "YES",
                AlarmManagement = "YES",
                ScreenSize = 30.5f
            };
            Products Intellivuex3 = new Products()
            {
                ProductName = "Intellivue",
                ProductNumber = "X3",
                TouchScreen = "YES",
                WearableMonitor = "NO",
                AlarmManagement = "YES",
                ScreenSize = 15.5f
            };
            Products IntellivueMX450 = new Products()
            {
                ProductName = "Intellivue",
                ProductNumber = "MX450",
                TouchScreen = "YES",
                WearableMonitor = "NO",
                AlarmManagement = "YES",
                ScreenSize = 30.48f
            };
            Products IntellivueMP5 = new Products()
            {
                ProductName = "Intellivue",
                ProductNumber = "MP5",
                TouchScreen = "YES",
                WearableMonitor = "NO",
                AlarmManagement = "YES",
                ScreenSize = 30.734f
            };
            List<Products> productList = new List<Products>();
            productList.AddRange(new List<Products>() { IntellivueMX40, Intellivuex3, IntellivueMX450, IntellivueMP5 });
            bool flag = false;
            foreach (var p in productList)
            {
                if (product.ScreenSize == p.ScreenSize && product.AlarmManagement.Equals(p.AlarmManagement) && product.TouchScreen.Equals(p.TouchScreen) && product.WearableMonitor.Equals(p.WearableMonitor))
                {
                    YourProduct = "Superb!!! you can buy " + p.ProductName + p.ProductNumber;
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                YourProduct = "Sorry there is no products with this features!!!!!";
            }
            return YourProduct;
        }
    }
}
