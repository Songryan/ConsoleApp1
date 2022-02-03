// 아무리 생각해도 모든 경우의수를 저장하는건 비효율. 폐기처리. 220203 

/*using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace ConsoleApp1
{
    class Program_new
    {
        static void Main(string[] args)
        {
            try
            {
                doSort_new doSort_list_new = new doSort_new();
                List<set_Flask_new> list_F = new List<set_Flask_new>();
                doSort_list_new.defalut_Flask_new(list_F);

                int[] empt_check = doSort_list_new.Listempty_Check(list_F);

                //리스트랑 색갯수 보냄
                if (!(doSort_list_new.validationCheck_new(list_F, (list_F.Count- empt_check[0]) )))
                {
                    Console.WriteLine("플라스크 색, 갯수 오류"); return;
                }

                *//*foreach (set_Flask s in list_F)
                {
                    string str = s.S.Count > 0 ? s.S.Peek() : "없음.";
                    Console.WriteLine($"{s.F_Num} 는 : ${str} 총 크기는 {s.StackNum}");
                }*//*
                var q1 = new Queue<int>();
                //List<Stack<string>> stk_list = new List<Stack<string>>();
                int[,] colarr = doSort_list_new.Add_totColor(list_F);

                Queue<int> pri_f_num = doSort_list_new.PriorityColnum_Search(colarr, list_F.Count - empt_check[0]);


                *//*  if (empt_check[0] == 2) {
                      doSort_list_new.do_repetition_except_new(list_F, q1, empt_check);
                  }
                  else { 
                      doSort_list_new.do_repetition_new(list_F, q1);
                  }*//*

                doSort_list_new.priority_Flask_new(list_F, pri_f_num);
                doSort_list_new.do_repetition_new(list_F, q1);

                int count_q1 = q1.Count / 2;
                //stk_list.Add(stk);


                var q2 = new Queue<int>(); //두번쨰 스택
                var q3 = new Queue<int>(); //담아담아
                int count_q3 = 0;
                for (int a = 0; a < count_q1; a++)
                {
                    list_F.Clear();
                    doSort_list_new.defalut_Flask_new(list_F);
                    doSort_list_new.priority_Flask_new(list_F, pri_f_num);

                    //Console.WriteLine($"{str}");
                    int i = q1.Dequeue();
                    int j = q1.Dequeue();

                    doSort_list_new.change_Flask_new(list_F, i, j); //1번변경

                    doSort_list_new.do_repetition_new(list_F, q2);    //1번에 대한 경우의수 ex 2,2 3,2 4,2
                    int count_q2 = q2.Count / 2;
                    //doSort_list.reverse_Flask(list_F, j, i); // 1번 변경에 대한 되돌리기

                    for (int b = 0; b < count_q2; b++)
                    {
                        q3.Enqueue(i);       //ex 1,1+/2,2     1,1+/3,2      1,1+/4,2
                        q3.Enqueue(j);
                        int p_i = q2.Dequeue();
                        int p_j = q2.Dequeue();
                        q3.Enqueue(p_i);
                        q3.Enqueue(p_j);
                        q3.Enqueue(99); //종결점 ex 1,1 2,2     99     1,1 3,2     99      1,1 4,2     99
                        count_q3 += 2;
                    }

                    //q2.Clear(); //Dequeue이 아니므로 clear
                }

                *//*int aefa = 1;
                foreach (int result in q3) {
                    if (result == 99) continue;
                    if (aefa == 2 || aefa==4) {
                        Console.Write(result);
                        Console.Write("/");
                    } else {
                        Console.Write(result + ",");
                    }
                    if (aefa == 4) {
                        aefa = 0;
                        Console.WriteLine();
                    }
                    aefa++;
                }*//*

            //q1.Clear(); //Dequeue이 아니므로 clear
            //int count_q3 = q3.Count / 2;



            var q4 = new Queue<int>(); //담고 업어지고..!
            var q5 = new Queue<int>(); //담아담아
            var q6 = new Queue<int>();

            for (int k = 0; k < 10; k++)
            {

                if (k != 0) {
                    q3 = new Queue<int>(q5);
                    q5.Clear();  //처음빼곤 clear
                }
                
                Console.WriteLine($"{k+1}번째 q3의 Count는 {count_q3 /2}");
                int count_q_final = count_q3;
                count_q3 = 0;
                for (int c = 0; c < count_q_final; c++)    // ex 1,1/2,2     99     1,1/3,2     99      1,1/4,2     99
                {
                    //ex 1,1  2,2     99 안하고 넘김
                    if (q3.Peek() == 99) {
                        q3.Dequeue();
                        continue;
                    }
                    list_F.Clear();
                    doSort_list_new.defalut_Flask_new(list_F);
                    doSort_list_new.priority_Flask_new(list_F, pri_f_num);

                    do
                    {
                        int p_i = q3.Dequeue();
                        int p_j = q3.Dequeue();
                        doSort_list_new.change_Flask_new(list_F, p_i, p_j);
                        q6.Enqueue(p_i);
                        q6.Enqueue(p_j);
                    } while (q3.Peek() != 99);
                    

                    doSort_list_new.do_repetition_new(list_F, q4);    // ex 1,1/2,2 로변경된거에서 또 돌려
                    int count_q4 = 0;

                    if (q4.Count == 0)
                    {  // 가능한 옮김이 없으면 넘기기

                        if (doSort_list_new.Check_completeYN(list_F)){
                                Console.Write($"완성 : {q6.ToString()}");
                                break;
                        }
                        else { 
                            q4.Clear();
                            q6.Clear();
                            continue;
                        }
                    }
                    else {
                        count_q4 = q4.Count / 2;
                    }

                    for (int d = 0; d < count_q4; d++)
                    {
                        //q5.Enqueue(p_str + "/" + d1_str); // ex 1,1/2,2/4,4      99    1,1/2,2/5,5     99    1,1/2,2/7.7    99
                        foreach (int deQ in q6) {
                            q5.Enqueue(deQ);
                        }
                        q5.Enqueue(q4.Dequeue());
                        q5.Enqueue(q4.Dequeue());
                        q5.Enqueue(99);
                        count_q3 += 2;
                    }
                    q4.Clear();
                    q6.Clear();

                }
                q3.Clear();   //q3이 할일을 다했으므로 

            }

            *//*foreach (int result in q3)
            {
                Console.WriteLine(result);
            }*//*

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
}
*/