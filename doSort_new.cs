using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Text;

namespace ConsoleApp1
{
    class doSort_new
    {

		public Boolean validationCheck_new(List<set_Flask_new> list_Flask, int col_num) // 색과 색의총수가 4개인지 체크
		{
			bool result = true;
			int[] sum_num = new int[col_num];
			foreach (set_Flask_new sfn in list_Flask)
			{
				if (sfn.S.Count == 0) continue; //비어있으면 다음꺼.

				int count_F = sfn.S.Count / 2;
				for (int i = 0; i < count_F; i++) {
					int quantity = sfn.S.Pop();
					int col_N = sfn.S.Pop() -1;
					sum_num[col_N] += quantity;
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
			list_Flask.Clear();
			defalut_Flask_new(list_Flask);

			return result;
		}


		public bool check_moveCol_new(set_Flask_new sel_F, set_Flask_new chk_F) //이동할지 말지 체크 (속도향상을위해)
		{
			bool result = true;

			// 1 둘다 빈거면 나가리
			if (sel_F.StackNum == 0 && chk_F.StackNum == 0) return false;

			// 2 선택된 Flask에 뽑을게 없으면 나가리
			if (sel_F.StackNum == 0) return false;

			// 3 chk의 총량이 4면 나가리
			if (chk_F.StackNum == 4) return false;

			// chk가 빈거면 freepass // 4개를 무의미하게 옮기는거면 의미가 없음.
			if (chk_F.StackNum == 0) return true;

			//꺼내서 비교. 크기 색깔
			int sel_Quantity = sel_F.S.Pop();
			int sel_Num = sel_F.S.Pop();

			int chk_Quantity = chk_F.S.Pop();
			int chk_Num = chk_F.S.Pop();

			//pop 했던거 다시 넣어주기.
			sel_F.S.Push(sel_Num);
			sel_F.S.Push(sel_Quantity);

			chk_F.S.Push(chk_Num);
			chk_F.S.Push(chk_Quantity);

			//4 색이 다르거나, 넘어간 후 총량이 4보다 크면 나가리
			if (sel_Num != chk_Num || (chk_F.StackNum + sel_Quantity) >= 5) return false;

			//5 옮기려는게 색하나에 4개면 쓸대없는 무빙.
			if (sel_Quantity == 4) return false;

			return result;
		}


		public void defalut_Flask_new(List<set_Flask_new> list_F)
		{
			//1번
			Stack<int> f_col1 = new Stack<int>();
			f_col1.Push(4);
			f_col1.Push(1);

			f_col1.Push(3);
			f_col1.Push(1);

			f_col1.Push(2);
			f_col1.Push(1);

			f_col1.Push(1);
			f_col1.Push(1);
			set_Flask_new f1_0 = new set_Flask_new(1, 4, f_col1);

			//2번
			Stack<int> f_col2 = new Stack<int>();
			f_col2.Push(7);
			f_col2.Push(2);

			f_col2.Push(6);
			f_col2.Push(1);

			f_col2.Push(5);
			f_col2.Push(1);
			set_Flask_new f2_0 = new set_Flask_new(2, 4, f_col2);

			//3번
			Stack<int> f_col3 = new Stack<int>();
			f_col3.Push(4);
			f_col3.Push(1);

			f_col3.Push(2);
			f_col3.Push(1);

			f_col3.Push(5);
			f_col3.Push(1);

			f_col3.Push(1);
			f_col3.Push(1);
			set_Flask_new f3_0 = new set_Flask_new(3, 4, f_col3);

			//4번
			Stack<int> f_col4 = new Stack<int>();
			f_col4.Push(8);
			f_col4.Push(1);

			f_col4.Push(4);
			f_col4.Push(1);

			f_col4.Push(9);
			f_col4.Push(1);

			f_col4.Push(2);
			f_col4.Push(1);
			set_Flask_new f4_0 = new set_Flask_new(4, 4, f_col4);

			//5번
			Stack<int> f_col5 = new Stack<int>();
			f_col5.Push(3);
			f_col5.Push(1);

			f_col5.Push(4);
			f_col5.Push(1);

			f_col5.Push(7);
			f_col5.Push(1);

			f_col5.Push(2);
			f_col5.Push(1);
			set_Flask_new f5_0 = new set_Flask_new(5, 4, f_col5);

			//6번
			Stack<int> f_col6 = new Stack<int>();
			f_col6.Push(6);
			f_col6.Push(1);

			f_col6.Push(9);
			f_col6.Push(1);

			f_col6.Push(5);
			f_col6.Push(1);

			f_col6.Push(3);
			f_col6.Push(1);
			set_Flask_new f6_0 = new set_Flask_new(6, 4, f_col6);

			//7번
			Stack<int> f_col7 = new Stack<int>();
			f_col7.Push(1);
			f_col7.Push(2);

			f_col7.Push(9);
			f_col7.Push(1);

			f_col7.Push(8);
			f_col7.Push(1);
			set_Flask_new f7_0 = new set_Flask_new(7, 4, f_col7);

			//8번
			Stack<int> f_col8 = new Stack<int>();
			f_col8.Push(8);
			f_col8.Push(1);

			f_col8.Push(7);
			f_col8.Push(1);

			f_col8.Push(3);
			f_col8.Push(1);

			f_col8.Push(9);
			f_col8.Push(1);
			set_Flask_new f8_0 = new set_Flask_new(8, 4, f_col8);

			//9번
			Stack<int> f_col9 = new Stack<int>();
			f_col9.Push(8);
			f_col9.Push(1);

			f_col9.Push(5);
			f_col9.Push(1);

			f_col9.Push(6);
			f_col9.Push(2);
			set_Flask_new f9_0 = new set_Flask_new(9, 4, f_col9);

			//10번
			Stack<int> f_col10 = new Stack<int>();
			set_Flask_new f10_0 = new set_Flask_new(10, 0, f_col10);

			//11번
			Stack<int> f_col11 = new Stack<int>();
			set_Flask_new f11_0 = new set_Flask_new(11, 0, f_col11);

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
		}

		public List<set_Flask_new> change_Flask_new(List<set_Flask_new> new_list, int i, int j) // 부을 수 있다면 붇기!
		{
			try
			{
				int i_col_quantity = new_list[i].S.Pop();
				//check_moveCol에서 색체크함
				int i_col_num = new_list[i].S.Pop();
				new_list[i].StackNum -= i_col_quantity;     // 부은 후 총량감소.

				//int j_col_num;
				//int j_col_quantity;
				if (new_list[j].StackNum == 0) // new_list[j]가 빈거면
				{
					//j_col_num = i_col_num;
					//j_col_quantity = i_col_quantity;
					new_list[j].StackNum += i_col_quantity;     // i 량만큼 총량 증가.
					new_list[j].S.Push(i_col_num);
					new_list[j].S.Push(i_col_quantity);
				}
				else
				{
					//string[] j_Flask = new_list[j].S.Pop().Split(",");  //일단 꺼낸다음 다시 푸쉬로 넣기.
					int j_col_quantity = new_list[j].S.Pop();
					//j_col_num = new_list[j].S.Pop();
					new_list[j].StackNum += i_col_quantity;     // i 량만큼 총량 증가.
					j_col_quantity += i_col_quantity;           // i량만큼 j량 증가.
					new_list[j].S.Push(j_col_quantity); // 증가시킨 색다시 푸쉬.
					//new_list[j].S.Push();
				}
			}
			catch (Exception ex){
				Console.WriteLine($"i : {i} j : {j} ");
				Console.WriteLine($"i StackNum : {new_list[i].StackNum} j StackNum : {new_list[j].StackNum} ");
			}

			return new_list;
		}
		//i를 j로 옮겨진것에 성공했다면, 0. 히스토리와 1. 현재 상태를 저장하고, 2. 그 상태에서 파생시켜 다시 돌리기.

		public void do_repetition_new(List<set_Flask_new> list_F, Queue<int> q)
		{
			for (int i = 0; i < list_F.Count; i++)
			{
				for (int j = 0; j < list_F.Count; j++)
				{
					// 반복 시작
					if (i != j)
					{
						if (check_moveCol_new(list_F[i], list_F[j])) //이동가능한지 여부체크
						{
							q.Enqueue(i);
							q.Enqueue(j);
							//change_Flask(list_F, i, j);   // 원본은 그대로두고 f2에 변경 저장
							//Console.WriteLine($"변경 후 list_F2\ni번호 : {i + 1}, {list_F[i].S.Peek()}, 총크기 : {list_F[i].StackNum}, \nj번호 : {j + 1}, {list_F[j].S.Peek()}, 총크기 :  {list_F[j].StackNum}");
							//reverse_Flask(list_F, j, i);    //다시 j들어서 i에 붓기
						}
					}
				}
			}
		}


		public bool Check_completeYN(List<set_Flask_new> list)	// 완성확인
		{
			bool result = true;

			foreach (set_Flask_new f in list)
			{
				if (f.S.Peek() != 4 && f.StackNum != 4) result = false;
			}

			return result;
		}

		// 빈플라스크 번호 리턴
		public int[] Listempty_Check(List<set_Flask_new> list) {
			int[] result = { 0, 0, 0 };
			foreach (set_Flask_new obj in list) {
				if (obj.StackNum == 0) {
					result[0] += 1;
					result[result[0]] = obj.F_Num - 1;
				}
			}
			return result;
		}


		public void do_repetition_except_new(List<set_Flask_new> list_F, Queue<int> q, int[] empt_check)
		{
			for (int i = 0; i < list_F.Count; i++)
			{
				for (int j = 0; j < list_F.Count; j++)
				{
					// 반복 시작
					if (i != j)
					{
						// 두번째 빈플라스크 연산 pass;
						if (j == empt_check[2]) continue;

						if (check_moveCol_new(list_F[i], list_F[j])) //이동가능한지 여부체크
						{
							q.Enqueue(i);
							q.Enqueue(j);
							//change_Flask(list_F, i, j);   // 원본은 그대로두고 f2에 변경 저장
							//Console.WriteLine($"변경 후 list_F2\ni번호 : {i + 1}, {list_F[i].S.Peek()}, 총크기 : {list_F[i].StackNum}, \nj번호 : {j + 1}, {list_F[j].S.Peek()}, 총크기 :  {list_F[j].StackNum}");
							//reverse_Flask(list_F, j, i);    //다시 j들어서 i에 붓기
						}
					}
				}
			}
		}

		public int[,] Add_totColor(List<set_Flask_new> list) {

			int[,] colarr = new int[ list.Count, 4 ];
			int row = 0;

			foreach (set_Flask_new obj in list){

				if (obj.StackNum == 0) continue;

				int column = 0;
				int count = obj.S.Count;
				int size = 0;

				if (obj.StackNum < 4)  //비어있는거!
				{
					int empty_num = 4 - obj.StackNum;
					column += empty_num;
				}
				
				foreach (int num in obj.S) {
					if (count % 2 == 0) {   //오는게 크기면.
						size = num;
					}
					else {  // 오는게 색이면
						for (int i = 0; i < size; i++) {
							colarr[row, column] = num;
							column++;
						}
					}
					count--;
				}
				row++;
			}

			return colarr;
		}

		public Queue<int> PriorityColnum_Search(int[,] intarr, int totCol)
		{

			int[,] pri_arr = new int[totCol, 4];

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < totCol; j++)
				{
					//if (intarr[j, i] == 0) continue;
					pri_arr[intarr[j, i] - 1, i] += 1;
				}
			}

			Queue<int> first_pri = new Queue<int>();
			Queue<int> second_pri = new Queue<int>();
			Queue<int> third_pri = new Queue<int>();
			int maxC = 4;
			do
			{
				for (int k = 0; k < totCol; k++)
				{
					if (pri_arr[k, 0] >= maxC && pri_arr[k, 3] == 0 && pri_arr[k, 1] > 0) {
						first_pri.Enqueue(k + 1);
					}
					if (pri_arr[k, 0] >= maxC && pri_arr[k, 3] == 0) {
						second_pri.Enqueue(k + 1);
					}
					if (pri_arr[k, 0] >= maxC && pri_arr[k, 1] > 0)
					{
						third_pri.Enqueue(k + 1);
					}
				}
				maxC--;
			} while (maxC > 0);

			Queue<int> result = new Queue<int>();

			if (first_pri.Count > 0)
			{
				foreach (int num in first_pri) {
					for (int fnum = 0; fnum < totCol + 2; fnum++) {
						if( intarr[fnum,0] == num ) result.Enqueue(fnum+1);
					}
				}
				return result;
			}
			else if (second_pri.Count > 0)
			{
				foreach (int num in second_pri)
				{
					for (int fnum = 0; fnum < totCol + 2; fnum++)
					{
						if (intarr[fnum, 0] == num) result.Enqueue(fnum + 1);
					}
				}
				return result;
			}
			else 
			{
				foreach (int num in third_pri)
				{
					for (int fnum = 0; fnum < totCol + 2; fnum++)
					{
						if (intarr[fnum, 0] == num) result.Enqueue(fnum + 1);
					}
				}
				return result;
			}
		}

