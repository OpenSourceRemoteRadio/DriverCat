/*
Copyright (c) <2017>, Intel Corporation

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

    * Redistributions of source code must retain the above copyright notice,
      this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.
    * Neither the name of Intel Corporation nor the names of its contributors
      may be used to endorse or promote products derived from this software
      without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Automation_Tool
{
    public partial class DrvrCatAppSettings : Form
    {
        public DrvrCatAppSettings()
        {
            InitializeComponent();
            this.Settings_Project_Name_Text_Box.Text = Properties.Settings.Default.Project_Name;
            this.Settings_Editor_TabSize_Text_Box.Text = Properties.Settings.Default.Code_Tab_Size.ToString();
            this.Settings_Editor_Comments_CheckBox.Checked = Properties.Settings.Default.Generate_Doxygen_Comments;
            this.Settings_Project_License_Text_Box.Text = Properties.Settings.Default.License_Message;
        }

        private void Settings_Project_Name_Text_Box_TextChanged(object sender, EventArgs e)
        {
            TextBox Project_Name = (TextBox)sender;
            Properties.Settings.Default.Project_Name = Project_Name.Text;
        }


        private void Settings_Tree_View_DoubleClick(object sender, EventArgs e)
        {
            TreeView Settings_Tree = (TreeView)sender;
            String Node_Name = "Settings";

            TreeNode Selected_Node = Settings_Tree.SelectedNode;
            if (Selected_Node.Level == 0)
            {
                Node_Name += "_" + Selected_Node.Text;
                if (Selected_Node.FirstNode != null)
                {
                    Selected_Node = Selected_Node.FirstNode;
                    Node_Name += "_" + Selected_Node.Text + "_Panel";
                }
                else
                {
                    Node_Name += "_Panel";
                }
            }
            else
            {
                Node_Name += "_" + Selected_Node.Parent.Text;
                Node_Name += "_" + Selected_Node.Text + "_Panel";
            }

            foreach (Control c in this.Controls)
            {
                if (c is Panel)
                {
                    if (c.Name.Equals(Node_Name))
                    {
                        c.Visible = true;
                    }
                    else
                    {
                        c.Visible = false;
                    }
                }
            }



            return;
        }

        private void Settings_Editor_TabSize_Text_Box_TextChanged(object sender, EventArgs e)
        {
            TextBox TabSize = (TextBox)sender;
            Properties.Settings.Default.Code_Tab_Size = int.Parse(TabSize.Text);
        }

        private void Settings_Editor_Comments_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox Generate_Comment = (CheckBox)sender;
            Properties.Settings.Default.Generate_Doxygen_Comments = Generate_Comment.Checked;
        }

        private void Settings_Accept_Button_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void Settings_Cancel_Button_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            this.Close();
        }

        private void Settings_Project_License_Text_Box_TextChanged(object sender, EventArgs e)
        {
            TextBox Project_Licese = (TextBox)sender;
            Properties.Settings.Default.License_Message = Project_Licese.Text;
        }
    }
}
