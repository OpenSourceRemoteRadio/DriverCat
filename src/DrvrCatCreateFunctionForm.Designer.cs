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

namespace Code_Automation_Tool
{
    partial class DrvrCatCreateFunctionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrvrCatCreateFunctionForm));
            this.label1 = new System.Windows.Forms.Label();
            this.Function_Module_List_Combo_Box = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Function_Name_Text_Box = new System.Windows.Forms.TextBox();
            this.Function_Description_Text_Box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Parameter_Data_Type_Text_Box = new System.Windows.Forms.TextBox();
            this.Parameter_Variable_Name_Text_Box = new System.Windows.Forms.TextBox();
            this.Parameter_Add_Button = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Parameters_Panel = new System.Windows.Forms.Panel();
            this.Parameters_List_View = new System.Windows.Forms.ListView();
            this.Parameters_List_Variable_Name_Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Parameters_List_Data_Type_Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Parameter_Remove_Button = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.Parameter_Description_Text_Box = new System.Windows.Forms.TextBox();
            this.Return_Panel = new System.Windows.Forms.Panel();
            this.Return_Value_Context_List_View = new System.Windows.Forms.ListView();
            this.Return_Value_Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Return_Context_Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label15 = new System.Windows.Forms.Label();
            this.Return_Value_Context_Text_Box = new System.Windows.Forms.TextBox();
            this.Return_Remove_Button = new System.Windows.Forms.Button();
            this.Return_Value_Text_Box = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Return_Add_Button = new System.Windows.Forms.Button();
            this.Return_Data_Type_Text_Box = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Return_Description_Text_Box = new System.Windows.Forms.TextBox();
            this.Function_Create_Menu_Bar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Function_Statements_Edit_Box = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Parameters_Panel.SuspendLayout();
            this.Return_Panel.SuspendLayout();
            this.Function_Create_Menu_Bar.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Module";
            // 
            // Function_Module_List_Combo_Box
            // 
            this.Function_Module_List_Combo_Box.FormattingEnabled = true;
            this.Function_Module_List_Combo_Box.Location = new System.Drawing.Point(104, 33);
            this.Function_Module_List_Combo_Box.Name = "Function_Module_List_Combo_Box";
            this.Function_Module_List_Combo_Box.Size = new System.Drawing.Size(121, 21);
            this.Function_Module_List_Combo_Box.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Function Name";
            // 
            // Function_Name_Text_Box
            // 
            this.Function_Name_Text_Box.Location = new System.Drawing.Point(104, 64);
            this.Function_Name_Text_Box.Name = "Function_Name_Text_Box";
            this.Function_Name_Text_Box.Size = new System.Drawing.Size(467, 20);
            this.Function_Name_Text_Box.TabIndex = 4;
            // 
            // Function_Description_Text_Box
            // 
            this.Function_Description_Text_Box.Location = new System.Drawing.Point(104, 94);
            this.Function_Description_Text_Box.Multiline = true;
            this.Function_Description_Text_Box.Name = "Function_Description_Text_Box";
            this.Function_Description_Text_Box.Size = new System.Drawing.Size(467, 60);
            this.Function_Description_Text_Box.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Parameter(s)";
            // 
            // Parameter_Data_Type_Text_Box
            // 
            this.Parameter_Data_Type_Text_Box.Location = new System.Drawing.Point(83, 24);
            this.Parameter_Data_Type_Text_Box.Name = "Parameter_Data_Type_Text_Box";
            this.Parameter_Data_Type_Text_Box.Size = new System.Drawing.Size(151, 20);
            this.Parameter_Data_Type_Text_Box.TabIndex = 8;
            // 
            // Parameter_Variable_Name_Text_Box
            // 
            this.Parameter_Variable_Name_Text_Box.Location = new System.Drawing.Point(83, 50);
            this.Parameter_Variable_Name_Text_Box.Name = "Parameter_Variable_Name_Text_Box";
            this.Parameter_Variable_Name_Text_Box.Size = new System.Drawing.Size(151, 20);
            this.Parameter_Variable_Name_Text_Box.TabIndex = 9;
            // 
            // Parameter_Add_Button
            // 
            this.Parameter_Add_Button.Location = new System.Drawing.Point(238, 22);
            this.Parameter_Add_Button.Name = "Parameter_Add_Button";
            this.Parameter_Add_Button.Size = new System.Drawing.Size(29, 23);
            this.Parameter_Add_Button.TabIndex = 13;
            this.Parameter_Add_Button.Text = "+";
            this.Parameter_Add_Button.UseVisualStyleBackColor = true;
            this.Parameter_Add_Button.Click += new System.EventHandler(this.Parameter_Add_Button_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Data type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Variable Name";
            // 
            // Parameters_Panel
            // 
            this.Parameters_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Parameters_Panel.Controls.Add(this.Parameters_List_View);
            this.Parameters_Panel.Controls.Add(this.label4);
            this.Parameters_Panel.Controls.Add(this.label6);
            this.Parameters_Panel.Controls.Add(this.Parameter_Remove_Button);
            this.Parameters_Panel.Controls.Add(this.Parameter_Add_Button);
            this.Parameters_Panel.Controls.Add(this.Parameter_Data_Type_Text_Box);
            this.Parameters_Panel.Controls.Add(this.label12);
            this.Parameters_Panel.Controls.Add(this.label5);
            this.Parameters_Panel.Controls.Add(this.Parameter_Variable_Name_Text_Box);
            this.Parameters_Panel.Controls.Add(this.Parameter_Description_Text_Box);
            this.Parameters_Panel.Location = new System.Drawing.Point(5, 162);
            this.Parameters_Panel.Name = "Parameters_Panel";
            this.Parameters_Panel.Size = new System.Drawing.Size(275, 198);
            this.Parameters_Panel.TabIndex = 17;
            // 
            // Parameters_List_View
            // 
            this.Parameters_List_View.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.Parameters_List_View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Parameters_List_Variable_Name_Column,
            this.Parameters_List_Data_Type_Column});
            this.Parameters_List_View.FullRowSelect = true;
            this.Parameters_List_View.GridLines = true;
            this.Parameters_List_View.Location = new System.Drawing.Point(5, 113);
            this.Parameters_List_View.MultiSelect = false;
            this.Parameters_List_View.Name = "Parameters_List_View";
            this.Parameters_List_View.Size = new System.Drawing.Size(262, 80);
            this.Parameters_List_View.TabIndex = 23;
            this.Parameters_List_View.UseCompatibleStateImageBehavior = false;
            this.Parameters_List_View.View = System.Windows.Forms.View.Details;
            this.Parameters_List_View.ItemActivate += new System.EventHandler(this.Parameters_List_View_ItemActivate);
            // 
            // Parameters_List_Variable_Name_Column
            // 
            this.Parameters_List_Variable_Name_Column.Tag = "Variable Name";
            this.Parameters_List_Variable_Name_Column.Text = "Variable Name";
            this.Parameters_List_Variable_Name_Column.Width = 131;
            // 
            // Parameters_List_Data_Type_Column
            // 
            this.Parameters_List_Data_Type_Column.Tag = "Data Type";
            this.Parameters_List_Data_Type_Column.Text = "Data Type";
            this.Parameters_List_Data_Type_Column.Width = 125;
            // 
            // Parameter_Remove_Button
            // 
            this.Parameter_Remove_Button.Location = new System.Drawing.Point(238, 47);
            this.Parameter_Remove_Button.Name = "Parameter_Remove_Button";
            this.Parameter_Remove_Button.Size = new System.Drawing.Size(29, 23);
            this.Parameter_Remove_Button.TabIndex = 13;
            this.Parameter_Remove_Button.Text = "x";
            this.Parameter_Remove_Button.UseVisualStyleBackColor = true;
            this.Parameter_Remove_Button.Click += new System.EventHandler(this.Parameter_Remove_Button_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Description";
            // 
            // Parameter_Description_Text_Box
            // 
            this.Parameter_Description_Text_Box.Location = new System.Drawing.Point(83, 77);
            this.Parameter_Description_Text_Box.Multiline = true;
            this.Parameter_Description_Text_Box.Name = "Parameter_Description_Text_Box";
            this.Parameter_Description_Text_Box.Size = new System.Drawing.Size(184, 30);
            this.Parameter_Description_Text_Box.TabIndex = 9;
            // 
            // Return_Panel
            // 
            this.Return_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Return_Panel.Controls.Add(this.Return_Value_Context_List_View);
            this.Return_Panel.Controls.Add(this.label15);
            this.Return_Panel.Controls.Add(this.Return_Value_Context_Text_Box);
            this.Return_Panel.Controls.Add(this.Return_Remove_Button);
            this.Return_Panel.Controls.Add(this.Return_Value_Text_Box);
            this.Return_Panel.Controls.Add(this.label10);
            this.Return_Panel.Controls.Add(this.label7);
            this.Return_Panel.Controls.Add(this.label8);
            this.Return_Panel.Controls.Add(this.Return_Add_Button);
            this.Return_Panel.Controls.Add(this.Return_Data_Type_Text_Box);
            this.Return_Panel.Controls.Add(this.label9);
            this.Return_Panel.Controls.Add(this.Return_Description_Text_Box);
            this.Return_Panel.Location = new System.Drawing.Point(286, 162);
            this.Return_Panel.Name = "Return_Panel";
            this.Return_Panel.Size = new System.Drawing.Size(285, 199);
            this.Return_Panel.TabIndex = 18;
            // 
            // Return_Value_Context_List_View
            // 
            this.Return_Value_Context_List_View.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.Return_Value_Context_List_View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Return_Value_Column,
            this.Return_Context_Column});
            this.Return_Value_Context_List_View.FullRowSelect = true;
            this.Return_Value_Context_List_View.GridLines = true;
            this.Return_Value_Context_List_View.Location = new System.Drawing.Point(6, 122);
            this.Return_Value_Context_List_View.MultiSelect = false;
            this.Return_Value_Context_List_View.Name = "Return_Value_Context_List_View";
            this.Return_Value_Context_List_View.Size = new System.Drawing.Size(274, 71);
            this.Return_Value_Context_List_View.TabIndex = 23;
            this.Return_Value_Context_List_View.UseCompatibleStateImageBehavior = false;
            this.Return_Value_Context_List_View.View = System.Windows.Forms.View.Details;
            this.Return_Value_Context_List_View.ItemActivate += new System.EventHandler(this.Return_Value_Context_List_View_ItemActivate);
            // 
            // Return_Value_Column
            // 
            this.Return_Value_Column.Tag = "Variable Name";
            this.Return_Value_Column.Text = "Value";
            this.Return_Value_Column.Width = 131;
            // 
            // Return_Context_Column
            // 
            this.Return_Context_Column.Tag = "Data Type";
            this.Return_Context_Column.Text = "Context";
            this.Return_Context_Column.Width = 125;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 99);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(78, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "Return Context";
            // 
            // Return_Value_Context_Text_Box
            // 
            this.Return_Value_Context_Text_Box.Location = new System.Drawing.Point(90, 96);
            this.Return_Value_Context_Text_Box.Name = "Return_Value_Context_Text_Box";
            this.Return_Value_Context_Text_Box.Size = new System.Drawing.Size(155, 20);
            this.Return_Value_Context_Text_Box.TabIndex = 19;
            // 
            // Return_Remove_Button
            // 
            this.Return_Remove_Button.Location = new System.Drawing.Point(251, 94);
            this.Return_Remove_Button.Name = "Return_Remove_Button";
            this.Return_Remove_Button.Size = new System.Drawing.Size(29, 23);
            this.Return_Remove_Button.TabIndex = 13;
            this.Return_Remove_Button.Text = "x";
            this.Return_Remove_Button.UseVisualStyleBackColor = true;
            this.Return_Remove_Button.Click += new System.EventHandler(this.Return_Remove_Button_Click);
            // 
            // Return_Value_Text_Box
            // 
            this.Return_Value_Text_Box.Location = new System.Drawing.Point(90, 72);
            this.Return_Value_Text_Box.Name = "Return_Value_Text_Box";
            this.Return_Value_Text_Box.Size = new System.Drawing.Size(155, 20);
            this.Return_Value_Text_Box.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Return Value";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Return";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(62, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Description";
            // 
            // Return_Add_Button
            // 
            this.Return_Add_Button.Location = new System.Drawing.Point(251, 69);
            this.Return_Add_Button.Name = "Return_Add_Button";
            this.Return_Add_Button.Size = new System.Drawing.Size(29, 23);
            this.Return_Add_Button.TabIndex = 13;
            this.Return_Add_Button.Text = "+";
            this.Return_Add_Button.UseVisualStyleBackColor = true;
            this.Return_Add_Button.Click += new System.EventHandler(this.Return_Add_Button_Click);
            // 
            // Return_Data_Type_Text_Box
            // 
            this.Return_Data_Type_Text_Box.Location = new System.Drawing.Point(128, 6);
            this.Return_Data_Type_Text_Box.Name = "Return_Data_Type_Text_Box";
            this.Return_Data_Type_Text_Box.Size = new System.Drawing.Size(152, 20);
            this.Return_Data_Type_Text_Box.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Data type";
            // 
            // Return_Description_Text_Box
            // 
            this.Return_Description_Text_Box.Location = new System.Drawing.Point(128, 30);
            this.Return_Description_Text_Box.Multiline = true;
            this.Return_Description_Text_Box.Name = "Return_Description_Text_Box";
            this.Return_Description_Text_Box.Size = new System.Drawing.Size(152, 36);
            this.Return_Description_Text_Box.TabIndex = 9;
            // 
            // Function_Create_Menu_Bar
            // 
            this.Function_Create_Menu_Bar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.Function_Create_Menu_Bar.Location = new System.Drawing.Point(0, 0);
            this.Function_Create_Menu_Bar.Name = "Function_Create_Menu_Bar";
            this.Function_Create_Menu_Bar.Size = new System.Drawing.Size(574, 24);
            this.Function_Create_Menu_Bar.TabIndex = 19;
            this.Function_Create_Menu_Bar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.importToolStripMenuItem.Text = "&Import";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exportToolStripMenuItem.Text = "&Export";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.createToolStripMenuItem.Text = "&Create";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.createToolStripMenuItem_Click);
            // 
            // Function_Statements_Edit_Box
            // 
            this.Function_Statements_Edit_Box.Location = new System.Drawing.Point(5, 385);
            this.Function_Statements_Edit_Box.Multiline = true;
            this.Function_Statements_Edit_Box.Name = "Function_Statements_Edit_Box";
            this.Function_Statements_Edit_Box.Size = new System.Drawing.Size(566, 195);
            this.Function_Statements_Edit_Box.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 369);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Function Statements";
            // 
            // Create_Function_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 584);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Function_Statements_Edit_Box);
            this.Controls.Add(this.Return_Panel);
            this.Controls.Add(this.Parameters_Panel);
            this.Controls.Add(this.Function_Description_Text_Box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Function_Name_Text_Box);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Function_Module_List_Combo_Box);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Function_Create_Menu_Bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.Function_Create_Menu_Bar;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Create_Function_Form";
            this.Text = "Create Function";
            this.Parameters_Panel.ResumeLayout(false);
            this.Parameters_Panel.PerformLayout();
            this.Return_Panel.ResumeLayout(false);
            this.Return_Panel.PerformLayout();
            this.Function_Create_Menu_Bar.ResumeLayout(false);
            this.Function_Create_Menu_Bar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Function_Module_List_Combo_Box;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Function_Name_Text_Box;
        private System.Windows.Forms.TextBox Function_Description_Text_Box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Parameter_Data_Type_Text_Box;
        private System.Windows.Forms.TextBox Parameter_Variable_Name_Text_Box;
        private System.Windows.Forms.Button Parameter_Add_Button;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel Parameters_Panel;
        private System.Windows.Forms.Panel Return_Panel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Return_Add_Button;
        private System.Windows.Forms.TextBox Return_Data_Type_Text_Box;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Return_Description_Text_Box;
        private System.Windows.Forms.TextBox Return_Value_Context_Text_Box;
        private System.Windows.Forms.TextBox Return_Value_Text_Box;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MenuStrip Function_Create_Menu_Bar;
        private System.Windows.Forms.TextBox Function_Statements_Edit_Box;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.Button Parameter_Remove_Button;
        private System.Windows.Forms.Button Return_Remove_Button;
        private System.Windows.Forms.ListView Parameters_List_View;
        private System.Windows.Forms.ColumnHeader Parameters_List_Data_Type_Column;
        private System.Windows.Forms.ColumnHeader Parameters_List_Variable_Name_Column;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Parameter_Description_Text_Box;
        private System.Windows.Forms.ListView Return_Value_Context_List_View;
        private System.Windows.Forms.ColumnHeader Return_Value_Column;
        private System.Windows.Forms.ColumnHeader Return_Context_Column;
    }
}