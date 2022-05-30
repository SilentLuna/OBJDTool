﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBJDTool.forms
{
    public partial class FirstSetup : Form
    {
        private FolderBrowserDialog fbd;
        public FirstSetup()
        {
            InitializeComponent();
        }

        private void FileOpenButton_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if(result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                FileOpenText.Text = fbd.SelectedPath;
            }
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(FileOpenText.Text))
            {
                using(StreamWriter writer = File.CreateText(@"resrc/path.conf"))
                {
                    writer.WriteLine(FileOpenText.Text);
                    writer.Close();
                }
                this.Close();
            }
        }
    }
}
