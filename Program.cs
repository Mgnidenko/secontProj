using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace secontProj
{
    internal class Program
    {
        static void Main(string[] args)
        {



            Console.Write("Введите цифру 1, если вам нужно зашифровать текст , введите цифру 2 если текст нужно расшифровать: ");
            int checkNumber = ReadNumberInRange(1, 2, "");



            while (true)
            {
                if (checkNumber == 1 | checkNumber == 2)
                {
                    break;
                }
                else
                {
                    checkNumber = ReadNumberInRange(1, 2, "Вы ввели не число или число больше 2 или меньше 1: ");
                    continue;
                }
            }

            Console.WriteLine("Введите ваше слово на русском языке.");
            string userWord = Console.ReadLine();

            Console.WriteLine("Теперь введите число на которое будут сдвинуты все буквы, число не должно быть больше 33 и меньше 0. ");
            int isNumberKey = ReadNumberInRange(0, 33, "");


            while (true)
            {
                if (isNumberKey > -1 & isNumberKey < 34)
                {
                    break;
                }
                else
                {
                    isNumberKey = ReadNumberInRange(0, 33, "вы ввели не число, или число выходящее за приделы диапазона: ");
                }
            }


            if (checkNumber == (int)definitionFunction.Encoder)
            {
                Console.WriteLine(unionFun(userWord, isNumberKey, 1));
            }
            else if (checkNumber == (int)definitionFunction.Decoder)
            {
                Console.WriteLine(unionFun(userWord, isNumberKey, -1));
            }
        }



        public enum definitionFunction
        {
            Decoder,
            Encoder
        }

        private static string unionFun(string userWord, int userNumber, int unionMeaning)
        {
            char[] lowerCaseAlphabet = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            char space = ' ';
            int[] arryOfIndeces = new int[userWord.Length];

            for (int indexUserWord = 0; indexUserWord < userWord.Length; indexUserWord++)
            {

                int oneIndex = 0;
                for (int j = 0; j < lowerCaseAlphabet.Length; j++)
                {
                    if (lowerCaseAlphabet[j] == userWord[indexUserWord])
                        oneIndex = j;
                }


                oneIndex = oneIndex + (unionMeaning * userNumber);

                if (userWord[indexUserWord] == space)
                {
                    arryOfIndeces[indexUserWord] = 38;
                    continue;
                }
                else if (oneIndex < 0 | oneIndex > 32)
                    oneIndex = oneIndex + (33 * unionMeaning);
                arryOfIndeces[indexUserWord] = oneIndex;
            }


            string answerString = "";
            for (int k = 0; k < arryOfIndeces.Length; k++)
            {
                if (arryOfIndeces[k] == -userNumber | arryOfIndeces[k] == 38)
                {
                    answerString += space;                  

                }
                else
                {
                    answerString += lowerCaseAlphabet[arryOfIndeces[k]];
                }
            }
            return answerString;
        }


        private static int ReadNumberInRange(int min, int max, string message)
        {
            Console.Write(message);
            while (true)
            {
                var input = Console.ReadLine();

                if (int.TryParse(input, out var result))
                {
                    if (result >= min | result < max)
                    {
                        return result;
                    }
                }
                else
                {
                    PrintError("Введите число");
                }
            }
        }

        private static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }
}
