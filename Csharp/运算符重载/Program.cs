using System;

namespace 运算符重载
{
    public class Box
    {

        float _Length;
        float _Width;
        float _Hight;
        public void setLength(float len)
        {
            _Length = len;
        }

        public void setBreadth(float bre)
        {
            _Width = bre;
        }

        public void setHeight(float hei)
        {
            _Hight = hei;
        }
        public static Box operator +(Box a, Box b)
        {
            Box box = new Box();
            box._Length = a._Length + b._Length;
            box._Width = a._Width + b._Width;
            box._Hight = a._Hight + b._Hight;
            return box;
        }
        public static bool operator ==(Box a, Box b)
        {
            if ((a._Length == b._Length) && (a._Width == b._Width) && (a._Hight == b._Hight))
            {
                return true;
            }
            else
                return false;
        }


        public static bool operator !=(Box a, Box b)
        {
            if ((a._Length != b._Length) || (a._Width != b._Width) || (a._Hight != b._Hight))
            {
                return true;
            }
            else
                return false;
        }
        public double getVolume()
        {
            return _Length * _Width * _Hight;
        }

        public override bool Equals(object obj)
        {
            return obj is Box box &&
                   _Length == box._Length &&
                   _Width == box._Width &&
                   _Hight == box._Hight;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Box Box1 = new Box();         // 声明 Box1，类型为 Box
            Box Box2 = new Box();         // 声明 Box2，类型为 Box
            Box Box3 = new Box();

            Box1.setLength(6.0f);
            Box1.setBreadth(6.0f);
            Box1.setHeight(6.0f);

            // Box2 详述
            Box2.setLength(6.0f);
            Box2.setBreadth(6.0f);
            Box2.setHeight(10.0f);

            Box3 = Box1 + Box2;
            Console.WriteLine("{0}", Box2 != Box3);
        }
    }
    }
