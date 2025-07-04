public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step-by-Step Plan:
        // 1. Create a new array of doubles with the specified length
        // 2. Use a loop to fill the array with multiples of the input number
        // 3. For each index i (0 to length-1), calculate the multiple as number * (i+1)
        //    (We use i+1 because the first multiple should be number*1, not number*0)
        // 4. Return the populated array

        // Implementation:
        double[] result = new double[length];
        
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        
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
        // Step-by-Step Plan:
        // 1. Handle edge case where amount equals list length (no rotation needed)
        // 2. Calculate the effective rotation amount using modulo operation
        //    (This handles cases where amount > data.Count, though problem says it's in range)
        // 3. Find the split point: data.Count - effectiveAmount
        // 4. Get the range of elements that need to be moved to the front
        // 5. Remove these elements from their current position
        // 6. Insert them at the beginning of the list

        // Implementation:
        if (amount == data.Count || data.Count == 0)
        {
            return; // No rotation needed
        }

        int effectiveAmount = amount % data.Count;
        if (effectiveAmount == 0) return;

        int splitIndex = data.Count - effectiveAmount;
        List<int> elementsToMove = data.GetRange(splitIndex, effectiveAmount);
        
        data.RemoveRange(splitIndex, effectiveAmount);
        data.InsertRange(0, elementsToMove);
    }
}