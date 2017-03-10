using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad1
{
    public partial class Notepad : Form
    {
        private string fileName = null;
        private bool isUnsaved = false;
        private bool ignoreTextChangedEvent = true;

        public Notepad()
        {
            InitializeComponent();
            UpdateTitle();
        }

        private void UpdateTitle()
        {
            string file;

            if (string.IsNullOrEmpty(fileName))
            {
                file = "unnamed";  
            }
            else
            {
                file = Path.GetFileName(fileName);

            }
            if(isUnsaved)
            {
                Text = file + "* - Notepad";
            }
            else
            {
                Text = file + " - Notepad";
            }
            
        }

        private void nyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Text = string.Empty;
            fileName = null;
            UpdateTitle();
        }

        private void öppnaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ignoreTextChangedEvent = true;
                textBox.Text = File.ReadAllText(openFileDialog.FileName);
                fileName = openFileDialog.FileName;
                UpdateTitle();
            }
        }

        private void sparaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return;
            }
        File.WriteAllText(fileName, textBox.Text);
            
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (ignoreTextChangedEvent)
            {
                ignoreTextChangedEvent = false;
                return;
            }
            isUnsaved = true;
            UpdateTitle();
        }
    }
}
