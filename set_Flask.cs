using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class set_Flask
    {
        private int f_Num;              //플라스크고유번호
        private int stackNum;        //총량
        Dictionary<int, int> color_Num;             //색번호, 크기
        Stack<Dictionary<int, int>> s = new Stack<Dictionary<int, int>>();

        public set_Flask(int f_Num, int stackNum, Dictionary<int, int> color_Num, Stack<Dictionary<int, int>> s)
        {
            this.f_Num = f_Num;
            this.stackNum = stackNum;
            this.color_Num = color_Num;
            this.s = s;
        }

        public int F_Num { get => f_Num; set => f_Num = value; }
        public int StackNum { get => stackNum; set => stackNum = value; }
        public Dictionary<int, int> Color_Num { get => color_Num; set => color_Num = value; }
        public Stack<Dictionary<int, int>> S { get => s; set => s = value; }
        
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
