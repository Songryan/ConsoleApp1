using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
	
    public class doSort
	{

        public Boolean validationCheck(List<set_Flask> list_Flask,int col_num)	// 색과 색의총수가 4개인지 체크
		{
			bool result = true;
			int[] sum_num = new int[col_num];
			foreach (set_Flask sf in list_Flask)
			{
				int cnt = (sf.S).Count;
				foreach (string ss in sf.S)
				{
					if (cnt != 0)
					{
						string[] set = ss.Split(",");
						int col_Num = Int32.Parse(set[0]);
						int col_Quantity = Int32.Parse(set[1]);
						// 색번호 index에 Quantity채움.
						sum_num[col_Num - 1] += col_Quantity;
					}
				}
			}
			int index = 1;
			foreach (int four in sum_num) 
			{
				if (four != 4) 
				{
					Console.WriteLine("색번호 : " + index + " 총량 : " + four);
					result = false;
				}
				index++;
			}

				return result;
		}

		public bool check_moveCol(set_Flask sel_F, set_Flask chk_F)	//이동할지 말지 체크 (속도향상을위해)
		{
			bool result = true;

			// 1 둘다 빈거면 나가리
			if(sel_F.StackNum == 0 && chk_F.StackNum == 0) return false;

			// 2 선택된 Flask에 뽑을게 없으면 나가리
			if (sel_F.StackNum == 0) return false;

			// 3 chk의 총량이 4면 나가리
			if (chk_F.StackNum == 4) return false;

			// chk가 빈거면 freepass // 4개를 무의미하게 옮기는거면 의미가 없음.
			//if (chk_F.StackNum == 0) return true;

			//꺼내서 비교.
			string sel = sel_F.S.Peek();

			string[] set1 = sel.Split(",");
			int sel_Num = Int32.Parse(set1[0]);
			int sel_Quantity = Int32.Parse(set1[1]);

			int chk_stackNum = chk_F.StackNum;
			string chk = "";
			int chk_Num = 0;
			int chk_Quantity =0;
			if (chk_stackNum == 0)  // chk가 빈거면
			{  
				//sel_F.S.Push(sel);  //pop 했던거 다시 넣어주기.
				return true;
			}
			else
			{	
				chk = chk_F.S.Peek();
				string[] set2 = chk.Split(",");
				chk_Num = Int32.Parse(set2[0]);
				chk_Quantity = Int32.Parse(set2[1]);
			}

			//pop 했던거 다시 넣어주기.
			//sel_F.S.Push(sel);
			//chk_F.S.Push(chk);

			//4 색이 다르거나, 넘어간 후 총량이 4보다 크면 나가리
			if (sel_Num != chk_Num || (chk_stackNum + sel_Quantity) >= 5) return false;

			//5 옮기려는게 색하나에 4개면 쓸대없는 무빙.
			if(sel_Quantity == 4) return false;

			return result;
		}

		public List<set_Flask> change_Flask(List<set_Flask> new_list ,int i ,int j)	// 부을 수 있다면 붇기!
		{
			string[] i_Flask = new_list[i].S.Pop().Split(",");
			int i_col_num = Int32.Parse(i_Flask[0]);		//check_moveCol에서 색체크함
			int i_col_quantity = Int32.Parse(i_Flask[1]);
			new_list[i].StackNum = new_list[i].StackNum - i_col_quantity;     // 부은 후 총량감소.

			int j_col_num = 0;
			int j_col_quantity = 0;
			if (new_list[j].StackNum == 0) // new_list[j]가 빈거면
			{
				j_col_num = i_col_num;
				j_col_quantity = i_col_quantity;
				new_list[j].StackNum = i_col_quantity;     // i 량만큼 총량 증가.
				new_list[j].S.Push(j_col_num.ToString() + "," + j_col_quantity.ToString());
			}
			else 
			{
				string[] j_Flask = new_list[j].S.Pop().Split(",");  //일단 꺼낸다음 다시 푸쉬로 넣기.
				j_col_num = Int32.Parse(j_Flask[0]);
				j_col_quantity = Int32.Parse(j_Flask[1]);
				new_list[j].StackNum = new_list[j].StackNum + i_col_quantity;     // i 량만큼 총량 증가.
				j_col_quantity = j_col_quantity + i_col_quantity;           // i량만큼 j량 증가.
				new_list[j].S.Push(j_col_num.ToString() + "," + j_col_quantity.ToString());	// 증가시킨 색다시 푸쉬.
			}

			return new_list;
		}
		//i를 j로 옮겨진것에 성공했다면, 0. 히스토리와 1. 현재 상태를 저장하고, 2. 그 상태에서 파생시켜 다시 돌리기.

		public void do_repetition(List<set_Flask> list_F, Stack<string> stk)
		{
			for (int i = 0; i < list_F.Count; i++)
			{
				for (int j = 0; j < list_F.Count; j++)
				{
					// 반복 시작
					if (i != j)
					{
						if (check_moveCol(list_F[i], list_F[j])) //이동가능한지 여부체크
						{
							stk.Push(i + "," + j);
							//change_Flask(list_F, i, j);   // 원본은 그대로두고 f2에 변경 저장
							//Console.WriteLine($"변경 후 list_F2\ni번호 : {i + 1}, {list_F[i].S.Peek()}, 총크기 : {list_F[i].StackNum}, \nj번호 : {j + 1}, {list_F[j].S.Peek()}, 총크기 :  {list_F[j].StackNum}");
							//reverse_Flask(list_F, j, i);    //다시 j들어서 i에 붓기
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

		public void reverse_Flask(List<set_Flask> new_list, int i, int j)
		{
			string[] i_Flask = new_list[i].S.Pop().Split(",");
			int i_col_num = Int32.Parse(i_Flask[0]);        //check_moveCol에서 색체크함
			int i_col_quantity = Int32.Parse(i_Flask[1]);
			new_list[i].StackNum = new_list[i].StackNum - i_col_quantity;     // 부은 후 총량감소.

			int j_col_num = 0;
			int j_col_quantity = 0;
			if (new_list[j].StackNum == 0) // new_list[j]가 빈거면
			{
				j_col_num = i_col_num;
				j_col_quantity = i_col_quantity;
				new_list[j].StackNum = i_col_quantity;     // i 량만큼 총량 증가.
				new_list[j].S.Push(j_col_num.ToString() + "," + j_col_quantity.ToString());
			}
			else
			{
				string[] j_Flask = new_list[j].S.Pop().Split(",");  //일단 꺼낸다음 다시 푸쉬로 넣기.
				j_col_num = Int32.Parse(j_Flask[0]);
				j_col_quantity = Int32.Parse(j_Flask[1]);
				new_list[j].StackNum = new_list[j].StackNum + i_col_quantity;     // i 량만큼 총량 증가.
				j_col_quantity = j_col_quantity + i_col_quantity;           // i량만큼 j량 증가.
				new_list[j].S.Push(j_col_num.ToString() + "," + j_col_quantity.ToString()); // 증가시킨 색다시 푸쉬.
			}
		}


		public void defalut_Flask(List<set_Flask> list_F) 
		{
			//1번
			Stack<string> f_col1 = new Stack<string>();
			Stack<string> f_col1_1 = new Stack<string>();
			f_col1.Push("4,1");
			f_col1.Push("3,1");
			f_col1.Push("2,1");
			f_col1.Push("1,1");
			f_col1_1.Push("4,1");
			f_col1_1.Push("3,1");
			f_col1_1.Push("2,1");
			f_col1_1.Push("1,1");
			//플라스크고유번호//총량//색,크기
			set_Flask f1_0 = new set_Flask(1, 4, f_col1);
			set_Flask f1_1 = new set_Flask(1, 4, f_col1_1);


			//2번
			Stack<string> f_col2 = new Stack<string>();
			Stack<string> f_col2_1 = new Stack<string>();
			f_col2.Push("7,2");
			f_col2.Push("6,1");
			f_col2.Push("5,1");
			f_col2_1.Push("7,2");
			f_col2_1.Push("6,1");
			f_col2_1.Push("5,1");
			//플라스크고유번호//총량//색,크기
			set_Flask f2_0 = new set_Flask(2, 4, f_col2);
			set_Flask f2_1 = new set_Flask(2, 4, f_col2_1);

			//3번
			Stack<string> f_col3 = new Stack<string>();
			Stack<string> f_col3_1 = new Stack<string>();
			f_col3.Push("4,1");
			f_col3.Push("2,1");
			f_col3.Push("5,1");
			f_col3.Push("1,1");
			f_col3_1.Push("4,1");
			f_col3_1.Push("2,1");
			f_col3_1.Push("5,1");
			f_col3_1.Push("1,1");
			//플라스크고유번호//총량//색,크기
			set_Flask f3_0 = new set_Flask(3, 4, f_col3);
			set_Flask f3_1 = new set_Flask(3, 4, f_col3_1);

			//4번
			Stack<string> f_col4 = new Stack<string>();
			Stack<string> f_col4_1 = new Stack<string>();
			f_col4.Push("8,1");
			f_col4.Push("4,1");
			f_col4.Push("9,1");
			f_col4.Push("2,1");
			f_col4_1.Push("8,1");
			f_col4_1.Push("4,1");
			f_col4_1.Push("9,1");
			f_col4_1.Push("2,1");
			//플라스크고유번호//총량//색,크기
			set_Flask f4_0 = new set_Flask(4, 4, f_col4);
			set_Flask f4_1 = new set_Flask(4, 4, f_col4_1);

			//5번
			Stack<string> f_col5 = new Stack<string>();
			Stack<string> f_col5_1 = new Stack<string>();
			f_col5.Push("3,1");
			f_col5.Push("4,1");
			f_col5.Push("7,1");
			f_col5.Push("2,1");
			f_col5_1.Push("3,1");
			f_col5_1.Push("4,1");
			f_col5_1.Push("7,1");
			f_col5_1.Push("2,1");
			//플라스크고유번호//총량//색,크기
			set_Flask f5_0 = new set_Flask(5, 4, f_col5);
			set_Flask f5_1 = new set_Flask(5, 4, f_col5_1);

			//6번
			Stack<string> f_col6 = new Stack<string>();
			Stack<string> f_col6_1 = new Stack<string>();
			f_col6.Push("6,1");
			f_col6.Push("9,1");
			f_col6.Push("5,1");
			f_col6.Push("3,1");
			f_col6_1.Push("6,1");
			f_col6_1.Push("9,1");
			f_col6_1.Push("5,1");
			f_col6_1.Push("3,1");
			//플라스크고유번호//총량//색,크기
			set_Flask f6_0 = new set_Flask(6, 4, f_col6);
			set_Flask f6_1 = new set_Flask(6, 4, f_col6);

			//7번
			Stack<string> f_col7 = new Stack<string>();
			Stack<string> f_col7_1 = new Stack<string>();
			f_col7.Push("1,2");
			f_col7.Push("9,1");
			f_col7.Push("8,1");
			f_col7_1.Push("1,2");
			f_col7_1.Push("9,1");
			f_col7_1.Push("8,1");
			//플라스크고유번호//총량//색,크기
			set_Flask f7_0 = new set_Flask(7, 4, f_col7);
			set_Flask f7_1 = new set_Flask(7, 4, f_col7_1);

			//8번
			Stack<string> f_col8 = new Stack<string>();
			Stack<string> f_col8_1 = new Stack<string>();
			f_col8.Push("8,1");
			f_col8.Push("7,1");
			f_col8.Push("3,1");
			f_col8.Push("9,1");
			f_col8_1.Push("8,1");
			f_col8_1.Push("7,1");
			f_col8_1.Push("3,1");
			f_col8_1.Push("9,1");
			//플라스크고유번호//총량//색,크기
			set_Flask f8_0 = new set_Flask(8, 4, f_col8);
			set_Flask f8_1 = new set_Flask(8, 4, f_col8_1);

			//9번
			Stack<string> f_col9 = new Stack<string>();
			Stack<string> f_col9_1 = new Stack<string>();
			f_col9.Push("8,1");
			f_col9.Push("5,1");
			f_col9.Push("6,2");
			f_col9_1.Push("8,1");
			f_col9_1.Push("5,1");
			f_col9_1.Push("6,2");
			//플라스크고유번호//총량//색,크기
			set_Flask f9_0 = new set_Flask(9, 4, f_col9);
			set_Flask f9_1 = new set_Flask(9, 4, f_col9_1);

			//10번
			Stack<string> f_col10 = new Stack<string>();
			Stack<string> f_col10_1 = new Stack<string>();
			//플라스크고유번호//총량//색,크기
			set_Flask f10_0 = new set_Flask(10, 0, f_col10);
			set_Flask f10_1 = new set_Flask(10, 0, f_col10_1);

			//11번
			Stack<string> f_col11 = new Stack<string>();
			Stack<string> f_col11_1 = new Stack<string>();
			//플라스크고유번호//총량//색,크기
			set_Flask f11_0 = new set_Flask(11, 0, f_col11);
			set_Flask f11_1 = new set_Flask(11, 0, f_col11_1);

			//list_F = new List<set_Flask>();
			list_F.Add(f1_0);
			list_F.Add(f2_0);
			list_F.Add(f3_0);
			list_F.Add(f4_0);
			list_F.Add(f5_0);
			list_F.Add(f6_0);
			list_F.Add(f7_0);
			list_F.Add(f8_0);
			list_F.Add(f9_0);
			list_F.Add(f10_0);
			list_F.Add(f11_0);

			List<set_Flask> list_F2 = new List<set_Flask>();
			list_F2.Add(f1_1);
			list_F2.Add(f2_1);
			list_F2.Add(f3_1);
			list_F2.Add(f4_1);
			list_F2.Add(f5_1);
			list_F2.Add(f6_1);
			list_F2.Add(f7_1);
			list_F2.Add(f8_1);
			list_F2.Add(f9_1);
			list_F2.Add(f10_1);
			list_F2.Add(f11_1);
		}










		// 이 밑에껀 안쓴다.
		// 이 밑에껀 안쓴다.
		// 이 밑에껀 안쓴다.
		// 이 밑에껀 안쓴다.
		public void make_history(int i, int j, int list_Index, List<set_Flask> new_list) //0. 이력 만들기
		{
			if (list_Index == 0){   //처음이면 push만

				
			}
			else {  //처음이 아니면 이전 스택들 카피해서 저장 후 pop하고 푸쉬.
				
				
				
			}
		}

		public void make_status(int i, int j, int list_Index, List<set_Flask> list_instance)	//1. 현상태 저장
		{
			if (list_Index == 0)
			{   //처음이면 push만
				set_Flask[] new_list = new set_Flask[list_instance.Count];
				list_instance.CopyTo(new_list);
				List<set_Flask> new_list2 = new List<set_Flask>();
				foreach (set_Flask single in list_instance) {
					new_list2.Add(single);
				}
				new_list2 = change_Flask(new_list2, i, j);
				//this.History_status.Push(new_list2);
			}
			else
			{  //처음이 아니면 이전 스택들 카피해서 저장 후 pop하고 푸쉬.
				//for (int k = 0; k < this.History_status.Count; i++)
				//{
					//List<set_Flask> pre_obj = this.History_status.Pop();
				//}
			}
		}

		public void make_Reroll() //2. 상태를 고정하고 다시 돌리기.
		{

		}

	}

}
