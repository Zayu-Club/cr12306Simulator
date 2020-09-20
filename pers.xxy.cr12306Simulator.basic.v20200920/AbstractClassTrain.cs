using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pers.xxy.cr12306Simulator.basic.v20200920
{
    /// <summary>
    /// 列车抽象类
    /// </summary>
    public abstract class AbstractClassTrain
    {
        /// <summary>
        /// 车次
        /// </summary>
        public string trainNumber;
        /// <summary>
        /// 所属路局
        /// </summary>
        public string ascription;
        /// <summary>
        /// 发车日期
        /// </summary>
        public DateTime departureDate;
        /// <summary>
        /// 发车具体时间
        /// </summary>
        public DateTime departureTime;
        /// <summary>
        /// 车型
        /// </summary>
        public string trainModelName;
        /// <summary>
        /// 编组数
        /// </summary>
        public int countCar;
        /// <summary>
        /// 每节编组座位排数
        /// </summary>
        public int countSeatNum;
        /// <summary>
        /// 座位字母
        /// </summary>
        public static readonly char[] CountseatLetter = { 'A', 'B', 'C', 'D', 'F' };
        /// <summary>
        /// 途径站点
        /// </summary>
        public string[] passesStations; 
    }
}
