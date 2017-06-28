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
    partial class DrvrCatEthernetFieldAddForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrvrCatEthernetFieldAddForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Add_Ethernet_Field_Name_Text_Box = new System.Windows.Forms.TextBox();
            this.Add_Ethernet_Field_Description_Text_Box = new System.Windows.Forms.TextBox();
            this.Add_Ethernet_Field_Bits_Text_Box = new System.Windows.Forms.TextBox();
            this.Add_Ethernet_Field_Accept_Button = new System.Windows.Forms.Button();
            this.Add_Ethernet_Field_Cancel_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Field Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Number of bits";
            // 
            // Add_Ethernet_Field_Name_Text_Box
            // 
            this.Add_Ethernet_Field_Name_Text_Box.Location = new System.Drawing.Point(91, 9);
            this.Add_Ethernet_Field_Name_Text_Box.Name = "Add_Ethernet_Field_Name_Text_Box";
            this.Add_Ethernet_Field_Name_Text_Box.Size = new System.Drawing.Size(184, 20);
            this.Add_Ethernet_Field_Name_Text_Box.TabIndex = 0;
            // 
            // Add_Ethernet_Field_Description_Text_Box
            // 
            this.Add_Ethernet_Field_Description_Text_Box.Location = new System.Drawing.Point(91, 38);
            this.Add_Ethernet_Field_Description_Text_Box.Multiline = true;
            this.Add_Ethernet_Field_Description_Text_Box.Name = "Add_Ethernet_Field_Description_Text_Box";
            this.Add_Ethernet_Field_Description_Text_Box.Size = new System.Drawing.Size(184, 71);
            this.Add_Ethernet_Field_Description_Text_Box.TabIndex = 1;
            // 
            // Add_Ethernet_Field_Bits_Text_Box
            // 
            this.Add_Ethernet_Field_Bits_Text_Box.Location = new System.Drawing.Point(91, 123);
            this.Add_Ethernet_Field_Bits_Text_Box.Name = "Add_Ethernet_Field_Bits_Text_Box";
            this.Add_Ethernet_Field_Bits_Text_Box.Size = new System.Drawing.Size(184, 20);
            this.Add_Ethernet_Field_Bits_Text_Box.TabIndex = 2;
            // 
            // Add_Ethernet_Field_Accept_Button
            // 
            this.Add_Ethernet_Field_Accept_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Add_Ethernet_Field_Accept_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_Ethernet_Field_Accept_Button.Location = new System.Drawing.Point(218, 158);
            this.Add_Ethernet_Field_Accept_Button.Name = "Add_Ethernet_Field_Accept_Button";
            this.Add_Ethernet_Field_Accept_Button.Size = new System.Drawing.Size(57, 23);
            this.Add_Ethernet_Field_Accept_Button.TabIndex = 3;
            this.Add_Ethernet_Field_Accept_Button.Text = "Ok";
            this.Add_Ethernet_Field_Accept_Button.UseVisualStyleBackColor = true;
            this.Add_Ethernet_Field_Accept_Button.Click += new System.EventHandler(this.Add_Ethernet_Field_Accept_Button_Click);
            // 
            // Add_Ethernet_Field_Cancel_Button
            // 
            this.Add_Ethernet_Field_Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Add_Ethernet_Field_Cancel_Button.Location = new System.Drawing.Point(155, 158);
            this.Add_Ethernet_Field_Cancel_Button.Name = "Add_Ethernet_Field_Cancel_Button";
            this.Add_Ethernet_Field_Cancel_Button.Size = new System.Drawing.Size(57, 23);
            this.Add_Ethernet_Field_Cancel_Button.TabIndex = 4;
            this.Add_Ethernet_Field_Cancel_Button.Text = "Cancel";
            this.Add_Ethernet_Field_Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // Ethernet_Field_Add_Form
            // 
            this.AcceptButton = this.Add_Ethernet_Field_Accept_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Add_Ethernet_Field_Cancel_Button;
            this.ClientSize = new System.Drawing.Size(284, 193);
            this.Controls.Add(this.Add_Ethernet_Field_Accept_Button);
            this.Controls.Add(this.Add_Ethernet_Field_Cancel_Button);
            this.Controls.Add(this.Add_Ethernet_Field_Description_Text_Box);
            this.Controls.Add(this.Add_Ethernet_Field_Bits_Text_Box);
            this.Controls.Add(this.Add_Ethernet_Field_Name_Text_Box);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ethernet_Field_Add_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Ethernet Field";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Add_Ethernet_Field_Name_Text_Box;
        private System.Windows.Forms.TextBox Add_Ethernet_Field_Description_Text_Box;
        private System.Windows.Forms.TextBox Add_Ethernet_Field_Bits_Text_Box;
        private System.Windows.Forms.Button Add_Ethernet_Field_Accept_Button;
        private System.Windows.Forms.Button Add_Ethernet_Field_Cancel_Button;
    }
}