using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pers.xxy.cr12306Simulator.basic.v20200920
{
    public class ClassPassenger
    {
        private string passengerName;
        private string trainNumber;
        private string soureStation;
        private string destStation;
        private ClassTicket ownTicket;

        public ClassPassenger(string passengerName, string trainNumber, string soureStation, string destStation)
        {
            this.passengerName = passengerName;
            this.trainNumber = trainNumber;
            this.soureStation = soureStation;
            this.destStation = destStation;
            ownTicket = new ClassTicket(this.trainNumber, this.soureStation, this.destStation);
        }

        public ClassTicket OwnTicket { get => ownTicket; }

        public void BuyTicket(ClassTrain train)
        {
            if (ownTicket.Effective1)
            {
                Console.WriteLine("[ERROR]同一乘客同一车次只能买一张票");
            }
            //ownTicket = new ClassTicket(this.trainNumber, this.soureStation, this.destStation);
            if (train.IsSoure2DestEffective(this.soureStation, this.destStation))
            {
                int soureStationIndex = Array.IndexOf(train.passesStations, soureStation);
                int destStationIndex = Array.IndexOf(train.passesStations, destStation);
                foreach (ClassSeat seat in train.SeatCollection)
                {
                    if (train.IsSeatBitMapInAreaEffective(seat, soureStationIndex, destStationIndex))
                    {
                        //当前座位可用，修改座位表，并设置票面信息
                        for (int i = soureStationIndex; i < destStationIndex; i++) 
                        {
                            seat.OccupiedAreaFlag[i] = false;
                        }
                        seat.OccupiedPassenger.Add(passengerName);
                        ownTicket.CarNum = seat.CarNumber;
                        ownTicket.SeatNum = seat.SeatNumber;
                        ownTicket.SeatLetter = seat.SeatLetter;
                        ownTicket.Effective1 = true;
                        Console.WriteLine("[INFO]出票成功，{0}，{1}车{2}{3}，由{4}到{5}", passengerName, ownTicket.CarNum, ownTicket.SeatNum, ownTicket.SeatLetter,ownTicket.SoureStation,ownTicket.DestStation);
                        return;
                    }
                    else
                    {
                        //当前座位不可用
                        continue;
                    }
                }
                Console.WriteLine("[WARNING]无法分配座位");
            }
            else
            {
                Console.WriteLine("[ERROR]输入的区间有误");
            }
        }

        public bool RefundTacket()
        {
            return true;
        }
    }
}
