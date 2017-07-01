using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_PUZZEL
{
    public class Solvability
    {
        private static int Inversions;
        private static bool OddBlankRow;
        //used by devied&conquer solution
        private static int[] CalculateInversions(int[] a, int TotalSize)
        {
            int Mid;
            if (TotalSize == 1)
                return a;
            if (TotalSize % 2 == 0)
                Mid = TotalSize / 2;
            else
                Mid = (TotalSize + 1) / 2;

            int[] left = new int[Mid];
            for (int i = 0; i < Mid; i++)
                left[i] = a[i];
            int rightSize = TotalSize - Mid;
            int[] right = new int[rightSize];
            for (int i = 0; i < rightSize; i++)
                right[i] = a[Mid + i];

            left = CalculateInversions(left, Mid);
            right = CalculateInversions(right, rightSize);
            int[] final = ConcatenateTwoArrays(left, right, Mid, TotalSize);
            return final;
        }

        //used by devied&conquer solution
        private static int[] ConcatenateTwoArrays(int[] left, int[] right, int Mid, int TotalSize)
        {
            int[] final = new int[TotalSize];
            bool sorted = false;
            int rightSize = right.Length;
            int l = 0, r = 0, f = 0;
            while (!sorted)
            {
                if (l == Mid)
                {
                    for (; f < TotalSize; f++)
                    {
                        final[f] = right[r];
                        r++;
                    }
                    sorted = true;
                }
                else if (r == rightSize)
                {
                    for (; f < TotalSize; f++)
                    {
                        final[f] = left[l];
                        l++;
                    }
                    sorted = true;
                }
                else if (left[l] < right[r])
                {
                    final[f] = left[l];
                    l++;
                    f++;
                }
                else if (left[l] > right[r])
                {
                    final[f] = right[r];
                    Inversions += Mid - l;
                    r++;
                    f++;
                }
            }
            return final;
        }

        //used by both solution
        private static int[] GetOneDeminsionArray(TreeNode node)
        {
            ushort[,] Board = node.GetBord();
            ushort[] board = Board.Cast<ushort>().ToArray();
            int length = board.Length;
            int[] NewArr = new int[length - 1];
            int NewI = 0;
            for (int i = 0; i < length; i++)
                if (board[i] != 0)
                {
                    NewArr[NewI] = board[i];
                    NewI++;
                }
                else
                {
                    int size = node.GetSize();
                    int blankRow = size - (i / size);
                    if (blankRow % 2 != 0)
                        OddBlankRow = true;
                    else
                        OddBlankRow = false;
                }
            return NewArr;
        }

        //used by both solution
        public static bool CheckSolvability(TreeNode node)
        {
            Inversions = 0;
            int blankRow = 0;
            bool inversionsEven;
            bool evensize;
            int[] board = GetOneDeminsionArray(node);
            int size = board.Length;

            if (size % 2 == 0)
                evensize = false;
            else
                evensize = true;
            CalculateInversions(board, size);
            //CheckSolvability2(node);
            if (Inversions % 2 == 0)
                inversionsEven = true;
            else
                inversionsEven = false;

            if (!evensize && inversionsEven)
                return true;
            else if (!evensize && !inversionsEven)
                return false;
            else
            {
                if (OddBlankRow && inversionsEven)
                    return true;
                else if (!OddBlankRow && !inversionsEven)
                    return true;
                else
                    return false;
            }
        }

    }
}
