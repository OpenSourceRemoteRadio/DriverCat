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
    public partial class DrvrCatEthernetFieldAddForm : Form
    {
        public String Field_Name;
        public String Field_Description;
        public int Field_Bit_Width;

        public DrvrCatEthernetFieldAddForm()
        {
            InitializeComponent();
        }

        private void Add_Ethernet_Field_Accept_Button_Click(object sender, EventArgs e)
        {
            if (Add_Ethernet_Field_Name_Text_Box.Text.CompareTo(String.Empty) != 0)
            {
                Field_Name = Add_Ethernet_Field_Name_Text_Box.Text;
            }
            else
            {
                MessageBox.Show("Enter Field Name", "Missing Mandatory fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None; 
                return;
            }

            if (Add_Ethernet_Field_Description_Text_Box.Text.CompareTo(String.Empty) != 0)
            {
                Field_Description = Add_Ethernet_Field_Description_Text_Box.Text;
            }
            else
            {
                MessageBox.Show("Enter Field Description", "Missing Mandatory fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None; 
                return;
            }

            if (int.TryParse(Add_Ethernet_Field_Bits_Text_Box.Text,out Field_Bit_Width))
            {
                if(Field_Bit_Width <= 64)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Field bit width should be less than 64", "Incorrect bit width", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.DialogResult = DialogResult.None; 
                    return;
                }
            }
            else
            {
                MessageBox.Show("Enter valid integer in field bit width", "Incorrect Mandatory fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }
        }
    }
}
