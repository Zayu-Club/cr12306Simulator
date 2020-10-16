using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pers.xxy.cr12306Simulator.basic.v20200920;

namespace testBuyingTicketsConsoleApp1
{
    class Program
    {
        public static int CONSOLE_WIDTH = 140;
        public static int CONSOLE_HEIGHT = 55;
        public static string TRAIN_NUMBER = "G9998";
        public static string ASCRIPTION = "SH";
        public static string TRAIN_MODE_NAME = "CRH2A";
        public static int COUNT_CAR = 2;
        public static int COUNT_SEAT_NUM = 2;
        public static string[] PASSS_TATIONS = { "安庆", "池州", "铜陵", "芜湖", "马鞍山", "南京南", "镇江", "常州", "无锡", "苏州", "上海虹桥" };
        public static DateTime DEPARTURE_DATE = new DateTime(2020, 9, 21);
        public static DateTime DEPARTURE_TIME = new DateTime(2020, 9, 21, 8, 30, 0);
        static void Main(string[] args)
        {
            Console.WindowWidth = CONSOLE_WIDTH;
            Console.WindowHeight = CONSOLE_HEIGHT;
            Console.WriteLine("-----This is Toy Project CR 12306 Simulator-----");
            //初始化车次
            ClassTrain trainG9998 = new ClassTrain(TRAIN_NUMBER, ASCRIPTION, DEPARTURE_DATE, DEPARTURE_TIME, TRAIN_MODE_NAME, COUNT_CAR, COUNT_SEAT_NUM, PASSS_TATIONS);
            trainG9998.InitTrain();
            //遍历座位表
            //trainG9998.LoopThrough_seatCollection();

            //初始化乘客
            ClassPassenger passenger0 = new ClassPassenger("王二狗", TRAIN_NUMBER, "池州", "上海虹桥");
            ClassPassenger passenger1 = new ClassPassenger("李美丽", TRAIN_NUMBER, "安庆", "南京南");
            ClassPassenger passenger2 = new ClassPassenger("孙大胖", TRAIN_NUMBER, "铜陵", "芜湖");
            ClassPassenger passenger3 = new ClassPassenger("赵喵喵", TRAIN_NUMBER, "芜湖", "马鞍山");
            ClassPassenger passenger4 = new ClassPassenger("刘活宝", TRAIN_NUMBER, "镇江", "苏州");
            ClassPassenger passenger5 = new ClassPassenger("钱多多", TRAIN_NUMBER, "安庆", "芜湖");
            ClassPassenger passenger6 = new ClassPassenger("周咪咪", TRAIN_NUMBER, "马鞍山", "南京南");
            ClassPassenger passenger7 = new ClassPassenger("吴富贵", TRAIN_NUMBER, "南京南", "无锡");
            ClassPassenger passenger8 = new ClassPassenger("郑天下", TRAIN_NUMBER, "无锡", "苏州");
            ClassPassenger passenger9 = new ClassPassenger("苏母鸡", TRAIN_NUMBER, "苏州", "上海虹桥");
            ClassPassenger passenger10 = new ClassPassenger("潘哈哈", TRAIN_NUMBER, "安庆", "铜陵");
            ClassPassenger passenger11 = new ClassPassenger("陈威威", TRAIN_NUMBER, "安庆", "铜陵");
            //买票
            passenger0.BuyTicket(trainG9998);
            passenger1.BuyTicket(trainG9998);
            passenger2.BuyTicket(trainG9998);
            passenger3.BuyTicket(trainG9998);
            passenger4.BuyTicket(trainG9998);
            passenger5.BuyTicket(trainG9998);
            passenger6.BuyTicket(trainG9998);
            passenger7.BuyTicket(trainG9998);
            passenger8.BuyTicket(trainG9998);
            passenger9.BuyTicket(trainG9998);
            passenger10.BuyTicket(trainG9998);
            passenger11.BuyTicket(trainG9998);

            trainG9998.LoopThrough_seatCollection();
            Console.WriteLine("{0}到{1}间有余票{2}张", "安庆", "上海虹桥", trainG9998.GetRemainingTicketsCount("安庆", "上海虹桥"));
            Console.WriteLine("{0}到{1}间有余票{2}张", "南京南", "镇江", trainG9998.GetRemainingTicketsCount("南京南", "镇江"));
            Console.WriteLine("{0}到{1}间有余票{2}张", "苏州", "上海虹桥", trainG9998.GetRemainingTicketsCount("苏州", "上海虹桥"));
            Console.WriteLine("{0}到{1}间有余票{2}张", "安庆", "铜陵", trainG9998.GetRemainingTicketsCount("安庆", "铜陵"));




            Console.ReadLine();
        }
    }
}
