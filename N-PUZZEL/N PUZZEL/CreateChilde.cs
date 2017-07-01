using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace N_PUZZEL
{
    class CreateChilde
    {
        
        TreeNode nod;
        short MzX;
        short MzY;
        int Siz;
        short MpzX;
        short MpzY;
        ushort[,] newbord;
        ushort[,] bord;
        ushort H ;
        ushort M ;
        Point T;
       
        public CreateChilde()
         {
              

            
         }
        
        public void SetNod(TreeNode n)
        {

             nod=n;
             MzX = nod.GetMyZero().getX();
             MzY = nod.GetMyZero().getY();
             Siz = nod.GetSize();
             MpzX = nod.GetPerantZero().getX();
             MpzY = nod.GetPerantZero().getY();
             bord = nod.GetBord();

        }
        public List<TreeNode> Create()
        {

            List<TreeNode> T = new List<TreeNode>();
           
            if (check_vaild(MzX - 1, MzY, Siz))
            {

                if (((MzX - 1) != MpzX) || (MzY != MpzY))
                    Childe(new Point( (short)(MzX - 1) , MzY),ref T);
              
            }

            if (check_vaild(MzX + 1, MzY, Siz))
            {
                if (((MzX + 1) != MpzX) || ( MzY != MpzY ))
                    Childe(new Point((short)(MzX + 1), MzY), ref T);

            }

            if (check_vaild(MzX, MzY - 1, Siz))
            {
                if ((MzX != MpzX) || ((MzY - 1) != MpzY))
                    Childe(new Point(MzX, (short)(MzY - 1)), ref T);

            }
            if (check_vaild(MzX, MzY + 1, Siz))
            {

                if (((MzX) != MpzX) || ((MzY + 1) != MpzY))
                    Childe(new Point(MzX,(short)(MzY + 1)), ref T);

            }

            return T;

        }

        private bool check_vaild(int x, int y, int N)
        {
            if (x < 0 || x >= N || y < 0 || y >= N)
                return false;

            else return true;
        }


        private void Childe(Point x,ref List<TreeNode> Tz)
        {

   
            newbord = new ushort[Siz, Siz];
                             
             H = 0;
            
             M = 0;

             string u = "";

            swap(ref bord[MzX, MzY], ref bord[x.getX(), x.getY()]);

            


            for (int i = 0; i < Siz; i++)
            {
                for (int j = 0; j < Siz; j++)
                {
                    newbord[i, j] = bord[i, j];

                    u += newbord[i, j].ToString();

                    T=CorrecPositon(i,j,Siz,newbord[i, j]);
                    
                    if(i!=T.getX() || j!=T.getY())
                    {
                        if(newbord[i, j]!=0)
                        {
                            H += 1;
                            M +=(ushort) (Math.Abs(i-T.getX()) + Math.Abs(j - T.getY()));

                        }


                    }

                }
            }
            
            swap(ref bord[MzX, MzY], ref bord[x.getX(), x.getY()]);
            
            TreeNode m = new TreeNode(newbord, nod.GetNumOfMove() + 1);
            
            m.SetMyZero(x);

            m.SetHammingValue(H);

            m.SetManhattanValue(M);

            m.SetMyperent(nod.id);

            m.SetPerantZero(nod.GetMyZero());

            m.id = u.GetHashCode();

            Tz.Add(m);
            

        }

        private Point CorrecPositon(int x,int y,int size,int Value)
        {

            
            int Tempi;
            
            int Tempj;

            if (Value == 0)
            {
                Tempi = size - 1;
                Tempj = size - 1;

            }

            else if (Value % size == 0)
            {
                Tempj = size - 1;
                Tempi = (Value / size) - 1;

            }
            else
            {

                Tempj = (Value % size) - 1;
                Tempi = (Value / size);

            }


            return new Point((short)Tempi, (short)Tempj);

            

        }

        void swap(ref ushort x,ref ushort y)
        {
            ushort temp = x;
            x = y;
            y = temp;

        }

       

            






    }
}
