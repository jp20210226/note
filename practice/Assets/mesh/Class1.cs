using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.mesh
{
    /// <summary>
    /// Definition of commands.
    /// </summary>
    enum CommandID
    {
        Abs = 1,
        Sin = 2,
        Sinh = 3,
        Asin = 4,
        Tan = 5,
        Tanh = 6,
        Atan = 7,
        Cos = 8,
        Cosh = 9,
        Acos = 10
    }
    class CommandHandlerTest1
    {
        /// <summary>
        /// Handle the command.
        /// </summary>
        /// <param name="cmdID">The command ID of the command to be handled.</param>
        /// <param name="cmdArg">The command argument of the command to be handled.</param>
        /// <returns>The handle result.</returns>
        public double HandleCommand(CommandID cmdID, double cmdArg)
        {
            double retValue;
            switch (cmdID)
            {
                case CommandID.Abs:
                    retValue = this.HandleDefaultCommand(cmdArg);
                    //retValue = Math.Abs(cmdArg);
                    break;
                case CommandID.Sin:
                    retValue = this.HandleDefaultCommand(cmdArg);
                    //retValue = Math.Sin(cmdArg);
                    break;
                case CommandID.Sinh:
                    retValue = this.HandleDefaultCommand(cmdArg);
                    //retValue = Math.Sinh(cmdArg);
                    break;
                case CommandID.Asin:
                    retValue = this.HandleDefaultCommand(cmdArg);
                    //retValue = Math.Asin(cmdArg);
                    break;
                case CommandID.Tan:
                    retValue = this.HandleDefaultCommand(cmdArg);
                    //retValue = Math.Tan(cmdArg);
                    break;
                case CommandID.Tanh:
                    retValue = this.HandleDefaultCommand(cmdArg);
                    //retValue = Math.Tanh(cmdArg);
                    break;
                case CommandID.Atan:
                    retValue = this.HandleDefaultCommand(cmdArg);
                    //retValue = Math.Atan(cmdArg);
                    break;
                case CommandID.Cos:
                    retValue = this.HandleDefaultCommand(cmdArg);
                    //retValue = Math.Cos(cmdArg);
                    break;
                case CommandID.Cosh:
                    retValue = this.HandleDefaultCommand(cmdArg);
                    //retValue = Math.Cosh(cmdArg);
                    break;
                case CommandID.Acos:
                    retValue = this.HandleDefaultCommand(cmdArg);
                    //retValue = Math.Acos(cmdArg);
                    break;
                default:
                    retValue = this.HandleDefaultCommand(cmdArg);
                    break;
            }

            return retValue;
        }

        /// <summary>
        /// Handle the default command.
        /// </summary>
        /// <param name="cmdArg">The command argument of the default command.</param>
        /// <returns>The handle result.</returns>
        private double HandleDefaultCommand(double cmdArg)
        {
            return 0;
        }
    }

    class CommandHandlerTest2
    {
        /// <summary>
        /// The dictionary contains all the command handlers to handle the commands.
        /// </summary>
        //private Dictionary<CommandID, Func<double, double>> cmdHandlers = new Dictionary<CommandID, Func<double, double>>
        //{
        //    {CommandID.Abs, Math.Abs}, {CommandID.Sin, Math.Sin}, {CommandID.Sinh, Math.Sinh}, {CommandID.Asin, Math.Asin},
        //    {CommandID.Tan, Math.Tan}, {CommandID.Tanh, Math.Tanh}, {CommandID.Atan, Math.Atan}, {CommandID.Cos, Math.Cos},
        //    {CommandID.Cosh, Math.Cosh}, {CommandID.Acos, Math.Acos}
        //};
        private Dictionary<CommandID, Func<double, double>> cmdHandlers;

        public CommandHandlerTest2()
        {
            cmdHandlers = new Dictionary<CommandID, Func<double, double>>
              {
                  {CommandID.Abs, this.HandleDefaultCommand}, {CommandID.Sin, this.HandleDefaultCommand},
                  {CommandID.Sinh, this.HandleDefaultCommand}, {CommandID.Asin, this.HandleDefaultCommand},
                  {CommandID.Tan, this.HandleDefaultCommand}, {CommandID.Tanh, this.HandleDefaultCommand},
                  {CommandID.Atan, this.HandleDefaultCommand}, {CommandID.Cos, this.HandleDefaultCommand},
                  {CommandID.Cosh, this.HandleDefaultCommand}, {CommandID.Acos, this.HandleDefaultCommand}
              };
        }

        /// <summary>
        /// Handle the command.
        /// </summary>
        /// <param name="cmdID">The command ID of the command to be handled.</param>
        /// <param name="cmdArg">The command argument of the command to be handled.</param>
        /// <returns>The handle result.</returns>
        public double HandleCommand(CommandID cmdID, double cmdArg)
        {
            var cmdHandler = this.cmdHandlers.ContainsKey(cmdID) ? this.cmdHandlers[cmdID] : this.HandleDefaultCommand;
            return cmdHandler(cmdArg);
        }

        /// <summary>
        /// Handle the default command.
        /// </summary>
        /// <param name="cmdArg">The command argument of the default command.</param>
        /// <returns>The handle result.</returns>
        private double HandleDefaultCommand(double cmdArg)
        {
            return 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<CommandID> cmdList = new List<CommandID>()
           {
                CommandID.Abs, CommandID.Sin, CommandID.Sinh, CommandID.Asin, CommandID.Tan,
                CommandID.Tanh, CommandID.Atan, CommandID.Cos, CommandID.Cosh, CommandID.Acos
           };

            Stopwatch watch = new Stopwatch();

            watch.Start();
            CommandHandlerTest1 test1 = new CommandHandlerTest1();
            for (int i = 0; i < 1000000; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    test1.HandleCommand(cmdList[j], 0.1);
                }
            }

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            watch.Reset();
            watch.Start();
            CommandHandlerTest2 test2 = new CommandHandlerTest2();
            for (int i = 0; i < 1000000; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    test2.HandleCommand(cmdList[j], 0.1);
                }
            }

            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            Console.ReadLine();
        }
    }




 
}

