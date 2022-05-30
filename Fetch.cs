using System;
using Aletheia.Service;
using Aletheia.Service.StockData;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;



namespace Fetch {
    public class Program {
        //only 5,000 requests a month
        /*
        static IHostBuilder CreateBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices((hostContext, services) => {
                services.AddHostedService<FlightData>();
                
            });
        }
        */
        public static void Main(string[] args) {
                GetStock("MSFT");
                //CreateBuilder(args).Build().Run();
            }
        static AletheiaService CallApi(){
            // Aletheia is called
            AletheiaService service = new AletheiaService("7FA4842C273E480E82BBDD69723301C4");
            return service;
        }
        static void GetStock(string stockCode) {
            AletheiaService service = CallApi();
            try {
                //request is made
                StockData quote = service.GetStockDataAsync(stockCode, true, true).Result;
                Console.WriteLine(quote.SummaryData.Name); //placeholder data
            }
            catch (Exception ex) {
                //the error thrown will be an outside code error
                Console.WriteLine(ex.Message);
            }
        }
        static void GenJson(StockData item){
            string jsonifiedData = JsonSerializer.Serialize(item);
            Console.WriteLine(jsonifiedData);
    }   
}
}        
