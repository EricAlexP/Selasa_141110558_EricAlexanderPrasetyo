using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Latihan_3_1
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public FontFamily[] Families { get; }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (FontFamily oneFontFamily in FontFamily.Families)
            {
                comboBox1.Items.Add(oneFontFamily.Name);
            }

            comboBox1.Text = this.richTextBox1.Font.Name.ToString();
            comboBox2.Text = this.richTextBox1.Font.Size.ToString();

            richTextBox1.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            float size = Convert.ToSingle(((ComboBox)sender).Text);

            richTextBox1.SelectionFont = new Font(richTextBox1.Font.FontFamily, size);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Bold == true)
            {
                richTextBox1.SelectionFont = new Font("Times New Roman", 12, FontStyle.Bold | FontStyle.Italic);
            }
            else
            {
                richTextBox1.SelectionFont = new Font("Times New Roman", 12, FontStyle.Bold);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont.Bold == true)
            {
                richTextBox1.SelectionFont = new Font("Times New Roman", 12, FontStyle.Bold | FontStyle.Italic);
            }
            else
            {
                richTextBox1.SelectionFont = new Font("Times New Roman", 12, FontStyle.Italic);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font("Times New Roman", 12, FontStyle.Underline);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
