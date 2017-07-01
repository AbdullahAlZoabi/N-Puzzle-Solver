using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N_PUZZEL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

           

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

           
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";

            if ((openFileDialog1.ShowDialog() == DialogResult.OK))
            {

                richTextBox1.Text = openFileDialog1.FileName;
            
            }
      
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                MessageBox.Show("  No File are Selected  ");
            }
            else
            {

                FileProcessor P = new FileProcessor(richTextBox1.Text);
                TreeNode t = P.GetInitialState();
                Form2 F = new Form2(t);
                F.MdiParent = this.Owner;
                F.ShowDialog();
                
                
            }
            
        }
    }
}
