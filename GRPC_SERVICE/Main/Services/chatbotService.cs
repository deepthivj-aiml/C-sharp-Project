using Main.Classes;
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
        private readonly ILogger<chatbotService> _logger;
        public chatbotService(ILogger<chatbotService> logger)
        {   
            _logger = logger;
        }
        public override Task<Productname> getProductName(ProductNameRequest request, ServerCallContext context)
        {
            ServiceLibrary.Products sp = new ServiceLibrary.Products()
            {
                TouchScreen = request.TouchScreen,
                WearableMonitor = request.WearableMonitor,
                AlarmManagement = request.AlarmManagement,
                ScreenSize = request.ScreenSize
            };
            sp.FindProduct(sp);
            Productname output = new Productname();
            output.ProductName = sp.YourProduct;
            return Task.FromResult(output);  
        }
    }
}
