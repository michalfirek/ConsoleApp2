using ConsoleApp2.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using static System.Net.WebRequestMethods;


namespace ConsoleApp2
{
	/// <summary>
	/// The main class of the application containing various utility methods and the entry point.
	/// </summary>
	public class Program
	{
		/// <summary>
		/// The entry point of the application.
		/// </summary>
		/// <param name="args">The command-line arguments.</param>
		static void Main(string[] args)
		{
			bool test1, test2;
			Stopwatch sw1 = new Stopwatch();
			Stopwatch sw2 = new Stopwatch();

			sw1.Start();
			test1 = IsPanagram("Raw Danger! (Zettai Zetsumei Toshi 2) for the PlayStation 2 is a bit queer, but an alright game I guess, uh... CJ kicks and vexes Tenpenny precariously? This should be a pangram now, probably.");
			sw1.Stop();

			sw2.Start();
			test2 = IsPanagram2("Raw Danger! (Zettai Zetsumei Toshi 2) for the PlayStation 2 is a bit queer, but an alright game I guess, uh... CJ kicks and vexes Tenpenny precariously? This should be a pangram now, probably.");
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

			Console.WriteLine(new List<int> { 5, 10, 15, 20, 25 } == FindMultiples(5, 25));

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
			Console.WriteLine($"Codewars error: {Decrypt("hsi  etTi sats!", 1)}");
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");

			sw1.Start();
			Console.WriteLine($"Result: {testString2 == encryptionString}");
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");

			sw1.Start();
			Console.WriteLine($"Result is end of string: {IsEndOfString("ninja", "ja")}");
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
			Console.WriteLine($"Result are they the same?: {comp(new int[] { }, new int[] { 1 })}");
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
			Console.WriteLine($"Result binary to number: {binaryArrayToNumber(new int[] { 0, 0, 0, 0 }) == 0}");
			Console.WriteLine($"Result binary to number: {binaryArrayToNumber(new int[] { 1, 1, 1, 1 }) == 15}");
			Console.WriteLine($"Result binary to number: {binaryArrayToNumber(new int[] { 0, 1, 1, 0 }) == 6}");
			Console.WriteLine($"Result binary to number: {binaryArrayToNumber(new int[] { 0, 1, 0, 1 }) == 5}");
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

			sw1.Start();
			DisplayTest("Test wodowy");
			sw1.Stop();
			Console.WriteLine($"{sw1.Elapsed.TotalMilliseconds}");
		}
		/// <summary>
		/// Checks if a given string is a pangram.
		/// </summary>
		/// <param name="str">The string to check.</param>
		/// <returns>True if the string is a pangram, otherwise false.</returns>
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
				if (l > 96 && l < 123)
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
		/// <summary>
		/// Checks if a given string is a pangram using LINQ.
		/// </summary>
		/// <param name="str">The string to check.</param>
		/// <returns>True if the string is a pangram, otherwise false.</returns>
		static bool IsPanagram2(string str)
		{
			return str.Where(ch => Char.IsLetter(ch)).Select(ch => Char.ToLower(ch)).Distinct().Count() == 26;
		}
		/// <summary>
		/// Checks if all characters in a string are uppercase.
		/// </summary>
		/// <param name="text">The string to check.</param>
		/// <returns>True if all characters are uppercase, otherwise false.</returns>
		static bool IsUpperCase(string text)
		{
			foreach (char l in text)
			{
				if (!(l > 31 && l < 91)) return false;
			}
			return true;
		}
		/// <summary>
		/// Checks if all characters in a string are uppercase using string comparison.
		/// </summary>
		/// <param name="text">The string to check.</param>
		/// <returns>True if all characters are uppercase, otherwise false.</returns>
		static bool IsUpperCase2(string text)
		{
			return text.ToUpper() == text;
		}
		/// <summary>
		/// Finds all multiples of a given integer up to a specified limit.
		/// </summary>
		/// <param name="integer">The integer to find multiples of.</param>
		/// <param name="limit">The upper limit.</param>
		/// <returns>A list of multiples.</returns>
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
				r += integer;
			}
			return list;
		}
		public static string Encrypt(string text, int n)
		{

			if (text == "" || n <= 0 || text == null) return text;

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
			string result = string.Empty;
			foreach (char c in x)
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
			for (int i = 0; i < numbers.Length; i++)
			{
				for (int j = i + 1; j < numbers.Length; j++)
				{
					if (numbers[i] + numbers[j] == target) return new int[] { i, j };
				}
			}

			return new int[] { 0, 0 };
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
			for (int x = n; x > 0; x--) result[x - n] = x;
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
				for (int k = i + 1; k < arr.Length; k++)
				{
					right += arr[k];
				}
				if (left == right) return i;
			}

			return -1;
		}
		public static double basicOp(char operation, double value1, double value2)
		{
			switch (operation)
			{
				case '+':
					return value1 + value2;
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
			return word.Select((value, index) => new { Value = value, Index = index }).Where(x => (x.Value > 64 && x.Value < 91)).Select(x => x.Index).ToArray();
		}
		public static int CountSmileys(string[] smileys)
		{
			int faceCounter = 0;
			foreach (var face in smileys)
			{
				if ((face.Contains(":") || face.Contains(";")) && (face.Contains("D") || face.Contains(")")) && (!face.Contains(" ") || face.Contains("-") || face.Contains("~"))) faceCounter++;
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
			return str.Where(x => x == letter).Count();
		}
		public static int MaxSequence(int[] arr)
		{
			int maxSum = 0;
			for (int i = 0; i < arr.Length; i++)
			{

				for (int j = i + 1; j < arr.Length; j++)
				{
					int sum = 0;
					for (int k = i; k <= j; k++)
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
			return (int)(new TimeSpan(h, m, s).TotalMilliseconds);
		}
		public static bool Xor(bool a, bool b)
		{

			return a != b;
		}
		public static string Remove_char(string s)
		{
			return s.Substring(1, s.Length - 2); // Your Code
		}
		public static int Sum(int[] numbers)
		{
			return numbers != null ? numbers.OrderBy(i => i).Skip(1).Take(numbers.Length - 2).Sum() : 0;
		}
		public static int binaryArrayToNumber(int[] BinaryArray)
		{
			return BinaryArray[BinaryArray.Length - 1] == 1 ? BinaryArray.Reverse().Skip(1).Select((i, index) => (int)Math.Pow(2, index + 1) * i).Sum() + 1 : BinaryArray.Reverse().Skip(1).Select((i, index) => (int)Math.Pow(2, index + 1) * i).Sum();
		}
		public double[] Tribonacci(double[] signature, int n)
		{
			double[] result = new double[n];

			for (int i = 0; i < n; i++)
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

			while (fighter1.Health > 0 || fighter2.Health > 0)
			{
				//First hit
				fighterB.Health -= fighterA.DamagePerAttack;
				AttackerDataPrint(fighterA, fighterB);

				//Is dead
				if (fighterB.Health <= 0)
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
			return new string[] { "I love you", "a little", "a lot", "passionately", "madly", "not at all" }[(nb_petals - 1) % 6];
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
			for (long i = a; i < b; i++)
			{
				long r = (long)i.ToString().Select((x, index) => Math.Pow(Convert.ToInt64(x - 48), index + 1)).Sum();
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


			return birds.Where(x => !geese.Contains(x));
		}

		public static string ExpandedForm(long num)
		{
			//Codewars top 1 
			//var str = num.ToString();
			//return String.Join(" + ", str
			//	.Select((x, i) => char.GetNumericValue(x) * Math.Pow(10, str.Length - i - 1))
			//	.Where(x => x > 0));

			return string.Join(" + ", num.ToString().ToCharArray().Select((x, index) => (x - 48) * Math.Pow(10, num.ToString().Length - (index + 1))).Where(x => x > 0));
		}

		public static int SumDigits(int number)
		{
			return number.ToString().ToCharArray().Where(x => x - 48 >= 0 && x - 48 <= 9).Select(x => x - 48).Sum();
		}

		public static bool IsIsogram(string str)
		{
			return str.ToLower().Distinct().Count() == str.Length;
		}

		public static bool XO(string input)
		{
			if (!input.Contains('o') && !input.Contains('x')) return true;

			if (input.Where(x => x == 'o' || x == 'O').Count() == input.Where(x => x == 'x' || x == 'X').Count())
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

			if (numbers.Where(x => x == unique.First()).Count() == 1) return unique.First();
			else return unique.Last();

			//return numbers.GroupBy(x=>x).Single(x=> x.Count() == 1).Key;
		}

		public static char GetGrade(int s1, int s2, int s3)
		{
			//Your code goes here...
			int s = (s1 + s2 + s3) / 3;
			return s < 60 ? 'F' : s < 70 ? 'D' : s < 80 ? 'C' : s < 90 ? 'B' : 'A';
		}

		public static List<int> RemoveSmallest(List<int> numbers)
		{
			if (numbers.Count < 1) return numbers;
			List<int> result = new List<int>();
			result.AddRange(numbers);
			int min = result.Min();
			foreach (int x in result)
			{
				if (x == min)
				{
					result.Remove(x);
					break;
				}
			}
			return result;
		}

		public static bool IsSquare(int n)
		{
			if (n <= 1) return true;
			for (int i = 2; i < n - 1; i++)
			{
				if (i * i == n) return true;
			}
			return false;
		}

		public static string GetMiddle(string s)
		{
			return s.Length % 2 == 0 ? s[(s.Length / 2) - 1].ToString() + s[(s.Length / 2)].ToString() : s[(s.Length) / 2].ToString();
		}

		public static List<string> MexicanWave(string str)
		{
			List<string> strings = new List<string>();

			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == ' ') continue;
				string sentence = string.Join("", str.Select((l, index) => i == index ? char.ToUpper(l) : l).ToArray());
				strings.Add(sentence);
			}
			return strings;
		}

		public static int RoundToNext5(int n)
		{
			return n % 5 == 0 ? n : n > 0 ? n + (5 - (n % 5)) : n + ((-n % 5));
		}

		public static int GetGoals(int laLigaGoals, int copaDelReyGoals, int championsLeagueGoals) => laLigaGoals + copaDelReyGoals + championsLeagueGoals;

		public static string PeopleWithAgeDrink(int old)
		{
			if (old < 14) return "drink toddy";
			if (old < 18) return "drink coke";
			if (old < 21) return "drink beer";
			else return "drink whisky";
		}
		public static string MouthSize(string animal) => animal.ToLower() == "alligator" ? "small" : "wide";

		public static int[] Between(int a, int b)
		{
			int[] result = new int[(b - a) + 1];
			for (int i = 0; i < b - a + 1; i++)
			{
				result[i] = a + i;
			}
			return result;

			//CodeWars Top 1
			//return Enumerable.Range(a, b - a + 1).ToArray();
		}

		public static bool Narcissistic(int value)
		{
			return value
				.ToString()
				.Select(x => Math.Pow(x - 48, value.ToString().Length))
				.Sum() == value;
		}
		public static string[] dirReduc(String[] arr)
		{
			List<string> result = arr.ToList();
			bool isOk = false;
			while (!isOk)
			{
				isOk = true;
				for (int i = 1; i < result.Count; i++)
				{
					switch (result[i])
					{
						case "WEST":
							if (result[i - 1] == "EAST")
							{
								result.RemoveRange(i - 1, 2);
								i = i - 1;
								isOk = false;
							}
							break;
						case "EAST":
							if (result[i - 1] == "WEST")
							{
								result.RemoveRange(i - 1, 2);
								i = i - 1;
								isOk = false;
							}
							break;
						case "NORTH":
							if (result[i - 1] == "SOUTH")
							{
								result.RemoveRange(i - 1, 2);
								i = i - 1;
								isOk = false;
							}
							break;
						case "SOUTH":
							if (result[i - 1] == "NORTH")
							{
								result.RemoveRange(i - 1, 2);
								i = i - 1;
								isOk = false;
							}
							break;
						default:
							break;

					}
				}
			}

			return result.ToArray();
		}

		public static bool IsAnagram(string a, string b)
		{
			return String.Concat(a.ToLower().OrderBy(l => l)) == String.Concat(b.ToLower().OrderBy(l => l));
		}
		//CodeWars = public static bool IsAnagram(string test, string original) => test.ToLower().OrderBy(x => x).SequenceEqual(original.ToLower().OrderBy(x => x));

		public static string FindNeedle(object[] haystack)
		{
			return $"found the needle at position {haystack.ToList().IndexOf("needle")}";
		}

		public static string Greet(string language)
		{
			var welcomes = new Dictionary<string, string>
			{
				{ "english",   "Welcome" },
				{ "czech",     "Vitejte" },
				{ "danish",    "Velkomst" },
				{ "dutch",     "Welkom" },
				{ "estonian",  "Tere tulemast" },
				{ "finnish",   "Tervetuloa" },
				{ "flemish",   "Welgekomen" },
				{ "french",    "Bienvenue" },
				{ "german",    "Willkommen" },
				{ "irish",     "Failte" },
				{ "italian",   "Benvenuto" },
				{ "latvian",   "Gaidits" },
				{ "lithuanian","Laukiamas" },
				{ "polish",    "Witamy" },
				{ "spanish",   "Bienvenido" },
				{ "swedish",   "Valkommen" },
				{ "welsh",     "Croeso" }
			};
			return welcomes.ContainsKey(language) ? welcomes[language] : "Welcome";
		}

		public static void DisplayTest(string text)
		{
			ITest test = new Test();
			test.Name = text;
			test.Print();
		}

		public static int[] SortNumbers(int[] nums)
		{
			return nums != null ? nums.ToList().OrderBy(x => x).ToArray() : new int[] { };
		}

		public static int sumTwoSmallestNumbers(int[] numbers)
		{
			return numbers.OrderBy(x => x).Take(2).Sum();
		}

		public static string Problem(String a)
		{
			double result;
			return Double.TryParse(a, out result) ? ((result * 50) + 6).ToString() : "Error";
		}

		public static ulong[] productFib(ulong prod)
		{
			if (prod == 0) return new ulong[] { 0 };

			ulong x = 0, y = 1;
			do
			{
				ulong r = y;
				y = y + x;
				x = r;
			} while (prod > x * y);
			return prod == x * y ? new ulong[] { x, y, 1 } : new ulong[] { x, y, 0 };
		}

		public static int[,] MultiplicationTable(int size)
		{
			int[,] numbers = new int[size, size];
			for (int i = 0; i < size; i++)
			{
				int x = i + 1;

				for (int j = 0; j < size; j++)
				{
					int y = j + 1;
					numbers[i, j] = x * y;
				}
			}
			return numbers;
		}

		public static int[] Take(int[] arr, int n)
		{
			return arr?.Take(n).ToArray();
		}

		public static int GetAge(string inputString)
		{
			return Convert.ToInt32(inputString.Split(' ')[0]);
		}

		public static int HexToDec(string hexString)
		{
			return hexString[0] == '-' ? int.Parse(hexString.Substring(1), System.Globalization.NumberStyles.HexNumber) * (-1) : int.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
		}
		public static string FirstNonRepeatingLetter(string s)
		{
			if (s.Length > 0)
			{
				var t = s.ToLower().GroupBy(l => l).Where(g => g.Count() == 1).Select(l => l.Key);
				if (t.Count() <= 0) return "";
				else
				{
					t.First().ToString();
					foreach (var l in s)
					{
						if (t.First().ToString() == l.ToString().ToLower()) return l.ToString();
					}
				}
				return s;
			}
			else return s;
			//Code from codewars
			//return s.GroupBy(char.ToLower)
			//.Where(gr => gr.Count() == 1)
			//.Select(x => x.First().ToString())
			//.DefaultIfEmpty("")
			//.First();
		}

		public static string[] Capitalize(string s)
		{
			return new string[] { string.Join("", s.Select((x, index) => index % 2 == 0 ? char.ToUpper(x) : x)), string.Join("", s.Select((x, index) => index % 2 == 1 ? char.ToUpper(x) : x)) };
		}

		public static int Divisors(int n)
		{
			int x = 0;
			for (int i = 1; i <= n; i++)
			{
				if (n % i == 0) x++;
			}
			return x;
		}
		public string Rps(string p1, string p2)
		{
			switch (p1)
			{
				case "scissors":
					return p2 == "rock" ? "Player 2 won!" : p2 == "paper" ? "Player 1 won!" : "Draw!";
				case "rock":
					return p2 == "paper" ? "Player 2 won!" : p2 == "scissors" ? "Player 1 won!" : "Draw!";
				case "paper":
					return p2 == "scissors" ? "Player 2 won!" : p2 == "rock" ? "Player 1 won!" : "Draw!";
				default:
					throw new Exception("Wrong input!");
			}
		}

		public static string[] AddLength(string str)
		{
			return str.Split(' ').Select(x => $"{x}  {x.Length}").ToArray();
		}

		public static string Mix(string s1, string s2)
		{
			List<string> result = new List<string>();
			var s11 = s1.Where(char.IsLower)
					  .GroupBy(c => c)
					  .ToDictionary(g => g.Key, g => g.Count());
			var s22 = s2.Where(char.IsLower)
					  .GroupBy(c => c)
					  .ToDictionary(g => g.Key, g => g.Count());

			var allLetters = s11.Keys.Concat(s22.Keys).Distinct();

			foreach (char letter in allLetters)
			{
				int countInS1 = s11.ContainsKey(letter) ? s11[letter] : 0;
				int countInS2 = s22.ContainsKey(letter) ? s22[letter] : 0;
				int maxCount = Math.Max(countInS1, countInS2);

				if (maxCount > 1)
				{
					string prefix = countInS1 > countInS2 ? "1:" :
									countInS1 < countInS2 ? "2:" : "=:";
					result.Add($"{prefix}{new string(letter, maxCount)}");
				}
			}
			return string.Join("/", result.OrderByDescending(s => s.Length)
									.ThenBy(s => s[0])
									.ThenBy(x => x));
		}


		//TODO
		public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
		{
			//Set variable to remember last yielded value
			T last = default;
			bool first = true;

			//Iterate by collection
			foreach (T item in iterable)
			{
				if (first)
				{
					//Yield first element
					yield return item;
					//Set variable to false because you just read first element
					first = false;
					//Set last to check if last element was different
					last = item;
				}
				//Check if value is different than last yielded. If yes set new value and yield new unique value
				else if (!object.Equals(last, item))
				{
					last = item;
					yield return item;
				}
			}
		}

		public static long digPow(int n, int p)
		{
			double result = 0;
			var nToSplit = n.ToString();
			foreach (var number in nToSplit)
			{
				result += Math.Pow(number - 48, p++);
			}

			return result / n == (long)result / (long)n ? (long)result / n : -1;
		}
		/// <summary>
		/// Exercise
		/// https://www.codewars.com/kata/5a34b80155519e1a00000009/train/csharp
		/// </summary>
		/// <param name="xs">List of numbers</param>
		/// <returns>Return a new array consisting of elements which are multiple of their own index in input array.</returns>
		public static List<int> MultipleOfIndex(List<int> xs)
		{
			return xs.Where((x, i) => (i != 0 && x != 0) ? x % i == 0 : 0 == x).ToList();
		}

		public static int NbYear(int p0, double percent, int aug, int p)
		{
			var actualPeople = p0;
			int years = 0;
			while (actualPeople < p)
			{
				actualPeople += (int)((actualPeople * (percent / 100)) + aug);
				years++;
			}

			return years;
		}

		public static List<int> PipeFix(List<int> numbers)
		{
			List<int> result = new List<int>();
			for (int i = numbers.First(); i < numbers.Last(); i++) result.Add(i);

			return result;
		}

		public static string Bmi(double weight, double height)
		{
			var bmi = weight / (height * height);

			if (bmi <= 18.5) return "Underweight";
			else if (bmi <= 25) return "Normal";
			else if (bmi <= 30) return "Overweight";
			else return "Obese";
		}

		public static string StringClean(string s)
		{
			return string.Join("", s.Where(l => !char.IsDigit(l)));
		}

		public static int Remainder(int a, int b)
		{
			return a > b ? a % b : b % a;
		}
		public static object[] RemoveEveryOther(object[] arr)
		{
			return arr.Where((e, i) => (int)i % 2 == 0).ToArray();
		}
		public static string[] StringToArray(string str)
		{
			return str.Split(' ');
		}
		public static string NoSpace(string input)
		{
			return string.Join("", input.Where(e => e != ' '));
		}
		public static int[] NoOdds(int[] values)
		{
			// Code??
			return values.Where(x => x % 2 == 0).ToArray();
		}
		public static bool IsCube(double volume, double side)
		{
			return side * side * side == volume;
		}
		public static bool CheckCoupon(string enteredCode, string correctCode, string currentDate, string expirationDate)
		{
			return DateTime.ParseExact(currentDate, "MMMM d, yyyy", CultureInfo.InvariantCulture) <= DateTime.ParseExact(expirationDate, "MMMM d, yyyy", CultureInfo.InvariantCulture) && enteredCode == correctCode;
		}
		public static int CalculateYears(double principal, double interest, double tax, double desiredPrincipal)
		{
			int years = 0;
			while (principal < desiredPrincipal)
			{
				double yearTax = (principal * interest) * tax;
				double yearInterest = (principal * interest);
				principal = principal + yearInterest - yearTax;
				years++;
			}
			return years;
		}
		public static string Remove(string s)
		{
			return s[s.Length - 1] == '!' ? s.Substring(0, s.Length - 2) : s;
		}
		public static bool SpeakEnglish(string sentence) => sentence.ToLower().Contains("english");
		public static string stockSummary(String[] lstOfArt, String[] lstOf1stLetter)
		{
			if (lstOfArt.Length == 0 || lstOf1stLetter.Length == 0) return string.Empty;
			var list = lstOfArt.Select(x => x.Split(' '));
			var dictionary = new Dictionary<string, int>();

			foreach (var letter in lstOf1stLetter)
			{
				int count = 0;
				foreach (var x in list)
				{
					if (x[0].ToArray()[0] == Convert.ToChar(letter))
					{
						count += Convert.ToInt32(x[1]);
					}
				}
				dictionary.Add(letter.Trim(), count);
			}
			return $"({string.Join(") - (", dictionary.Select(x => x.Key + " : " + x.Value))})";
		}
		public static int SumMul(int n, int m)
		{
			if (m < n) throw new ArgumentException();
			int result = 0;

			for (int i = n; i < m; i += n)

			{
				result += i;
			}
			return result;
		}

		public static int evaporator(double content, double evap_per_day, double threshold)
		{
			int days = 0;
			double limit = content * (threshold / 100);
			while (content >= limit)
			{
				content -= content * (evap_per_day / 100);
				days++;
			}
			return days;
		}

		public static bool Include(int[] arr, int item)
		{
			return arr.Contains(item);
		}
		public static long FindNextSquare(long num)
		{
			long sqrt = (long)Math.Sqrt(num);
			return sqrt * sqrt != num ? -1 : (sqrt + 1) * (sqrt + 1);
		}
		public static void If(bool condition, Action func1, Action func2)
		{
			if (condition) func1();
			else func2();
		}
		//Task: https://www.codewars.com/kata/65b9af728732e1002463ab5e/train/csharp
		//TODO
		public static string ToWords(string move)
		{
			if (move == "O-O") return "A kingside castle.";
			else if (move == "O-O-O") return "A queenside castle.";

			//Set "Pawn" because, If no piece type choosed only left option will be Pawn
			string pieceType = "Pawn";

			//Check what piece type selected, and remove it form string to easier serialize
			if (move.Contains('K'))
			{
				pieceType = "King";
				move.Remove(move.IndexOf('K'));
			}
			else if (move.Contains('Q'))
			{
				pieceType = "Queen";
				move.Remove(move.IndexOf('Q'));
			}
			else if (move.Contains('B'))
			{
				pieceType = "Bishop";
				move.Remove(move.IndexOf('B'));
			}
			else if (move.Contains('R'))
			{
				pieceType = "Rook";
				move.Remove(move.IndexOf('R'));
			}
			else if (move.Contains('N'))
			{
				pieceType = "Knight";
				move.Remove(move.IndexOf('N'));
			}


			//Find next move position and remove this from string
			int numberPosition = move.IndexOfAny("1234567890".ToCharArray());

			//Save new position of the piece
			string mewPosition = $"{move[numberPosition - 1] + move[numberPosition]}";

			//Delete data about new position from move
			move.Remove(numberPosition - 1, 2);

			//Check if captured
			bool isCaptured = move.Contains('x');
			if (move.Contains("ex")) move.Remove(move.IndexOf('x') - 1, 2);
			if (move.Contains('x')) move.Remove(move.IndexOf('x'));

			//Check if check or checkmates
			bool isCheck = move.Contains('+');
			bool isCheckmates = move.Contains('#');
			if (move.Contains('+')) move.Remove(move.IndexOf('+'));
			if (move.Contains('#')) move.Remove(move.IndexOf('#'));


			string moveText = $"{pieceType} moved to {mewPosition}";

			return moveText;
		}
		//Task: https://www.codewars.com/kata/515de9ae9dcfc28eb6000001/train/csharp
		public static string[] Solution(string str)
		{
			List<string> result = new List<string>();
			string pairOfLetters = string.Empty;
			for (int i = 0; i < str.Length; i++)
			{
				pairOfLetters += str[i];
				if (pairOfLetters.Length == 2)
				{
					result.Add(pairOfLetters);
					pairOfLetters = string.Empty;
				}
			}
			if (pairOfLetters.Length == 1)
			{
				pairOfLetters += "_";
				result.Add(pairOfLetters);
			}
			return result.ToArray();
		}
		public static string ArrayShort(string s)
		{
			return s.Count() < 5 ? null : string.Join(" ", s.Trim().Split(',').ToList().GetRange(1, s.Split(',').Count() - 1));
		}
		public static bool IsPrime(int n)
		{
			if (n <= 1) return false;
			if (n == 2) return true;
			if (n % 2 == 0) return false;

			var boundary = (int)Math.Floor(Math.Sqrt(n));

			for (int i = 3; i <= boundary; i += 2)
				if (n % i == 0)
					return false;

			return true;
		}
		public static int[] SortArray(int[] array)
		{
			//TODO
			//foreach (var item in array)
			//{
			//	if (item % 2 == 1)
			//	{
			//		item = null;
			//	}
			//}
			//int[,] oddList = new int[array.Length,2];
			//int index=0;
			//for (int i = 0; i < array.Length; i++)
			//{
			//	if (array[i] % 2 == 1)
			//	{
			//		oddList[index,0] = i;
			//		oddList[index,1] = array[i];
			//		index++;
			//	}
			//}
			//sortedList.Sort();
			return null;
		}

		public static char FindMissingLetter(char[] array)
		{
			int r = -1;
			bool first = true;

			foreach (char c in array)
			{
				if (first)
				{
					r = c;
					first = false;
				}
				else if (r - c == 1)
				{
					r = c;
				}
				else
				{
					r = r + 1;
					break;
				}
			}

			return (char)r;
			//if (array[0]>=97 && array[0] <= 122)
			//{
			//	for (int i = array[0]; i < 122; i++)
			//	{
			//		if()
			//	}
			//}
			//else
			//	return ' ';
		}
		/// <summary>
		/// Link: https://www.codewars.com/kata/56fc55cd1f5a93d68a001d4e/train/csharp
		/// </summary>
		/// <param name="stairs">Array represents every day in week and in every day you have count of the steps climbed</param>
		/// <returns>Return the 20 year estimate of the stairs climbed by monk</returns>
		public static long StairsIn20(int[][] stairs)
		{
			long sum = 0;
			for (int i = 0; i < stairs.Length; i++)
			{
				for (int j = 0; j < stairs[i].Length; j++)
				{
					sum += stairs[i][j];
				}
			}

			return sum;

			//LINQ
			//return stairs.Sum(x => x.Sum()) * 20
		}
		/// <summary>
		/// Link: https://www.codewars.com/kata/5a2fd38b55519ed98f0000ce/train/csharp
		/// </summary>
		/// <param name="number">Number by what is multipicated</param>
		/// <returns>Return multiplication table from 1 to 10, every result in new line</returns>
		public static string MultiTable(int number)
		{
			List<string> result = new List<string>();

			for (int i = 1; i < 11; i++)
			{
				result.Add($"{i} * {number} = {i * number}");
			}

			return string.Join("\n", result);

			//CODEWARS
			// return string.Join("\n", Enumerable.Range(1, 10).Select(i => $"{i} * {number} = {i * number}"));
		}
		public static string GetDrinkByProfession(string p)
		{
			switch (p.ToLower())
			{
				case "Jabroni":
					return "Patron Tequila";
				case "School Counselor":
					return "Anything with Alcohol";
				case "Programmer":
					return "Hipster Craft Beer";
				case "Bike Gang Member":
					return "Moonshine";
				case "Politician":
					return "Your tax dollars";
				case "Rapper":
					return "Cristal";
				default:
					return "Beer";
			}
		}
		/// <summary>
		/// You are given an odd-length array of integers, in which all of them are the same, except for one single number.
		/// </summary>
		/// <param name="numbers">method which accepts an array</param>
		/// <returns>returns single different number</returns>
		public static int Stray(int[] numbers)
		{
			return numbers.GroupBy(x => x).Where(x => x.Count() == 1).Select(x => x.Key).FirstOrDefault();
		}

		public static int Mxdiflg(string[] a1, string[] a2)
		{
			if (a1.Count() < 1 || a2.Count() < 1) return -1;
			var a1Sorted = a1.OrderBy(x => x.Length);
			var a2Sorted = a2.OrderBy(x => x.Length);

			int a1Min = a1Sorted.First().Length;
			int a1Max = a1Sorted.Last().Length;

			int a2Min = a2Sorted.First().Length;
			int a2Max = a2Sorted.Last().Length;

			return a1Max - a2Min > a2Max - a1Min ? a1Max - a2Min : a2Max - a1Min;
		}
		public static int SameCase(char a, char b)
		{
			return (char.IsLetter(a) && char.IsLetter(b)) ? ((char.IsUpper(a) && char.IsUpper(b)) || (!char.IsUpper(a) && !char.IsUpper(b))) ? 1 : 0 : -1;
		}
		/// <summary>
		///The method processes a string of positive numbers separated by spaces and returns a sorted string based on the "weight" of the numbers, defined as the sum of their digits. It utilizes LINQ for string manipulation, grouping, sorting, and joining the results.
		/// </summary>
		/// <param name="strng">Positive numbers divided by space</param>
		/// <returns>Returns "Sorted" string where 'weight' of the number decide where in ranking number is</returns>
		/// <seealso cref="https://www.codewars.com/kata/55c6126177c9441a570000cc/train/csharp"/>
		public static string OrderWeight(string strng) => string.Join(" ", strng
				//Divide by space
				.Split(' ')
				//Group by the 'weigth' Sum of numbers in number
				.GroupBy(x => x.Select(y => Convert.ToInt32(y) - 48).Sum())
				//Sort by value alphabetically
				.OrderBy(g => g.Key)
				//Join every element and set space between every element
				.SelectMany(g => g.OrderBy(x => x)));
		/// <summary>
		///Square all numbers between 0 and n. Count the numbers of digits d used in the writing of all the k**2. Implement the function taking n and d as parameters and returning this count.
		/// </summary>
		/// <param name="n">Range for loop more than 0 </param>
		/// <param name="d">Number for what we looking</param>
		/// <returns></returns>
		public static int NbDig(int n, int d) => Enumerable
			.Range(0, n + 1)
			.Select(x => (x * x).ToString()
			.Where(s => s == d + 48).Count())
			.Sum();
		/// <summary>
		/// Method returns mapped string where every element in string is multiply by index number.
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string Accum(string s) => string.Join("-", s.Select((x, i) => x + new string(char.ToLower(x), i)));
		/// <summary>
		/// Hide characters of the string and one the end shows only last 4 characters.
		/// </summary>
		/// <param name="cc">Receive a string to hide</param>
		/// <returns>Returns hiden characters</returns>
		/// <example>Receive "123456789" and return "#####6789"</example>
		public static string Maskify(string cc) => string.Join("",cc.Select((x, i) => i > cc.Length ? x : '#'));

		public static string RemoveExclamationMarks(string s) => string.Join("",s.Where(x => x != '!'));

		public static int OtherAngle(int a, int b) => (int)Math.Sqrt(Math.Pow(a,2)+Math.Pow(b,2));
		public static bool Feast(string beast, string dish) => (beast[0] == dish[0]) && (beast[beast.Length - 1] == dish[dish.Length - 1]);

		public static int[] DivisorsV2(int n) => Enumerable.Range(2, n - 2).Where(x => n % x == 0).ToArray().Count()==0 ? null : Enumerable.Range(2, n - 2).Where(x => n % x == 0).ToArray();
		/// <summary>
		/// Method receive the parameter m which contains total volume of the building. Method calculate and return the count of the cubess needed to build. If not possible return -1.
		/// </summary>
		/// <param name="m">Total volume of the building</param>
		/// <returns>Count of cubes needed to build tower with such volume</returns>
		/// <see cref="https://www.codewars.com/kata/5592e3bd57b64d00f3000047/train/csharp"/>
		public static long findNb(long m)
		{
			long totalVolume = 0;
			long totalCubes = 0;

			do
			{
				totalCubes++;
				totalVolume += (long)Math.Pow(totalCubes,3);
			} while (totalVolume < m);

			return totalVolume != m ? -1 : totalCubes;
		}

		public static string SwitchItUp(int number)
		{
			switch (number)
			{
				case 0: return "Zero";
				case 1: return "One";
				case 2: return "Two";
				case 3: return "Three";
				case 4: return "Four";
				case 5: return "Five";
				case 6: return "Six";
				case 7: return "Seven";
				case 8: return "Eigth";
				case 9: return "Nine";
				default: throw new Exception();
			}
		}

		public static int[] MonkeyCount(int n) => Enumerable.Range(1, n).ToArray();

		public static object FirstNonConsecutive(int[] arr)
		{
			int previousNumber = arr[0];
			for (int i = 1; i < arr.Length; i++)
			{
				if (arr[i]!=previousNumber+1) return arr[i];
				previousNumber=arr[i];
			}

			return null;
		}
		public static int[] PowersOfTwo(int n) => Enumerable.Range(0, n+1).Select(x => (int)Math.Pow(2, x)).Select(x => x == 0 ? 1 : x).ToArray();

		public static string ToAlternatingCase(string s) => string.Join("", s.Select(x => char.IsUpper(x) ? char.ToLower(x) : char.ToUpper(x)));

		public static string StringsSum(string s1, string s2) 
		{
			int.TryParse(s1, out var v1);
			int.TryParse(s2, out var v2);

			return (v1 + v2).ToString();

		}

		public static string TwoSort(string[] s) => string.Join("*",s.OrderBy(x => x).ToList().GetRange(0,3));
	};
}
