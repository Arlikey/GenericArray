namespace NumberConverter
{
    public class NumberConverter
    {
        public static string ConvertNumbersToWords(string inputText)
        {
            string[] words = inputText.Split(new[] { ' ', ',', '.', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if (int.TryParse(words[i], out int number) && number >= 1 && number <= 9999)
                {
                    words[i] = NumbersLibrary.Convert(number);
                }
            }

            return string.Join(" ", words);
        }
    }

    public static class NumbersLibrary
    {
        private static string[] digits = { "", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };
        private static string[] teens = { "", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
        private static string[] tens = { "", "десять", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
        private static string[] hundreds = {"", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
        private static string[] thousands = { "", "тысяча", "две тысячи", "три тысячи", "четыре тысячи", "пять тысяч", "шесть тысяч", "семь тысяч", "восемь тысяч", "девять тысяч" };

        public static string Convert(int number)
        {
            string result = "";

            int thousand = number / 1000;
            int hundred = number / 100 % 10;
            int ten = (number % 100) / 10;
            int digit = number % 10;

            if (thousand > 0 ) {
                result += thousands[thousand] + " ";
            }

            if (hundred > 0)
            {
                result += hundreds[hundred] + " ";
            }

            if (ten == 1 && digit > 0)
            {
                result += teens[digit] + " ";
            }
            else
            {
                result += tens[ten] + " " + digits[digit] + " ";
            }

            return result.Trim();
        }
    }
}
