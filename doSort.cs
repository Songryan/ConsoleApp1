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

		public void cal_Sort_list(List<set_Flask> list_F)
		{

			for (int i= 0; i<list_F.Count;i++)
			{
				for (int j = 0; j < list_F.Count; j++)
				{

					if (i != j)
					{
						bool canOX = check_moveCol(list_F[i], list_F[j]);   //이동가능한지 여부체크
						if (canOX)       //true면 옮겨진 상태 저장 진행
						{

						}
						else
						{ 

						}
					}
					else
					{ 
						//같으면 패스
					}

				}
			}





		}

		public bool check_moveCol(set_Flask sel_F, set_Flask chk_F)
		{
			bool result = true;

			//선택된 Flask에 뽑을게 없으면 나가리
			if (sel_F.StackNum == 0) return false;

			// chk의 총량이 4면 나가리
			if (chk_F.StackNum == 4) return false;

			// chk가 빈거면 freepass
			if (chk_F.StackNum == 0) return true;

			//꺼내서 비교.
			string sel = sel_F.S.Pop();
			string chk = chk_F.S.Pop();

			string[] set1 = chk.Split(",");
			int sel_Num = Int32.Parse(set1[0]);
			int sel_Quantity = Int32.Parse(set1[1]);

			string[] set2 = chk.Split(",");
			int chk_Num = Int32.Parse(set2[0]);
			int chk_Quantity = Int32.Parse(set2[1]);

			//색이 다르거나, 넘어간 후 총량이 4보다 크면 나가리
			if (sel_Num != chk_Num || (chk_F.StackNum + sel_Quantity) > 4) return false;

			return result;
		}
	}
}
