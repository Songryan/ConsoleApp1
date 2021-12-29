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

		public void cal_Sort_list(List<set_Flask> list_F)//한 가지 케이스를 딱 한번만 체크.
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
							List<set_Flask> new_list = new List<set_Flask>();
							new_list = change_Flask(list_F, i, j);
							// 새로운 상태!
						}
						else  //이동 불가 판정
						{

						}
					}
					else if(i == j)
					{
						//같으면 패스
					}

					// 반복 끝
				}
			}

		}

		public bool check_moveCol(set_Flask sel_F, set_Flask chk_F)	//이동할지 말지 체크 (속도향상을위해)
		{
			bool result = true;

			// 1 둘다 빈거면 나가리
			if(sel_F.S.Count == 0 && chk_F.S.Count == 0) return false;

			// 2 선택된 Flask에 뽑을게 없으면 나가리
			if (sel_F.S.Count == 0) return false;

			// 3 chk의 총량이 4면 나가리
			if (chk_F.StackNum == 4) return false;

			// chk가 빈거면 freepass // 4개를 무의미하게 옮기는거면 의미가 없음.
			//if (chk_F.StackNum == 0) return true;

			//꺼내서 비교.
			string sel = sel_F.S.Pop();
			string chk = chk_F.S.Pop();

			string[] set1 = chk.Split(",");
			int sel_Num = Int32.Parse(set1[0]);
			int sel_Quantity = Int32.Parse(set1[1]);

			string[] set2 = chk.Split(",");
			int chk_Num = Int32.Parse(set2[0]);
			int chk_Quantity = Int32.Parse(set2[1]);

			//pop 했던거 다시 넣어주기.
			sel_F.S.Push(sel);
			chk_F.S.Push(chk);

			//4 색이 다르거나, 넘어간 후 총량이 4보다 크면 나가리
			if (sel_Num != chk_Num || (chk_F.StackNum + sel_Quantity) > 4) return false;

			//5 옮기려는게 색하나에 4개면 쓸대없는 무빙.
			if(sel_Quantity == 4) return false;

			return result;
		}

		public List<set_Flask> change_Flask(List<set_Flask> new_list ,int i ,int j)	// 부을 수 있다면 붇기!
		{
			string[] i_Flask = new_list[i].S.Pop().Split(",");
			//int i_col_num = Int32.Parse(i_Flask[0]);		//check_moveCol에서 색체크함
			int i_col_quantity = Int32.Parse(i_Flask[1]);
			new_list[i].StackNum -= i_col_quantity;		// 부은 후 총량감소.


			string[] j_Flask = new_list[j].S.Pop().Split(",");	//일단 꺼낸다음 다시 푸쉬로 넣기.
			int j_col_num = Int32.Parse(j_Flask[0]);
			int j_col_quantity = Int32.Parse(j_Flask[1]);
			new_list[j].StackNum += i_col_quantity;     // i 량만큼 총량 증가.
			j_col_quantity += i_col_quantity;           // i량만큼 j량 증가.

			new_list[j].S.Push(j_col_num.ToString() + "," + j_col_quantity.ToString());	// 증가시킨 색다시 푸쉬.

			return new_list;
		}
	}
}
