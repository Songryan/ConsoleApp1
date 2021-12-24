using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Start
    {
        static void Main(string[] args)
        {
            //플라스크맨들고 array로 값넘김.
            //prepare();
            //넘겨받은값으로 경우의수 
            //doSort();
            //경우의수 체크해서 출력
            //printResult();

             int f_Num1 = 1;              //플라스크고유번호
             int stackNum1 = 4;        //총량
            Dictionary<int, int> color_Num1 = new Dictionary<int, int>();             //색번호, 크기
            
            //역순으로 push되게.
            color_Num1.Add(4, 1);
            color_Num1.Add(3, 1);
            color_Num1.Add(2, 1);
            color_Num1.Add(1, 1);

            Stack<Dictionary<int, int>> s = new Stack<Dictionary<int, int>>();
            
        }
    }
}
