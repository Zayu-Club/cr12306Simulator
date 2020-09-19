using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pers.xxy.cr12306Simulator.basic.v20200920;

namespace testConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is Toy Project CR 12306 Simulator");
            DateTime departureDate = new DateTime(2020, 9, 21);
            DateTime departureTime = new DateTime(2020, 9, 21, 8, 30, 0);
            ClassTrain testtrain = new ClassTrain("G9992", "SH", departureDate, departureTime, "CRH2A", 3);
            string[] passesStations = { "安庆", "池州", "铜陵", "繁昌西", "芜湖南", "芜湖", "当涂", "马鞍山", "江宁西", "南京南" };
            testtrain.setPassesStations(passesStations);
            testtrain.InitTrain();
            testtrain.LoopThrough_seatCollection();
            Console.ReadLine();
        }
    }
}
