using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using LitJson;
using Newtonsoft.Json.Linq;
namespace 测完即删
{
    public class father
    {
        int a1 = 1;
        static int v1 = 2;
        public father()
        {

        }
        static void Main()
        {
            son.dwa();
            son a = new son();
            a.dawa();
        }
 
    }
    public class son:father
    {
        public son()
        {

        }
        int a2 = 1;
        static int v2 = 2;
        public static void dwa()
        {

        }
        public void dawa()
        {

        }
    }
}

