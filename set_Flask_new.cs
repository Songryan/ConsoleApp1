using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class set_Flask_new
    {
        private int f_Num;              //플라스크고유번호
        private int stackNum;        //총량
        Stack<int> s = new Stack<int>();

        public set_Flask_new(int f_Num, int stackNum, Stack<int> s)
        {
            this.f_Num = f_Num;
            this.stackNum = stackNum;
            this.s = s;
        }

        public int F_Num { get => f_Num; set => f_Num = value; }
        public int StackNum
        {
            get => stackNum;
            set
            {
                if (value > 4 || value < 0)
                { Console.Write("최대량 4를 초과된 양 또는 0이하의 값이 입력되었습니다."); }
                else { stackNum = value; }
            }
        }

        public Stack<int> S { get => s; set => s = value; }
    }
    
}
