
using GrpcServiceProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Main.Models;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Main.Command;
using System.Threading.Tasks;

namespace Main.ViewModels
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private List<string> answers = new List<string>();
        private string name;
        public static int questionId = 0;
        private ObservableCollection<Item> _messages;
        private string _textProperty = string.Empty;
        public List<MCQQuestion> questionsForProduct = new List<MCQQuestion>();
        public MCQQuestion questionForProduct;
        public MCQQuestion questionForProduct1;
        public MCQQuestion questionForProduct2;
        public MCQQuestion questionForProduct3;
        public MCQQuestion questionForProduct4;
        public QuestionOption questionOption1 ;
        public QuestionOption questionOption2;
        public QuestionOption questionOptionSreenSize1;
        public QuestionOption questionOptionSreenSize2;
        public QuestionOption questionOptionSreenSize3;
        public QuestionOption questionOptionSreenSize4;
        public List<QuestionOption> questionOptionList;
        public List<QuestionOption> questionOptionListScreenSize;       
        Models.Products product = new Models.Products();
        public bool wrongOption = true;
        public ChatViewModel()
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
            questionForProduct1.Options= questionOptionList;
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
            questionForProduct4.Options= questionOptionListScreenSize;
            questionsForProduct.Add(questionForProduct4);
            Messages = new ObservableCollection<Item>();
            Messages.Add(new Item("CHAT BOT:  Hello...what is your name..?", new SolidColorBrush(Colors.Red)));
            SubmitCommand = new ButtonCommand(AddMessage);
            ClearChatCommand = new ButtonCommand(ClearChat);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand SubmitCommand { get; set; }
        public ICommand ClearChatCommand { get; set; }
        public ObservableCollection<Item> Messages
        {
            get { return _messages; }
            set
            {
                _messages = value;
                NotifyPropertyChanged("Messages");
            }
        }
        public String TextProperty
        {
            get { return _textProperty; }
            set
            {
                _textProperty = value;
                NotifyPropertyChanged(nameof(TextProperty));
            }
        }
        public class Item
        {
            public Item(string name, SolidColorBrush LineColour1)
            {
                Name = name;
                LineColour = Convert.ToString(LineColour1);
            }
            public string Name { get; set; }
            public string LineColour { get; set; }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void ClearChat(object parameter)
        {
            Messages.Clear();
            foreach (string a in answers)
            {
                Messages.Add(new Item(a, new SolidColorBrush(Colors.Red)));
            }
        }
        private  void AddMessage(object parameter)
        {
            name = TextProperty;
            TextProperty = string.Empty;
            if (questionId < 5)
            {
                if (questionId == 4)
                {
                    Messages.Add(new Item("YOU: " + name, new SolidColorBrush(Colors.Green)));
                    questionForProduct = questionsForProduct.Find(q => (q.QuestionId == questionId));
                    foreach (QuestionOption option in questionForProduct.Options)
                    {
                        if ((name.Equals(Convert.ToString(option.OptionId))))
                        {
                            wrongOption = false;
                            break;
                        }
                    }
                    if (wrongOption)
                    {
                        questionId = questionId - 1;
                        Messages.Add(new Item("CHAT BOT:  WRONG CHOICE!!!!", new SolidColorBrush(Colors.Red)));
                    }
                    else
                    {
                        wrongOption = true;
                        foreach (QuestionOption option in questionForProduct.Options)
                        {
                            if (option.OptionId == Convert.ToInt32(name))
                            {
                                questionForProduct.Answer = new QuestionOption(option.OptionText, Convert.ToInt32(name));
                            }
                        }

                        product.TouchScreen = questionsForProduct.Find(q => (q.QuestionId == 1)).Answer.OptionText;
                        product.WearableMonitor = questionsForProduct.Find(q => (q.QuestionId == 2)).Answer.OptionText;
                        product.AlarmManagement = questionsForProduct.Find(q => (q.QuestionId == 3)).Answer.OptionText;
                        product.ScreenSize = (float)Convert.ToDouble(questionsForProduct.Find(q => (q.QuestionId == 4)).Answer.OptionText);
                        GrpcServiceProvider.GrpcServiceProviderClass GRPCserviceProvider = new GrpcServiceProvider.GrpcServiceProviderClass(product.TouchScreen, product.WearableMonitor, product.AlarmManagement, product.ScreenSize);
                        var task = Task.Run( () =>  GRPCserviceProvider.GrpcServiceProviderFN());
                        task.Wait();
                        Messages.Add(new Item("CHAT BOT: " + GRPCserviceProvider.ProductSuggested, new SolidColorBrush(Colors.Red)));
                        Messages.Add(new Item("Thank you...see you soon!!!", new SolidColorBrush(Colors.Red)));
                    }
                }
                else
                {
                    if (questionId == 0)
                    {
                        Messages.Add(new Item("YOU: " + name, new SolidColorBrush(Colors.Green)));
                        Messages.Add(new Item("CHAT BOT:  Hello " + name + " Let us choose a product for you!!!!", new SolidColorBrush(Colors.Red)));
                        name = "";
                    }
                    else
                    {
                        questionForProduct = questionsForProduct.Find(q => (q.QuestionId == questionId));
                        foreach (QuestionOption option in questionForProduct.Options)
                        {
                            if ((name.Equals(Convert.ToString(option.OptionId))))
                            {
                                wrongOption = false;
                                break;
                            }
                        }
                        if (wrongOption)
                        {
                            questionId = questionId - 1;
                            Messages.Add(new Item("CHAT BOT:  WRONG CHOICE!!!!", new SolidColorBrush(Colors.Red)));
                        }
                        else
                        {
                            wrongOption = true;
                            questionForProduct = questionsForProduct.Find(q => (q.QuestionId == questionId));

                            foreach (QuestionOption option in questionForProduct.Options)
                            {
                                if (option.OptionId == Convert.ToInt32(name))
                                {
                                    questionForProduct.Answer = new QuestionOption(option.OptionText, Convert.ToInt32(name));
                                }
                            }
                        }

                        Messages.Add(new Item("YOU: " + name, new SolidColorBrush(Colors.Green)));
                    }
                }
                questionId = questionId + 1;
                if (questionId < 5)
                {
                    questionForProduct = questionsForProduct.Find(q => (q.QuestionId == questionId));
                    Messages.Add(new Item(questionForProduct.QuestionText, new SolidColorBrush(Colors.Red)));
                    foreach (QuestionOption option in questionForProduct.Options)
                    {
                        Messages.Add(new Item(Convert.ToString(option.OptionId) + " " + option.OptionText, new SolidColorBrush(Colors.Red)));
                    }
                }
            }
        }
    }    
}
