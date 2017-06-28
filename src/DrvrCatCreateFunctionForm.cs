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
    public partial class DrvrCatCreateFunctionForm : Form
    {
        public DrvrCatFunction created_function = null;
        private DrvrCatFunction function_builder = new DrvrCatFunction();
        //private List<Module_RegMap> Panel_Modules_List;
        //private List<Firmware_Module> Firmware_Module_List;

        public DrvrCatCreateFunctionForm(List<String> Module_Name_List)
        {
            //this.Panel_Modules_List = Panel_Modules_List;
            //this.Firmware_Module_List = Firmware_Module_List;
            InitializeComponent();

            Function_Module_List_Combo_Box.Items.Clear();

            //foreach (Module_RegMap current_module in Panel_Modules_List)
            //{
            //    Function_Module_List_Combo_Box.Items.Add(current_module.Module_Name);                
            //}

            //foreach (Firmware_Module current_module in Firmware_Module_List)
            //{
            //    Function_Module_List_Combo_Box.Items.Add(current_module.Module_Name);
            //}

            Function_Module_List_Combo_Box.Items.AddRange(Module_Name_List.ToArray());

            function_builder.Parameters = new List<DrvrCatFunctionParameter>();

            this.DialogResult = DialogResult.Cancel;

        }

        private void Parameter_Add_Button_Click(object sender, EventArgs e)
        {
         
            String Parameter_Data_Type = null;
            String Parameter_Variable_Name = null;

            if ((Parameter_Data_Type_Text_Box.Text.Trim().Length > 0))
            {
                Parameter_Data_Type = Parameter_Data_Type_Text_Box.Text.Trim();
            }
            else
            {
                MessageBox.Show("Data type field should be filled", "Incorrect Mandatory field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if((Parameter_Variable_Name_Text_Box.Text.Trim().Length > 0) && (!Parameter_Variable_Name_Text_Box.Text.Trim().Contains(" ")))
            {
                Parameter_Variable_Name = Parameter_Variable_Name_Text_Box.Text.Trim();
            }
            else
            {
                MessageBox.Show("Variable Name field should be filled", "Incorrect Mandatory field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] parameter_row = { Parameter_Variable_Name_Text_Box.Text.Replace(" ", "_"), Parameter_Data_Type_Text_Box.Text.Trim() };
            ListViewItem parameter_listViewItem = new ListViewItem(parameter_row);
            Parameters_List_View.Items.Add(parameter_listViewItem);

            DrvrCatFunctionParameter current_parameter = new DrvrCatFunctionParameter();
            current_parameter.data_type = Parameter_Data_Type_Text_Box.Text.Trim();
            current_parameter.parameter_name = Parameter_Variable_Name_Text_Box.Text.Replace(" ", "_");
            current_parameter.parameter_description = String.Copy(Parameter_Description_Text_Box.Text);

            function_builder.Parameters.Add(current_parameter);

            Parameter_Data_Type_Text_Box.Text = String.Empty;
            Parameter_Variable_Name_Text_Box.Text = String.Empty;
            Parameter_Description_Text_Box.Text = String.Empty;

        }

        private void Parameters_List_View_ItemActivate(object sender, EventArgs e)
        {
            ListView Parameter_List_View = (ListView)sender;

            ListView.SelectedListViewItemCollection Selected_Items = Parameters_List_View.SelectedItems;

            foreach (ListViewItem current_item in Selected_Items)
            {
                Parameter_Variable_Name_Text_Box.Text = current_item.SubItems[0].Text;
                Parameter_Data_Type_Text_Box.Text = current_item.SubItems[1].Text;
                function_builder.Parameters.RemoveAt(current_item.Index);
                current_item.Remove();
            }


        }

        private void Parameter_Remove_Button_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection Selected_Items = Parameters_List_View.SelectedItems;

            foreach (ListViewItem current_item in Selected_Items)
            {
                function_builder.Parameters.RemoveAt(current_item.Index);
                current_item.Remove();
            }

        }

        private void Return_Add_Button_Click(object sender, EventArgs e)
        {
            String Return_Value = null;
            String Return_Context = null;

            if ((Return_Value_Text_Box.Text.Trim().Length > 0) )
            {
                Return_Value = Return_Value_Text_Box.Text.Trim();
            }
            else
            {
                MessageBox.Show("Return Value field should be filled", "Incorrect Mandatory field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if ((Return_Value_Context_Text_Box.Text.Trim().Length > 0) )
            {
                Return_Context = Return_Value_Context_Text_Box.Text.Trim();
            }
            else
            {
                MessageBox.Show("Return Context field should be filled", "Incorrect Mandatory field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] result_row = { Return_Value, Return_Context };
            ListViewItem result_listViewItem = new ListViewItem(result_row);
            Return_Value_Context_List_View.Items.Add(result_listViewItem);
            
            DrvrCatFunctionReturnValue current_return_value = new DrvrCatFunctionReturnValue();
            current_return_value.Return_Context = Return_Context;
            current_return_value.Return_Value = Return_Value;

            function_builder.return_item.return_values.Add(current_return_value);

            Return_Value_Text_Box.Text = String.Empty;
            Return_Value_Context_Text_Box.Text = String.Empty;

        }

        private void Return_Value_Context_List_View_ItemActivate(object sender, EventArgs e)
        {
            ListView Return_Value_Context_List_View = (ListView)sender;

            ListView.SelectedListViewItemCollection Selected_Items = Return_Value_Context_List_View.SelectedItems;

            foreach (ListViewItem current_item in Selected_Items)
            {
                Return_Value_Text_Box.Text = current_item.SubItems[0].Text;
                Return_Value_Context_Text_Box.Text = current_item.SubItems[1].Text;
                function_builder.return_item.return_values.RemoveAt(current_item.Index);
                current_item.Remove();
            }
        }

        private void Return_Remove_Button_Click(object sender, EventArgs e)
        {
            ListView Return_Value_Context_List_View = (ListView)sender;

            ListView.SelectedListViewItemCollection Selected_Items = Return_Value_Context_List_View.SelectedItems;

            foreach (ListViewItem current_item in Selected_Items)
            {
                function_builder.return_item.return_values.RemoveAt(current_item.Index);
                current_item.Remove();
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Function_Module_List_Combo_Box.SelectedIndex >= 0)
            {
                String module_name = Function_Module_List_Combo_Box.GetItemText(Function_Module_List_Combo_Box.SelectedItem);
                function_builder.Module_Name = module_name;
                function_builder.Module_Index = 0;
            }
            else
            {
                MessageBox.Show("Select a module", "Incorrect Mandatory field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            function_builder.Function_Description = String.Copy(Function_Description_Text_Box.Text);

            if (Function_Name_Text_Box.Text.Length > 0)
            {
                function_builder.Function_Name = String.Copy(Function_Name_Text_Box.Text.Replace(" ","_"));
            }
            else
            {
                MessageBox.Show("Enter function name", "Incorrect Mandatory field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            if (Return_Data_Type_Text_Box.Text.Length > 0)
            {
                function_builder.return_item.Function_Return_type = Return_Data_Type_Text_Box.Text;
            }
            else
            {
                function_builder.return_item.Function_Return_type = "void";
            }

            function_builder.return_item.Return_Description = Return_Description_Text_Box.Text;

            DrvrCatCodeBuilder function_statements_builder = new DrvrCatCodeBuilder();

            function_builder.Function_Statements = String.Copy(Function_Statements_Edit_Box.Text);


            DrvrCatCodeBuilder function_code_builder = new DrvrCatCodeBuilder();
            function_code_builder.Define_Function_Code(function_builder);
            function_builder.Code = String.Copy(function_code_builder.GetCode());

            created_function = function_builder;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
