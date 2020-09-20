using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pers.xxy.cr12306Simulator.basic.v20200920
{
    public class ClassTicket
    {
        private string trainNumber;
        private string soureStation;
        private string destStation;
        private int carNum;
        private int seatNum;
        private char seatLetter;
        private bool Effective = false;

        public ClassTicket(string trainNumber, string soureStation, string destStation)
        {
            this.trainNumber = trainNumber;
            this.soureStation = soureStation;
            this.destStation = destStation;
        }

        public string TrainNumber { get => trainNumber; set => trainNumber = value; }
        public string SoureStation { get => soureStation; set => soureStation = value; }
        public string DestStation { get => destStation; set => destStation = value; }
        public int CarNum { get => carNum; set => carNum = value; }
        public int SeatNum { get => seatNum; set => seatNum = value; }
        public char SeatLetter { get => seatLetter; set => seatLetter = value; }
        public bool Effective1 { get => Effective; set => Effective = value; }
    }
}
