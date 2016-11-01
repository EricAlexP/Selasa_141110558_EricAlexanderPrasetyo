using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latihan_5_1
{
    public partial class Form2 : Form
    {
        Form1 parentform;
        public Form2(Form1 pf)
        {
            InitializeComponent();
            parentform = pf;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            foreach (KnownColor bg_color in Enum.GetValues(typeof(KnownColor)))
            {
                comboBox1.Items.Add(bg_color);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Text == "Background Color")
                panel1.Visible = true;
            else
                panel1.Visible = false;
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            {
                this.Close();
                parentform.textboxparent = Color.FromName(comboBox1.SelectedItem.ToString());
            }
        }
    }
}
