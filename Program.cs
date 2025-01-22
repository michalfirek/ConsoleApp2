using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace ConsoleApp2
{
    public class Program
    {
        static void Main(string[] args)
        {
			bool test1, test2;
			Stopwatch sw1 = new Stopwatch();
			Stopwatch sw2 = new Stopwatch();

			sw1.Start();
			test1 =IsPanagram("Raw Danger! (Zettai Zetsumei Toshi 2) for the PlayStation 2 is a bit queer, but an alright game I guess, uh... CJ kicks and vexes Tenpenny precariously? This should be a pangram now, probably.");
			sw1.Stop();

			sw2.Start();
			test2=IsPanagram2("Raw Danger! (Zettai Zetsumei Toshi 2) for the PlayStation 2 is a bit queer, but an alright game I guess, uh... CJ kicks and vexes Tenpenny precariously? This should be a pangram now, probably.");
			sw2.Stop();


			Console.WriteLine($"Dla ip1 czas to {sw1.Elapsed.TotalMilliseconds}");
			Console.WriteLine($"Dla ip2 czas to {sw2.Elapsed.TotalMilliseconds}");

			sw1.Start();
			test1 = IsUpperCase("X%X$BB");
			sw1.Stop();

			sw2.Start();
			test1 = IsUpperCase2("X%X$BB");
			sw2.Stop();

			Console.WriteLine($"Test1 czas:{sw1.Elapsed.TotalMilliseconds}");
			Console.WriteLine($"Test2 czas:{sw2.Elapsed.TotalMilliseconds}");

			Console.WriteLine(new List<int>{ 5, 10, 15, 20, 25 }==FindMultiples(5,25));

			string testString1 = "", testString2 = "";


			string encryptionString = "This is a test!";
			int encryptionLvl = 6;

			sw1.Start();
			testString1 = Encrypt(encryptionString, encryptionLvl);
			sw1.Stop();

			sw2.Start();
			testString2 = Decrypt(testString1, encryptionLvl);
			sw2.Stop();

			sw1.Start();
			Console.WriteLine($"Codewars error: {Decrypt("hsi  etTi sats!",1)}");
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");

			sw1.Start();
			Console.WriteLine($"Result: {testString2==encryptionString}");
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");

			sw1.Start();
			Console.WriteLine($"Result is end of string: {IsEndOfString("ninja","ja")}");
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");

			sw1.Start();
			Console.WriteLine($"Result number to 0 and 1: {FakeBin("45385593107843568")}");
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");

			sw1.Start();
			Console.WriteLine($"Result find two sum: {TwoSum(new[] { 1, 2, 3 }, 4) == new[] { 0, 2 }.OrderBy(a => a).ToArray()}");
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");

			sw1.Start();
			Console.WriteLine($"Result are they the same?: {comp(new int[] {}, new int[] {1} )}");
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");

			sw1.Start();
			Console.WriteLine($"Result even index?: {FindEvenIndex(new int[] { 1, 2, 3, 4, 3, 2, 1 })}");
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");

			sw1.Start();
			Console.WriteLine($"Result where is UpperCase: {Capitals("CodEWaRs")}");
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");

			sw1.Start();
			Console.WriteLine($"Result how many smiley face: {CountSmileys(new string[] { ":D", ":~)", ";~D", ":)" })}");
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");

			sw1.Start();
			Console.WriteLine($"Result max squence Sum: {MaxSequence(new int[] { 7, 4, 11, -11, 39, 36, 10, -6, 37, -10, -32, 44, -26, -34, 43, 43 })}");
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");

			sw1.Start();
			Console.WriteLine($"Result max squence Sum: {MaxSequence(new int[] { 7, 4, 11, -11, 39, 36, 10, -6, 37, -10, -32, 44, -26, -34, 43, 43 })}");
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");

			sw1.Start();
			Console.WriteLine($"Result binary to number: {binaryArrayToNumber(new int[] {0,0,0,0}) == 0}");
			Console.WriteLine($"Result binary to number: {binaryArrayToNumber(new int[] {1,1,1,1}) == 15}");
			Console.WriteLine($"Result binary to number: {binaryArrayToNumber(new int[] {0,1,1,0}) == 6}");
			Console.WriteLine($"Result binary to number: {binaryArrayToNumber(new int[] {0,1,0,1}) == 5}");
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");

			sw1.Start();
			Console.WriteLine(declareWinner(new Fighter("Lew", 10, 2), new Fighter("Harry", 5, 4), "Lew"));
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");


			sw1.Start();
			Console.WriteLine(HowMuchILoveYou(3));
			Console.WriteLine(HowMuchILoveYou(3));
			Console.WriteLine(HowMuchILoveYou(3));
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");
		}

		static bool IsPanagram(string str)
        {
			str = str.ToLower();
			if (str.Length < 26)
			{
				return false;
			}
			Dictionary<char, int> dictionaryData = new Dictionary<char, int>();
			foreach (char l in str)
			{
				if (l>96 && l<123)
				{
					if (dictionaryData.ContainsKey(l))
					{
						dictionaryData[l]++;
					}
					else
						dictionaryData.Add(l, 1);
				}
			}
			if (dictionaryData.Count == 26)
			{
				return true;
			}
			return false;
		}
		static bool IsPanagram2(string str)
		{
			return str.Where(ch => Char.IsLetter(ch)).Select(ch => Char.ToLower(ch)).Distinct().Count() == 26;
		}
		static bool IsUpperCase(string text)
		{
			foreach (char l in text)
			{
				if (!(l>31 && l<91)) return false;
			}
			return true;
		}
		static bool IsUpperCase2(string text)
		{
			return text.ToUpper() == text;
		}
		static List<int> FindMultiples(int integer, int limit)
		{
			var list = new List<int>();
			if (integer > limit)
			{
				return list;
			}
			int r = integer;
			while (r <= limit)
			{
				list.Add(r);
				r+=integer;
			}
			return list;
		}
		public static string Encrypt(string text, int n)
		{
			
			if (text == "" || n <= 0 || text==null) return text;
			
			for (int i = 0; i < n; i++)
			{
				string p1 = "", p2 = "";
				for (int y = 0; y < text.Length; y++)
				{
					if (y % 2 == 0) p1 += text[y];
					else p2 += text[y];
				}
				text = p2 + p1;
			}
			return text;
		}
		static string Decrypt(string encryptedText, int n)
		{
			if (string.IsNullOrEmpty(encryptedText) || n <= 0) return encryptedText;
			string p1 = "", p2 = "";
			int dataLength = encryptedText.Length;
			for (int i = 0; i < n; i++)
			{
				//Dzielenie na dwa 
				p1 = encryptedText.Substring(0, encryptedText.Length / 2);
				p2 = encryptedText.Substring(encryptedText.Length / 2);
				encryptedText = "";
				for (int j = 0; j < dataLength; j++)
				{
					if (j % 2 == 0) encryptedText += p2[j / 2];
					else encryptedText += p1[j / 2];
				}
				p1 = "";
				p2 = "";
			}
			return encryptedText;
		}

		public static bool IsEndOfString(string str, string ending)
		{
			return true;
		}
		static string FakeBin(string x)
		{
			string result=string.Empty;
			foreach(char c in x)
			{
				if (c < 53)
				{
					result += "0";
				}
				else
				{
					result += "1";
				}
			}

			return x.Select(a => a < '5' ? "0" : "1").ToString();
		}

		public static int[] Maps(int[] x)
		{
			return x.Select(d => d * 2).ToArray();
		}
		public static int[] TwoSum(int[] numbers, int target)
		{
			for(int i = 0; i < numbers.Length; i++)
			{
				for (int j = i+1; j < numbers.Length;j++)
				{
					if (numbers[i] + numbers[j] == target) return new int[] {i,j};
				}
			}

			return new int[] {0,0};
		}
		public static string AreYouPlayingBanjo(string name)
		{
			return name.ToLower()[0] == 'r' ? " plays banjo" : " does not play banjo";
		}
		public static double FindAverage(double[] array)
		{
			// Your code here
			return array.Average();
		}
		public static int[] ReverseSeq(int n)
		{
			int[] result = new int[n];
			for(int x = n; x > 0; x--) result[x - n] = x;
			return result;

		}
		public static IEnumerable<string> OpenOrSenior(int[][] data)
		{
			string[] listOfMembership = new string[data.Length];
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i][0] >= 55 && data[i][1] > 7)
				{
					listOfMembership[i] = "Senior";
				}
				else
				{
					listOfMembership[i] = "Open";
				}
			}
			return listOfMembership;
		}

		public static bool comp(int[] a, int[] b)
		{
			if (a == null || b == null) return false;
			else if (a.Length == 0 && b.Length == 0) return true;
			else if (a.Length <= 0 || b.Length <= 0) return false;
			else
			{
				a = a.Select(x => x * x).OrderBy(x => x).ToArray();
				b = b.OrderBy(x => x).ToArray();

				for (int i = 0; i < a.Length; i++)
				{
					if (a[i] != b[i]) return false;
				}
			}
			return true;
		}
		public static int[] minMax(int[] lst) => new int[] { lst.Min(), lst.Max() };

		public static int FindEvenIndex(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				int left = 0, right = 0;
				for (int j = 0; j < i; j++)
				{
					left += arr[j];
				}
				for (int k = i+1; k < arr.Length; k++)
				{
					right += arr[k];
				}
				if(left == right) return i;
			}

			return -1;
		}
		public static double basicOp(char operation, double value1, double value2)
		{
			switch (operation)
			{
				case '+':
					return value1+value2;
				case '-':
					return value1 - value2;
				case '*':
					return value1 * value2;
				case '/':
					return value1 / value2;
			}

			return 0;
		}
		public static int FindDifference(int[] a, int[] b)
		{
			int aCuboid = a[0] * a[1] * a[2], bCuboid = b[0] * b[1] * b[2];

			if (aCuboid > bCuboid) return aCuboid - bCuboid;
			return bCuboid - aCuboid;

		}
		public static int[] Capitals(string word)
		{
			// Write your code here
			return word.Select((value, index)=> new{ Value=value, Index=index }).Where(x=>(x.Value>64 && x.Value<91)).Select(x=>x.Index).ToArray();
		}
		public static int CountSmileys(string[] smileys)
		{
			int faceCounter = 0;
			foreach (var face in smileys)
			{
				if((face.Contains(":") || face.Contains(";")) && (face.Contains("D") || face.Contains(")")) && (!face.Contains(" ") || face.Contains("-") || face.Contains("~"))) faceCounter++;
			}
			
			return faceCounter;
			throw new NotImplementedException();
		}
		public static double Arithmetic(double a, double b, string op)
		{
			switch (op)
			{
				case "add":
					return a + b;
				case "substract":
					return a - b;
				case "multiply":
					return a * b;
				case "divide":
					return a / b;
			}
			throw new NotImplementedException();
		}
		public static int StrCount(string str, char letter)
		{
			return str.Where(x=>x==letter).Count(); 
		}
		public static int MaxSequence(int[] arr)
		{
			int maxSum = 0;
			for (int i = 0; i < arr.Length; i++)
			{
				
				for(int j = i+1; j < arr.Length; j++)
				{
					int sum = 0;
					for (int  k = i; k <= j; k++)
					{
						sum += arr[k];
					}
					if (sum > maxSum) maxSum = sum;
				}
				
			}
			return maxSum;
		}
		public static int Gimme(double[] inputArray)
		{
			var sortedArray = inputArray.OrderBy(i => i).ToArray();
			return Array.IndexOf(inputArray, sortedArray[1]);
		}
		public static int Past(int h, int m, int s)
		{
			return  (int)(new TimeSpan(h,m,s).TotalMilliseconds);
		}
		public static bool Xor(bool a, bool b)
		{

			return a!=b;
		}
		public static string Remove_char(string s)
		{
			return s.Substring(1,s.Length-2); // Your Code
		}
		public static int Sum(int[] numbers)
		{
			return numbers!=null ? numbers.OrderBy(i => i).Skip(1).Take(numbers.Length - 2).Sum() : 0;
		}
		public static int binaryArrayToNumber(int[] BinaryArray)
		{
			return BinaryArray[BinaryArray.Length-1]==1 ? BinaryArray.Reverse().Skip(1).Select((i, index) => (int)Math.Pow(2, index + 1) * i).Sum()+1 : BinaryArray.Reverse().Skip(1).Select((i, index) => (int)Math.Pow(2, index + 1) * i).Sum();
		}
		public double[] Tribonacci(double[] signature, int n)
		{
			double[] result = new double[n];

			for(int i = 0; i < n; i++)
			{
				if (i < 3) result[i] = signature[i];
				else
				{
					result[i] = result[i - 1] + result[i - 2] + result[i - 3];
				}
			}
			return result;
		}
		/// <summary>
		/// Class for declareWinner
		/// </summary>
		public class Fighter
		{
			public string Name;
			public int Health, DamagePerAttack;
			public Fighter(string name, int health, int damagePerAttack)
			{
				this.Name = name;
				this.Health = health;
				this.DamagePerAttack = damagePerAttack;
			}
		}
		public static string declareWinner(Fighter fighter1, Fighter fighter2, string firstAttacker)
		{
			Fighter fighterA, fighterB;
			string winner = string.Empty;

			//Who is fighter first and second
			if (fighter1.Name == firstAttacker)
			{
				fighterA = fighter1;
				fighterB = fighter2;
			}
			else
			{
				fighterA = fighter2;
				fighterB = fighter1;
			}
			
			while(fighter1.Health > 0 || fighter2.Health > 0)
			{
				//First hit
				fighterB.Health -= fighterA.DamagePerAttack;
				AttackerDataPrint(fighterA, fighterB);

				//Is dead
				if (fighterB.Health<=0)
				{
					winner = fighterA.Name; 
					break;
				}
				//Second hit
				fighterA.Health -= fighterB.DamagePerAttack;
				AttackerDataPrint(fighterB, fighterA);
				//Is dead
				if (fighterA.Health <= 0)
				{
					winner = fighterB.Name;
					break;
				}
			}

			return winner;
		}

		public static void AttackerDataPrint(Fighter attacker, Fighter damaged)
		{
			Console.WriteLine($"{attacker.Name} attacks {damaged.Name}; {damaged.Name} now has {damaged.Health} health.");
		}

		public static string HowMuchILoveYou(int nb_petals)
		{
			return new string[]{"I love you", "a little", "a lot", "passionately", "madly", "not at all"}[(nb_petals - 1)% 6];
		}

		public static string ReverseLetter(string str)
		{
			//coding and coding..
			return string.Join("", str
				.Where(Char.IsLetter)
				.Reverse());
		}

		public static long[] SumDigPow(long a, long b)
		{
			List<long> longs = new List<long>();
			for(long i = a; i < b; i++)
			{
				long r = (long)i.ToString().Select((x, index) => Math.Pow(Convert.ToInt64(x-48), index + 1)).Sum();
				if (i == r) longs.Add(i);
			}
			return longs.ToArray();
		}

		public static int SumMix(object[] x)
		{
			return x.Select(n => Convert.ToInt32(n)).Sum();
		}

		public static IEnumerable<string> GooseFilter(IEnumerable<string> birds)
		{
			// return IEnumerable of string containing all of the strings in the input collection, except those that match strings in geese
			string[] geese = new string[] { "African", "Roman Tufted", "Toulouse", "Pilgrim", "Steinbacher" };


			return birds.Where(x=>!geese.Contains(x));
		}

		public static string ExpandedForm(long num)
		{
			//Codewars top 1 
			//var str = num.ToString();
			//return String.Join(" + ", str
			//	.Select((x, i) => char.GetNumericValue(x) * Math.Pow(10, str.Length - i - 1))
			//	.Where(x => x > 0));

			return string.Join(" + ",num.ToString().ToCharArray().Select((x,index)=>(x-48)*Math.Pow(10,num.ToString().Length-(index+1))).Where(x=>x>0));
		}

		public static int SumDigits(int number)
		{
			return number.ToString().ToCharArray().Where(x=>x-48>=0 && x-48<=9).Select(x=>x-48).Sum();
		}

		public static bool IsIsogram(string str)
		{
			return str.ToLower().Distinct().Count() == str.Length;
		}

		public static bool XO(string input)
		{
			if(!input.Contains('o') && !input.Contains('x')) return true;

			if(input.Where(x => x == 'o' || x == 'O').Count() == input.Where(x => x == 'x' || x == 'X').Count())
			{
				return true;
			}

			return false;
		}

		public static string RemoveUrlAnchor(string url)
		{
			return url.Substring(0, url.Contains('#') ? url.IndexOf('#') : url.Length);
		}

		public static string Correct(string text)
		{
			return text
				.Replace('5', 'S')
				.Replace('0', 'O')
				.Replace('1', 'I');
		}

		public static int GetUnique(IEnumerable<int> numbers)
		{
			var unique = numbers.Distinct();

			if (numbers.Where(x => x == unique.First()).Count()==1) return unique.First();
			else return unique.Last();

			//return numbers.GroupBy(x=>x).Single(x=> x.Count() == 1).Key;
		}

		public static char GetGrade(int s1, int s2, int s3)
		{
			//Your code goes here...
			int s = (s1 + s2 + s3)/3;
			return s<60 ? 'F' : s<70 ? 'D' : s<80 ? 'C' : s<90 ? 'B' : 'A';
		}

		public static List<int> RemoveSmallest(List<int> numbers)
		{
			if(numbers.Count<1) return numbers;
			List<int> result = new List<int>();
			result.AddRange(numbers);
			int min = result.Min();
			foreach (int x in result)
			{
				if(x == min)
				{
					result.Remove(x);
					break;
				}
			}
			return result;
		}

		public static bool IsSquare(int n)
		{
			if(n<=1) return true;
			for (int i = 2; i < n-1; i++)
			{
				if (i * i == n) return true;
			}
			return false;
		}

		public static string GetMiddle(string s)
		{
			return s.Length % 2 == 0 ? s[(s.Length / 2)-1].ToString() + s[(s.Length / 2)].ToString() : s[(s.Length)/2].ToString();
		}
	};
}

