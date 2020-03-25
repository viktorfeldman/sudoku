using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sudoku
{
    public class Validator
    {

        public bool Validate(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return false;
            }
            string[] lines = File.ReadAllLines(fileName);
            if (lines.Length != 9) return false;
            try
            {
                int[,] sudokuArray = new int[9, 9];
                int lineNumber = 0;
                foreach (string line in lines)
                {
                    string[] numbers = line.Split(' ');
                    if (numbers.Length != 9)
                        return false;
                    int columnNumber = 0;
                    foreach (var number in numbers)
                    {
                        int value = Convert.ToInt32(number);
                        if (!(value >= 1 && value <= 9))
                        {
                            return false;
                        }
                        sudokuArray[lineNumber, columnNumber] = value;
                        columnNumber++;
                    }
                    lineNumber++;
                }

                //check row
                for (int i = 0; i < 9; i++)
                {
                    var row = Enumerable.Range(0, 9).Select(x => sudokuArray[i, x]);
                    if (row.Distinct().Count() != 9)
                        return false;
                }

                //check columns
                for (int i = 0; i < 9; i++)
                {
                    var column = Enumerable.Range(0, 9).Select(x => sudokuArray[x, i]);
                    if (column.Distinct().Count() != 9)
                        return false;
                }



                //check squares
                for (int i = 0; i < 3; i++)
                {

                    for (int j = 0; j < 3; j++)
                    {
                        if (!ValidateSquare(i, j, sudokuArray))
                            return false;
                    }
                }
            }
            catch
            {
                return false;
            }

            return true;
        }

        private bool ValidateSquare(int i, int j, int[,] sudokuArray)
        {
            var square = new List<int>();
            for (int i1 = 0; i1 < 3; i1++)
            {
                for (int j1 = 0; j1 < 3; j1++)
                {
                    square.Add(sudokuArray[i * 3 + i1, j * 3 + j1]);
                }
            }
            if (square.Distinct().Count() != 9)
                return false;

            return true;
        }
    }
}
