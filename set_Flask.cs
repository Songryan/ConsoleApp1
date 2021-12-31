using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class set_Flask
    {
        private int f_Num;              //플라스크고유번호
        private int stackNum;        //총량
        Stack<string> s = new Stack<string>();

        public set_Flask(int f_Num, int stackNum, Stack<string> s)
        {
            this.f_Num = f_Num;
            this.stackNum = stackNum;
            this.s = s;
        }

        public int F_Num { get => f_Num; set => f_Num = value; }
        public int StackNum { get => stackNum;
            set {
                if (value > 4) { Console.Write("최대량 4를 초과된 양이 입력되었습니다.");  }
                else {stackNum = value;}
            }
        }

        public Stack<string> S { get => s; set => s = value; }

    }

    public class tot_colorNum
    {
        public int Tot_colors { get; set; }
        public int Start { get; set; }
        public List<int> col_list;
        public void make_set(List<int> col_list, int Tot_colors)
        {
            int start = 1;
            for (int i = 0; i < Tot_colors; i++)
            {
                int stNum = start + i;
                col_list.Add(stNum);
            }

        }
    }

    public class prepare
    {
        
    }
}
