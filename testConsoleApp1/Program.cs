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
            string[] passesStations = { "安庆", "池州", "铜陵", "芜湖", "马鞍山", "南京南", "镇江", "常州", "无锡", "苏州", "上海虹桥" };
            testtrain.SetPassesStations(passesStations);
            testtrain.InitTrain(3);
            testtrain.LoopThrough_seatCollection();
            Console.ReadLine();
        }
    }
}
