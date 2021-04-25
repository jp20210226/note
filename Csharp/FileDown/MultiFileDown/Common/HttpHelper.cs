using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MultiFileDown.Common
{
    public class HttpHelper
    {
        public event EventHandler<ResultInfo> OnResultInfo;

        public string AgentIP;
        public void GetHtml(object pobj)
        {
            TParam param = (TParam)pobj;
            string strurl = param.URL;
            ResultState iresno;
            http ht = new http();
            ht.agentip = AgentIP;
            string strret = "";
            if (param.IsMulti)
            {
                string strnext = "";
                string pattern = @"(?<=<a href="").+?(?="">下一页)";
                string strpath = GetURLPath(strurl);
                string strname = Path.GetFileNameWithoutExtension(strurl);
                string strurltmp = strurl;
                do
                {
                    string strtmp = ht.gethtml(strurltmp, out iresno);
                    strret += strtmp;
                    strnext = Regex.Match(strtmp, pattern).Value;
                    if (strnext.IndexOf(strname) >= 0)
                    {
                        strurltmp = strpath + strnext;
                    }
                    else
                    {
                        break;
                    }
                } while (true);
            }
            else
            {
                strret += ht.gethtml(strurl, out iresno);
            }
            
            if (OnResultInfo != null)
            {
                ResultInfo ri = new ResultInfo();
                ri.RowNO = param.RowNO;
                ri.URL = param.URL;
                ri.RetStr = strret;
                ri.state = iresno;
                ri.ReTimes = param.ReTimes;
                OnResultInfo(this, ri);
            }
        }

        public static string GetURLPath(string pURL)
        {
            int lpos = pURL.LastIndexOf('/');
            if (lpos > 0)
                return pURL.Substring(0, lpos+1);
            return "";
        }
        public static string GetURLHost(string pURL)
        {
            int lpos = pURL.IndexOf("://");
            if (lpos > 0)
            {
                lpos = pURL.IndexOf("/", lpos+3);
                if(lpos>0)
                    return pURL.Substring(0, lpos);
            }
                
            return pURL;
        }

    }
}
