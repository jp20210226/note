using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
namespace DealJson
{
    class Program
    {
        static List<string> jsonPath;
        static List<string> restPath;
        static Dictionary<string, int> ArraryIndex = new Dictionary<string, int>();
        static string lastNode;
        static void Main(string[] args)
        {
            string jsonStr = File.ReadAllText(@"C:\Users\jp\Desktop\get到的.json");
            //数组：
            //    可通过数字索引查找  array[0]
            //    可通过数组中给定路径查找
            JObject Restut = GetJsonValue(jsonStr, ".data.lab_jcomp[*].comp.UnDisplayField.PGUID", ".data.lab_jcomp[*].comp.DisplayField[*]", "1234567890");
            //JObject Restut = getJsonValue1(jsonStr, ".data.lab_jcomp", "8679b7d3-1dfe-4ff6-95cd-0089e06f6375", ".data.lab_jcomp[*].comp");
            Console.WriteLine(Restut.ToString());
            Console.ReadLine();
        }
        /// <summary>
        /// 可通过指定路径获取json指定值或根据返回路径返回json串，也可通过匹配值查询指定值或json串
        /// </summary>
        /// <param name="_json">需要判断的json</param>
        /// <param name="_judgePath">给定的json路径</param>
        /// <param name="_returnPath">返回的json路径</param>
        /// <param name="_matchValue">匹配值</param>
        /// <returns></returns>
        public static JObject GetJsonValue(string _json, string _judgePath, string _returnPath = null, string _matchValue = null)
        {

            JObject Result = JObject.Parse(_json);
            try
            {
                //路径为空或者为根路径
                if (_judgePath == "" || _judgePath == ".")
                {
                    return Result;
                }
                string[] judgePath = _judgePath.Split(".");
                jsonPath = new List<string>(judgePath);
                //去掉 . 
                if (jsonPath[0] == "") { jsonPath.RemoveAt(0); }
                //取路径中数组
                if (jsonPath != null)
                { lastNode = jsonPath[jsonPath.Count - 1]; }

                //遇见数组时，数组内剩下判断的路径
                restPath = new List<string>(jsonPath.ToArray());
                //按路径从顶往下查询并返回所求数据
                foreach (var node in jsonPath)
                {
                    //代表该级是数组，进入数组处理函数
                    if (node.Contains("[") || node.Contains("]"))
                    {
                        Result = shuzu(Result, node, restPath, _matchValue);
                        //当为*后如果不跳出循环，会将后边路径再执行一边（本应是如果有*，剩余路径就将在递归中处理）
                        if (node.Contains("*"))
                        { break; }
                    }
                    else//代表该级是字段，进入字段处理函数
                    {
                        Result = shunxu(Result, node, _matchValue);
                    }
                    //每处理完一级，剩余路径将上一节点砍掉
                    restPath.Remove(node);
                }


                //通过求的数组索引，带入返回路径中求得真实值，进行最终获取
                if (_returnPath != null && Result != null)
                {
                    foreach (var item in ArraryIndex)
                    {
                        string RightNode = item.Key.Replace("*", item.Value.ToString());
                        _returnPath = _returnPath.Replace(item.Key, RightNode);
                    }
                    return getFinallyData(_json, _returnPath, _matchValue);
                }

                //返回值为空，特殊异常处理
                if (Result == null)
                {
                    Result = new JObject();
                }
            }
            catch (Exception ex)
            {

                Result = new JObject { { "错误：", ex.Message } }; ;
            }
            return Result;

        }
        /// <summary>
        /// 根据返回的json路径，解析json
        /// </summary>
        /// <param name="_json">json字符串</param>
        /// <param name="_judgePath">判断路径</param>
        /// <param name="_matchValue">匹配值</param>
        /// <returns></returns>
        public static JObject getFinallyData(string _json, string _judgePath, string _matchValue = null)
        {

            JObject Result = JObject.Parse(_json);
            try
            {
                if (_judgePath == "" || _judgePath == ".")
                {
                    return Result;
                }
                string[] judgePath = _judgePath.Split(".");
                jsonPath = new List<string>(judgePath);
                if (jsonPath[0] == "") { jsonPath.RemoveAt(0); }
                List<string> FinrestPath = new List<string>(jsonPath.ToArray());
                if (jsonPath[0] != "")
                {
                    foreach (var node in jsonPath)
                    {
                        //代表该级是数组，进入数组处理函数
                        if (node.Contains("[") || node.Contains("]"))
                        {
                            Result = shuzu(Result, node, FinrestPath);
                        }
                        else//代表该级是字段，进入字段处理函数
                        {
                            Result = shunxu(Result, node);
                        }
                        //每处理完一级，剩余路径将上一节点砍掉
                        FinrestPath.Remove(node);
                    }
                }
            }
            catch (Exception ex)
            {
                Result = new JObject { { "根据返回路径返回过程错误：", ex.Message } }; ;
            }
            return Result;
        }
        /// <summary>
        /// 顺序处理
        /// </summary>
        /// <param name="_result"></param>
        /// <param name="_node"></param>
        /// <returns></returns>
        public static JObject shunxu(JObject _result, string _node, string _matchValue = null)
        {
            JObject Result = _result;
            try
            {
                if (Result[_node].GetType() == typeof(JObject))
                {
                    Result = (JObject)Result[_node];
                }

                //如果当前节点类型为值，则返回最终结果对象
                else if (Result[_node].GetType() == typeof(JValue))
                {
                    if (_matchValue == null)
                    {
                        return new JObject { { _node, Result[_node] } };
                    }
                    else
                    {
                        if (Result[_node].ToString() == _matchValue)
                        {
                            return new JObject { { _node, Result[_node] } };
                        }
                        else
                        {
                            return null;
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                Result = new JObject { { "顺序过程错误：", ex.Message } }; ;
            }
            return Result;
        }
        /// <summary>
        /// 数组处理
        /// </summary>
        /// <param name="_result"></param>
        /// <param name="_node"></param>
        /// <param name="_restPath"></param>
        /// <param name="_matchValue"></param>
        /// <returns></returns>
        public static JObject shuzu(JObject _result, string _node, List<string> _restPath, string _matchValue = null)
        {

            JObject Result = null;

            try
            {
                //获取数组对象
                string ArrayName = _node.Substring(0, _node.IndexOf('['));
                JArray Aresults = (JArray)_result[ArrayName];
                if (lastNode == _node)
                {
                    Result = new JObject();
                    Result.Add(ArrayName, Aresults);
                    return Result;
                }
                #region 判断[]中值的类型
                int bracket1 = _node.IndexOf('[');
                int bracket2 = _node.IndexOf(']');
                string index = _node.Substring(bracket1 + 1, bracket2 - bracket1 - 1);
                bool IsNum = IndexTypeIsNum(index);
                #endregion

                //*代表数组中查找的值索引未知，需要按照路径末尾Key对应Value和匹配值去匹配
                if (index.Trim() == "*")
                {

                    if (_restPath.Count == 1 && _matchValue == null)
                    {
                        return new JObject { { ArrayName, Aresults } };
                    }
                    //数组索引
                    int i = 0;
                    //当前数组向下判断路径
                    List<string> currentRestPaths = _restPath;
                    //传过来的都带数组Key本身，将该值去掉，为实际剩余路径
                    currentRestPaths.Remove(_node);
                    bool ContainKey = true;
                    //临时数组
                    JObject TempResult = null;
                    //将数组中每个元素当作新对象处理，处理路径为剩余路径
                    foreach (var Aresult in Aresults)
                    {
                        //循环到的数组元素
                        //JObject Oresult = (JObject)Aresult;
                        TempResult = (JObject)Aresult;
                        //循环到数组用到的判断路径
                        List<string> TempRestPaths = new List<string>(currentRestPaths.ToArray());
                        foreach (var node in currentRestPaths)
                        {

                            if (node.Contains("[") || node.Contains("]"))
                            {
                                TempResult = shuzu(TempResult, node, TempRestPaths, _matchValue);
                            }
                            else
                            {
                                ContainKey = false;
                                foreach (var Temp in TempResult)
                                {
                                    ContainKey = Temp.Key.Contains(node);
                                    if (ContainKey) break;
                                }

                                if (ContainKey)
                                {
                                    //如果是最后一级，则不去除该级路径，用于下面判断
                                    if (TempResult[node].GetType() != typeof(JValue)&& TempRestPaths.Count!=1)
                                    { 
                                        TempRestPaths.Remove(node);
                                    }
                                    else if(TempResult[node].GetType() != typeof(JValue) && TempRestPaths.Count == 1)
                                    {
                                        return new JObject {{ ArrayName, Aresults } };
                                    }
                                    TempResult = shunxu(TempResult, node);
                                }
                                else
                                    break;
                                if (TempRestPaths[TempRestPaths.Count - 1] == node && TempResult[node].GetType() == typeof(JValue))
                                {
                                    if (TempResult[node].ToString() == _matchValue)
                                    {

                                        ArraryIndex.Add(_node, i);
                                        Result = (JObject)Aresult;
                                        break;
                                    }
                                }
                            }
                            //TempRestPaths.Remove(node);
                        }
                        if (Result != null)
                        { break; }
                        i++;
                    }
                }
                //如果[]中是数字，则直接取该索引值的对象返回
                else if (IsNum)
                {
                    Result = (JObject)Aresults[Convert.ToInt32(index)];
                }
            }
            catch (Exception ex)
            {

                Result = new JObject { { "数组过程错误：", ex.Message } }; ;
            }
            return Result;
        }

        private static bool IndexTypeIsNum(string index)
        {
            try
            {
                int x = Convert.ToInt32(index);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
