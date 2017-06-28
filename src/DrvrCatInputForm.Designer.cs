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
    partial class DrvrCatInputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrvrCatInputForm));
            this.Input_String_Text_Box = new System.Windows.Forms.TextBox();
            this.Query_String_Label = new System.Windows.Forms.Label();
            this.Input_Accept_Button = new System.Windows.Forms.Button();
            this.Input_Cancel_Button = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Input_String_Text_Box
            // 
            this.Input_String_Text_Box.Location = new System.Drawing.Point(12, 35);
            this.Input_String_Text_Box.Name = "Input_String_Text_Box";
            this.Input_String_Text_Box.Size = new System.Drawing.Size(89, 20);
            this.Input_String_Text_Box.TabIndex = 0;
            // 
            // Query_String_Label
            // 
            this.Query_String_Label.AutoSize = true;
            this.Query_String_Label.Location = new System.Drawing.Point(11, 14);
            this.Query_String_Label.Name = "Query_String_Label";
            this.Query_String_Label.Size = new System.Drawing.Size(65, 13);
            this.Query_String_Label.TabIndex = 1;
            this.Query_String_Label.Text = "Query String";
            // 
            // Input_Accept_Button
            // 
            this.Input_Accept_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Input_Accept_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_Accept_Button.Location = new System.Drawing.Point(74, 3);
            this.Input_Accept_Button.Name = "Input_Accept_Button";
            this.Input_Accept_Button.Size = new System.Drawing.Size(57, 23);
            this.Input_Accept_Button.TabIndex = 2;
            this.Input_Accept_Button.Text = "Ok";
            this.Input_Accept_Button.UseVisualStyleBackColor = true;
            this.Input_Accept_Button.Click += new System.EventHandler(this.Input_Accept_Button_Click);
            // 
            // Input_Cancel_Button
            // 
            this.Input_Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Input_Cancel_Button.Location = new System.Drawing.Point(11, 3);
            this.Input_Cancel_Button.Name = "Input_Cancel_Button";
            this.Input_Cancel_Button.Size = new System.Drawing.Size(57, 23);
            this.Input_Cancel_Button.TabIndex = 2;
            this.Input_Cancel_Button.Text = "Cancel";
            this.Input_Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Input_Accept_Button);
            this.flowLayoutPanel1.Controls.Add(this.Input_Cancel_Button);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 61);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(134, 27);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // Input_Form
            // 
            this.AcceptButton = this.Input_Accept_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.CancelButton = this.Input_Cancel_Button;
            this.ClientSize = new System.Drawing.Size(134, 88);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.Query_String_Label);
            this.Controls.Add(this.Input_String_Text_Box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Input_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Title String";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Input_String_Text_Box;
        private System.Windows.Forms.Label Query_String_Label;
        private System.Windows.Forms.Button Input_Accept_Button;
        private System.Windows.Forms.Button Input_Cancel_Button;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}