using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pers.xxy.cr12306Simulator.basic.v20200920
{
    public class ClassTrain : AbstractClassTrain
    {
        private ArrayList seatCollection = new ArrayList();
        public ClassTrain(string trainNumber,string ascription,DateTime departureDate,DateTime departureTime, string trainModelName, int countCar)
        {
            this.trainNumber = trainNumber;
            this.ascription = ascription;
            this.departureDate = departureDate;
            this.departureTime = departureTime;
            this.trainModelName = trainModelName;
            this.countCar = countCar;
        }



        public string TrainNumber { get => trainNumber; set => trainNumber = value; }
        public string Ascription { get => ascription; set => ascription = value; }
        public DateTime DepartureDate { get => departureDate; set => departureDate = value; }
        public DateTime DepartureTime { get => departureTime; set => departureTime = value; }
        public string TrainModelName { get => trainModelName; set => trainModelName = value; }
        public int CountTrain { get => countCar; set => countCar = value; }

        public void setPassesStations(string[] passesStations)
        {
            this.passesStations = passesStations;
        }

        public void InitTrain()
        {
            byte countStations = (byte)passesStations.Length;
            char[] seatLetter = { 'A', 'B', 'C', 'D', 'F' };
            for (int car = 1; car <= countCar; car++) 
            {
                for (int seatNum = 1; seatNum <= 4; seatNum++) 
                {
                    foreach(char seatletter in seatLetter)
                    {
                        ClassSeat seat = new ClassSeat(car, string.Concat(car, "车", seatNum, seatletter), countStations);
                        this.seatCollection.Add(seat);
                    }
                }
            }
        }

        public void LoopThrough_seatCollection()
        {
            foreach(string stationStr in passesStations)
            {
                Console.Write("\t");
                Console.Write("{0}", stationStr);
            }
            Console.WriteLine();
            foreach(ClassSeat seat in this.seatCollection)
            {
                Console.Write("{0}  ",seat.SeatNumber);
                for (int i = 0; i < seat.OccupiedAreaFlag.Count; i++)
                {
                    Console.Write("{0}\t", seat.OccupiedAreaFlag[i]);
                }
                Console.WriteLine();
            }
        }



    }
}
