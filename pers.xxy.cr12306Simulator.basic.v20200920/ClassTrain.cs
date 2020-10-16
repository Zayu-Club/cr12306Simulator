
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace pers.xxy.cr12306Simulator.basic.v20200920
{
    /// <summary>
    /// 车次类
    /// </summary>
    public class ClassTrain : AbstractClassTrain
    {
        /// <summary>
        /// 车次中所有座位的集合
        /// </summary>
        private ArrayList seatCollection = new ArrayList();
        public ClassTrain(string trainNumber, string ascription, DateTime departureDate, DateTime departureTime, string trainModelName, int countCar, int countSeatNum, string[] passesStations)
        {
            this.trainNumber = trainNumber;
            this.ascription = ascription;
            this.departureDate = departureDate;
            this.departureTime = departureTime;
            this.trainModelName = trainModelName;
            this.countCar = countCar;
            this.countSeatNum = countSeatNum;
            this.passesStations = passesStations;
        }



        public string TrainNumber { get => trainNumber; set => trainNumber = value; }
        public string Ascription { get => ascription; set => ascription = value; }
        public DateTime DepartureDate { get => departureDate; set => departureDate = value; }
        public DateTime DepartureTime { get => departureTime; set => departureTime = value; }
        public string TrainModelName { get => trainModelName; set => trainModelName = value; }
        public int CountTrain { get => countCar; set => countCar = value; }
        public int CountSeatNum { get => countSeatNum; set => countSeatNum = value; }
        public ArrayList SeatCollection { get => seatCollection; set => seatCollection = value; }

        /// <summary>
        /// 初始化一个车次，为车次分配座位
        /// </summary>
        /// <param name="countSeatNum">每节编组座位排数</param>
        public void InitTrain()
        {
            byte countStations = (byte)passesStations.Length;
            for (int car = 1; car <= countCar; car++) 
            {
                for (int seatNum = 1; seatNum <= countSeatNum; seatNum++) 
                {
                    foreach(char seatletter in CountseatLetter)
                    {
                        ClassSeat seat = new ClassSeat(car, seatNum, seatletter, countStations);
                        this.SeatCollection.Add(seat);
                    }
                }
            }
        }

        /// <summary>
        /// 遍历本车次全部座位
        /// </summary>
        public void LoopThrough_seatCollection()
        {
            Console.WriteLine("-----当前座位分配表-----");
            Console.Write("\t");
            foreach (string stationStr in passesStations)
            {                
                Console.Write("{0}\t", stationStr);
            }
            Console.Write("占用");
            Console.WriteLine();
            foreach(ClassSeat seat in this.SeatCollection)
            {
                Console.Write("{0}车{1}{2}\t", seat.CarNumber, seat.SeatNumber, seat.SeatLetter);
                for (int i = 0; i < seat.OccupiedAreaFlag.Count; i++)
                {
                    Console.Write("{0}\t", seat.OccupiedAreaFlag[i]);
                }
                if (seat.OccupiedPassenger != null) 
                {
                    for (int i = 0; i < seat.OccupiedPassenger.Count; i++)
                    {
                        Console.Write("{0}\t", seat.OccupiedPassenger[i]);
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("------------------------");
        }

        /// <summary>
        /// 返回当前ClassTrain在给定区间的余票
        /// </summary>
        /// <param name="soureStation">起点</param>
        /// <param name="destStation">终点</param>
        /// <returns></returns>
        public int GetRemainingTicketsCount(string soureStation, string destStation)
        {
            int ticketsCount = 0;
            if (IsSoure2DestEffective(soureStation, destStation))
            {
                int soureStationIndex = Array.IndexOf(passesStations, soureStation);
                int destStationIndex = Array.IndexOf(passesStations, destStation);
                foreach (ClassSeat Seat in SeatCollection)
                {
                    if (IsSeatBitMapInAreaEffective(Seat, soureStationIndex, destStationIndex))
                    {
                        ticketsCount++;
                    }
                }
            }
            return ticketsCount;
        }

        /// <summary>
        /// 判断区间是否有效
        /// </summary>
        /// <param name="soureStation">起点</param>
        /// <param name="destStation">终点</param>
        /// <returns>有效返回true，无效返回false</returns>
        public bool IsSoure2DestEffective(string soureStation,string destStation)
        {
            int soureStationIndex = Array.IndexOf(this.passesStations, soureStation);
            int destStationIndex = Array.IndexOf(this.passesStations, destStation);
            if (soureStationIndex < 0 || destStationIndex < 0)
            {
                if (soureStationIndex >= destStationIndex)
                {
                    Console.WriteLine("[ERROR]站区间无效");
                    return false;
                }
            }
            //Console.WriteLine("[INFO]站区间有效");
            return true;
        }

        /// <summary>
        /// 判断座位在给定的bitMap区间内是否全部可用
        /// </summary>
        /// <param name="seat">座位</param>
        /// <param name="soureIndex">BitMap起始索引</param>
        /// <param name="destIndex">BitMap结束索引</param>
        /// <returns>可用返回true，不可用返回false</returns>
        public bool IsSeatBitMapInAreaEffective(ClassSeat seat, int soureIndex, int destIndex)
        {
            for (int i = soureIndex; i < destIndex; i++) 
            {
                if (seat.OccupiedAreaFlag[i] == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 判断座位号是否有效
        /// </summary>
        /// <param name="carNum">编组号</param>
        /// <param name="seatNum">座位号</param>
        /// <param name="seatLetter">座位字母</param>
        /// <returns>有效返回true，无效返回false</returns>
        public bool IsSeatEffective(int carNum,int seatNum,char seatLetter)
        {
            if (carNum <= this.countCar && seatNum <= this.countSeatNum && Array.IndexOf(AbstractClassTrain.CountseatLetter, seatLetter) > -1)
            {
                return true;
            }
            return false;
        }

    }
}
