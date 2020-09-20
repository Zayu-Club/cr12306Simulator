using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pers.xxy.cr12306Simulator.basic.v20200920
{
    /// <summary>
    /// 座位类
    /// </summary>
    public class ClassSeat
    {
        /// <summary>
        /// 座位所在编组号
        /// </summary>
        private int carNumber;
        /// <summary>
        /// 座位号
        /// </summary>
        private int seatNumber;
        /// <summary>
        /// 座位字母
        /// </summary>
        private char seatLetter;
        /// <summary>
        /// 途径站点计数
        /// </summary>
        private Byte countStation;
        /// <summary>
        /// 区间占用标记
        /// </summary>
        private BitArray occupiedAreaFlag;
        /// <summary>
        /// 占用该座位的乘客
        /// </summary>
        private ArrayList occupiedPassenger=new ArrayList();

        public ClassSeat(int carNumber, int seatNumber, char seatLetter, Byte countStation)
        {
            this.carNumber = carNumber;
            this.seatNumber = seatNumber;
            this.seatLetter = seatLetter;
            this.countStation = countStation;
            this.occupiedAreaFlag = new BitArray(countStation, true);
        }

        public int SeatNumber { get => seatNumber; set => seatNumber = value; }
        public BitArray OccupiedAreaFlag { get => occupiedAreaFlag; set => occupiedAreaFlag = value; }
        public int CarNumber { get => carNumber; set => carNumber = value; }
        public ArrayList OccupiedPassenger { get => occupiedPassenger; set => occupiedPassenger = value; }
        public char SeatLetter { get => seatLetter; set => seatLetter = value; }
    }
}
