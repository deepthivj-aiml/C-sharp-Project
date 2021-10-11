using System;
using ChatbotService;
using Grpc.Net.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GrpcServiceProvider
{
    public class GrpcServiceProviderClass
    {
        public GrpcServiceProviderClass()
        {
        }
        public async Task<String> GrpcServiceGetProductName(string TouchScreen, string WearableMonitor, string AlarmManagement, float ScreenSize)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var inputFeatures = new ProductNameRequest { TouchScreen = TouchScreen, WearableMonitor = WearableMonitor, AlarmManagement = AlarmManagement, ScreenSize = ScreenSize };
             var productClient = new chatbot.chatbotClient(channel);
            var productName = await productClient.getProductNameAsync(inputFeatures);
            return (productName.ProductName);
        }
        public async Task<ProductMCQQuestion> GrpcServiceGetProductMCQQuestion(int questionId)
        {
             var channel = GrpcChannel.ForAddress("https://localhost:5001");
             var productClient = new chatbot.chatbotClient(channel);
             var inputQuestionId = new ProductQuestionRequest { QuestionId = questionId };
             var productMCQQuestionMessage = await productClient.getProductQuestionAsync(inputQuestionId);
             return productMCQQuestionMessage;      
        }
    }
}
