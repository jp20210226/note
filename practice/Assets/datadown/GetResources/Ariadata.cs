using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.datadown.GetResources
{
    public class GlobalStatData
    {
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public GlobalStatResult result { get; set; }

    }
    public class GlobalStatResult
    {
        public string downloadSpeed { get; set; }
        public string numActive { get; set; }
        public string numStopped { get; set; }
        public string numStoppedTotal { get; set; }
        public string numWaiting { get; set; }
        public string uploadSpeed { get; set; }
    }

    public class TellStatusData
    {
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public CommonResult result { get; set; }

    }

    public class TellStopped
    {
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public TellStoppedResult[] result { get; set; }
    }

    public class TellStoppedResult
    {
        public string bitfield { get; set; }
        public string completedLength { get; set; }
        public string connections { get; set; }
        public string dir { get; set; }
        public string downloadSpeed { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set;}
        public Files[] files { get; set; }
        public string gid { get; set; }
        public string numPieces { get; set; }
        public string pieceLength { get; set; } 
        public string status { get; set; }
        public string totalLength { get; set; }
        public string uploadLength { get; set; }
        public string uploadSpeed { get; set; }
    }
    public class Files
    {
        public string completedLength { get; set; }
        public string index { get; set; }
        public string length { get; set; }
        public string path { get; set; }
        public string selected { get; set; }
        public Uris[] uris { get; set; }
    }
    public class Uris
    {
        public string status { get; set; }
        public string uri { get; set; }
    }

    public class TellActive
    {
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public CommonResult result { get; set; }

    }

    public class TellWaiting
    {
        public string id { get; set; }
        public string jsonrpc { get; set; }
        public CommonResult result { get; set; }

    }

    public class CommonResult
    {
        public string completedLength { get; set; }
        public string connections { get; set; }
        public string downloadSpeed { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public string gid { get; set; }
        public string status { get; set; }
        public string totalLength { get; set; }
        public string uploadLength { get; set; }
        public string uploadSpeed { get; set; }
    }
}
