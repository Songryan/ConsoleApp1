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

            //1번
            Stack<string> f_col1 = new Stack<string>();
            f_col1.Push("4,1");
            f_col1.Push("3,1");
            f_col1.Push("2,1");
            f_col1.Push("1,1");
            //플라스크고유번호//총량//색,크기
            set_Flask f1 = new set_Flask(1, 4, f_col1);

            //2번
            Stack<string> f_col2 = new Stack<string>();
            f_col2.Push("7,2");
            f_col2.Push("6,1");
            f_col2.Push("5,1");
            //플라스크고유번호//총량//색,크기
            set_Flask f2 = new set_Flask(2, 4, f_col2);

            //3번
            Stack<string> f_col3 = new Stack<string>();
            f_col3.Push("4,1");
            f_col3.Push("2,1");
            f_col3.Push("5,1");
            f_col3.Push("1,1");
            //플라스크고유번호//총량//색,크기
            set_Flask f3 = new set_Flask(3, 4, f_col3);

            //4번
            Stack<string> f_col4 = new Stack<string>();
            f_col4.Push("8,1");
            f_col4.Push("4,1");
            f_col4.Push("9,1");
            f_col4.Push("2,1");
            //플라스크고유번호//총량//색,크기
            set_Flask f4 = new set_Flask(4, 4, f_col4);

            //5번
            Stack<string> f_col5 = new Stack<string>();
            f_col5.Push("3,1");
            f_col5.Push("4,1");
            f_col5.Push("7,1");
            f_col5.Push("2,1");
            //플라스크고유번호//총량//색,크기
            set_Flask f5 = new set_Flask(5, 4, f_col5);

            //6번
            Stack<string> f_col6 = new Stack<string>();
            f_col6.Push("6,1");
            f_col6.Push("9,1");
            f_col6.Push("5,1");
            f_col6.Push("3,1");
            //플라스크고유번호//총량//색,크기
            set_Flask f6 = new set_Flask(6, 4, f_col6);

            //7번
            Stack<string> f_col7 = new Stack<string>();
            f_col7.Push("1,2");
            f_col7.Push("9,1");
            f_col7.Push("8,1");
            //플라스크고유번호//총량//색,크기
            set_Flask f7 = new set_Flask(7, 4, f_col7);

            //8번
            Stack<string> f_col8 = new Stack<string>();
            f_col8.Push("8,1");
            f_col8.Push("7,1");
            f_col8.Push("3,1");
            f_col8.Push("9,1");
            //플라스크고유번호//총량//색,크기
            set_Flask f8 = new set_Flask(8, 4, f_col8);

            //9번
            Stack<string> f_col9 = new Stack<string>();
            f_col9.Push("8,1");
            f_col9.Push("5,1");
            f_col9.Push("6,2");
            //플라스크고유번호//총량//색,크기
            set_Flask f9 = new set_Flask(9, 4, f_col9);

            //10번
            Stack<string> f_col10 = new Stack<string>();
            //플라스크고유번호//총량//색,크기
            set_Flask f10 = new set_Flask(10, 0, f_col10);

            //11번
            Stack<string> f_col11 = new Stack<string>();
            //플라스크고유번호//총량//색,크기
            set_Flask f11 = new set_Flask(11, 0, f_col11);

            List<set_Flask> list_F = new List<set_Flask>();
            list_F.Add(f1);
            list_F.Add(f2);
            list_F.Add(f3);
            list_F.Add(f4);
            list_F.Add(f5);
            list_F.Add(f6);
            list_F.Add(f7);
            list_F.Add(f8);
            list_F.Add(f9);
            list_F.Add(f10);
            list_F.Add(f11);

            List<set_Flask> list_F2 = new List<set_Flask>();
            list_F2.Add(f1);
            list_F2.Add(f2);
            list_F2.Add(f3);
            list_F2.Add(f4);
            list_F2.Add(f5);
            list_F2.Add(f6);
            list_F2.Add(f7);
            list_F2.Add(f8);
            list_F2.Add(f9);
            list_F2.Add(f10);
            list_F2.Add(f11);

            doSort doSort_list = new doSort();
            //리스트랑 색갯수 보냄
            if (!(doSort_list.validationCheck(list_F, 9)))
            {
                Console.WriteLine("플라스크 색, 갯수 오류"); return;
            }

            Stack<List<set_Flask>> save_set_flask = new Stack<List<set_Flask>>();
            //변경된 플라스크셋 저장 stack

            //i를 j로 옮겨진것에 성공했다면, 0. 히스토리와 1. 현재 상태를 저장하고, 2. 그 상태에서 파생시켜 다시 돌리기.
            for (int i = 0; i < list_F.Count; i++)
            {
                for (int j = 0; j < list_F.Count; j++)
                {
                    // 반복 시작
                    if (i != j)
                    {
                        if (doSort_list.check_moveCol(list_F[i], list_F[j])) //이동가능한지 여부체크
                        {
                            save_set_flask.Push(doSort_list.change_Flask(list_F2, i, j));   // 원본은 그대로두고 f2에 변경 저장
                            Console.WriteLine($"변경 후 list_F2 ..... i는 : {list_F2[i].ToString()}, j는 : {list_F2[j].ToString()}");
                            //초기상태로 되돌려서 변경점 리스트만 저장하기. (깊은복사) F데이터를 F2에 복사
                            list_F2.Clear();
                            list_F2 = list_F.ConvertAll(obj => new set_Flask(obj.F_Num,obj.StackNum,obj.S));
                            Console.WriteLine($"복사 후 list_F2 ..... i는 : {list_F2[i].ToString()}, j는 : {list_F2[j].ToString()}");
                        }
                        else  //이동 불가 판정
                        {

                            //불가해도  패스
                        }
                    }
                    else if (i == j)
                    {
                        //같으면 패스
                    }
                }
            }


        }
    }
}
