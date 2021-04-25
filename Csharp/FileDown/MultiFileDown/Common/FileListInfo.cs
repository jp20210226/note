using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiFileDown.Common
{
    [Serializable]
    public class FileListInfo
    {
        public string FileName;
        public long FileSize;
        public long DownSize;
        //public float DownProgress;
        //public float DownSpeed;
        public DateTime StartTime;
        //public int UseTime;
        public string Dir;
        public string URL;
        public DownStatus Status;
        public bool isModify;

    }
}
