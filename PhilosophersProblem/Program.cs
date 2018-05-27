using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PhilosophersProblem
{
    class A
    {
        /// <summary>
        /// 同时允许4个哲学家入座
        /// </summary>
        private int r = 0;
        /// <summary>
        /// 定义挂起事件
        /// </summary>
        ManualResetEvent[] phiolosopheResetEvent = new ManualResetEvent[5];
        /// <summary>
        /// 定义筷子使用状态
        /// </summary>
        private bool[] fork = new bool[5];
        /// <summary>
        /// 定义哲学家
        /// </summary>
        Philosopher[] philosophers = new Philosopher[5];
        /// <summary>
        /// 初始化变量
        /// </summary>
        void init()
        {

            for (int i = 0; i < 5; i++)
            {
                fork[i] = false;
                phiolosopheResetEvent[i] = new ManualResetEvent(false);
                philosophers[i] = new Philosopher(i);
            }
        }

        public void run(object index)
        {
            int i = (int) index;
           
            while (true)
            {
                ///思考
                philosophers[i].Think(i);
                if (r >= 4)
                {
                    ///如果已经有四个哲学家则挂起
                    Console.WriteLine("{0}号哲学家准备进入饭桌，但是已经有四个哲学家在饭桌上了！",i);
                phiolosopheResetEvent[i].WaitOne();
                }
                ///人数增加
                r++;
                if (fork[i] == true)
                {
                    // philosophers[i].IsRightHand = true;
                    ///如果筷子被使用则挂起线程
                    Console.WriteLine("正在等待其他哲学家释放筷子");
                    Thread.Sleep(500);
                    phiolosopheResetEvent[i].WaitOne();

                }
                ///拿起右手边筷子

                fork[i] = true;


                if (fork[(i + 1) % 5] == true)
                {
                    // philosophers[i].IsLeftHand = true;
                    ///如果筷子被使用则挂起线程
                    Console.WriteLine("正在等待其他哲学家释放筷子");
                    Thread.Sleep(500);
                    phiolosopheResetEvent[i].WaitOne();

                }
                ///拿起左手边筷子
                fork[(i + 1) % 5] = true;
                /// 吃饭
                Console.WriteLine("{0}号哲学家筷子准备完毕,开始吃饭",i);
                Thread.Sleep(500*(i+1));
                philosophers[i].Eat(i);
                ///吃饭完毕 离开减少
                Console.WriteLine("{0}吃饭完毕，离开桌子",i);
                r--;
                ///吃饭完毕释放筷子使用权
                /// //唤起左右手的人使用筷子
              //  Console.WriteLine("哲学家{0}吃饭完毕，释放筷子",i);
                fork[i] = false;
                phiolosopheResetEvent[RightGetnumber(i)].Set();
                fork[(i + 1) % 5] = false;
                phiolosopheResetEvent[LeftGetnumber(i)].Set();
            
            }

        }

        int LeftGetnumber(int i)
        {
            if (i == 4)
            {
                return 0;
            }
            else
            {
                return i + 1;
            }
        }
        int RightGetnumber(int i)
        {
            if (i == 0)
            {
                return 4;
            }
            else
            {
                return i - 1;
            }
        }

        public void lunch()
        {
            init();
            Thread[] philosooherThreads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                philosooherThreads[i]= new Thread(new ParameterizedThreadStart(run));
             
            }

         
            {
                for (int i = 0; i < 5; i++)
                {
                    philosooherThreads[i].Start(i);
                }
             
            }
          
             

       
           
        }
    }

    class Program
    {
      
        static void Main(string[] args)
        {
            A test=new A();


                test.lunch();
 
        
     
        }
    }
}
