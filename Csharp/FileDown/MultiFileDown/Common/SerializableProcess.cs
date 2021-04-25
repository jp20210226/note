using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MultiFileDown.Common
{
    public class SerializableProcess
    {
        public static bool SaveListClass<T>(string filename, T pListClass)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, pListClass);

                return true;
            }
            catch (Exception)
            {
                //MessageBox.Show("保存失败！！！" + ex.Message);
                return false;
            }
            finally
            {

                if (fs != null)
                    fs.Close();
            }
        }

        public static T LoadListClass<T>(string filename)            //序列化读取文件
        {
            FileStream fs = null;
            T ListClass = default(T);
            try
            {
                fs = new FileStream(filename, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                ListClass = (T)bf.Deserialize(fs);
            }
            catch (Exception)
            {
                //MessageBox.Show("读取失败！！！" + ex.Message);
                //return null;
            }
            finally
            {
                if (fs != null)
                    fs.Close();

            }
            return ListClass;
        }
    }
}
