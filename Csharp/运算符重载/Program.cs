using System;
using System.Data.SqlTypes;
using System.Reflection.Metadata.Ecma335;

namespace 运算符重载
{
    #region 普通运算符重载
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Note B = new Note(2);
    //        Note sharp = B + 2;
    //        sharp += 2;
    //    }
    //}

    //public struct Note
    //{
    //    public int value;

    //    public Note(int semitonesFromA)
    //    {
    //        value = semitonesFromA;
    //    }

    //    public static Note operator +(Note x, int semitones)
    //    {
    //        return new Note(x.value + semitones);
    //    }

    //    public static bool operator >(Note x, int semitones)
    //    {
    //        return x.value > semitones;
    //    }
    //    public static bool operator <(Note x, int semitones)
    //    {
    //        return x.value < semitones;
    //    }
    //    //public  static  Note operator +(Note x, int semitones) =>  new Note(x.value+semitones);
    //}
    #endregion

    #region 隐式（implicit）显示（explicit）运算符重载
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Note n = (Note) 554.37;//显示转换;
    //        double x = n;//隐式转换;
    //        //Note n1 = 554.37 as Note;//编译器报错 554.37不是引用类型或者可空值类型
    //    }
    //}

    //public struct Note
    //{
    //    public int value;

    //    public Note(int semitonesFromA)
    //    {
    //        value = semitonesFromA;
    //    }
    //    //隐式转化 
    //    public static implicit operator double(Note x) => 440 * Math.Pow(2, (double) x.value / 2);
    //    //显示转化 
    //    public static explicit operator Note(double x) => new Note((int) (0.5 + 12 * (Math.Log(x / 440 / Math.PI))));

    //}
    #endregion

    #region true 和 false运算符重载
    class Program
    {
        static void Main(string[] args)
        {
            SqlBoolean a= SqlBoolean.Null;
            if (a)
            {
                Console.WriteLine("true");
            }
            else if (!a)
            {
                Console.WriteLine("false");
            }
            else
            {
                Console.WriteLine("Null");
            }
        }
    }

    //public struct SqlBoolean
    //{
    //    public static readonly SqlBoolean Null = new SqlBoolean(0);
    //    public static readonly SqlBoolean False = new SqlBoolean(1);
    //    public static readonly SqlBoolean True = new SqlBoolean(2);
    //    public static bool operator true(SqlBoolean x) => x.m_value == True.m_value;
    //    public static bool operator false(SqlBoolean x) => x.m_value == False.m_value;

    //    public static SqlBoolean operator !(SqlBoolean x)
    //    {
    //        if(x.m_value == Null.m_value) return  Null;
    //        if (x.m_value == False.m_value) return True;
    //        return False;
    //    }

    //    private byte m_value;

    //    private SqlBoolean(byte value)
    //    {
    //        m_value = value;
    //    }
    //}
    #endregion

    }
