
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceLibrary;

namespace Main.Services
{
    public class chatbotService : chatbot.chatbotBase
    {
        string yourProduct;
        ServiceLibrary.MCQQuestion yourMCQQuestion;
        private readonly ILogger<chatbotService> _logger;
        public chatbotService(ILogger<chatbotService> logger)
        {
            _logger = logger;
        }
        public override Task<Productname> getProductName(ProductNameRequest request, ServerCallContext context)
        {
            ServiceLibrary.Products p = new Products()
            {
                TouchScreen = request.TouchScreen,
                WearableMonitor = request.WearableMonitor,
                AlarmManagement = request.AlarmManagement,
                ScreenSize = request.ScreenSize
            };
            ServiceLibrary.Services sp = new ServiceLibrary.Services();
            yourProduct = sp.FindProduct(p);
            Productname output = new Productname();
            output.ProductName = yourProduct;
            return Task.FromResult(output);
        }

        public override Task<ProductMCQQuestion> getProductQuestion(ProductQuestionRequest request, ServerCallContext context)
        {
            ServiceLibrary.Services sp = new ServiceLibrary.Services();
            yourMCQQuestion = sp.getMCQQuestionForProduct(request.QuestionId);
            ProductMCQQuestion output = new ProductMCQQuestion();
            foreach (ServiceLibrary.QuestionOption op in yourMCQQuestion.Options)
            {
                output.OptionId.Add(op.OptionId);
                output.OptionText.Add(op.OptionText);
            }
            output.QuestionText = yourMCQQuestion.QuestionText;
            output.QuestionId = request.QuestionId;
            Console.WriteLine(output);
            Console.WriteLine(yourMCQQuestion.Options.Count);
            return Task.FromResult(output);
        }
    }
}
