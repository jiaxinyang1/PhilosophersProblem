using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhilosophersProblem
{
    class Philosopher
    {
        /// <summary>
        /// 左右手是否拿到筷子
        /// </summary>
        public bool IsRightHand { get; set; } = false;
        public bool IsLeftHand { get; set; } = false;

        public int number;
        /// <summary>
        /// 吃饭
        /// </summary>
        /// <param name="i"></param>
        
        public void Eat(int i)
        {
            Console.WriteLine("哲学家{0}正在吃饭....",i);
        }
        /// <summary>
        /// 思考
        /// </summary>
        /// <param name="i"></param>
        public void Think(int i)
        {
            Console.WriteLine("哲学家{0}正在思考....", i);
        }

        public Philosopher(int i)
        {
            number = i;
        }
    }
}
