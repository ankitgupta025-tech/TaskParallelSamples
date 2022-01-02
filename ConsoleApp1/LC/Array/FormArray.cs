
namespace ConsoleApp1.LC.Array
{
    static class FormArray
    {
        //Input: arr = [91,4,64,78], pieces = [[78],[4,64],[91]]
        //Input: arr = [49,18,16], pieces = [[16,18,49]]
        //{ 1,2,3 }    { 2 },{ 1,3}
        public static bool CanFormArray(int[] arr, int[][] pieces)
        {
            int x = -1, y = -1;
            foreach (var a in arr)
            {
                bool found = false;

                for (int i = 0; i < pieces.Length; i++)
                {
                    for (int j = 0; j < pieces[i].Length; j++)
                    {
                        if (a == pieces[i][j])
                        {
                            if (x != i)
                                found = true;
                            if (x==i && j > y && y < pieces[i].Length)
                                found = true;
                            x = i;
                            y = j;
                        }
                    }
                }
                if (!found)
                    return false;
            }

            return true;
        }
    }
}
