using System;

namespace 类通过接口依赖
{
    class Program
    {
        static void Main()
        {
            A a = new A();
            a.depend1(new B());//A类通过接口去依赖 
            a.depend2(new B());
            a.depend3(new B());

            C c = new C();
            c.depend1(new D());
            c.depend4(new D());
            c.depend5(new D());
        }
    }

    class B : Iface1, Iface2
    {
        public void operate1()
        {
            Console.WriteLine("B实现了operate1");
        }

        public void operate2()
        {
            Console.WriteLine("B实现了operate2");
        }

        public void operate3()
        {
            Console.WriteLine("B实现了operate3");
        }


    }

    class D : Iface1, Iface3
    {
        public void operate1()
        {
            Console.WriteLine("D实现了operate1");
        }

        public void operate4()
        {
            Console.WriteLine("D实现了operate4");
        }

        public void operate5()
        {
            Console.WriteLine("D实现了operate5");
        }
    }

    interface Iface1
    {
        void operate1();

    }

    interface Iface2
    {
        void operate2();
        void operate3();
    }

    interface Iface3
    {
        void operate4();
        void operate5();
    }

    class A
    {
        public void depend1(Iface1 i)
        {
            i.operate1();
        }

        public void depend2(Iface2 i)
        {
            i.operate2();
        }
        public void depend3(Iface2 i)
        {
            i.operate3();
        }
    }

    class C
    {
        public void depend1(Iface1 i)
        {
            i.operate1();
        }

        public void depend4(Iface3 i)
        {
            i.operate4();
        }
        public void depend5(Iface3 i)
        {
            i.operate5();
        }
    }
}
