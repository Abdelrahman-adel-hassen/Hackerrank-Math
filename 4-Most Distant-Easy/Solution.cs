using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'solve' function below.
     *
     * The function is expected to return a DOUBLE.
     * The function accepts 2D_INTEGER_ARRAY coordinates as parameter.
     */

    public static double solve(List<List<int>> coordinates)
    {
       double result=0;
       const int limit=1000000000;
       int maxX=-limit,minX=limit,maxY=-limit,minY=limit;
       for(var index=0;index<coordinates.Count;index++){
           maxX=Math.Max(maxX,coordinates[index][0]);
           minX=Math.Min(minX,coordinates[index][0]);
           maxY=Math.Max(maxY,coordinates[index][1]);
           minY=Math.Min(minY,coordinates[index][1]);
       }
        result=Math.Max(result,GetDistance(maxX,0,minX,0));
        result=Math.Max(result,GetDistance(maxX,0,0,maxY));
        result=Math.Max(result,GetDistance(maxX,0,0,minY));
        result=Math.Max(result,GetDistance(minX,0,0,maxY));
        result=Math.Max(result,GetDistance(minX,0,0,minY));
        result=Math.Max(result,GetDistance(0,maxY,0,minY));
       return result;
    }
    private static double GetDistance(int x1,int y1,int x2,int y2){
        return Math.Sqrt((double)(x1-x2)*(x1-x2)+(double)(y1-y2)*(y1-y2));
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> coordinates = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            coordinates.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(coordinatesTemp => Convert.ToInt32(coordinatesTemp)).ToList());
        }

        double result = Result.solve(coordinates);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