		public void priority_Flask_new(List<set_Flask_new> list, Queue<int> pri_f_num) 
		{
			foreach (set_Flask_new obj in list) {
				if (obj.StackNum == 0)
				{
					int j = obj.F_Num;
					list = change_Flask_new(list, pri_f_num.Dequeue(), j-1);
					list = change_Flask_new(list, pri_f_num.Dequeue(), j-1);
					break;
				}
			}
		}






























		public List<set_Flask_new> change_Flask_new(List<set_Flask_new> new_list, int i, int j, string check_str) // 부을 수 있다면 붇기!
		{
			try
			{
				int i_col_quantity = new_list[i].S.Pop();
				//check_moveCol에서 색체크함
				int i_col_num = new_list[i].S.Pop();
				new_list[i].StackNum -= i_col_quantity;     // 부은 후 총량감소.

				int j_col_num = 0;
				int j_col_quantity = 0;
				if (new_list[j].StackNum == 0) // new_list[j]가 빈거면
				{
					//j_col_num = i_col_num;
					//j_col_quantity = i_col_quantity;
					new_list[j].StackNum = i_col_quantity;     // i 량만큼 총량 증가.
					new_list[j].S.Push(i_col_num);
					new_list[j].S.Push(i_col_quantity);
				}
				else
				{
					//string[] j_Flask = new_list[j].S.Pop().Split(",");  //일단 꺼낸다음 다시 푸쉬로 넣기.
					j_col_quantity = new_list[j].S.Pop();
					//j_col_num = new_list[j].S.Pop();
					new_list[j].StackNum = new_list[j].StackNum + i_col_quantity;     // i 량만큼 총량 증가.
					j_col_quantity = j_col_quantity + i_col_quantity;           // i량만큼 j량 증가.
					new_list[j].S.Push(j_col_quantity); // 증가시킨 색다시 푸쉬.
														//new_list[j].S.Push();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"i : {i} j : {j}  {check_str}");
				
			}
			finally
			{

			}
			return new_list;
		}
	}
}
