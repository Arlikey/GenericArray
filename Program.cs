using NumberConverter;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace GenericArray
{
    /*internal class Program
    {
        static void Main(string[] args)
        {
            Array<int> array = new Array<int>();

            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }

            array.Remove(2);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public class Array<T>
        {
            private T[] array;

            public Array(T[] array)
            {
                this.array = array;
            }

            public Array()
            {
                this.array = new T[0];
            }

            public int Length { get => array.Length; }
            public T this[int index]
            {
                get => array[index];
            }

            public void Add(T value)
            {
                T[] tempArray = new T[array.Length + 1];

                for (int i = 0; i < array.Length; i++)
                {
                    tempArray[i] = array[i];
                }

                tempArray[tempArray.Length - 1] = value;

                array = tempArray;
            }

            public void Remove(int index)
            {
                T[] tempArray = new T[array.Length - 1];

                for (int i = 0, j = 0; i < array.Length; i++)
                {
                    if (i == index) continue;
                    tempArray[j++] = array[i];
                }

                array = tempArray;
            }

            public int GetLength()
            {
                return array.Length;
            }
        }
    }*/

    /*public class AdditionalTask1
    {
        static void Main()
        {
            Book book = new Book() {
                Title = "451 градус по Фаренгейту",
                Author = "Рэй Бредбери",
                Year = 1953,
                Description = "Роман описывает американское          общество близкого будущего, " +
                "в котором книги               находятся\n под запретом; «пожарные», к числу которых принадлежит" +
                " и главный герой Гай Монтэг, сжигают любые             найденные книги."
            };

            Console.WriteLine(book.Info());
        }

        public record Book
        {
            private string title;
            public string Title
            {
                get => title;
                set => title = NumberConverter.NumberConverter.ConvertNumbersToWords(value);
            }
            private string description;
            public string Description
            {
                get => description;
                set => description = RemoveDuplicateSpaces(value);
            }
            public string Author { get; set; }
            public int Year { get; set; } 

            public string Info()
            {
                return $"Название - {title}\nАвтор - {Author}\nГод - {Year}\nОписание: {description}";
            }
        }

        public static string RemoveDuplicateSpaces(string text)
        {
            string newText = "";
            bool wasSpace = false;

            foreach (char character in text)
            {
                if (char.IsWhiteSpace(character))
                {
                    if (!wasSpace)
                    {
                        newText += character;
                        wasSpace = true;
                    }
                }
                else
                {
                    newText += character;
                    wasSpace = false;
                }
            }

            return newText;
        }
    }*/

    /*public class AdditionalTask2
    {
        static void Main()
        {
            Matrix<int> matrixInt = new Matrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } });

            Console.WriteLine("\n\nMATRIX INT\n\n");

            matrixInt.Print();

            *//*Matrix<char> matrix1 = new Matrix<char>(new char[,] { { 'a', 'b', 'c' }, { 'a', 'b', 'c' } });

            Matrix<char> matrix2 = new Matrix<char>(new char[,] { { 'a', 'b', 'c' }, { 'a', 'b', 'c' } });

            var matrix3 = matrix1 * matrix2;*//*

            var matrixDecimal = new Matrix<decimal>(new decimal[,] { { 2.3m, 4.2m, 5.7m }, { 2.3m, 4.2m, 5.7m } });

            var matrixDecimalSum = matrixDecimal * 3;

            Console.WriteLine("\n\nMATRIX DECIMAL MULTIPLY NUMBER\n\n");

            matrixDecimalSum.Print();

        }

        public class Matrix<T>
        {
            private T[,] matrix;

            public int Rows { get => matrix.GetLength(0); }
            public int Cols { get => matrix.GetLength(1); }

            public int Length { get => matrix.Length; }

            public Matrix(T[,] matrix)
            {
                this.matrix = matrix;
            }

            public Matrix(int rows, int cols)
            {
                matrix = new T[rows, cols];
            }

            public T this[int i, int j]
            {
                get => matrix[i, j];
                set => matrix[i, j] = value;
            }

            public static Matrix<T> operator +(Matrix<T> a, Matrix<T> b)
            {
                if (a.Length != b.Length)
                {
                    throw new Exception("Matrix have different length!");
                }

                T[,] matrix = new T[a.Rows, a.Cols];

                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Cols; j++)
                    {
                        matrix[i, j] = (dynamic)a[i, j] + b[i, j];
                    }
                }

                return new Matrix<T>(matrix);
            }

            public static Matrix<T> operator *(Matrix<T> a, int b)
            {
                T[,] matrix = new T[a.Rows, a.Cols];

                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Cols; j++)
                    {
                        matrix[i, j] = (dynamic)a[i, j] * b;
                    }
                }

                return new Matrix<T>(matrix);
            }

            public static Matrix<T> operator *(Matrix<T> a, Matrix<T> b)
            {
                if (a[0, 0] is char || a[0, 0] is string)
                {
                    throw new Exception("Char and string is not available!");
                }

                if (a.Length != b.Length)
                {
                    throw new Exception("Matrix have different length!");
                }

                T[,] matrix = new T[a.Rows, a.Cols];

                for (int i = 0; i < a.Rows; i++)
                {
                    for (int j = 0; j < a.Cols; j++)
                    {
                        matrix[i, j] = (dynamic)a[i, j] * b[i, j];
                    }
                }

                return new Matrix<T>(matrix);
            }

            public void Print()
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }*/

    /*public class AdditionalTask3
    {
        static void Main()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 3 };

            var duplicatedArray = DuplicateElements<int>(array);

            for (int i = 0; i < duplicatedArray.Length; i++)
            {
                Console.Write(duplicatedArray[i] + " ");
            }
        }

        public static T[] DuplicateElements<T>(T[] elements)
        {
            T[] array = new T[elements.Length * 2];

            int index = 0;

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < elements.Length; j++)
                {
                    array[index++] = elements[j];
                }
            }

            return array;
        }
    }*/

    /*public class AdditionalTask7
    {
        static void Main()
        {
            Record object1 = new Record("Array", new int[] { 1, 2, 3, 4, 5 });

            Record object2 = object1 with { name = "Array", array = new int[] { 6, 7, 8, 9 } };

            Console.WriteLine(object1);
            Console.WriteLine(object2);

            Console.WriteLine(object1.Equals(object2));
        }

        public record Record(string name, int[] array);
    }*/
}
