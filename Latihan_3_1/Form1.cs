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

            comboBox1.Text = this.RT.Font.Name.ToString();
            comboBox2.Text = this.RT.Font.Size.ToString();

            RT.Focus();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            float size = Convert.ToSingle(((ComboBox)sender).Text);

            RT.SelectionFont = new Font(RT.Font.FontFamily, size);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Font SelectedText_Font = RT.SelectionFont;
            if (SelectedText_Font != null)
                RT.SelectionFont = new Font(SelectedText_Font, SelectedText_Font.Style ^ FontStyle.Bold);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Font SelectedText_Font = RT.SelectionFont;
            if (SelectedText_Font != null)
                RT.SelectionFont = new Font(SelectedText_Font, SelectedText_Font.Style ^ FontStyle.Italic);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Font SelectedText_Font = RT.SelectionFont;
            if (SelectedText_Font != null)
                RT.SelectionFont = new Font(SelectedText_Font, SelectedText_Font.Style ^ FontStyle.Underline);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void RT_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
