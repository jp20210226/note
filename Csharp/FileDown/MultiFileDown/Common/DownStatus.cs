using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiFileDown.Common
{
    public enum DownStatus
    {
        Free,
        Waiting,
        Downing,
        Finished,
        Pause,
        Error
    }
}
