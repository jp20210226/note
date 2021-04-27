using System;

namespace virtual方法
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new B();
            a.Say();    //SayB
            a.Speak();  //SpeakA

            B b = new B();
            b.Say();    //SayB
            b.Speak();  //SpeakB

            Console.ReadLine();
        }
    }
 
    public class A
    {
        public virtual void Say()
        {
            Console.WriteLine("SayA");
        }

        public virtual void Speak()
        {
            Console.WriteLine("SpeakA");
        }
    }

    public class B : A
    {
        public void OnlyB()
        {

        }
        public override void Say()
        {
            Console.WriteLine("SayB");
        }

        new   public  void Speak()
        {
            Console.WriteLine("SpeakB");
        }
    }
   

    public class Parent
    {
        protected readonly string name = "wedq";

        public Parent()
        {
            Console.WriteLine(GetNamelen());
        }
        public virtual int GetNamelen()
        {
            return 0;
        }
    }

    public class Child : Parent
    {
        public override  int GetNamelen()
        {
            return base.name.Length; 
        }
    }

}
