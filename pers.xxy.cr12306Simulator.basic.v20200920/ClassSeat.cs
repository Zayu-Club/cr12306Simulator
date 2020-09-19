using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pers.xxy.cr12306Simulator.basic.v20200920
{
    public class ClassSeat
    {
        private int carNumber;
        private string seatNumber;
        private Byte countStation;
        private BitArray occupiedAreaFlag;

        public ClassSeat(int carNumber, string seatNumber, Byte countStation)
        {
            this.carNumber = carNumber;
            this.seatNumber = seatNumber;
            this.countStation = countStation;
            this.occupiedAreaFlag = new BitArray(countStation, true);
        }

        public string SeatNumber { get => seatNumber; set => seatNumber = value; }
        public BitArray OccupiedAreaFlag { get => occupiedAreaFlag; set => occupiedAreaFlag = value; }
        public int CarNumber { get => carNumber; set => carNumber = value; }
    }
}
