using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module09Practice
{
    internal class Class1
    {
        public interface IInternalDeliveryService
        {
            void DeliverOrder(string oredId);
            string GetDeliveryStatus(string oredId);
        }

        public class InternalDeliveryService : IInternalDeliveryService
        {
            public void DeliverOrder(string oredId)
            {
                Console.WriteLine("Order DeliverOrder: " + oredId);
            }

            public string GetDeliveryStatus(string oredId)
            {
                return "Satus for Order " + oredId;
            }
        }
        public class GlovoLogisticService
        {
            public void ShipItem(int ItemId);

            public string TrackShipment(int ItemId);
            
        }

        public class LogisticAdapterGlovo : IInternalDeliveryService
        {
            private GlovoLogisticService glovoLogistics;
            public LogisticAdapterGlovo(GlovoLogisticService glovoLogistics)
            {
                this.glovoLogistics = glovoLogistics;
            }
            public void DeliverOrder(string oredId)
            {
                int item = int.Parse(oredId);
                glovoLogistics.ShipItem(item);
            }

            public string GetDeliveryStatus(string orderId)
            {
                int item = int.Parse(orderId);
                return glovoLogistics.TrackShipment(item);
            }
        }
    }
}

       
    static void Main(string[] args)
    {
     IInternalDeliveryService service = null;

     string typeDelivery = "Glovo"
         if(typeDelivery == "Glovo")
        {
            service = new LogisticAdapterGlovo(new GlovoLogisticsService());
         }
         else
        {
            service = new IInternalDeliveryService();
        }
    service.DeliveryyOrder("1241241");
        string st = service.GetDeliveryStatus("1241241");
    }
