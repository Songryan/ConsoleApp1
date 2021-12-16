using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class set_Flask
	{
        public int f_Num;
        public int stackNum;    //총 양
        Dictionary<int, int> color_Num;
        Stack<Dictionary<int, int>> s = new Stack<Dictionary<int, int>>();

    }
    public class tot_colorNum
    {
        public int Tot_colors { get; set; }
        public int start = 1;
        public int Start { get; set; }
        public List<int> col_list;
        public void make_set(List<int> col_list, int Tot_colors)
        {

            for (int i = 0; i < Tot_colors; i++)
            {
                int stNum = start + i;
                col_list.Add(stNum);
            }

        }

    }
}
