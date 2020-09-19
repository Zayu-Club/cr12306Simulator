using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pers.xxy.cr12306Simulator.basic.v20200920
{
    public abstract class AbstractClassTrain
    {
       public string trainNumber;
       public string ascription;
       public DateTime departureDate;
       public DateTime departureTime;
       public string trainModelName;
       public int countCar;
       public string[] passesStations; 
    }
}
