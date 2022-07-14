
// Задача 59: Из двумерного массива целых чисел удалить строку и столбец, на пересечении которых расположен наименьший элемент.

using System;
using static System.Console;
Clear();

int[,] myArray = GetRandomArray(3,3,1,20);
PrintArray(myArray);
WriteLine();
int min = FindMinEl(myArray);
int row = FindMinRow(myArray, min);
int col = FindMinCol(myArray, min);
WriteLine($"MinRow: {row}, MinCol: {col}, nim el: {min}");
int[,] myArrayNew = DeleteRow(myArray, row);
int[,] myArrayNew2 = RemoveColumn(myArrayNew, col);
PrintArray(myArrayNew2);



int[,] GetRandomArray(int row, int column, int min, int max)
{
    int[,] result = new int [row, column];
    for (int i = 0; i < row; i++)
    {
        int k =0;
        while(k<column)
        {
            int element = new Random().Next(min, max+1);
            if(FindElement(result, element)) continue;
            result[i,k] = element;
            k++;
        }
    }
    return result;
}


bool FindElement(int[,] arr, int el)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if(arr[i,j] == el) return true;
        }
    }
    return false;
} 


void PrintArray (int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Write($"{array[i,j]} ");
        }
        WriteLine();
    }
}

int FindMinEl (int[,] arr)
{
    int min = arr[0,0];
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if(arr[i,j]<min) 
            min = arr[i,j];
        }
    }
    return min;
}

int FindMinRow (int[,] arr, int minEl)
{
    int r =0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            
            if(arr[i,j]==minEl) 
            r = i;
        }
    }
    return r;
}


int FindMinCol (int[,] arr, int minEl)
{
    int c =0;
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        
        for (int j = 0; j < arr.GetLength(1); j++)
        {
            if(arr[i,j]==minEl) 
            c = j;
        }
    }
    return c;
}


int[,] RemoveColumn(int[,] matrix, int column)
        {
            int cnt = 0;
            int[,] res = new int [matrix.GetLength(0), matrix.GetLength(1) -1];
 
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                cnt = -1;
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (j == column) continue;
                    else
                    {
                        cnt++;
                    }
 
                    res[i, cnt] = matrix[i, j];
                }
            }
            return res;
        }

int[,] DeleteRow(int[,] table, int num)
        {
            int [,] temp = new int[table.GetLength(0)-1, table.GetLength(1)];
            int i, j;
            int index = 0;
            for (i = 0; i < table.GetLength(0); i++)
            {
                if (i == num)
                {
                    continue;
                }
                else
                {
                    for (j = 0; j < table.GetLength(1); j++)
                    {
                              temp[index, j] = table[i, j];
                    }
                    index++;
                }
                
            }
            return temp ;
        }


