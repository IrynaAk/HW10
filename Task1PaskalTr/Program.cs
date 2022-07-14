// Задача 61: Показать треугольник Паскаля. *Сделать вывод в виде равнобедренного треугольника.


using System;
using static System.Console;
Clear();
WriteLine("Please type number of rows (should be less then 10)");
int row = int.Parse(ReadLine());
int column = row*2+1;

int[,] myArray = PaskalTr(row,column);
PrintArray(myArray);

int[,] PaskalTr(int row, int col)
{
    int[,] result = new int[row, col];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            if(i == 0)
            {
                if(j==col/2) {result[i,j] = 1;}
                else {result[i,j] = 0;}
            }
            else
            {
                if(j==0){result[i,j] = result[i-1,j+1];}
                else
                {
                    if (j==col-1) {result[i,j] = result[i-1,j-1];}
                    else
                    {
                        result[i,j] = result[i-1,j-1] + result[i-1,j+1];
                    }
                }
            }
        }
    }
    return result;
}


void PrintArray (int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if(array[i,j] == 0) Write("   ");
            else
            { 
                if(array[i,j]/10<0) Write($" {array[i,j]}  ");
                else
                {
                    Write($" {array[i,j]} ");
                }
            }
            
            
        }
        WriteLine();
    }
}