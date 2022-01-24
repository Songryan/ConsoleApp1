using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Start
    {
        /*static void Main(string[] args)
        {
            try {
                doSort doSort_list = new doSort();
                List<set_Flask> list_F = new List<set_Flask>();
                doSort_list.defalut_Flask(list_F);

                //리스트랑 색갯수 보냄
                if (!(doSort_list.validationCheck(list_F, 9)))
                {
                    Console.WriteLine("플라스크 색, 갯수 오류"); return;
                }

                *//*foreach (set_Flask s in list_F)
                {
                    string str = s.S.Count > 0 ? s.S.Peek() : "없음.";
                    Console.WriteLine($"{s.F_Num} 는 : ${str} 총 크기는 {s.StackNum}");
                }*//*
                Stack<string> stk = new Stack<string>();
                //List<Stack<string>> stk_list = new List<Stack<string>>();

                doSort_list.do_repetition(list_F, stk);
                //stk_list.Add(stk);


                Stack<string> stk2 = new Stack<string>(); //두번쨰 스택
                Stack<string> stk3 = new Stack<string>(); //담아담아

                foreach (string str in stk)
                {
                    list_F.Clear();
                    doSort_list.defalut_Flask(list_F);

                    //Console.WriteLine($"{str}");
                    string p_str = str; // 추가될 경우의 수를 담을 string 1,1

                    string[] arr_str = str.Split(",");
                    int i = Int32.Parse(arr_str[0]);
                    int j = Int32.Parse(arr_str[1]);

                    doSort_list.change_Flask(list_F, i, j); //1번변경

                    doSort_list.do_repetition(list_F, stk2);    //1번에 대한 경우의수 ex 2,2 3,2 4,2

                    //doSort_list.reverse_Flask(list_F, j, i); // 1번 변경에 대한 되돌리기

                    foreach (string c_str in stk2)
                    {
                        stk3.Push(p_str + "/" + c_str);       //ex 1,1+/2,2     1,1+/3,2      1,1+/4,2
                        stk3.Push("@"); //종결점 ex 1,1/2,2     @     1,1/3,2     @      1,1/4,2     @
                    }

                    stk2.Clear(); //pop이 아니므로 clear
                }
                stk.Clear(); //pop이 아니므로 clear



                Stack<string> stk4 = new Stack<string>(); //담고 업어지고..!
                Stack<string> stk5 = new Stack<string>(); //담아담아

                for (int k = 0; k < 10; k++)
                {

                    if (k != 0) {
                        stk3 = new Stack<string>(stk5);
                        stk5.Clear();  //처음빼곤 clear
                    }
                    *//*foreach (string str111 in stk3) 
                    {
                        Console.WriteLine($"{str111}");
                    }*//*
                    Console.WriteLine($"{k+1}번째 stk3의 Count는 {stk3.Count}");

                    foreach (string str in stk3)    // ex 1,1/2,2     @     1,1/3,2     @      1,1/4,2     @
                    {
                        if (str.Equals("@")) continue; //ex 1,1 / 2,2     @안하고 넘김

                        list_F.Clear();
                        doSort_list.defalut_Flask(list_F);

                        string p_str = str;

                        string[] d2_arr_str = str.Split("/");       //ex [0]1,1      [1]2,2
                        //int count_cr = 0;   //reverse 할 숫자
                        foreach (string str_split in d2_arr_str)
                        {
                            string[] d1_arr_str = str_split.Split(",");     //ex 1,1
                            int i = Int32.Parse(d1_arr_str[0]);
                            int j = Int32.Parse(d1_arr_str[1]);

                            doSort_list.change_Flask(list_F, i, j); //ex 1,1      2,2 변경
                            //count_cr++;
                        }

                        doSort_list.do_repetition(list_F, stk4);    // ex 1,1/2,2 로변경된거에서 또 돌려

                        if (stk4.Count == 0) {  // 가능한 옮김이 없으면 넘기기
                            continue;
                        }

                        foreach (string d1_str in stk4)
                        {
                            stk5.Push(p_str + "/" + d1_str); // ex 1,1/2,2/4,4       @    1,1/2,2/5,5     @    1,1/2,2/7.7
                            stk5.Push("@");
                        }

                        stk4.Clear();

                        *//*for (int reverse = count_cr - 1; reverse >= 0; reverse--)  //ex     [1]2,2    [0]1,1   reverse는 2로시작
                        {
                            string[] d1_arr_str = d2_arr_str[reverse].Split(","); //ex     [1]2,2
                            int i = Int32.Parse(d1_arr_str[0]);
                            int j = Int32.Parse(d1_arr_str[1]);

                            doSort_list.reverse_Flask(list_F, j, i);
                        }*//*

                    }

                    stk3.Clear();   //stk3이 할일을 다했으므로 

                }

                *//*foreach (string result in stk5)
                {
                    Console.WriteLine(result);
                }*//*


            }

            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

        }*/
    }
}
