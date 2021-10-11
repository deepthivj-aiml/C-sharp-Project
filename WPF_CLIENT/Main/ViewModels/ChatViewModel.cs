
using GrpcServiceProvider;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Main.Command;
using System.Threading.Tasks;
using Main.Models;
using ChatbotService;

namespace Main.ViewModels
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        private List<string> answers = new List<string>();
        private string name;
        public static int questionId = 0;
        private ObservableCollection<Item> _messages;
        List<MCQQuestion> quetions = new List<MCQQuestion>();
        private string _textProperty = string.Empty;
        Products product;
        public bool wrongOption = true;
        public List<MCQQuestion> questionsForProduct;
        public MCQQuestion questionForProduct;
        public GrpcServiceProviderClass GRPCserviceProviderGetMCQ;
        public MCQQuestion mCQQuestion;
        public QuestionOption questionOption;
        public List<QuestionOption> questionOptions;
        public ProductMCQQuestion productMCQQuestionMessage;
        public ChatViewModel()
        {
            questionForProduct = new MCQQuestion();
            questionOptions = new List<QuestionOption>();
            questionsForProduct = new List<MCQQuestion>();
            Messages = new ObservableCollection<Item>();
            GRPCserviceProviderGetMCQ = new GrpcServiceProviderClass();
            productMCQQuestionMessage = new ProductMCQQuestion();
            product = new Products();
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
        private void AddMessage(object parameter)
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
                        GrpcServiceProviderClass GRPCserviceProviderGetProduct = new GrpcServiceProviderClass();
                        var task1 = Task.Run(() => GRPCserviceProviderGetProduct.GrpcServiceGetProductName(product.TouchScreen, product.WearableMonitor, product.AlarmManagement, product.ScreenSize));
                        task1.Wait();
                        Messages.Add(new Item("CHAT BOT: " + task1.Result, new SolidColorBrush(Colors.Red)));
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
                                    break;
                                }
                            }
                        }
                        Messages.Add(new Item("YOU: " + name, new SolidColorBrush(Colors.Green)));
                    }
                }
                questionId = questionId + 1;
                if (questionId < 5)
                {
                    MCQQuestion mcq = new MCQQuestion();
                    var task = Task.Run(() => GRPCserviceProviderGetMCQ.GrpcServiceGetProductMCQQuestion(questionId));
                    task.Wait();
                    productMCQQuestionMessage = task.Result;
                    mcq.QuestionText = productMCQQuestionMessage.QuestionText;
                    mcq.QuestionId = productMCQQuestionMessage.QuestionId;
                    int i = 0;
                    while (i < productMCQQuestionMessage.OptionId.Count)
                    {
                        questionOption = new QuestionOption();
                        questionOption.OptionId = productMCQQuestionMessage.OptionId[i];
                        questionOption.OptionText = productMCQQuestionMessage.OptionText[i];
                        questionOptions.Add(questionOption);
                        i++;
                    }
                    mcq.Options = questionOptions;
                    questionsForProduct.Add(mcq);
                    Messages.Add(new Item(mcq.QuestionText, new SolidColorBrush(Colors.Red)));
                    foreach (QuestionOption option in mcq.Options)
                    {
                        Messages.Add(new Item(Convert.ToString(option.OptionId) + " " + option.OptionText, new SolidColorBrush(Colors.Red)));
                    }
                }
            }
        }
    }
}
