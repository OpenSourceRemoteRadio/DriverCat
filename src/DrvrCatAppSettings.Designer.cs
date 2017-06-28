/*
Copyright (c) 2017, BigCat Wireless Pvt Ltd
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

    * Redistributions of source code must retain the above copyright notice,
      this list of conditions and the following disclaimer.

    * Redistributions in binary form must reproduce the above copyright
      notice, this list of conditions and the following disclaimer in the
      documentation and/or other materials provided with the distribution.

    * Neither the name of the copyright holder nor the names of its contributors
      may be used to endorse or promote products derived from this software
      without specific prior written permission.



THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

namespace Code_Automation_Tool
{
    partial class DrvrCatAppSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Project");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("General", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Editor");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrvrCatAppSettings));
            this.Settings_Tree_View = new System.Windows.Forms.TreeView();
            this.Settings_General_Project_Panel = new System.Windows.Forms.Panel();
            this.Settings_Project_License_Text_Box = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Settings_Project_Name_Text_Box = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Settings_Accept_Button = new System.Windows.Forms.Button();
            this.Settings_Cancel_Button = new System.Windows.Forms.Button();
            this.Settings_Editor_Panel = new System.Windows.Forms.Panel();
            this.Settings_Editor_TabSize_Text_Box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Settings_Editor_Comments_CheckBox = new System.Windows.Forms.CheckBox();
            this.Settings_General_Project_Panel.SuspendLayout();
            this.Settings_Editor_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // Settings_Tree_View
            // 
            this.Settings_Tree_View.Location = new System.Drawing.Point(12, 34);
            this.Settings_Tree_View.Name = "Settings_Tree_View";
            treeNode1.Name = "Settings_General_Project";
            treeNode1.Text = "Project";
            treeNode2.Name = "Settings_General";
            treeNode2.Text = "General";
            treeNode3.Name = "Settings_Editor";
            treeNode3.Text = "Editor";
            this.Settings_Tree_View.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            this.Settings_Tree_View.ShowNodeToolTips = true;
            this.Settings_Tree_View.Size = new System.Drawing.Size(116, 372);
            this.Settings_Tree_View.TabIndex = 0;
            this.Settings_Tree_View.DoubleClick += new System.EventHandler(this.Settings_Tree_View_DoubleClick);
            // 
            // Settings_General_Project_Panel
            // 
            this.Settings_General_Project_Panel.Controls.Add(this.Settings_Project_License_Text_Box);
            this.Settings_General_Project_Panel.Controls.Add(this.label2);
            this.Settings_General_Project_Panel.Controls.Add(this.Settings_Project_Name_Text_Box);
            this.Settings_General_Project_Panel.Controls.Add(this.label1);
            this.Settings_General_Project_Panel.Location = new System.Drawing.Point(134, 34);
            this.Settings_General_Project_Panel.Name = "Settings_General_Project_Panel";
            this.Settings_General_Project_Panel.Size = new System.Drawing.Size(419, 343);
            this.Settings_General_Project_Panel.TabIndex = 1;
            // 
            // Settings_Project_License_Text_Box
            // 
            this.Settings_Project_License_Text_Box.Location = new System.Drawing.Point(102, 55);
            this.Settings_Project_License_Text_Box.Multiline = true;
            this.Settings_Project_License_Text_Box.Name = "Settings_Project_License_Text_Box";
            this.Settings_Project_License_Text_Box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Settings_Project_License_Text_Box.Size = new System.Drawing.Size(301, 272);
            this.Settings_Project_License_Text_Box.TabIndex = 3;
            this.Settings_Project_License_Text_Box.Text = resources.GetString("Settings_Project_License_Text_Box.Text");
            this.Settings_Project_License_Text_Box.WordWrap = false;
            this.Settings_Project_License_Text_Box.TextChanged += new System.EventHandler(this.Settings_Project_License_Text_Box_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "License";
            // 
            // Settings_Project_Name_Text_Box
            // 
            this.Settings_Project_Name_Text_Box.Location = new System.Drawing.Point(102, 12);
            this.Settings_Project_Name_Text_Box.Name = "Settings_Project_Name_Text_Box";
            this.Settings_Project_Name_Text_Box.Size = new System.Drawing.Size(142, 20);
            this.Settings_Project_Name_Text_Box.TabIndex = 1;
            this.Settings_Project_Name_Text_Box.Text = "Hepta_Lime_RF";
            this.Settings_Project_Name_Text_Box.TextChanged += new System.EventHandler(this.Settings_Project_Name_Text_Box_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project";
            // 
            // Settings_Accept_Button
            // 
            this.Settings_Accept_Button.Location = new System.Drawing.Point(385, 383);
            this.Settings_Accept_Button.Name = "Settings_Accept_Button";
            this.Settings_Accept_Button.Size = new System.Drawing.Size(75, 23);
            this.Settings_Accept_Button.TabIndex = 2;
            this.Settings_Accept_Button.Text = "Apply";
            this.Settings_Accept_Button.UseVisualStyleBackColor = true;
            this.Settings_Accept_Button.Click += new System.EventHandler(this.Settings_Accept_Button_Click);
            // 
            // Settings_Cancel_Button
            // 
            this.Settings_Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Settings_Cancel_Button.Location = new System.Drawing.Point(478, 382);
            this.Settings_Cancel_Button.Name = "Settings_Cancel_Button";
            this.Settings_Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this.Settings_Cancel_Button.TabIndex = 2;
            this.Settings_Cancel_Button.Text = "Cancel";
            this.Settings_Cancel_Button.UseVisualStyleBackColor = true;
            this.Settings_Cancel_Button.Click += new System.EventHandler(this.Settings_Cancel_Button_Click);
            // 
            // Settings_Editor_Panel
            // 
            this.Settings_Editor_Panel.Controls.Add(this.Settings_Editor_TabSize_Text_Box);
            this.Settings_Editor_Panel.Controls.Add(this.label3);
            this.Settings_Editor_Panel.Controls.Add(this.Settings_Editor_Comments_CheckBox);
            this.Settings_Editor_Panel.Location = new System.Drawing.Point(134, 34);
            this.Settings_Editor_Panel.Name = "Settings_Editor_Panel";
            this.Settings_Editor_Panel.Size = new System.Drawing.Size(419, 343);
            this.Settings_Editor_Panel.TabIndex = 7;
            // 
            // Settings_Editor_TabSize_Text_Box
            // 
            this.Settings_Editor_TabSize_Text_Box.Location = new System.Drawing.Point(162, 23);
            this.Settings_Editor_TabSize_Text_Box.Name = "Settings_Editor_TabSize_Text_Box";
            this.Settings_Editor_TabSize_Text_Box.Size = new System.Drawing.Size(100, 20);
            this.Settings_Editor_TabSize_Text_Box.TabIndex = 5;
            this.Settings_Editor_TabSize_Text_Box.Text = "4";
            this.Settings_Editor_TabSize_Text_Box.TextChanged += new System.EventHandler(this.Settings_Editor_TabSize_Text_Box_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tab Size";
            // 
            // Settings_Editor_Comments_CheckBox
            // 
            this.Settings_Editor_Comments_CheckBox.AutoSize = true;
            this.Settings_Editor_Comments_CheckBox.Checked = true;
            this.Settings_Editor_Comments_CheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Settings_Editor_Comments_CheckBox.Location = new System.Drawing.Point(19, 55);
            this.Settings_Editor_Comments_CheckBox.Name = "Settings_Editor_Comments_CheckBox";
            this.Settings_Editor_Comments_CheckBox.Size = new System.Drawing.Size(120, 17);
            this.Settings_Editor_Comments_CheckBox.TabIndex = 4;
            this.Settings_Editor_Comments_CheckBox.Text = "Doxygen Comments";
            this.Settings_Editor_Comments_CheckBox.UseVisualStyleBackColor = true;
            this.Settings_Editor_Comments_CheckBox.CheckedChanged += new System.EventHandler(this.Settings_Editor_Comments_CheckBox_CheckedChanged);
            // 
            // App_Settings
            // 
            this.AcceptButton = this.Settings_Accept_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Settings_Cancel_Button;
            this.ClientSize = new System.Drawing.Size(565, 418);
            this.Controls.Add(this.Settings_Cancel_Button);
            this.Controls.Add(this.Settings_Accept_Button);
            this.Controls.Add(this.Settings_Tree_View);
            this.Controls.Add(this.Settings_General_Project_Panel);
            this.Controls.Add(this.Settings_Editor_Panel);
            this.Name = "App_Settings";
            this.Text = "Settings";
            this.Settings_General_Project_Panel.ResumeLayout(false);
            this.Settings_General_Project_Panel.PerformLayout();
            this.Settings_Editor_Panel.ResumeLayout(false);
            this.Settings_Editor_Panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView Settings_Tree_View;
        private System.Windows.Forms.Panel Settings_General_Project_Panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Settings_Project_Name_Text_Box;
        private System.Windows.Forms.Button Settings_Accept_Button;
        private System.Windows.Forms.Button Settings_Cancel_Button;
        private System.Windows.Forms.Panel Settings_Editor_Panel;
        private System.Windows.Forms.TextBox Settings_Editor_TabSize_Text_Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox Settings_Editor_Comments_CheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Settings_Project_License_Text_Box;
    }
}