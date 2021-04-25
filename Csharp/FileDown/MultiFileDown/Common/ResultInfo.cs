using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiFileDown.Common
{
    public enum ResultState
    {
        OK,
        Error,
        TimeOut
    }
    public class ResultInfo
    {
        public int RowNO;
        public string URL;
        public string RetStr;
        public ResultState state;
        public int ReTimes;
    }
}
