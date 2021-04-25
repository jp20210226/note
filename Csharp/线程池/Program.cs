using System;
using System.Threading;
//定义对象类，用以包装参数，实现多个参数的传递
class Packet
{
    //成员属性包括两个输入参数和一个输出参数
    protected internal String inval1;
    protected internal String inval2;
    protected internal String outval;
}
class ThreadPoolExam
{
    //定义执行相同内容的两个方法
    public void Task1(object Obj)
    {
        //声明Packet类对象，用以传递参数
        Packet PacketObj;
        PacketObj = (Packet)Obj;
        Console.WriteLine("任务一中的第一个输入参数：" + PacketObj.inval1);
        Console.WriteLine("任务一中的第二个输入参数：" + PacketObj.inval2);
        //为输出参数赋值
        PacketObj.outval = PacketObj.inval1 + " " + PacketObj.inval2;
    }
    public void Task2(object Obj)
    {
        Packet PacketObj;
        PacketObj = (Packet)Obj;
        Console.WriteLine("任务二中的第一个输入参数：" + PacketObj.inval1);
        Console.WriteLine("任务二中的第二个输入参数：" + PacketObj.inval2);

        PacketObj.outval = PacketObj.inval1 + " " + PacketObj.inval2;
    }
    static void Main()
    {
        ////声明两个Packet对象，并为输入参数赋值
        //Packet PacketObj1 = new Packet();
        //Packet PacketObj2 = new Packet();
        //PacketObj1.inval1 = "Task 1 - 1";
        //PacketObj1.inval2 = "Task 1 - 2";
        //PacketObj2.inval1 = "Task 2 - 1";
        //PacketObj2.inval2 = "Task 2 - 2";
        //ThreadPoolExam tps = new ThreadPoolExam();
        ////将方法放入线程池的队列中
        //ThreadPool.QueueUserWorkItem(new WaitCallback(tps.Task1), PacketObj1);
        //ThreadPool.QueueUserWorkItem(new WaitCallback(tps.Task2), PacketObj2);
        //Console.ReadLine();

        int workerThreads;
        int completionPortThreads;
        ThreadPool.GetMaxThreads(out  workerThreads, out  completionPortThreads);
        Console.WriteLine("workerThreads:{0},completionPortThreads:{1}", workerThreads, completionPortThreads);
    }
}