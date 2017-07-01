using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace N_PUZZEL
{
    class FileProcessor
    {
        private string File_Path;
        private FileStream File;
        private StreamReader Reader;
        private int BoardSize;
        private ushort  [,] array;
        public  TreeNode n;
        private Point ZeroIn;
       
        public FileProcessor(string FilePath)
        {

            File_Path = FilePath;
            File = new FileStream(File_Path, FileMode.Open, FileAccess.Read);
            Reader = new StreamReader(File);

        }

        public TreeNode GetInitialState()
        {
           
            BoardSize =int.Parse(Reader.ReadLine());
            
            array = new ushort[BoardSize, BoardSize];

            ushort H = 0;

            ushort M = 0;

            string u = "";

            for (int i = 0; i < BoardSize;i++)
            {
                
                String Temp = Reader.ReadLine();
                
                string[] TempArray = Temp.Split(' ');
                
                for (int j = 0; j < BoardSize;j++)
                {

                    array[i,j] = ushort.Parse(TempArray[j]);


                    u += array[i, j].ToString();

                    if (array[i, j] == 0)
                        ZeroIn = new Point((short)i,(short)j);


                    Point T = CorrecPositon(i, j, BoardSize, array[i, j]);
                    if (i != T.getX() || j != T.getY())
                    {
                        if (array[i, j] != 0)
                        {
                            H += 1;
                            M +=(ushort) (Math.Abs(i - T.getX()) + Math.Abs(j - T.getY()));

                        }


                    }


                }
                
            }

            n = new TreeNode(array, 0);

            n.SetMyZero(ZeroIn);

            n.SetHammingValue(H);

            n.SetManhattanValue(M);

           n.SetRoot();

           n.id = u.GetHashCode();
            
           n.SetPerantZero(new Point(-1, -1));

            return n;
            
        }

        public int GetBoardSize()
        {
            return BoardSize;
        }

        public ushort [,]  GetArray()
        {
            return array;

        }


        private Point CorrecPositon(int x, int y, int size, int Value)
        {

            Point temp;

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


            temp = new Point((short)Tempi,(short) Tempj);

            return temp;

        }



    }
}
