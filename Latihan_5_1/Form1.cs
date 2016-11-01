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
    public partial class Form1 : Form
    {
        private bool txtchange;
        public Form1()
        {
            InitializeComponent();
            txtchange = false;
        }
        public Color textboxparent
        {
            get { return this.RT.BackColor; }
            set { this.RT.BackColor = value; }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (txtchange)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*|Rich Textbox Format (*.rtf)|*.rtf";
                save.FilterIndex = 3;
                save.RestoreDirectory = true;

                DialogResult result = MessageBox.Show("Save changes ?", "My Application", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK && save.FileName.Length > 0)
                    {
                        RT.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
                    }
                    RT.Clear();
                }
                else if (result == DialogResult.No)
                {
                    RT.Clear();
                }
            }
            else
            {
                RT.Clear();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog file_open = new OpenFileDialog();

            file_open.Filter = "Rich Text File (*.rtf)|*.rtf| Plain Text File (*.txt)|*.txt";
            file_open.FilterIndex = 1;
            file_open.Title = "Open text or RTF file";

            RichTextBoxStreamType stream_type;
            stream_type = RichTextBoxStreamType.RichText;
            if (DialogResult.OK == file_open.ShowDialog())
            {
                if (string.IsNullOrEmpty(file_open.FileName))
                    return;
                if (file_open.FilterIndex == 2)
                    stream_type = RichTextBoxStreamType.PlainText;

                RT.LoadFile(file_open.FileName, stream_type);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            string filename = "";


            saveDlg.Filter = "Rich Text File (*.rtf)|*.rtf|Plain Text File (*.txt)|*.txt";
            saveDlg.DefaultExt = "*.rtf";
            saveDlg.FilterIndex = 1;
            saveDlg.Title = "Save the contents";


            DialogResult retval = saveDlg.ShowDialog();
            if (retval == DialogResult.OK)
                filename = saveDlg.FileName;
            else
                return;


            RichTextBoxStreamType stream_type;
            if (saveDlg.FilterIndex == 2)
                stream_type = RichTextBoxStreamType.PlainText;
            else
                stream_type = RichTextBoxStreamType.RichText;


            RT.SaveFile(filename, stream_type);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Want to save changes?", "Exit", MessageBoxButtons.YesNoCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Font SelectedText_Font = RT.SelectionFont;
            if (SelectedText_Font != null)
                RT.SelectionFont = new Font(SelectedText_Font, SelectedText_Font.Style ^ FontStyle.Bold);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Font SelectedText_Font = RT.SelectionFont;
            if (SelectedText_Font != null)
                RT.SelectionFont = new Font(SelectedText_Font, SelectedText_Font.Style ^ FontStyle.Italic);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Font SelectedText_Font = RT.SelectionFont;
            if (SelectedText_Font != null)
                RT.SelectionFont = new Font(SelectedText_Font, SelectedText_Font.Style ^ FontStyle.Underline);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripComboBox1.Text = "8";
    
            
            foreach (KnownColor fontcolor in Enum.GetValues(typeof(KnownColor)))
            {
                toolStripComboBox2.Items.Add(fontcolor);
            }

            
            foreach (KnownColor back_color in Enum.GetValues(typeof(KnownColor)))
            {
                toolStripComboBox3.Items.Add(back_color);
            }

            
            for (int i = 2; i <= 74; i += 2)
            {
                toolStripComboBox1.Items.Add(i + " px");
            }
        }

        private void RT_TextChanged(object sender, EventArgs e)
        {

        }



        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 theme = new Form2(this);
            theme.MdiParent = this.ParentForm;
            theme.Show();
            
            
        }

        private void toolStripComboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            RT.SelectionColor = Color.FromName(toolStripComboBox2.Text);
        }

        private void toolStripComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            RT.SelectionFont = new System.Drawing.Font(RT.SelectionFont.FontFamily, Convert.ToSingle(toolStripComboBox1.Text.Split(' ')[0]), RT.SelectionFont.Style);

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
