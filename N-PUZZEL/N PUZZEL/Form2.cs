using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Dynamic;

namespace N_PUZZEL
{
    public partial class Form2 : Form
    {
        TreeNode intialState;

        
        int index;
        
        int statesmovs;
        
        List<TreeNode> stats;

        public Form2(TreeNode IntialState)
        {



            InitializeComponent();
            statesmovs = 0;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            intialState = IntialState;

            if (IntialState.GetSize() <= 10)
            {
                SetTable(IntialState);
                label5.Visible = true;

            }
        }

        public Form2()
        {


        }


        void SetTable(TreeNode nod)
        {


            tableLayoutPanel1.Controls.Clear();

            tableLayoutPanel1.BackColor = Color.AliceBlue;

            tableLayoutPanel1.Width = 400;
    
            tableLayoutPanel1.Height = 400;

            int siz = nod.GetSize();

            tableLayoutPanel1.ColumnCount = siz;

            tableLayoutPanel1.RowCount = siz;

            ushort[,] x = nod.GetBord();

            for (int i = 0; i < siz; i++)
            {

                for (int j = 0; j < siz; j++)
                {

                    Label l = new Label();

                    l.TextAlign = ContentAlignment.MiddleCenter;

                    l.Font = new Font(l.Font.FontFamily, 11);


                    label5.Text = "     Hamming : " + nod.GetHammingValue().ToString() + "     Manhatten : " + nod.GetManhattanValue().ToString() + "     # of moves : " + (statesmovs).ToString();

                    if (x[i, j]==0)
             
                    l.BackColor = Form2.DefaultBackColor;

                    l.Width = (tableLayoutPanel1.Width) / siz -6 ;
                    l.Height = (tableLayoutPanel1.Height) / siz;
                    l.Text = (x[i, j]).ToString();
                    tableLayoutPanel1.Controls.Add(l, j, i);

                }


            }



        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {


        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Solver X = null;

            if (radioButton1.Checked == true)
            {

                X = new Solver(intialState, "Hamming");

            }
            else if (radioButton2.Checked == true)
            {

                X = new Solver(intialState, "Manhatten");

            }

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
           
            if (intialState.GetSize() <= 10)
              SetTable(intialState);

            if(!X.solvabile())
            {


              label4.Visible = true;


            }
            else
            {

                long timeBefore = System.Environment.TickCount;

                X.Solve();

                long time = System.Environment.TickCount - timeBefore;

                stats = X.GetMyPath();

                index = stats.Count - 1;

                label1.Visible = true;

                label2.Visible = true;

                if (intialState.GetSize()<=10)
                    label5.Visible = true;


                label3.Visible = true;

                if (stats.Count > 1 && intialState.GetSize() <= 10)
                button2.Visible = true;

                label1.Text = "Number of Moves : " + (stats.Count - 1).ToString();

                label2.Text = "Time : " + time.ToString() + " ms";

                label3.Text = "Visted States : " + X.countr.ToString();

            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            index++;
            statesmovs = (stats.Count - 1) - index;
            SetTable(stats[index]);
            if (index == (stats.Count - 1))
                button3.Visible = false;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            index--;
            statesmovs = (stats.Count - 1) - index;
            SetTable(stats[index]);
            button3.Visible = true;
            if (index == 0)
                button2.Visible = false;


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

    }
}
