using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_PUZZEL
{
  public  class TreeNode
    {

        
        private ushort[,] Bord;
        private int NumOfMove;
        private ushort HammingValue;
        private ushort ManhattanValue;
        private Point MyZero;
        private Point PerantZero;
        private bool IRoot;
       
        private int Myperent;
        public int id;

        public TreeNode(ushort[,] bord, int numOfMove)
        {

            this.Bord = bord;
            this.NumOfMove = numOfMove;
            IRoot = false;
            id =0;
        }
        
        public ushort [,] GetBord()
        {return Bord;}

        public int GetNumOfMove()
        { return NumOfMove; }


        public void SetRoot()
        {

            IRoot = true;

        }
      
       public bool IsRoot()
        {

            return IRoot;
        }
        public int Heuristicvalue(String Method)
        {
            if (Method.Equals("Hamming"))
                return HammingValue;
            else
                return ManhattanValue;

        }

        public int CompareTo(TreeNode X, String Method)
        {


                return GetPriority(Method) - X.GetPriority(Method);
            
        }

        public void SetMyZero(Point myZero)
        {

            MyZero = myZero;

        }
        public Point GetMyZero()
        {

            return MyZero;

        }


        public void SetPerantZero(Point perantZero)
        {

            PerantZero = perantZero;

        }
        public Point GetPerantZero()
        {

            return PerantZero;

        }
        public int GetPriority(String Method)
        {
            if (Method.Equals("Hamming"))
                return (HammingValue + NumOfMove);
            else
                return (ManhattanValue + NumOfMove);

        }

        public int GetSize()
        { return Bord.GetLength(0); }

        public int GetHammingValue()
        { return HammingValue; }

        public void SetHammingValue(ushort hammingValue)
        { HammingValue = hammingValue; }

                
        public int GetManhattanValue()
        { return ManhattanValue; }

        public void SetManhattanValue(ushort manhattanValue)
        { ManhattanValue = manhattanValue; }
      
        public int GetMyperent()
        { return Myperent; }
         public void SetMyperent(int myperent)
         { Myperent = myperent; }

      
    }
}
