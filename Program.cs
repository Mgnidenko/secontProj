using System.ComponentModel.Design;
using System.Text;

namespace secontProj
{
    internal class Program
    {
        static void Main(string[] args)
        {


            // Первый блок кода.

            Console.Write("Введите цифру 1, если вам нужно зашифровать текст , введите цифру 2 если текст нужно расшифровать: ");

            int checkNumber = ReadNumberInRange(1, 2, "");


            while (true)
            {
                if (checkNumber == 1)
                {
                    break;
                }
                else if (checkNumber == 2)
                {
                    break;
                }
                else
                {
                    checkNumber = ReadNumberInRange(1, 2, "Вы ввели не число или число больше 2 или меньше 1: ");
                    continue;
                }
            }

            // второй блок кода
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
                    isNumberKey = ReadNumberInRange(34, -1, "вы ввели не число, или число выходящее за приделы диапазона");
                }

            }

            // заменить на enum
            if (checkNumber == 1)
            {
                Console.WriteLine(Encoder(userWord, isNumberKey));
            }
            else if (checkNumber == 2)
            {
                Console.WriteLine(Decoder(userWord, isNumberKey));
            }


            // третий блок
        }

        /// <summary>
        /// Метод шифрует пользовательский текст по методу Цезаря
        /// </summary>
        /// <param name="userWord"></param>
        /// <param name="userNumber"></param>
        /// <returns></returns>
        static string Encoder(string userWord, int userNumber)
        {


            char[] lowerCaseAlphabet = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            char space = ' ';
            int[] arryOfIndeces = new int[userWord.Length];
            for (int i = 0; i < userWord.Length; i++)
            {


                int oneIndex = 0;

                for (int j = 0; j < lowerCaseAlphabet.Length; j++)
                {

                    if (lowerCaseAlphabet[j] == userWord[i])
                        oneIndex = j;
                }


                oneIndex += userNumber;
                if (userWord[i] == space)
                {
                    arryOfIndeces[i] = 38;
                    continue;
                }
                else if (oneIndex > 32)
                    oneIndex -= 33;
                arryOfIndeces[i] = oneIndex;
            }



            string encoderString = "";
            for (int k = 0; k < arryOfIndeces.Length; k++)
            {
                if (arryOfIndeces[k] == 38)
                {
                    encoderString += space;
                }
                else
                {
                    encoderString += lowerCaseAlphabet[arryOfIndeces[k]];
                }
            }

            return encoderString;

        }

        // четвертый блок

        /// <summary>
        /// Дешифратор по методу цезаря используя пользовательский введеный текст и сдвиг на заданное число.
        /// </summary>
        /// <param name="userWord"></param>
        /// <param name="userNumber"></param>
        /// <returns></returns>
        static string Decoder(string userWord, int userNumber)
        {
            char[] lowerCaseAlphabet = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            int[] arryOfIndeces = new int[userWord.Length];
            char space = ' ';

            for (int i = 0; i < userWord.Length; i++)
            {
                int oneIndex = 0;
                for (int j = 0; j < lowerCaseAlphabet.Length; j++)
                {
                    if ((lowerCaseAlphabet[j] == userWord[i]))
                        oneIndex = j;
                }
                oneIndex -= userNumber;
                if (userWord[i] == space)
                {
                    arryOfIndeces[i] = 38;
                }
                else if (oneIndex < 0)
                    oneIndex += 33;
                arryOfIndeces[i] = oneIndex;
            }

            string decoderString = "";
            for (int k = 0; k < arryOfIndeces.Length; k++)
            {
                if (arryOfIndeces[k] == -userNumber)
                {
                    decoderString += space;
                }
                else if (arryOfIndeces[k] < 0)
                {

                    continue;
                }
                else
                {
                    decoderString += lowerCaseAlphabet[arryOfIndeces[k]];
                }

            }

            return decoderString;
        }


        private static int ReadNumberInRange(int min, int max, string message)
        {
            Console.Write(message);
            while (true)
            {
                var input = Console.ReadLine();

                if (int.TryParse(input, out var result))
                {
                    if (result > min ^ result < max)
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
