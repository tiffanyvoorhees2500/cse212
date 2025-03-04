public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    /// 
    public static void Run(){
        var result1 = MultiplesOf(7, 5);
        Console.WriteLine("<double[]>{" + string.Join(", ", result1) + "}"); // <double[]>{7, 14, 21, 28, 35}

        var result2 = MultiplesOf(3, 5);
        Console.WriteLine("<double[]>{" + string.Join(", ", result2) + "}"); // <double[]>{3, 6, 9, 12, 15}

        var data1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(data1, 5);
        Console.WriteLine("<List>{" + string.Join(", ", data1) + "}"); // <List>{5, 6, 7, 8, 9, 1, 2, 3, 4} 

        var data2 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(data2, 3);
        Console.WriteLine("<List>{" + string.Join(", ", data2) + "}"); // <List>{7, 8, 9, 1, 2, 3, 4, 5, 6}
    }   

    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // IMPLEMENTATION PLAN
        // Result to hold the finished array
        double[] result = new double[length];

        // Loop through the length of the array
        for (int i = 0; i < length; i++)
        {   
            // For each iteration, multiply the number by the current index plus 1 and store the result in the array.
            result[i] = number * (i + 1);
        }

        // Return array of doubles
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // IMPLEMENTATION PLAN
        // Use GetRange to get the last 'amount' elements of the list
        List<int> lastElements = data.GetRange(data.Count - amount, amount);

        // Remove the last 'amount' elements from the list
        data.RemoveRange(data.Count - amount, amount);

        // Insert the last 'amount' elements at the beginning of the list
        data.InsertRange(0, lastElements);
    }
}
