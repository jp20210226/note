using System;

namespace 枚举
{
    public enum Common 
    {
        None = 0,    
        Left = 1,    
        Right = 2,   
        Top = 3,     
        Bottom = 4  
    }

    /// <summary>
    /// 最多到255
    /// </summary>
    public enum Test:byte
    {
        None = 0,   //0000 0000
        Left = 1,   //0000 0001
        Right = 2,  //0000 0010
        Top = 3,    //0000 0100
        Bottom = 4 //0000 1000
    } 

    [Flags]
    /*
    1、按约定,如果枚举成员可组合的话,flags属性就应该应用在枚举类型上
    如果声明了这样的枚举却没有使用flags属性,你仍然可以组合枚举的成员,但是
    调用枚举实例的 ToString 方法时,输出的将是一个数值而不是一组名称。
    按约定,可组合枚举的名称应该是复数
    2、在声明可组合枚举的时候,可以直接使用组合的枚举成员作为成员
    */
    public enum BorderSides
    {
        None =0,   //0000 0000
        Left =1,   //0000 0001
        Right =2,  //0000 0010
        Top =4,    //0000 0100
        Bottom = 8, //0000 1000
        LeftRight = Left |  Right,
        TopBottom = Top| Bottom,
        All= LeftRight| TopBottom
    } 
    class Program
    {
        static void Main(string[] args)
        {
            
            BorderSides leftright = BorderSides.Left | BorderSides.Right;
            Console.WriteLine(leftright.ToString());

            var b = BorderSides.Top | BorderSides.Right | BorderSides.Bottom;
            /*
            Top         0000 0100
            Right       0000 0010
            Bottom      0000 1000
            ---------------------
            b:          0000 1110
            */

            Console.WriteLine(b.ToString());
            var c = b & BorderSides.Right;
            /*
            b           0000 1110
            Right       0000 0010
            ---------------------
            b:          0000 0010
            */
            Console.WriteLine(c.ToString());


            //检查枚举值的合理性: Enum.dEfined)静态方法
            Common test = (Common) 12345;
            Console.WriteLine(Enum.IsDefined(typeof(Test), test)); // False
        }
    }
}
