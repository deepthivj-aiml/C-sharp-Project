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
        public string ProductSuggested {get; set;}
        internal string TouchScreen { get; set; }
        internal string WearableMonitor { get; set; }
        internal string AlarmManagement { get; set; }
        internal float ScreenSize { get; set; }
        public GrpcServiceProviderClass(string touchScreen, string wearableMonitor, string alarmManagement, float screenSize)
        {
            this.TouchScreen = touchScreen;
            this.WearableMonitor = wearableMonitor;
            this.AlarmManagement = alarmManagement;
            this.ScreenSize = screenSize;
        }
        public async Task GrpcServiceProviderFN()
        {   
            var channel = GrpcChannel.ForAddress("https://localhost:5001");     
            var input1 = new ProductNameRequest { TouchScreen = TouchScreen, WearableMonitor = WearableMonitor, AlarmManagement = AlarmManagement, ScreenSize = ScreenSize };
            var productClient = new chatbot.chatbotClient(channel);
            var productName = await productClient.getProductNameAsync(input1);
            this.ProductSuggested = productName.ProductName;
        }
    }
}
