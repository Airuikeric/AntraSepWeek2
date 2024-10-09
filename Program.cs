using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

// Uncomment the method calls to run each specific example

// DisplayNumberTypeInfo();
// ConvertCenturies();
// FizzBuzzGame();
// PrintPyramid();
// GuessTheNumber();
// CalculateDaysSinceBirth();
// DisplayTimeOfDayGreeting();
// CountWithDifferentIncrements();
// CopyArrayExample();
// ManageListExample();
// DisplayPrimesInRange(10, 50);
// RotateAndSumArrayExample();
// FindLongestSequenceExample();
// FindMostFrequentNumberExample();
// ReverseStringExample();
// ReverseWordsInSentenceExample();
// ExtractPalindromesExample();
// ParseUrlExample();

    static void DisplayNumberTypeInfo()
    {
        Console.WriteLine("{0, -10} {1, -10} {2, -30} {3, -30}", "Type", "Bytes", "Min Value", "Max Value");
        Console.WriteLine(new string('-', 80));

        DisplayTypeInfo<sbyte>("sbyte");
        DisplayTypeInfo<byte>("byte");
        DisplayTypeInfo<short>("short");
        DisplayTypeInfo<ushort>("ushort");
        DisplayTypeInfo<int>("int");
        DisplayTypeInfo<uint>("uint");
        DisplayTypeInfo<long>("long");
        DisplayTypeInfo<ulong>("ulong");
        DisplayTypeInfo<float>("float");
        DisplayTypeInfo<double>("double");
        DisplayTypeInfo<decimal>("decimal");

        Console.WriteLine("=========================================================================");
    }

    static void DisplayTypeInfo<T>(string typeName) where T : struct
    {
        int byteSize = System.Runtime.InteropServices.Marshal.SizeOf(typeof(T));
        var minValue = typeof(T).GetField("MinValue").GetValue(null);
        var maxValue = typeof(T).GetField("MaxValue").GetValue(null);

        Console.WriteLine("{0, -10} {1, -10} {2, -30} {3, -30}", typeName, byteSize, minValue, maxValue);
    }

    static void ConvertCenturies()
    {
        Console.Write("Enter the number of centuries: ");
        int centuries = int.Parse(Console.ReadLine());

        int years = centuries * 100;
        int days = (int)(years * 365.24);
        long hours = days * 24;
        long minutes = hours * 60;
        long seconds = minutes * 60;
        long milliseconds = seconds * 1000;
        long microseconds = milliseconds * 1000;
        decimal nanoseconds = (decimal)microseconds * 1000;

        Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
        Console.WriteLine("=========================================================================");
    }

    static void FizzBuzzGame()
    {
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0) Console.WriteLine("FizzBuzz");
            else if (i % 3 == 0) Console.WriteLine("Fizz");
            else if (i % 5 == 0) Console.WriteLine("Buzz");
            else Console.WriteLine(i);
        }
    }

    static void PrintPyramid()
    {
        Console.Write("Enter the number of rows for the pyramid: ");
        int rows = int.Parse(Console.ReadLine());

        for (int i = 1; i <= rows; i++)
        {
            Console.Write(new string(' ', rows - i));
            Console.WriteLine(new string('*', 2 * i - 1));
        }
    }

    static void GuessTheNumber()
    {
        int correctNumber = new Random().Next(3) + 1;
        Console.WriteLine("Guess a number between 1 and 3:");

        while (true)
        {
            int guessedNumber = int.Parse(Console.ReadLine());
            if (guessedNumber < 1 || guessedNumber > 3) Console.WriteLine("Please enter a number between 1 and 3.");
            else if (guessedNumber < correctNumber) Console.WriteLine("Too low, try again.");
            else if (guessedNumber > correctNumber) Console.WriteLine("Too high, try again.");
            else { Console.WriteLine("Correct! You guessed the number."); break; }
        }
    }

    static void CalculateDaysSinceBirth()
    {
        DateTime birthDate = new DateTime(1997, 12, 20);
        DateTime today = DateTime.Now;
        int ageInDays = (today - birthDate).Days;

        Console.WriteLine($"The person is {ageInDays} days old.");

        int daysToNextAnniversary = 10000 - (ageInDays % 10000);
        DateTime nextAnniversaryDate = today.AddDays(daysToNextAnniversary);

        Console.WriteLine($"Days until the next 10,000-day anniversary: {daysToNextAnniversary}");
        Console.WriteLine($"The next 10,000-day anniversary will be on: {nextAnniversaryDate.ToShortDateString()}");
    }

    static void DisplayTimeOfDayGreeting()
    {
        DateTime currentTime = DateTime.Now;
        int currentHour = currentTime.Hour;

        if (currentHour >= 5 && currentHour < 12) Console.WriteLine("Good Morning");
        if (currentHour >= 12 && currentHour < 17) Console.WriteLine("Good Afternoon");
        if (currentHour >= 17 && currentHour < 21) Console.WriteLine("Good Evening");
        if ((currentHour >= 21 && currentHour <= 23) || (currentHour >= 0 && currentHour < 5)) Console.WriteLine("Good Night");
    }

    static void CountWithDifferentIncrements()
    {
        for (int increment = 1; increment <= 4; increment++)
        {
            for (int i = 0; i <= 24; i += increment)
            {
                Console.Write(i + (i + increment <= 24 ? ", " : ""));
            }
            Console.WriteLine();
        }
    }

    static void CopyArrayExample()
    {
        int[] originalArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] copiedArray = new int[originalArray.Length];
        for (int i = 0; i < originalArray.Length; i++) copiedArray[i] = originalArray[i];

        Console.WriteLine("Original Array: " + string.Join(" ", originalArray));
        Console.WriteLine("Copied Array: " + string.Join(" ", copiedArray));
    }

    static void ManageListExample()
    {
        List<string> itemList = new List<string>();
        while (true)
        {
            Console.WriteLine("\nEnter command (+ item, - item, or -- to clear):");
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;

            if (input.StartsWith("+"))
            {
                string itemToAdd = input.Substring(1).Trim();
                if (!string.IsNullOrWhiteSpace(itemToAdd)) itemList.Add(itemToAdd);
            }
            else if (input.StartsWith("-") && input.Length > 1)
            {
                string itemToRemove = input.Substring(1).Trim();
                itemList.Remove(itemToRemove);
            }
            else if (input == "--") itemList.Clear();
            else Console.WriteLine("Invalid command");

            Console.WriteLine("\nCurrent List: " + (itemList.Count > 0 ? string.Join(", ", itemList) : "(empty)"));
        }
    }

    static void DisplayPrimesInRange(int start, int end)
    {
        Console.WriteLine("Prime numbers in the range: " + string.Join(", ", FindPrimesInRange(start, end)));
    }

    static int[] FindPrimesInRange(int startNum, int endNum)
    {
        List<int> primes = new List<int>();
        for (int i = startNum; i <= endNum; i++) if (IsPrime(i)) primes.Add(i);
        return primes.ToArray();
    }

    static bool IsPrime(int number)
    {
        if (number < 2) return false;
        for (int i = 2; i <= Math.Sqrt(number); i++) if (number % i == 0) return false;
        return true;
    }

    static void RotateAndSumArrayExample()
    {
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int k = int.Parse(Console.ReadLine());
        int n = array.Length;
        int[] sumArray = new int[n];

        for (int r = 0; r < k; r++)
        {
            int lastElement = array[n - 1];
            for (int i = n - 1; i > 0; i--) array[i] = array[i - 1];
            array[0] = lastElement;

            for (int i = 0; i < n; i++) sumArray[i] += array[i];
        }
        Console.WriteLine("Sum after rotations: " + string.Join(" ", sumArray));
    }

    static void FindLongestSequenceExample()
    {
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        int bestLength = 0;
        int bestElement = array[0];
        int currentLength = 1;

        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] == array[i - 1]) currentLength++;
            else
            {
                if (currentLength > bestLength)
                {
                    bestLength = currentLength;
                    bestElement = array[i - 1];
                }
                currentLength = 1;
            }
        }

        if (currentLength > bestLength)
        {
            bestLength = currentLength;
            bestElement = array[array.Length - 1];
        }

        Console.WriteLine("Longest sequence: " + string.Join(" ", Enumerable.Repeat(bestElement, bestLength)));
    }

    static void FindMostFrequentNumberExample()
    {
        int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Dictionary<int, int> frequency = new Dictionary<int, int>();

        foreach (var number in array)
        {
            if (frequency.ContainsKey(number)) frequency[number]++;
            else frequency[number] = 1;
        }

        int maxFrequency = 0;
        int mostFrequentNumber = array[0];

        foreach (var number in array)
        {
            if (frequency[number] > maxFrequency)
            {
                maxFrequency = frequency[number];
                mostFrequentNumber = number;
            }
        }

        Console.WriteLine($"The number {mostFrequentNumber} is the most frequent (occurs {maxFrequency} times)");
    }

    static void ReverseStringExample()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        // Method 1: Using char array and Array.Reverse
        string reversedWithArray = ReverseWithCharArray(input);
        Console.WriteLine("Reversed (Method 1): " + reversedWithArray);

        // Method 2: Using a for loop to print in reverse
        Console.Write("Reversed (Method 2): ");
        ReverseWithForLoop(input);
    }

    static string ReverseWithCharArray(string input)
    {
        char[] charArray = input.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    static void ReverseWithForLoop(string input)
    {
        for (int i = input.Length - 1; i >= 0; i--) Console.Write(input[i]);
        Console.WriteLine();
    }

    static void ReverseWordsInSentenceExample()
    {
        Console.WriteLine("Enter a sentence:");
        string input = Console.ReadLine();

        string result = ReverseWordsInSentence(input);
        Console.WriteLine("Reversed words:");
        Console.WriteLine(result);
    }

    static string ReverseWordsInSentence(string sentence)
    {
        string pattern = @"[\.,:;=\(\)\&\[\]""'\\\/!\?\s]";
        var words = new List<string>();
        var separators = new List<string>();

        int start = 0;
        bool isSeparator = Regex.IsMatch(sentence[0].ToString(), pattern);

        for (int i = 0; i <= sentence.Length; i++)
        {
            if (i == sentence.Length || Regex.IsMatch(sentence[i].ToString(), pattern) != isSeparator)
            {
                if (isSeparator) separators.Add(sentence.Substring(start, i - start));
                else words.Add(sentence.Substring(start, i - start));
                start = i;
                isSeparator = !isSeparator;
            }
        }

        words.Reverse();
        var result = new StringBuilder();
        int wordIndex = 0, separatorIndex = 0;
        bool addWord = !Regex.IsMatch(sentence[0].ToString(), pattern);

        for (int i = 0; i < words.Count + separators.Count; i++)
        {
            if (addWord) result.Append(words[wordIndex++]);
            else result.Append(separators[separatorIndex++]);
            addWord = !addWord;
        }

        return result.ToString();
    }

    static void ExtractPalindromesExample()
    {
        Console.WriteLine("Enter a text:");
        string input = Console.ReadLine();

        var palindromes = ExtractUniquePalindromes(input);
        Console.WriteLine("Palindromic words:");
        Console.WriteLine(string.Join(", ", palindromes));
    }

    static List<string> ExtractUniquePalindromes(string text)
    {
        string[] words = Regex.Split(text, @"\W+");
        HashSet<string> uniquePalindromes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        foreach (string word in words)
        {
            if (IsPalindrome(word) && word.Length > 0)
            {
                uniquePalindromes.Add(word);
            }
        }

        return uniquePalindromes.OrderBy(p => p).ToList();
    }

    static bool IsPalindrome(string word)
    {
        int len = word.Length;
        for (int i = 0; i < len / 2; i++)
        {
            if (char.ToLower(word[i]) != char.ToLower(word[len - i - 1])) return false;
        }
        return true;
    }

    static void ParseUrlExample()
    {
        Console.WriteLine("Enter a URL:");
        string url = Console.ReadLine();
        ParseUrl(url);
    }

    static void ParseUrl(string url)
    {
        string protocol = "";
        string server = "";
        string resource = "";

        int protocolIndex = url.IndexOf("://");
        if (protocolIndex != -1)
        {
            protocol = url.Substring(0, protocolIndex);
            url = url.Substring(protocolIndex + 3);
        }

        int resourceIndex = url.IndexOf('/');
        if (resourceIndex != -1)
        {
            server = url.Substring(0, resourceIndex);
            resource = url.Substring(resourceIndex + 1);
        }
        else
        {
            server = url;
        }

        Console.WriteLine($"[protocol] = \"{protocol}\"");
        Console.WriteLine($"[server] = \"{server}\"");
        Console.WriteLine($"[resource] = \"{resource}\"");
    }
