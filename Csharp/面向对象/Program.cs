using System;

namespace 面向对象
{
    using System;
    using System.Threading;

    namespace Restaurant
    {
        class Program
        {
            static void Main()
            {
                string[] PeopleName = { "GIN", "Brezee", "Tom", "Tim", "Cool", "998" };
                Customer customer = new Customer(); // customer 事件的拥有者
                Waiter zeroOne = new Waiter(); // zeroOne 事件的响应者

                customer.EnterEventHandler += zeroOne.Welcome; // 进店事件订阅
                                                               // customer.EnterEventHandler += zeroOne.WaiterTotal; // 事件订阅
                customer.OrderEventHandler += zeroOne.OrderHandler; // 点餐事件订阅
                customer.EndOfMealEventHandler += zeroOne.CollectMoney; // 买单事件订阅

                EatEventArgs people1 = new EatEventArgs("GIN");
                Random random = new Random();
                while (true)
                {
                    people1.CustomerName = PeopleName[random.Next(PeopleName.Length)];
                    customer.EnterTheStoreActivation(people1); // 顾客进店

                    people1.OrderRandom(); // 初始化点餐信息
                    customer.OrderActivation(people1); // 顾客点餐

                    customer.EndOfMealEventHandlerActivation(people1); // 顾客买单
                }
            }
        }


        public class EatEventArgs : EventArgs
        {
            public string CustomerName { get; set; } // 客人名字
            public float Price { get; set; } // 消费金额
            public string DishName { get; set; } // 菜名
            public string Measure { get; set; } // 菜量：大份，小份。没有中份   
            public EatEventArgs(string name)
            {
                this.CustomerName = name;
            }


            private string[] DishNameList = { "小炒肉", "红烧肉", "蒜苗火锅肉", "酱肘子", "酸菜鱼", "水煮鱼片" };
            private string[] SizeList = { "Large", "Less" };
            private Random random = new Random();
            public void OrderRandom()
            {
                this.DishName = this.DishNameList[this.random.Next(this.DishNameList.Length)]; // 随机选择菜名
                this.Measure = this.SizeList[this.random.Next(this.SizeList.Length)]; // 随机选择份量
            }
        }


        public delegate void EatEventHandler(Customer obj, EatEventArgs e); // 事件类型声明 有两个参数

        public class Customer
        {
            private event EatEventHandler EnterTheStore; // 客人进店事件字段。 private 不想暴露给外部
            public event EatEventHandler EnterEventHandler // 进店事件属性
            {
                add
                {
                    this.EnterTheStore += value;
                }
                remove
                {
                    this.EnterTheStore -= value;
                }
            }

            public void EnterTheStoreActivation(EatEventArgs people) // 激活客人进店事件
            {
                Console.WriteLine("<客人>  ：{0} 进店", people.CustomerName);
                if (this.EnterTheStore != null) // 检查事件有没有被订阅
                {
                    this.EnterTheStore(this, people);
                }
            }

            private event EatEventHandler Order; // 客人点餐事件字段
            public event EatEventHandler OrderEventHandler // 客人点餐事件属性
            {
                add
                {
                    this.Order += value;
                }
                remove
                {
                    this.Order -= value;
                }
            }

            public void OrderActivation(EatEventArgs people) // 客人开始点餐
            {
                for (byte i = 0; i < 5; i++)
                {
                    Console.WriteLine("<客人>  ：等我看看菜单。。。");
                    Thread.Sleep(1000);
                }

                Console.WriteLine("<客人>  ：来一份 {0}, 份量：{1}.", people.DishName, people.Measure);
                if (this.Order != null)
                {
                    this.Order(this, people);
                    Thread.Sleep(2000);
                }
            }

            private event EatEventHandler End;
            public event EatEventHandler EndOfMealEventHandler
            {
                add
                {
                    this.End += value;
                }
                remove
                {
                    this.End -= value;
                }
            }

            public void EndOfMealEventHandlerActivation(EatEventArgs people) // 客人买单
            {
                Console.WriteLine("<客人>  ：服务员买单。。。");
                if (this.End != null)
                {
                    this.End(this, people);
                }
                else
                {
                    Console.WriteLine("<客人>  ：跑路咯。。。");
                }
            }
        }

        public class Waiter
        {
            // 客人进店事件处理
            public void Welcome(object sender, EatEventArgs e)
            {
                Console.WriteLine("<服务员>：欢迎光临本店：{0}.", e.CustomerName);
                Console.WriteLine("<服务员>：我们这里所有的菜大份 五元， 小份 三元！");
                Console.WriteLine("<服务员>：您需要吃点什么?");
            }

            // 客人点餐事件处理
            public void OrderHandler(object sender, EatEventArgs e)
            {
                Console.WriteLine("<服务员>：您点了 {0}, 份量为：{1}.", e.DishName, e.Measure);
                Console.WriteLine("<服务员>：您请稍等！");
                // 悄悄的先把顾客的帐单记好
                switch (e.Measure)
                {
                    case "Less":
                        e.Price = 3;
                        break;
                    case "Large":
                        e.Price = 5;
                        break;
                    default:
                        break;
                }
                Thread.Sleep(2000);
                Console.WriteLine("<服务员>：您的菜已经好了！请慢用！");
            }

            // 客人买单事件处理
            public void CollectMoney(object sender, EatEventArgs e)
            {
                Console.WriteLine("<服务员>：来了来了！！！");
                Thread.Sleep(2000);
                Console.WriteLine("<服务员>：您点了 {0}, 份量为：{1}.", e.DishName, e.Measure);
                Console.WriteLine("<服务员>：您总共消费 {0} 元！", e.Price);
                Console.WriteLine("<服务员>：等待客户付款 {0} 元", e.Price);
                Console.WriteLine("<服务员>：收到顾客 {0} 的消费款 {1} 元！", e.CustomerName, e.Price);
                Console.WriteLine("<服务员>：{0} 欢迎下次光临！", e.CustomerName);
                Console.WriteLine("<本次服务结束>：------------- End -------------");
            }

            public void WaiterTotal(object sender, EatEventArgs e)
            {
                // 事件处理器可以 根据传入 sender 对象或者 sender 的某些属性， 使用不同 事件处理
                // 一个事件可以被多个事件处理器订阅
                // 一个事件处理器可以订阅多个事件
                // 只要遵循相同的声明类型
                Console.WriteLine("sender:" + sender);
            }
        }
    }
}
