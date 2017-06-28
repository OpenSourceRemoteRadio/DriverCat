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
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Deployment.Application;
using System.Xml;

namespace Code_Automation_Tool
{
    ///<Summary>
    /// Main Panel Form
    ///</Summary>
    public partial class DrvrCatCodeAutomationPanel : Form
    {
        ///<Summary>
        /// Main Panel Constructor
        ///</Summary>
        public DrvrCatCodeAutomationPanel()
        {
            InitializeComponent();
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
            DrvrCatCodeAutomationPanel.Panel_Modules_List = new List<DrvrCatModule>();
            DrvrCatCodeAutomationPanel.Firmware_Modules_List = new List<DrvrCatFirmwareModule>();
            DrvrCatCodeAutomationPanel.Selected_Module_Regmap = null;
            DrvrCatCodeAutomationPanel.Selected_Register = null;
            DrvrCatCodeAutomationPanel.Selected_Register_Bit = null;
            DrvrCatCodeAutomationPanel.Selected_Function = null;

            DrvrCatCodeAutomationPanel.Functions_List_All_Modules = new List<DrvrCatFunction>();
            DrvrCatCodeAutomationPanel.Functions_Name_List_All_Modules = new List<String>();
            DrvrCatCodeAutomationPanel.Device_List = new List<DrvrCatDtDevice>();

            Module_Functions_List_Box.Tag = (object)new List<DrvrCatFunction>();

            this.Packet_Header_String_Label.Tag = new DrvrCatEthernetFieldCode("Header String","char Header_String[6]",6*8);
            this.Packet_Id_Label.Tag = new DrvrCatEthernetFieldCode("Id","unsigned short Id", 16);
            this.Packet_Length_Label.Tag = new DrvrCatEthernetFieldCode("Length","unsigned int Length", 32);

            this.Command_Header_TransferType_Label.Tag = new DrvrCatEthernetFieldCode("Transfer Type", "unsigned int Transfer_Type:1", 1);
            this.Command_Header_OperationType_Label.Tag = new DrvrCatEthernetFieldCode("Operation Type", "unsigned int Operation_Type:4", 4);
            this.Command_Header_ModuleIndex_Label.Tag = new DrvrCatEthernetFieldCode("Module Index", "unsigned int Module_Index:8", 8);
            this.Command_Header_Address_Label.Tag = new DrvrCatEthernetFieldCode("Address", "unsigned int Address:20", 20);
            this.Command_Header_Length_Label.Tag = new DrvrCatEthernetFieldCode("Length", "unsigned int Length:20", 20);
            this.Command_Header_Instance_Num_Label.Tag = new DrvrCatEthernetFieldCode("Instance", "unsigned int Instance:4", 4);

            Refresh_Packet_Header_Fields();
            Refresh_Command_Header_Fields();
            Ethernet_Packet_Header_String = "alt";
        }

        //private readonly int DPD_SHEET = 8;
        //private readonly int DEVICE_REGMAP_START_ROW = 5;
        //private readonly int DEVICE_REGMAP_COL = 2;
        //private readonly int DEVICE_REG_OFFSET_COL = 3;
        //private readonly int DEVICE_HEADING_ROW = 5;
        //private readonly int REG_BIT_DEFINITION_COL = 9;
        //private readonly int DTS_Start_Address_Column = 5;
        //private readonly int DTS_End_Address_Column = 6;
        //private readonly int BIT_COUNT = 32;
        private string MODULE_NAME="device";
        private Excel.Workbook xlopened_book;
        private Excel.Application xlApp;

        private static List<DrvrCatModule> Panel_Modules_List;
        private static List<DrvrCatFirmwareModule> Firmware_Modules_List;
        private static DrvrCatModule Selected_Module_Regmap;
        private static DrvrCatRegister Selected_Register;
        private static DrvrCatRegisterBit Selected_Register_Bit;
        private static DrvrCatFunction Selected_Function;
        private static bool Select_RRH_DUC_BW_Config = false;
        private static bool Select_RRH_DDC_BW_Config = false;
        private static bool Select_RRH_DUC_NCO_Config = false;
        private static bool Select_RRH_DDC_NCO_Config = false;
        public static List<DrvrCatFunction> Functions_List_All_Modules;
        public static List<String> Functions_Name_List_All_Modules;
        public String Ethernet_Packet_Header_String = String.Empty;
        private static List<DrvrCatDtDevice> Device_List;
        
       
        private void Parse_FID_button_Click(object sender, EventArgs e)
        {
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;

            if(String.IsNullOrEmpty(FID_path_text.Text))
            {
                MessageBox.Show("Choose FID path");
                Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
                return;
            }
   
            xlApp = new Excel.Application();
            try
            {
                 //if(xlApp.Workbooks.CanCheckOut(@FID_path_text.Text))
                 {
                     xlopened_book = xlApp.Workbooks.Open(@FID_path_text.Text);// "D:\Big_Cat\WS-FID-00001 Hepta.xlsx");          
                   //  xlApp.Workbooks.CheckOut(@FID_path_text.Text);
                 }
                 /*else
                 {
                     MessageBox.Show("File on Sharepoint can NOT be checked out. Make sure no one else is working in the file.Including yourself.");
                     return;
                 }*/
            }
            catch (Exception exception_excel_open)
            {
                MessageBox.Show("Cannot open the specified file " + exception_excel_open.ToString());
                return;
            }
            //xlopened_book = xlWorkbook;
            Excel.Worksheet current_sheet = null;

            if (xlopened_book!=null)
            {
                //FID_Sheet_Module_Names.Items.Clear();
                //FID_Sheet_Module_Names.Items.Add("---Select Sheet---");
                for (int i = 1; i <= xlopened_book.Sheets.Count; i++)
                {
                    current_sheet = xlopened_book.Sheets[i];
                    if (current_sheet.Visible == Excel.XlSheetVisibility.xlSheetVisible)
                    {
                        //FID_Sheet_Module_Names.Items.Add(current_sheet.Name.ToString());
                        FID_Parse_Modules_List.Items.Add(current_sheet.Name.ToString());
                    }
                }

                //FID_Sheet_Module_Names.SelectedIndex = 0; 
            }
            
            //xlWorkbook.Close();
            //xlopened_book.CheckIn(false);
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
        }

        private void FID_path_open_button_Click(object sender, EventArgs e)
        {
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;
            DialogResult fid_path_result = FID_path_open_dialog.ShowDialog();
            if (fid_path_result == DialogResult.OK) // Test result.
            {
                string fid_full_path = FID_path_open_dialog.FileName;
                FID_path_text.Text = fid_full_path;
            }

            Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
        }


        private void FID_Sheet_Module_Names_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;

            if (String.IsNullOrEmpty(FID_path_text.Text))
            {
                MessageBox.Show("Choose FID path");
                Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
                return;
            }


            DrvrCatExcelResourceTable Current_Sheet_Extract = new DrvrCatExcelResourceTable();
            String Table_Name;
            String Selected_Module_Name;

            if (FID_Sheet_Module_Names.SelectedIndex > 0)
            {
                DrvrCatModule Current_Module_RegMap = null;
                Current_Module_RegMap = DrvrCatModule.Get_ModuleRegmap_by_Module_Index(DrvrCatCodeAutomationPanel.Panel_Modules_List,FID_Sheet_Module_Names.SelectedIndex-1);

                if (Current_Module_RegMap == null)
                {
                    Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
                    return;
                }

                List<DrvrCatFunction> Module_Functions_List_Box_Functions_List = (List<DrvrCatFunction>)Module_Functions_List_Box.Tag;

                DrvrCatCodeAutomationPanel.Selected_Module_Regmap = Current_Module_RegMap;

                Module_Registers_List_Box_Heading.Text = "Registers in " + Current_Module_RegMap.Module_Name  + " module";

                Module_Function_Filter_by_Register_Checkbox.Enabled = true;
                Module_Function_List_Box_Filter_by_Register_bit.Enabled = false;

                Module_Function_Filter_by_Register_Combobox.Enabled = false;
                Module_Function_Filter_by_Register_Bit_Combobox.Enabled = false;

                Module_Function_Filter_by_Register_Checkbox.Checked = false;
                Module_Function_List_Box_Filter_by_Register_bit.Checked = false;


                Module_Registers_List_Box.Items.Clear();
                Module_Function_Filter_by_Register_Combobox.Items.Clear();
                Module_Function_Filter_by_Register_Bit_Combobox.Items.Clear();
                Module_Functions_List_Box_Functions_List.Clear();

                //FIX
                foreach (DrvrCatRegister Register in Current_Module_RegMap.Resources.ElementAt(0).Register_Offsets)
                {
                    Module_Registers_List_Box.Items.Add(Register.Register_Name);
                    Module_Function_Filter_by_Register_Combobox.Items.Add(Register.Register_Name);
                    if (Register.Bits!=null)
                    {
                        foreach (DrvrCatRegisterBit current_bit in Register.Bits)
                        {
                            if (current_bit.Functions_List!=null)
                            {
                                Module_Functions_List_Box_Functions_List.AddRange(current_bit.Functions_List); 
                            }
                        } 
                    }
                }
                Module_Functions_List_Box_Functions_List.AddRange(Current_Module_RegMap.Module_functions_list);

                Module_Functions_List_Box_Update_Functions_List(Module_Functions_List_Box_Functions_List);

                //FIX
                Module_Register_Def_Code_Text_Box.Text = Current_Module_RegMap.Resources.ElementAt(0).Code;

                Configurations_List_View.Items.Clear();
                Configuration_Enum_Text_Box.Text = String.Empty;
                if(Current_Module_RegMap.Config_List.Count > 0)
                {
                    foreach (DrvrCatConfigServiceItem current_config in Current_Module_RegMap.Config_List)
                    {
                        string[] config_row = { current_config.Config_Service_Name , current_config.Description };
                        ListViewItem config_listViewItem = new ListViewItem(config_row);
                        Configurations_List_View.Items.Add(config_listViewItem);
                    }

                    Configuration_Enum_Text_Box.Text = Current_Module_RegMap.Config_List_Enumeration.Enumeration_Code;
                }

                Service_List_View.Items.Clear();
                Service_Enum_Text_Box.Text = String.Empty;
                if (Current_Module_RegMap.Service_List.Count > 0)
                {
                    foreach (DrvrCatConfigServiceItem current_service in Current_Module_RegMap.Service_List)
                    {
                        string[] service_row = { current_service.Config_Service_Name, current_service.Description };
                        ListViewItem service_listViewItem = new ListViewItem(service_row);
                        Service_List_View.Items.Add(service_listViewItem);
                    }

                    Service_Enum_Text_Box.Text = Current_Module_RegMap.Config_List_Enumeration.Enumeration_Code;
                }
                

            }
            else
            {
                List<DrvrCatFunction> Module_Functions_List_Box_Functions_List = (List<DrvrCatFunction>)Module_Functions_List_Box.Tag;
                Module_Functions_List_Box_Functions_List.Clear();
                Module_Functions_List_Box_Update_Functions_List(Module_Functions_List_Box_Functions_List);
            }

            Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
        }

        private void Module_Functions_List_Box_Update_Functions_List(List<DrvrCatFunction> Module_Functions_List_Box_Functions_List)
        {
            Module_Functions_List_Box.Items.Clear();
            foreach (DrvrCatFunction current_function in Module_Functions_List_Box_Functions_List)
            {
                Module_Functions_List_Box.Items.Add(current_function.Function_Name);
            }
            return;
        }

        private void Tab_Control_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Tab_Control.SelectedIndex == 1 || Tab_Control.SelectedIndex == 2 || Tab_Control.SelectedIndex == 3)
            {
                FID_Sheet_Module_Names.Parent = Tab_Control.SelectedTab;
            }

            //Code_Automation_Panel.Select_RRH_DUC_BW_Config = false;
            //Code_Automation_Panel.Select_RRH_DDC_BW_Config = false;
            //Code_Automation_Panel.Select_RRH_DUC_NCO_Config = false;
            //Code_Automation_Panel.Select_RRH_DDC_NCO_Config = false;


        }

        private void Application_Code_Generation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (xlopened_book != null)
            {
                xlopened_book.Close();
            }

            if(xlApp != null)
            {
                xlApp.Quit();
            }
        }

        private void Application_Code_Generation_Panel_Load(object sender, EventArgs e)
        {
            Status_Version_Label.Text = Status_Version_Label.Text + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }


        private void BigCat_logo_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Resources.Company_Site);
        }

        private void feedbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Properties.Resources.Feedback_ID);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DrvrCatToolAbout about_form =  new DrvrCatToolAbout();
            about_form.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Driver_Code_Generation_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            System.Diagnostics.Process.Start("https://bigcatwireless.sharepoint.com/CAT/_layouts/15/start.aspx#/CatWiki/");
        }

        private void Module_Registers_List_Box_DoubleClick(object sender, EventArgs e)
        {
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;

            ListBox Module_Register_List_Box = (ListBox)sender;
            DrvrCatRegister selected_register = null;
            
            //Module_RegMap Selected_Module_Regmap = Code_Automation_Panel.Get_ModuleRegmap_by_Module_Index(Module_Registers_List_Box.SelectedIndex);
            DrvrCatModule Selected_Module_Regmap = DrvrCatCodeAutomationPanel.Selected_Module_Regmap;

            //FIX
            selected_register = Selected_Module_Regmap.Resources[0].Register_Offsets.ElementAt(Module_Registers_List_Box.SelectedIndex);
            DrvrCatCodeAutomationPanel.Selected_Register = selected_register;

            Module_Register_Name_Text_Box.Text = selected_register.Register_Name;
            Module_Register_Address_Text_Box.Text = selected_register.Address_offset.ToString();
            Module_Register_Address_Text_Box_Hex.Text = "0x" + selected_register.Address_offset.ToString("X");
            Module_Register_POR_Text_Box.Text = selected_register.Power_On_Reset_Value.ToString();
            Module_Register_Def_Code_Text_Box.Text = selected_register.Code;

            List<DrvrCatRegisterBit> register_bits = selected_register.Bits;
            

            Module_Register_Bit_Table_Layout.Controls.Clear();
            Module_Register_Bit_Table_Layout.ColumnCount = 1;
            Module_Register_Bit_Table_Layout.RowCount = 1;

            foreach (DrvrCatRegisterBit bit in register_bits)
            {
                StringBuilder bit_value_tip_builder = new StringBuilder();
                Label bit_item = new Label();
                bit_item.Dock = DockStyle.Fill;
                bit_item.Text = bit.Bit_Name;
                bit_item.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                bit_item.MouseDoubleClick += new MouseEventHandler(Register_Bit_MouseDblClick);

                ToolTip bit_item_tooltip = new ToolTip();

                bit_item_tooltip.ToolTipIcon = ToolTipIcon.None;
                bit_item_tooltip.IsBalloon = false;
                bit_item_tooltip.ShowAlways = true;

                foreach (var value_description in bit.Value_Description)
                {
                    bit_value_tip_builder.AppendLine(Convert.ToString(value_description.configuration_value,2) + "\t" + value_description.configuration_result);
                }

                bit_item_tooltip.SetToolTip(bit_item, bit_value_tip_builder.ToString());

                Module_Register_Bit_Table_Layout.Controls.Add(bit_item, Module_Register_Bit_Table_Layout.ColumnCount - 1, 0);
                Module_Register_Bit_Table_Layout.ColumnCount = Module_Register_Bit_Table_Layout.ColumnCount + 1;
            }

            Module_Register_Bit_Table_Layout.ColumnCount = Module_Register_Bit_Table_Layout.ColumnCount - 1;

            TableLayoutColumnStyleCollection column_styles = Module_Register_Bit_Table_Layout.ColumnStyles;

            foreach (ColumnStyle column_style in column_styles)
            {
                column_style.SizeType = SizeType.Percent;
                column_style.Width = ((float)100 )/ (Module_Register_Bit_Table_Layout.ColumnCount);
            }

            Module_Register_Bit_Position_Text_Box.Text = String.Empty;
            Module_Register_Bit_Description_Text_Box.Text = String.Empty;

            Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
            return;
        }

    
        private void Register_Bit_MouseDblClick(object sender, EventArgs e)
        {
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;
            Label selected_bit_label = (Label) sender;
            DrvrCatRegisterBit selected_bit = DrvrCatRegisterBit.Get_Register_Bit_by_BitName(DrvrCatCodeAutomationPanel.Selected_Register.Bits, selected_bit_label.Text);

            if(selected_bit!=null)
            {
                Module_Register_Bit_Position_Text_Box.Text = (selected_bit.Bit_Width == 1) ? selected_bit.Bit_Position.ToString() : "[" + (selected_bit.Bit_Position + selected_bit.Bit_Width - 1).ToString() + ":" + selected_bit.Bit_Position.ToString() + "]";
                Module_Register_Bit_Description_Text_Box.Text = selected_bit.Bit_Description;

                if(selected_bit.bit_values_enum !=null)
                {
                    Module_Register_Def_Code_Text_Box.Text = selected_bit.bit_values_enum.Enumeration_Code;
                }
                else
                {
                    Module_Register_Def_Code_Text_Box.Clear();
                }

                //if(selected_bit.Functions_List!=null)
                //{
                //    Module_Functions_List_Box.Items.Clear();

                //    foreach (Function current_function in selected_bit.Functions_List)
                //    {
                //        Module_Functions_List_Box.Items.Add(current_function.Function_Name);
                //    }
                //}
                DrvrCatCodeAutomationPanel.Selected_Register_Bit = selected_bit;
            }

            Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
            return;
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form Settings_Form = new DrvrCatAppSettings();
            Settings_Form.Show();
        }

        private void Module_Functions_List_Box_DoubleClick(object sender, EventArgs e)
        {
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;

            ListBox Module_Functions_List_Box = (ListBox)sender;
            DrvrCatFunction selected_function = null;
            
            //Register_Bit Selected_Reg_Bit = Code_Automation_Panel.Selected_Register_Bit;
            //if (Selected_Register_Bit != null)
            //{
            //    selected_function = Selected_Reg_Bit.Functions_List.ElementAt(Module_Functions_List_Box.SelectedIndex);
            //    if (selected_function != null)
            //    {
            //        Code_Automation_Panel.Selected_Function = selected_function;
            //        Selected_Function_Code_Text_Box.Text = selected_function.Code;
            //    }
            //}

            List<DrvrCatFunction> Module_Functions_List_Box_Functions_List = (List<DrvrCatFunction>)Module_Functions_List_Box.Tag;


            selected_function = Module_Functions_List_Box_Functions_List.ElementAt(Module_Functions_List_Box.SelectedIndex);
            if (selected_function != null)
            {
                //Code_Automation_Panel.Selected_Function = selected_function;
                Selected_Function_Code_Text_Box.Text = selected_function.Code;
            }


            Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
        }

        private void Code_Generate_Button_Click(object sender, EventArgs e)
        {
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;
            DialogResult code_save_path_result = Code_Destination_Browser_dialog.ShowDialog();

            if(code_save_path_result == DialogResult.OK)
            {
                String code_save_path = Code_Destination_Browser_dialog.SelectedPath;

                if(DrvrCatCodeAutomationPanel.Panel_Modules_List!=null)
                {
                    if(DrvrCatCodeAutomationPanel.Panel_Modules_List.Count > 0)
                    {
                        String Include_Directorty = code_save_path + "\\" + Properties.Settings.Default.Code_Include_Directory_Name;
                        bool isExists = System.IO.Directory.Exists(Include_Directorty);
                        if(isExists)
                        {
                            System.IO.Directory.Delete(Include_Directorty, true);
                        }

                        String Source_Directorty = code_save_path + "\\" + Properties.Settings.Default.Code_Source_Directory_Name;
                        isExists = System.IO.Directory.Exists(Source_Directorty);
                        if (isExists)
                        {
                            System.IO.Directory.Delete(Source_Directorty, true);
                        }
                            
                        System.IO.Directory.CreateDirectory(Include_Directorty);
                        System.IO.Directory.CreateDirectory(Source_Directorty);

                        List<String> module_inc_file_list = new List<string>();

                        foreach (DrvrCatModule current_regmap in DrvrCatCodeAutomationPanel.Panel_Modules_List)
                        {
                            //foreach (Function current_function in current_regmap.Module_functions_list)
                            //{
                            //    CodeBuilder function_code_builder = new CodeBuilder();
                            //    function_code_builder.Define_Function_Code(current_function);

                            //    current_function.Code = String.Copy(function_code_builder.GetCode());
                            //}

                            module_inc_file_list.Add(DrvrCatCodeBuilder.Write_Module_Code(current_regmap, Include_Directorty, Source_Directorty));
                        }



                        foreach (DrvrCatFirmwareModule current_module in DrvrCatCodeAutomationPanel.Firmware_Modules_List)
                        {
                            DrvrCatCodeBuilder.Write_Firmware_Module_Code(current_module, Include_Directorty, Source_Directorty, module_inc_file_list);
                        }

             
                        String Firmware_Include_Name = Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ","_") +"_firmware.h";
                        String Protocol_Include_Name = Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_")  + "_protocol.h";
                        String Ethernet_Include_Name = Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_")  + "_command_format.h";

#if false
                        String firmware_include_code = String.Copy(Properties.Resources.firmware_header_content);
                        firmware_include_code = firmware_include_code.Replace("HEPTA_FIRMWARE_H_", Firmware_Include_Name.ToUpper().Replace(".", "_") + "_");
                        firmware_include_code = firmware_include_code.Replace("hepta_datatype.h", Datatype_Include_Name);
                        firmware_include_code = firmware_include_code.Replace("hepta_protocol.h", Protocol_Include_Name);
#endif
                        Write_Firmware_Header_File(Include_Directorty);

#if false

                        String Datatype_include_code = String.Copy(Properties.Resources.hepta_datatype);
                        Datatype_include_code = Datatype_include_code.Replace("HEPTA_DATATYPES_H", Datatype_Include_Name.ToUpper().Replace(".", "_") + "_");


                        String Protocol_include_code = String.Copy(Properties.Resources.hepta_protocol);
                        Protocol_include_code = Protocol_include_code.Replace("HEPTA_PROTOCOL_H_", Protocol_Include_Name.ToUpper().Replace(".", "_") + "_");
                        Protocol_include_code = Protocol_include_code.Replace("hepta_datatype.h", Datatype_Include_Name);
#endif

                        Write_Protocol_Header_File(Include_Directorty);
                        Write_Ethernet_Header_File(Include_Directorty);

                        Write_TCP_Client_Source_File(Source_Directorty);

                        Write_Client_Main_Source_File(Source_Directorty);

#if false

                        //File.WriteAllText(Include_Directorty + "\\" + Firmware_Include_Name, Properties.Resources.hepta_firmware);
                        File.WriteAllText(Include_Directorty + "\\" + Firmware_Include_Name, firmware_include_code);


                        //File.WriteAllText(Include_Directorty + "\\" + Protocol_Include_Name , Properties.Resources.hepta_protocol);
                        File.WriteAllText(Include_Directorty + "\\" + Protocol_Include_Name, Protocol_include_code);
                        //File.WriteAllText(Include_Directorty + "\\" + Datatype_Include_Name , Properties.Resources.hepta_datatype);
                        File.WriteAllText(Include_Directorty + "\\" + Datatype_Include_Name , Datatype_include_code);



                        String cm_client_source_code = String.Copy(Properties.Resources.hepta_cm_client);
                        cm_client_source_code = cm_client_source_code.Replace("hepta_protocol.h", Protocol_Include_Name);
                        cm_client_source_code = cm_client_source_code.Replace("hepta_firmware.h", Firmware_Include_Name);
                        cm_client_source_code = cm_client_source_code.Replace("hepta_datatype.h", Datatype_Include_Name);
                        cm_client_source_code = cm_client_source_code.Replace("return_status=hepta_command_decoder(pCmdHeader,pRdWrTcpPacket->id,&pRdWrTcpPacket);",
                            "return_status=" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_command_decoder(pCmdHeader,pRdWrTcpPacket->id,&pRdWrTcpPacket);");



                        File.WriteAllText(Source_Directorty + "\\" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_cm_client.c", cm_client_source_code);


#endif
                       
                        DrvrCatXmlWriter.Create_XML_Document(code_save_path + "\\" + Properties.Settings.Default.Project_Name.ToLower().Replace(" ", "_") + "_Definition.xml", DrvrCatCodeAutomationPanel.Panel_Modules_List);
                        DrvrCatXmlWriter.Create_Commands_List_XML_Document(code_save_path + "\\" + Properties.Settings.Default.Project_Name.ToLower().Replace(" ", "_") + "_Commands.xml", Command_Mapper_Table_Layout);

                    }
                }
            }
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
        }

        private void Write_Client_Main_Source_File(string Source_Directorty)
        {

            String source_file_name = Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_main.c";

            String source_file_path = Source_Directorty + "\\" + source_file_name;

            String Source_Doxygen_Comment = String.Empty;

            StreamWriter source_file_stream = new StreamWriter(source_file_path, false);


            source_file_stream.WriteLine(Properties.Settings.Default.License_Message);
            source_file_stream.WriteLine();

            if (Properties.Settings.Default.Generate_Doxygen_Comments)
            {
                Source_Doxygen_Comment = String.Copy(DrvrCatDoxygen.Generate_File_Comment(source_file_name, "Application main file"));
                source_file_stream.WriteLine(Source_Doxygen_Comment);
                source_file_stream.WriteLine();
            }



            source_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include public/global Header files"));

            source_file_stream.WriteLine("#include <stdio.h>	\n#define _GNU_SOURCE \n#define __USE_GNU	 \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <sys/select.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <netdb.h>       \n#include <signal.h>      \n#include <unistd.h>      \n#include <stdio.h>       \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <sys/mman.h>    \n#include <netdb.h>       \n#include <sys/stat.h>    \n#include <fcntl.h>       \n#include <pthread.h>     \n#include <sys/ioctl.h>   \n#include <stdbool.h>\n   #include <errno.h>\n");

            source_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include private Header files"));

            source_file_stream.WriteLine("#define KNRM  \"\\x1B[0m\"");
            source_file_stream.WriteLine("#define KRED  \"\\x1B[31m\"");
            source_file_stream.WriteLine("#define KGRN  \"\\x1B[32m\"");
            source_file_stream.WriteLine("#define KYEL  \"\\x1B[33m\"");
            source_file_stream.WriteLine("#define KBLU  \"\\x1B[34m\"");
            source_file_stream.WriteLine("#define KMAG  \"\\x1B[35m\"");
            source_file_stream.WriteLine("#define KCYN  \"\\x1B[36m\"");
            source_file_stream.WriteLine("#define KWHT  \"\\x1B[37m\"");

            source_file_stream.WriteLine("");

            source_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Replace(" ", "_") + "_firmware.h\"");
            source_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Replace(" ", "_") + "_protocol.h\"");
            source_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Replace(" ", "_") + "_command_format.h\"");


            source_file_stream.WriteLine("socket_manager_header "+Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_")+"_socket_manager;");
            source_file_stream.WriteLine("#define SOCKET_MANAGER_VARIABLE_NAME " + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_socket_manager");

            source_file_stream.WriteLine("");

            String main_file_content = String.Copy(Properties.Resources.main_text_file.Replace("project_name", Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_")));

            source_file_stream.WriteLine(main_file_content);
            source_file_stream.WriteLine("");


            source_file_stream.Close();


            return;
        }

        private void Write_TCP_Client_Source_File(string Source_Directorty)
        {
            String source_file_name = Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_tcp_client.c";


            String source_file_path = Source_Directorty + "\\" + source_file_name;

            String Source_Doxygen_Comment = String.Empty;

            StreamWriter source_file_stream = new StreamWriter(source_file_path, false);


            source_file_stream.WriteLine(Properties.Settings.Default.License_Message);
            source_file_stream.WriteLine();

            if (Properties.Settings.Default.Generate_Doxygen_Comments)
            {
                Source_Doxygen_Comment = String.Copy(DrvrCatDoxygen.Generate_File_Comment(source_file_name, "TCP Client APIs are defined in this file"));
                source_file_stream.WriteLine(Source_Doxygen_Comment);
                source_file_stream.WriteLine();
            }



            source_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include public/global Header files"));

            source_file_stream.WriteLine("#include <stdio.h>	\n#define _GNU_SOURCE \n#define __USE_GNU	 \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <sys/select.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <netdb.h>       \n#include <signal.h>      \n#include <unistd.h>      \n#include <stdio.h>       \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <sys/mman.h>    \n#include <netdb.h>       \n#include <sys/stat.h>    \n#include <fcntl.h>       \n#include <pthread.h>     \n#include <sys/ioctl.h>   \n#include <stdbool.h>\n   #include <netinet/tcp.h>\n");

            source_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include private Header files"));


            source_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Replace(" ", "_") + "_firmware.h\"");
            source_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Replace(" ", "_") + "_protocol.h\"");
            source_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Replace(" ", "_") + "_command_format.h\"");

            source_file_stream.WriteLine("");
            source_file_stream.WriteLine("extern socket_manager_header " + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_socket_manager;");

            source_file_stream.WriteLine("");
            source_file_stream.WriteLine(Properties.Resources.tcp_client_file_content);
            source_file_stream.WriteLine("");


            source_file_stream.Close();


            return;
        }

        private void Write_Ethernet_Header_File(string Include_Directorty)
        {
            String inc_file_name = Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_command_format" + ".h";

            String inc_file_path = Include_Directorty + "\\" + inc_file_name;

            String inc_Doxygen_Comment = String.Empty;

            StreamWriter inc_file_stream = new StreamWriter(inc_file_path, false);

            inc_file_stream.WriteLine(Properties.Settings.Default.License_Message);
            inc_file_stream.WriteLine();

            if (Properties.Settings.Default.Generate_Doxygen_Comments)
            {
                inc_Doxygen_Comment = String.Copy(DrvrCatDoxygen.Generate_File_Comment(inc_file_name, "Ethernet Header"));
                inc_file_stream.WriteLine(inc_Doxygen_Comment);
                inc_file_stream.WriteLine();
            }

            StringBuilder enum_definition_builder = new StringBuilder();
            StringBuilder register_definition_builder = new StringBuilder();
            StringBuilder function_declaration_builder = new StringBuilder();


            String define_string = inc_file_name.Trim().Replace(".", "_").ToUpper() + "_";
            inc_file_stream.WriteLine("#ifndef " + define_string);
            inc_file_stream.WriteLine("#define " + define_string);


            inc_file_stream.WriteLine("#ifdef __cplusplus");
            inc_file_stream.WriteLine("extern \"C\"");
            inc_file_stream.WriteLine("{");
            inc_file_stream.WriteLine("#endif");


            inc_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include public/global Header files"));

            inc_file_stream.WriteLine("#include <stdio.h>	\n#define _GNU_SOURCE \n#define __USE_GNU	 \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <sys/select.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <netdb.h>       \n#include <signal.h>      \n#include <unistd.h>      \n#include <stdio.h>       \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <sys/mman.h>    \n#include <netdb.h>       \n#include <sys/stat.h>    \n#include <fcntl.h>       \n#include <pthread.h>     \n#include <sys/ioctl.h>   \n#include <stdbool.h>\n");

            inc_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include private Header files"));





            inc_file_stream.WriteLine("");

            inc_file_stream.WriteLine("#define TCP_PACKET_HEADER_STRING 		\"" + this.Ethernet_Packet_Header_String + "\"");
            inc_file_stream.WriteLine("#define TCP_PACKET_HEADER_STRING_SIZE   (sizeof(TCP_PACKET_HEADER_STRING)-1)");
            inc_file_stream.WriteLine("#define TCP_PACKET_HEADER_SIZE 			sizeof(Packet_Header)");

            inc_file_stream.WriteLine("");

            inc_file_stream.WriteLine("#define COMMAND_DECODER_FUNCTION_NAME " + Properties.Settings.Default.Project_Name.Trim().Replace(" ", "_").ToLower() + "_command_decoder");

            inc_file_stream.WriteLine("");

            DrvrCatCodeBuilder Module_Index_Enum_Builder = new DrvrCatCodeBuilder();
            DrvrCatEnumeration Module_Index_Enum = new DrvrCatEnumeration();
            Module_Index_Enum.Enumeration_Name = "Module_Index_Enum_Def";
            Module_Index_Enum.Enumeration_Description = "Tells the decoder in which module the operation to be performed";

            for (int module_index = 0; module_index < DrvrCatCodeAutomationPanel.Panel_Modules_List.Count; module_index++)
            {
                Module_Index_Enum.Enumeration_members.Add("MODULE_INDEX_" + DrvrCatCodeAutomationPanel.Panel_Modules_List.ElementAt(module_index).Module_Name.Replace(" ", "_").ToUpper());
                Module_Index_Enum.Enumeration_values.Add((uint)module_index);
                Module_Index_Enum.Enumeration_member_description.Add("Operation to be performed in the " + DrvrCatCodeAutomationPanel.Panel_Modules_List.ElementAt(module_index).Module_Name + " module");
            }

            Module_Index_Enum.Enumeration_members.Add("MODULE_INDEX_COMMAND_MANAGER");
            Module_Index_Enum.Enumeration_values.Add((uint)DrvrCatCodeAutomationPanel.Panel_Modules_List.Count);
            Module_Index_Enum.Enumeration_member_description.Add("To configure the Command Manager module");


            Module_Index_Enum_Builder.Define_Bit_Typedef_Enumeration(Module_Index_Enum,String.Empty, "CommandManager");
            inc_file_stream.WriteLine(Module_Index_Enum_Builder.GetCode());





            int number_of_commands = Command_Mapper_Table_Layout.RowCount - 2;
            int number_of_modules = Command_Mapper_Table_Layout.ColumnCount - 2;


            DrvrCatCodeBuilder Operation_Type_Enum_Builder = new DrvrCatCodeBuilder();
            DrvrCatEnumeration Operation_Type_Enum = new DrvrCatEnumeration();
            Operation_Type_Enum.Enumeration_Name = "Operation_Type_Enum_Def";
            Operation_Type_Enum.Enumeration_Description = "Tells the decoder what to operation be performed";




            for (int row_index = 1; row_index <= number_of_commands; row_index++)
            {
                int col_index = 0;

                Control current_control = Command_Mapper_Table_Layout.GetControlFromPosition(col_index, row_index);

                if (current_control is TextBox)
                {
                    TextBox current_function_text_box = (TextBox)current_control;


                    Operation_Type_Enum.Enumeration_members.Add("OPERATION_TYPE_" + current_function_text_box.Text.Replace(" ", "_").ToUpper());
                    Operation_Type_Enum.Enumeration_values.Add((uint)(row_index-1));
                    Operation_Type_Enum.Enumeration_member_description.Add(current_function_text_box.Text +" operation");

                }

            }

            Operation_Type_Enum.Enumeration_members.Add("OPERATION_TYPE_ERROR");
            Operation_Type_Enum.Enumeration_values.Add((uint)(number_of_commands));
            Operation_Type_Enum.Enumeration_member_description.Add("Inform a error report to the server");

            Operation_Type_Enum.Enumeration_members.Add("OPERATION_TYPE_ACK");
            Operation_Type_Enum.Enumeration_values.Add((uint)(number_of_commands + 1));
            Operation_Type_Enum.Enumeration_member_description.Add("Acknowledge to an action to the server");

            Operation_Type_Enum.Enumeration_members.Add("OPERATION_TYPE_MANAGE");
            Operation_Type_Enum.Enumeration_values.Add((uint)(number_of_commands + 2));
            Operation_Type_Enum.Enumeration_member_description.Add("Command to manage the application");


            Operation_Type_Enum_Builder.Define_Bit_Typedef_Enumeration(Operation_Type_Enum, String.Empty, "CommandManager");
            inc_file_stream.WriteLine(Operation_Type_Enum_Builder.GetCode());


            //FIX
            //inc_file_stream.WriteLine(Packet_Header_Code.Text);
            inc_file_stream.WriteLine(Properties.Resources.Packet_Header_Structure_Text);

            inc_file_stream.WriteLine();
            inc_file_stream.WriteLine();

            //FIX
            //inc_file_stream.WriteLine(Command_Header_Code.Text);
            inc_file_stream.WriteLine(Properties.Resources.Command_Header_Structure_Text);

            inc_file_stream.WriteLine();
            inc_file_stream.WriteLine();









            inc_file_stream.WriteLine("#ifdef __cplusplus");
            inc_file_stream.WriteLine("}/* close the extern \"C\" { */");
            inc_file_stream.WriteLine("#endif");
            inc_file_stream.WriteLine("#endif");

            inc_file_stream.Close();


            return;
        }

        private void Write_Firmware_Header_File(string Include_Directorty)
        {
            //CodeBuilder Firmware_include_header_code_builder = new CodeBuilder();
            //Firmware_include_header_code_builder.AppendLine(Properties.Settings.Default.License_Message);

            String inc_file_name = Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_firmware.h";


            String inc_file_path = Include_Directorty + "\\" + inc_file_name;

            String inc_Doxygen_Comment = String.Empty;

            StreamWriter inc_file_stream = new StreamWriter(inc_file_path, false);


            inc_file_stream.WriteLine(Properties.Settings.Default.License_Message);
            inc_file_stream.WriteLine();

            if (Properties.Settings.Default.Generate_Doxygen_Comments)
            {
                inc_Doxygen_Comment = String.Copy(DrvrCatDoxygen.Generate_File_Comment(inc_file_name, "Firmware Header"));
                inc_file_stream.WriteLine(inc_Doxygen_Comment);
                inc_file_stream.WriteLine();
            }

            StringBuilder enum_definition_builder = new StringBuilder();
            StringBuilder register_definition_builder = new StringBuilder();
            StringBuilder function_declaration_builder = new StringBuilder();


            String define_string = inc_file_name.Trim().Replace(".", "_").ToUpper() + "_";
            inc_file_stream.WriteLine("#ifndef " + define_string);
            inc_file_stream.WriteLine("#define " + define_string);


            inc_file_stream.WriteLine("#ifdef __cplusplus");
            inc_file_stream.WriteLine("extern \"C\"");
            inc_file_stream.WriteLine("{");
            inc_file_stream.WriteLine("#endif");


            inc_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include public/global Header files"));

            inc_file_stream.WriteLine("#include <stdio.h>	\n#define _GNU_SOURCE \n#define __USE_GNU	 \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <sys/select.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <netdb.h>       \n#include <signal.h>      \n#include <unistd.h>      \n#include <stdio.h>       \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <sys/mman.h>    \n#include <netdb.h>       \n#include <sys/stat.h>    \n#include <fcntl.h>       \n#include <pthread.h>     \n#include <sys/ioctl.h>   \n#include <stdbool.h>\n");

            inc_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include private Header files"));


            inc_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Replace(" ","_") + "_protocol.h\"");
            inc_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Replace(" ", "_") + "_command_format.h\"");



            inc_file_stream.WriteLine("");
            inc_file_stream.WriteLine(Properties.Resources.firmware_header_content);
            inc_file_stream.WriteLine("");

            


            inc_file_stream.WriteLine("#ifdef __cplusplus");
            inc_file_stream.WriteLine("}/* close the extern \"C\" { */");
            inc_file_stream.WriteLine("#endif");

            inc_file_stream.WriteLine("#endif");

            inc_file_stream.Close();


            return;
        }

#if true
        private void Write_Protocol_Header_File(string Include_Directorty)
        {
            //CodeBuilder Protocol_include_header_code_builder = new CodeBuilder();
            //Protocol_include_header_code_builder.AppendLine(Properties.Settings.Default.License_Message);

                String inc_file_name = Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_protocol" + ".h";

                String inc_file_path = Include_Directorty + "\\" + inc_file_name;

                String inc_Doxygen_Comment = String.Empty;
            
                StreamWriter inc_file_stream = new StreamWriter(inc_file_path, false);

                inc_file_stream.WriteLine(Properties.Settings.Default.License_Message);
                inc_file_stream.WriteLine();

                if (Properties.Settings.Default.Generate_Doxygen_Comments)
                {
                    inc_Doxygen_Comment = String.Copy(DrvrCatDoxygen.Generate_File_Comment(inc_file_name, "Protocol Header"));
                    inc_file_stream.WriteLine(inc_Doxygen_Comment);
                    inc_file_stream.WriteLine();
                }

                StringBuilder enum_definition_builder = new StringBuilder();
                StringBuilder register_definition_builder = new StringBuilder();
                StringBuilder function_declaration_builder = new StringBuilder();


                String define_string = inc_file_name.Trim().Replace(".", "_").ToUpper() + "_";
                inc_file_stream.WriteLine("#ifndef " + define_string);
                inc_file_stream.WriteLine("#define " + define_string);


                inc_file_stream.WriteLine("#ifdef __cplusplus");
                inc_file_stream.WriteLine("extern \"C\"");
                inc_file_stream.WriteLine("{");
                inc_file_stream.WriteLine("#endif");	


                inc_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include public/global Header files"));

                inc_file_stream.WriteLine("#include <stdio.h>	\n#define _GNU_SOURCE \n#define __USE_GNU	 \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <sys/select.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <netdb.h>       \n#include <signal.h>      \n#include <unistd.h>      \n#include <stdio.h>       \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <sys/mman.h>    \n#include <netdb.h>       \n#include <sys/stat.h>    \n#include <fcntl.h>       \n#include <pthread.h>     \n#include <sys/ioctl.h>   \n#include <stdbool.h>\n");

                inc_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include private Header files"));





                inc_file_stream.WriteLine("");
                inc_file_stream.WriteLine(Properties.Resources.protocol_header_context);
                inc_file_stream.WriteLine("");

                

                

                


                inc_file_stream.WriteLine("#ifdef __cplusplus");
                inc_file_stream.WriteLine("}/* close the extern \"C\" { */");
                inc_file_stream.WriteLine("#endif");
                inc_file_stream.WriteLine("#endif");

                inc_file_stream.Close();


            return;
        }
#endif
        private void devicetree_parse_button_Click(object sender, EventArgs e)
        {
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;

            if (String.IsNullOrEmpty(device_tree_path_text_box.Text))
            {
                MessageBox.Show("Choose Device tree path");
                Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
                return;
            }

            Device_List_View.Items.Clear();
            DrvrCatCodeAutomationPanel.Device_List.Clear();
            
            String line;
            DrvrCatDtNode current_DT_node = null;
            List<DrvrCatDtNode> DT_node_list = new List<DrvrCatDtNode>();
            bool sopc_node_detected = false;


            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(device_tree_path_text_box.Text);
            while ((line = file.ReadLine()) != null)
            {
                if(  line.Trim().Length > 0 )
                {
                    if (line.Contains("{") && line.Contains("sopc"))
                    {
                        sopc_node_detected = true;
                        String node_name = String.Empty;
                        String group_name = String.Empty;
                        if(line.Contains(":"))
                        {
                            String[] name_split = line.Split(':');
                            node_name = String.Copy(name_split[0].Trim());
                            line = String.Copy(name_split[1]);
                        }

                        if (line.Contains("@"))
                        {
                            String[] name_split = line.Split('@');
                            group_name = String.Copy(name_split[0].Trim());
                        }
                        else
                        {
                            String[] name_split = line.Split('{');
                            group_name = String.Copy(name_split[0].Trim());
                        }

                        current_DT_node = new DrvrCatDtNode(node_name, group_name.Replace("-","_").Trim(), null);
                        DT_node_list.Add(current_DT_node);
                        continue;
                    }

                    if (sopc_node_detected)
                    {
                        if (line.Contains("{"))
                        {
                            String node_name = String.Empty;
                            String group_name = String.Empty;
                            if(line.Contains(":"))
                            {
                                String[] name_split = line.Split(':');
                                node_name = String.Copy(name_split[0].Trim());
                                line = String.Copy(name_split[1]);
                            }

                            if (line.Contains("@"))
                            {
                                String[] name_split = line.Split('@');
                                group_name = String.Copy(name_split[0].Trim());
                            }
                            else
                            {
                                String[] name_split = line.Split('{');
                                group_name = String.Copy(name_split[0].Trim());
                            }

                            current_DT_node = new DrvrCatDtNode(node_name, group_name.Replace("-", "_").Trim(), current_DT_node);
                            DT_node_list.Add(current_DT_node);
                            if(current_DT_node.parent_node.child_nodes==null)
                            {
                                current_DT_node.parent_node.child_nodes = new List<DrvrCatDtNode>();
                            }
                            current_DT_node.parent_node.child_nodes.Add(current_DT_node);
                        }
                        else if (line.Contains("};"))
                        {
                            if(current_DT_node.parent_node!=null)
                            {
                                current_DT_node = current_DT_node.parent_node;
                            }
                            else
                            {
                                sopc_node_detected = false;
                                break;
                            }
                        }
                        else if (line.Contains("compatible"))
                        {
                            if(line.Contains("="))
                            {
                                String[] name_split = line.Split('=');
                                line = String.Copy(name_split[1].Trim());
                            }
                            line = line.Replace(";", "");
                            List<String> compatible_parsed = ParseDelimitedString(line);
                            current_DT_node.compatible_string_list = compatible_parsed;
                        }
                        else if (line.Contains("interrupts"))
                        {
                            current_DT_node.interrupt_list = new List<DrvrCatDtInterrupt>();
                            Regex r1 = new Regex("\\d+");
                            Match m1 = r1.Match(line);
                            int index = 0;
                            while(m1.Success)
                            {
                                if (index == 1)
                                {
                                    current_DT_node.interrupt_list.Add(new DrvrCatDtInterrupt(int.Parse(m1.Value.Trim()), String.Empty));
                                }

                                if(index == 2)
                                {
                                    index = 0;
                                }
                                else
                                {
                                    index = index + 1;
                                }
                                m1 = m1.NextMatch();
                            }
                        }
                    }
                }
            }

            file.Close();
            //var q = DT_node_list.GroupBy(x => x)
            //            .Select(g => new { Value = g.Key, Count = g.Count() })
            //            .OrderByDescending(x => x.Count);

            //foreach (var x in q)
            //{
            //    Console.WriteLine("Value: " + x.Value + " Count: " + x.Count);
            //}

            var q = from x in DT_node_list
                    group x by x into g
                    let count = g.Count()
                    //orderby count descending
                    select new { Name = g.Key.Group, Count = count ,First_node = g.First()};



            foreach (var x in q)
            {
                //Console.WriteLine("Count: " + x.Count + " Name: " + x.Name);
                //List<DT_Node> similar_nodes_list = DT_Node.Get_Device_Node_List_By_Group_Name(x.First_node, DT_node_list);
                List<DrvrCatDtNode> similar_nodes_list = x.First_node.Get_Similar_Device_Node_List(DT_node_list);
                DrvrCatDtDevice device_node = new DrvrCatDtDevice(x.Name);
                device_node.device_nodes =  similar_nodes_list;
                device_node.compatible =  String.Empty;
                if(similar_nodes_list.ElementAt(0) != null)
                {
                    if(similar_nodes_list.ElementAt(0).compatible_string_list != null)
                    {
                        device_node.compatible = String.Copy(similar_nodes_list.ElementAt(0).compatible_string_list.ElementAt(0));
                    }
                }

                foreach (DrvrCatModule current_regmap in DrvrCatCodeAutomationPanel.Panel_Modules_List)
                {
                    if(current_regmap.Module_Name.ToLower().Equals(device_node.Name.ToLower()))
                    {
                        if (current_regmap.Instances_Name_List.Count == 0)
                        {
                            foreach (DrvrCatDtNode current_node in device_node.device_nodes)
                            {
                                current_regmap.Instances_Name_List.Add(current_node.Name);
                            }
                        }
                    }
                }

                DrvrCatCodeAutomationPanel.Device_List.Add(device_node);
            }


            foreach (DrvrCatDtDevice current_device in DrvrCatCodeAutomationPanel.Device_List)
            {
                string[] device_row = { current_device.Name , current_device.device_nodes.Count.ToString() };
                ListViewItem device_listViewItem = new ListViewItem(device_row);
                Device_List_View.Items.Add(device_listViewItem);
            }





        }

        private void device_tree_open_button_Click(object sender, EventArgs e)
        {
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;
            DialogResult device_tree_path_result = device_tree_open_dialog.ShowDialog();
            if (device_tree_path_result == DialogResult.OK) // Test result.
            {
                string device_tree_full_path = device_tree_open_dialog.FileName;
                device_tree_path_text_box.Text = device_tree_full_path;
            }

            Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
        }

        private void driver_tree_Node_add_button_Click(object sender, EventArgs e)
        {
            if(device_tree_tree_view.SelectedNode!=null)
            {
                device_driver_selected_node_treeview.Nodes.Add((TreeNode)device_tree_tree_view.SelectedNode.Clone());
            }
        }

        private void driver_selected_node_delete_button_Click(object sender, EventArgs e)
        {
            if(device_driver_selected_node_treeview.SelectedNode!=null)
            {
                device_driver_selected_node_treeview.SelectedNode.Remove();
            }
        }

        private void Device_Driver_Generate_Button_Click(object sender, EventArgs e)
        {

            String destination_folder;
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;

            int Signal_number = 64;

            if (Device_List_View.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select a module");
                Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
                return;
            }

            DialogResult destination_folder_result = Code_Destination_Browser_dialog.ShowDialog();
            if (destination_folder_result == DialogResult.OK)
            {

                destination_folder = Code_Destination_Browser_dialog.SelectedPath;


                if (!System.IO.Directory.Exists(@destination_folder + "\\" + Properties.Resources.Driver_Code_Folder_Name))
                {
                    System.IO.Directory.CreateDirectory(@destination_folder + "\\" + Properties.Resources.Driver_Code_Folder_Name);
                    //System.IO.Directory.Delete(@destination_folder + "\\" + Properties.Resources.Driver_Code_Folder_Name, true);
                }

                if (!System.IO.Directory.Exists(@destination_folder + "\\" + Properties.Resources.Include_Header_Code_Folder_Name))
                {
                    System.IO.Directory.CreateDirectory(@destination_folder + "\\" + Properties.Resources.Include_Header_Code_Folder_Name);
                    //System.IO.Directory.Delete(@destination_folder + "\\" + Properties.Resources.Driver_Code_Folder_Name, true);
                }


                String compilation_script_file_name = Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_driver_compile.sh";
                String load_script_file_name = Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_driver_load.sh";
                String unload_script_file_name = Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_driver_unload.sh";

                String compilation_script_file_path = destination_folder + "\\" + compilation_script_file_name;
                String load_script_file_path = destination_folder + "\\" + load_script_file_name;
                String unload_script_file_path = destination_folder + "\\" + unload_script_file_name;

                StreamWriter compilation_script_file_stream = new StreamWriter(compilation_script_file_path, false);
                StreamWriter load_script_file_stream = new StreamWriter(load_script_file_path, false);
                StreamWriter unload_script_file_stream = new StreamWriter(unload_script_file_path, false);

                compilation_script_file_stream.WriteLine(Properties.Resources.Driver_Compile_Script_Content);
                load_script_file_stream.WriteLine("#!/bin/sh");
                unload_script_file_stream.WriteLine("#!/bin/sh");

                ListView.CheckedListViewItemCollection Selected_Items = Device_List_View.CheckedItems;

                foreach (ListViewItem current_item in Selected_Items)
                {
                    DrvrCatDtDevice current_device = DrvrCatCodeAutomationPanel.Device_List.ElementAt(current_item.Index);

                    String Source_Directorty = @destination_folder + "\\drv\\" + current_device.Name.ToLower();

                    if (!System.IO.Directory.Exists(Source_Directorty))
                    {
                        System.IO.Directory.CreateDirectory(Source_Directorty);
                    }
                    File.WriteAllText(Source_Directorty + "\\" + "Makefile", Properties.Resources.Makefile.Replace("driver_name_to_replace", Properties.Settings.Default.Project_Name.Replace(" ", "_").Trim() + "_" + current_device.Name.ToLower() + "_driver.o"));

                    compilation_script_file_stream.WriteLine("Driver_Compile $PWD\"/drv/" + current_device.Name.ToLower() + "/\" \"" + current_device.Name.ToUpper() + " Driver\" " + "$PWD\"/drv/" + current_device.Name.ToLower() + "/" + Properties.Settings.Default.Project_Name.Replace(" ", "_").Trim() + "_" + current_device.Name.ToLower() + "_driver.ko\"");
                    compilation_script_file_stream.WriteLine();
                   

                    Signal_number = Signal_number - (Write_Driver_Source_File(Source_Directorty, current_device, Signal_number));

                    load_script_file_stream.Write("echo \"Installing " + current_device.Name.ToUpper() + " driver\"\n");
                    load_script_file_stream.Write("insmod " + Properties.Settings.Default.Project_Name.Replace(" ", "_").Trim() + "_" + current_device.Name.ToLower() + "_driver.ko\n");
                    load_script_file_stream.Write("rm -f /dev/" + current_device.Name.ToLower() + "*\n");

                    unload_script_file_stream.Write("echo \"Uninstalling " + current_device.Name.ToUpper() + " driver\"\n");
                    unload_script_file_stream.Write("rmmod " + Properties.Settings.Default.Project_Name.Replace(" ", "_").Trim() + "_" + current_device.Name.ToLower() + "_driver.ko\n");
                    unload_script_file_stream.Write("rm -f /dev/" + current_device.Name.ToLower() + "*\n");

                    for (int instance = 0; instance < current_device.device_nodes.Count; instance++)
                    {
                        if (instance <= 9)
                        {
                            load_script_file_stream.Write("major=$(awk '$2== \"" + current_device.Name.ToLower() + "\" && length($3)!=0 && $3==" + instance.ToString() + "  {print $1}' /proc/devices)\n");
                        }
                        else
                        {
                            load_script_file_stream.Write("major=$(awk '$2== \"" + current_device.Name.ToLower() + instance.ToString() + "\" {print $1}' /proc/devices)\n");
                        }
                        load_script_file_stream.Write("mknod /dev/" + current_device.Name.ToLower() + instance.ToString() + " c $major 0\n");
                    }

                    


                    
                }




                compilation_script_file_stream.WriteLine("echo -e -n \"\\n\\n\" >> $COMPILE_REPORT_FILE");
                compilation_script_file_stream.WriteLine("echo \"Script done\"");
                compilation_script_file_stream.Close();
                load_script_file_stream.Close();
                unload_script_file_stream.Close();

                Write_Driver_Header_File(@destination_folder + "\\inc");

                System.Diagnostics.Process.Start(@destination_folder + "\\drv");

            }



            Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;

        }

        private int Write_Driver_Source_File(string Source_Directorty, DrvrCatDtDevice current_device, int signal_number)
        {
            String Group_Name = Properties.Settings.Default.Project_Name.ToLower() + "_" + current_device.Name.ToLower() + "_driver";
            String inc_file_name = Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_driver" + ".h";
            String src_file_name = Properties.Settings.Default.Project_Name.Replace(" ", "_").Trim() + "_" + current_device.Name.ToLower() + "_driver.c";

            String src_file_path = Source_Directorty + "\\" + src_file_name;

            int number_of_signals_used = 0;


            String src_Doxygen_Comment = String.Empty;

            StreamWriter src_file_stream = new StreamWriter(src_file_path, false);

            src_file_stream.WriteLine(Properties.Settings.Default.License_Message);

            if (Properties.Settings.Default.Generate_Doxygen_Comments)
            {
                src_Doxygen_Comment = String.Copy(DrvrCatDoxygen.Generate_File_Comment(src_file_name, Group_Name, "Driver for " + current_device.Name + " IP", true));

                src_file_stream.WriteLine(src_Doxygen_Comment);
                src_file_stream.WriteLine();
            }

            String probe_function_name = current_device.Name.ToLower() + "_platform_probe";
            String remove_function_name = current_device.Name.ToLower() + "_platform_remove";

            src_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include public/global Header files"));

            src_file_stream.WriteLine("#include <linux/init.h> \n#include <linux/module.h> \n#include <linux/moduleparam.h> \n#include <linux/kdev_t.h> \n#include <linux/fs.h> \n#include <linux/cdev.h> \n#include <linux/kernel.h> \n#include <asm/uaccess.h> \n#include <linux/proc_fs.h> \n#include <linux/string.h> \n#include <linux/ioctl.h> \n#include <linux/device.h> \n#include <linux/version.h> \n#include <linux/ioport.h> \n#include <asm/io.h> \n#include <linux/platform_device.h> \n#include <linux/slab.h> \n#include <linux/fb.h> \n#include <linux/delay.h> \n#include <linux/init.h> \n#include <linux/ioport.h> \n#include <linux/mm.h> \n#include <linux/spinlock.h> \n#include <linux/semaphore.h> \n#include <linux/mutex.h> \n#include <linux/string.h> \n#include <linux/irq.h> \n#include <asm/siginfo.h>	 \n#include <linux/sched.h>	 \n#include <linux/rcupdate.h>	 \n#include <linux/interrupt.h>\n");


            src_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include private Header files"));

            src_file_stream.WriteLine("#define KERNEL");
            src_file_stream.WriteLine("#include \"../../inc/" + inc_file_name + "\"");

            src_file_stream.WriteLine("#define COMPATIBLE_STRING \"" + current_device.compatible + "\"");
            src_file_stream.WriteLine("#define DRIVER_MODULE_NAME \"" + current_device.Name.ToLower() + "\"");
            src_file_stream.WriteLine("#define NUMBER_OF_INSTANCES " + current_device.device_nodes.Count.ToString());



            src_file_stream.Write("unsigned int number_of_irqs[NUMBER_OF_INSTANCES] = {");
            
            for (int node_index = 0; node_index < current_device.device_nodes.Count ; node_index++)
			{
                DrvrCatDtNode current_node = current_device.device_nodes.ElementAt(node_index);
                if(current_node.interrupt_list != null)
                {
                    src_file_stream.Write(current_node.interrupt_list.Count);   
                }
                else
                {
                    src_file_stream.Write("0");    
                }

                if(node_index == (current_device.device_nodes.Count -1 ))
                {
                    src_file_stream.WriteLine("};");    
                }
                else
                {
                    src_file_stream.Write(","); 
                }
			}

            src_file_stream.Write("unsigned int interrupt_signal_numbers[NUMBER_OF_INSTANCES] = {");

            for (int node_index = 0; node_index < current_device.device_nodes.Count; node_index++)
            {
                DrvrCatDtNode current_node = current_device.device_nodes.ElementAt(node_index);
                if (current_node.interrupt_list != null)
                {
                    src_file_stream.Write(signal_number.ToString());
                    signal_number--;
                    number_of_signals_used++;
                }
                else
                {
                    src_file_stream.Write("0");
                }

                if (node_index == (current_device.device_nodes.Count - 1))
                {
                    src_file_stream.WriteLine("};");
                }
                else
                {
                    src_file_stream.Write(",");
                }
            }

            src_file_stream.WriteLine("interrupt_signal_info * interrupt_signal_info_ptr[NUMBER_OF_INSTANCES];");
            src_file_stream.WriteLine("unsigned int * module_count_ptr;");
            src_file_stream.WriteLine("struct proc_dir_entry *device_proc_dir_ptr;");
            src_file_stream.WriteLine("struct proc_dir_entry *num_of_instance_proc_ptr;");
            src_file_stream.WriteLine("char * module_char_name;");


            src_file_stream.WriteLine("int " + probe_function_name + "(struct platform_device *pdev);");
            src_file_stream.WriteLine("int " + remove_function_name + "(struct platform_device *pdev);");


            DrvrCatCodeBuilder driver_id_match_code_builder = new DrvrCatCodeBuilder();
            driver_id_match_code_builder.AppendLine("static struct of_device_id " + current_device.Name.ToLower() + "_driver_id_match[] =");
            driver_id_match_code_builder.Start_Block();
            driver_id_match_code_builder.AppendLine("{ .compatible = COMPATIBLE_STRING, },");
            driver_id_match_code_builder.AppendLine("{}");
            driver_id_match_code_builder.End_Block(";");
            src_file_stream.WriteLine(driver_id_match_code_builder.GetCode());


            DrvrCatCodeBuilder platform_driver_builder = new DrvrCatCodeBuilder();
            platform_driver_builder.AppendLine("static struct platform_driver "+ current_device.Name.ToLower() + "_platform_driver = ");
            platform_driver_builder.Start_Block();
            platform_driver_builder.AppendLine(".probe = "+probe_function_name+",");
            platform_driver_builder.AppendLine(".remove = " + remove_function_name + ",");
            platform_driver_builder.AppendLine(".driver =");
            platform_driver_builder.Start_Block();
            platform_driver_builder.AppendLine(".name = DRIVER_MODULE_NAME,");
            platform_driver_builder.AppendLine(".owner = THIS_MODULE,");
            platform_driver_builder.AppendLine(".of_match_table = " + current_device.Name.ToLower() + "_driver_id_match,");
            platform_driver_builder.End_Block(",");
            platform_driver_builder.End_Block(";");
            src_file_stream.WriteLine(platform_driver_builder.GetCode());


            DrvrCatFunction module_init_function = new DrvrCatFunction();
            module_init_function.Function_Description = current_device.Name + " driver init function. Called when " + current_device.Name + " driver is installed in kernel. Initialises " + current_device.Name + " platfrom device";
            module_init_function.Function_Name = current_device.Name.ToLower() + "_driver_init";
            module_init_function.return_item.Function_Return_type = "static int __init";
            module_init_function.Function_Statements = "printk(KERN_INFO \"%s : Module Initialisation\\n\",DRIVER_MODULE_NAME);" +
	        "\nmodule_count_ptr=kmalloc(sizeof(unsigned int),GFP_KERNEL);" +
	        "\n*module_count_ptr=0;" +
	        "\ndevice_proc_dir_ptr = proc_mkdir(DRIVER_MODULE_NAME,NULL);" +
	        "\nnum_of_instance_proc_ptr = proc_create_data(\"num_of_instance\",0,device_proc_dir_ptr,&proc_num_of_instance_fops,module_count_ptr);" +
	        "\nplatform_driver_register(&"+ current_device.Name.ToLower() +"_platform_driver);"+
	        "\nprintk(KERN_INFO \"%s : Platform Driver registered\\n\",DRIVER_MODULE_NAME);"+
	        "\nreturn 0;";
            
            DrvrCatCodeBuilder module_init_function_code_builder = new DrvrCatCodeBuilder();
            module_init_function_code_builder.Define_Function_Code(module_init_function, Group_Name);
            src_file_stream.WriteLine(module_init_function_code_builder.GetCode());


            DrvrCatFunctionParameter platform_device_param = new DrvrCatFunctionParameter();
            platform_device_param.data_type = "struct platform_device *";
            platform_device_param.parameter_name = "pdev";
            platform_device_param.parameter_description = current_device.Name + " platform device node from kernel";


            DrvrCatFunction device_probe_function = new DrvrCatFunction();
            device_probe_function.Function_Description = current_device.Name + " probe function. Called when " + current_device.Name + " instance found in device tree";
            device_probe_function.Function_Name = probe_function_name;
            device_probe_function.return_item.Function_Return_type = "int";
            device_probe_function.Parameters = new List<DrvrCatFunctionParameter>();
            device_probe_function.Parameters.Add(platform_device_param);
            device_probe_function.Function_Statements = Properties.Resources.Driver_Probe_Function_Content;

            DrvrCatCodeBuilder device_probe_function_code_builder = new DrvrCatCodeBuilder();
            device_probe_function_code_builder.Define_Function_Code(device_probe_function, Group_Name);
            src_file_stream.WriteLine(device_probe_function_code_builder.GetCode());


            DrvrCatFunction device_remove_function = new DrvrCatFunction();
            device_remove_function.Function_Description = current_device.Name + " platform device file remove function. Called when " + current_device.Name + " platform device file is removed from kernel";
            device_remove_function.Function_Name = remove_function_name;
            device_remove_function.return_item.Function_Return_type = "int";
            device_remove_function.Parameters = new List<DrvrCatFunctionParameter>();
            device_remove_function.Parameters.Add(platform_device_param);
            device_remove_function.Function_Statements = Properties.Resources.Driver_Remove_Function_Content;

            DrvrCatCodeBuilder device_remove_function_code_builder = new DrvrCatCodeBuilder();
            device_remove_function_code_builder.Define_Function_Code(device_remove_function, Group_Name);
            src_file_stream.WriteLine(device_remove_function_code_builder.GetCode());


            DrvrCatFunction module_exit_function = new DrvrCatFunction();
            module_exit_function.Function_Description = current_device.Name + " driver exit function. Called when " + current_device.Name + " driver is removed from kernel";
            module_exit_function.Function_Name = current_device.Name.ToLower() + "_driver_exit";
            module_exit_function.return_item.Function_Return_type = "static void";
            module_exit_function.Function_Statements = "printk(KERN_INFO \"%s : Module Exit\\n\",DRIVER_MODULE_NAME);" +
            "\nplatform_driver_unregister(&" + current_device.Name.ToLower() + "_platform_driver);" +
            "\nprintk(KERN_INFO \"%s : Platform Driver Unregistered\\n\",DRIVER_MODULE_NAME);" +
            "\nkfree(module_count_ptr);" +
            "\nkfree(module_char_name);" +
            "\nremove_proc_entry(\"num_of_instance\",device_proc_dir_ptr);" +
            "\nremove_proc_entry(DRIVER_MODULE_NAME,NULL);" +
            "\nreturn;";

            DrvrCatCodeBuilder module_exit_function_code_builder = new DrvrCatCodeBuilder();
            module_exit_function_code_builder.Define_Function_Code(module_exit_function, Group_Name);
            src_file_stream.WriteLine(module_exit_function_code_builder.GetCode());

            src_file_stream.WriteLine("module_init(" + current_device.Name.ToLower() +"_driver_init);");
            src_file_stream.WriteLine("module_exit(" + current_device.Name.ToLower() +"_driver_exit);");

            src_file_stream.WriteLine("MODULE_AUTHOR(\"Intel\");");
            src_file_stream.WriteLine("MODULE_VERSION(\"1.0.0\");");
            src_file_stream.WriteLine("MODULE_LICENSE(\"Dual BSD/GPL\");");
            src_file_stream.WriteLine("MODULE_DESCRIPTION(\"Memory-mapped I/O interface driver for " + current_device.Name.ToUpper() + "\");");

            src_file_stream.Close();
            return number_of_signals_used;
        }

        private void Write_Driver_Header_File(string Include_Directorty)
        {
            //CodeBuilder Protocol_include_header_code_builder = new CodeBuilder();
            //Protocol_include_header_code_builder.AppendLine(Properties.Settings.Default.License_Message);

                String inc_file_name = Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_driver" + ".h";

                String inc_file_path = Include_Directorty + "\\" + inc_file_name;

                String inc_Doxygen_Comment = String.Empty;
            
                StreamWriter inc_file_stream = new StreamWriter(inc_file_path, false);

                inc_file_stream.WriteLine(Properties.Settings.Default.License_Message);
                inc_file_stream.WriteLine();

                if (Properties.Settings.Default.Generate_Doxygen_Comments)
                {
                    inc_Doxygen_Comment = String.Copy(DrvrCatDoxygen.Generate_File_Comment(inc_file_name, "Header file for Drivers"));
                    inc_file_stream.WriteLine(inc_Doxygen_Comment);
                    inc_file_stream.WriteLine();
                }

                String define_string = inc_file_name.Trim().Replace(".", "_").ToUpper() + "_";
                inc_file_stream.WriteLine("#ifndef " + define_string);
                inc_file_stream.WriteLine("#define " + define_string);

                inc_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include public/global Header files"));

                inc_file_stream.WriteLine("#include <linux/init.h> \n#include <linux/module.h> \n#include <linux/moduleparam.h> \n#include <linux/kdev_t.h> \n#include <linux/fs.h> \n#include <linux/cdev.h> \n#include <linux/kernel.h> \n#include <asm/uaccess.h> \n#include <linux/proc_fs.h> \n#include <linux/string.h> \n#include <linux/ioctl.h> \n#include <linux/device.h> \n#include <linux/version.h> \n#include <linux/ioport.h> \n#include <asm/io.h> \n#include <linux/platform_device.h> \n#include <linux/slab.h> \n#include <linux/fb.h> \n#include <linux/delay.h> \n#include <linux/init.h> \n#include <linux/ioport.h> \n#include <linux/mm.h> \n#include <linux/spinlock.h> \n#include <linux/semaphore.h> \n#include <linux/mutex.h> \n#include <linux/string.h> \n#include <linux/irq.h> \n#include <asm/siginfo.h>	 \n#include <linux/sched.h>	 \n#include <linux/rcupdate.h>	 \n#include <linux/interrupt.h>\n#include <linux/uio_driver.h>\n");

                inc_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include private Header files"));


                inc_file_stream.WriteLine("");
                inc_file_stream.WriteLine(Properties.Resources.driver_header_content);
                inc_file_stream.WriteLine("");

                inc_file_stream.WriteLine("#endif");
                inc_file_stream.Close();


            return;
        }

        private static List<string> ParseDelimitedString(string arguments, char delim = ',')
        {
            bool inQuotes = false;
            
            List<string> strings = new List<string>();

            StringBuilder sb = new StringBuilder();
            foreach (char c in arguments)
            {
                if (c == '"')
                {
                    if (!inQuotes)
                        inQuotes = true;
                    else
                        inQuotes = false;
                }
                else if (c == delim)
                {
                    if (!inQuotes)
                    {
                        strings.Add(sb.ToString().Trim());
                        sb.Clear();
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
                else
                {
                    sb.Append(c);
                }
            }
            strings.Add(sb.ToString().Trim());

            return strings;
        }

        private void rrh_config_duc_add_bw_button_Click(object sender, EventArgs e)
        {
            DrvrCatCodeAutomationPanel.Select_RRH_DUC_BW_Config = true;

            Tab_Control.SelectedIndex = 1;
        }

        private void rrh_config_duc_add_nco_button_Click(object sender, EventArgs e)
        {
            DrvrCatCodeAutomationPanel.Select_RRH_DUC_NCO_Config = true;

            Tab_Control.SelectedIndex = 1;
        }

        private void rrh_config_ddc_add_bw_button_Click(object sender, EventArgs e)
        {
            DrvrCatCodeAutomationPanel.Select_RRH_DDC_BW_Config = true;

            Tab_Control.SelectedIndex = 1;
        }

        private void rrh_config_ddc_add_nco_button_Click(object sender, EventArgs e)
        {
            DrvrCatCodeAutomationPanel.Select_RRH_DDC_NCO_Config = true;

            Tab_Control.SelectedIndex = 1;
        }

        private void Module_Register_Address_Text_Box_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;

                DrvrCatRegister selected_register = null;

                DrvrCatModule Selected_Module_Regmap = DrvrCatCodeAutomationPanel.Selected_Module_Regmap;

                Int32 register_address;
                    
                bool result = Int32.TryParse(Module_Register_Address_Text_Box.Text,out register_address);

                if(result)
                {
                    Module_Register_Address_Text_Box_Hex.Text = "0x" + register_address.ToString("X");
                }

                if (Selected_Module_Regmap!=null && result)
                {
                    //FIX
                    foreach (DrvrCatRegister current_register in Selected_Module_Regmap.Resources[0].Register_Offsets)
                    {
                        if(current_register.Address_offset == register_address)
                        {
                            selected_register = current_register;
                            break;
                        }
                    }

                    if(selected_register==null)
                    {
                        MessageBox.Show("Address not available");
                        return;
                    }

                    DrvrCatCodeAutomationPanel.Selected_Register = selected_register;

                    Module_Register_Name_Text_Box.Text = selected_register.Register_Name;
                    Module_Register_Address_Text_Box.Text = selected_register.Address_offset.ToString();
                    Module_Register_Address_Text_Box_Hex.Text = "0x" + selected_register.Address_offset.ToString("X");
                    Module_Register_POR_Text_Box.Text = selected_register.Power_On_Reset_Value.ToString();
                    Module_Register_Def_Code_Text_Box.Text = selected_register.Code;

                    List<DrvrCatRegisterBit> register_bits = selected_register.Bits;


                    Module_Register_Bit_Table_Layout.Controls.Clear();
                    Module_Register_Bit_Table_Layout.ColumnCount = 1;
                    Module_Register_Bit_Table_Layout.RowCount = 1;

                    foreach (DrvrCatRegisterBit bit in register_bits)
                    {
                        StringBuilder bit_value_tip_builder = new StringBuilder();
                        Label bit_item = new Label();
                        bit_item.Dock = DockStyle.Fill;
                        bit_item.Text = bit.Bit_Name;
                        bit_item.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                        bit_item.MouseDoubleClick += new MouseEventHandler(Register_Bit_MouseDblClick);

                        ToolTip bit_item_tooltip = new ToolTip();

                        bit_item_tooltip.ToolTipIcon = ToolTipIcon.None;
                        bit_item_tooltip.IsBalloon = false;
                        bit_item_tooltip.ShowAlways = true;

                        foreach (var value_description in bit.Value_Description)
                        {
                            bit_value_tip_builder.AppendLine(Convert.ToString(value_description.configuration_value, 2) + "\t" + value_description.configuration_result);
                        }

                        bit_item_tooltip.SetToolTip(bit_item, bit_value_tip_builder.ToString());

                        Module_Register_Bit_Table_Layout.Controls.Add(bit_item, Module_Register_Bit_Table_Layout.ColumnCount - 1, 0);
                        Module_Register_Bit_Table_Layout.ColumnCount = Module_Register_Bit_Table_Layout.ColumnCount + 1;
                    }

                    Module_Register_Bit_Table_Layout.ColumnCount = Module_Register_Bit_Table_Layout.ColumnCount - 1;

                    TableLayoutColumnStyleCollection column_styles = Module_Register_Bit_Table_Layout.ColumnStyles;

                    foreach (ColumnStyle column_style in column_styles)
                    {
                        column_style.SizeType = SizeType.Percent;
                        column_style.Width = ((float)100) / (Module_Register_Bit_Table_Layout.ColumnCount);
                    }

                    Module_Register_Bit_Position_Text_Box.Text = String.Empty;
                    Module_Register_Bit_Description_Text_Box.Text = String.Empty; 
                }

                Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
                return;
            }
        }

     

      

        private void Command_Mapper_Add_Command_Button_Click(object sender, EventArgs e)
        {
            //TextBox command_item = new TextBox();
            //command_item.Dock = DockStyle.Fill;
            //command_item.Text = "new command";
            //command_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            ////ToolTip bit_item_tooltip = new ToolTip();

            ////bit_item_tooltip.ToolTipIcon = ToolTipIcon.None;
            ////bit_item_tooltip.IsBalloon = false;
            ////bit_item_tooltip.ShowAlways = true;

            ////foreach (var value_description in bit.Value_Description)
            ////{
            ////    bit_value_tip_builder.AppendLine(Convert.ToString(value_description.configuration_value, 2) + "\t" + value_description.configuration_result);
            ////}

            ////bit_item_tooltip.SetToolTip(command_item, bit_value_tip_builder.ToString());

            //Command_Mapper_Table_Layout.Controls.Add(command_item, 0, Command_Mapper_Table_Layout.RowCount - 1);

            //if (Command_Mapper_Table_Layout.ColumnCount > 2)
            //{
            //    for (int col_index = 1; col_index <= (Command_Mapper_Table_Layout.ColumnCount-2); col_index++)
            //    {
            //        ComboBox functions_combo_box = new ComboBox();
            //        functions_combo_box.Items.Add("Select function");
            //        foreach (String current_function_name in Code_Automation_Panel.Functions_Name_List_All_Modules)
            //        {
            //            functions_combo_box.Items.Add(current_function_name);
            //        }
            //        functions_combo_box.SelectedIndex = 0;
            //        Command_Mapper_Table_Layout.Controls.Add(functions_combo_box, col_index, Command_Mapper_Table_Layout.RowCount - 1);        
            //    }
            //}


            //Command_Mapper_Table_Layout.RowCount = Command_Mapper_Table_Layout.RowCount + 1;
            //TableLayoutRowStyleCollection row_styles = Command_Mapper_Table_Layout.RowStyles;

            //int row_index = 0;
            //foreach (RowStyle row_style in row_styles)
            //{
            //    if (true)
            //    {
            //        row_style.SizeType = SizeType.Absolute;
            //        row_style.Height = 25;
            //    }
            //    //else
            //    //{
            //    //    row_style.SizeType = SizeType.Absolute;
            //    //    //row_style.Height = ((float)(Command_Mapper_Table_Layout.Height-20)) / (Command_Mapper_Table_Layout.RowCount);
            //    //    row_style.Height = 20;
            //    //}
            //    row_index++;
            //}

            this.Add_Command_Mapper_Module_Command("new_command");

        }

        private void Command_Mapper_Add_Module_Button_Click(object sender, EventArgs e)
        {
            TextBox module_item = new TextBox();
            module_item.Dock = DockStyle.Fill;
            module_item.Text = "new module";
            module_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            //ToolTip bit_item_tooltip = new ToolTip();

            //bit_item_tooltip.ToolTipIcon = ToolTipIcon.None;
            //bit_item_tooltip.IsBalloon = false;
            //bit_item_tooltip.ShowAlways = true;

            //foreach (var value_description in bit.Value_Description)
            //{
            //    bit_value_tip_builder.AppendLine(Convert.ToString(value_description.configuration_value, 2) + "\t" + value_description.configuration_result);
            //}

            //bit_item_tooltip.SetToolTip(command_item, bit_value_tip_builder.ToString());

            Command_Mapper_Table_Layout.Controls.Add(module_item, Command_Mapper_Table_Layout.ColumnCount - 1, 0);

            if (Command_Mapper_Table_Layout.RowCount > 2)
            {
                for (int row_index = 1; row_index <= (Command_Mapper_Table_Layout.RowCount - 2); row_index++)
                {
                    ComboBox functions_combo_box = new ComboBox();
                    functions_combo_box.Items.Add("Select function");
                    foreach (String current_function_name in DrvrCatCodeAutomationPanel.Functions_Name_List_All_Modules)
                    {
                        functions_combo_box.Items.Add(current_function_name);
                    }
                    functions_combo_box.SelectedIndex = 0;
                    Command_Mapper_Table_Layout.Controls.Add(functions_combo_box, Command_Mapper_Table_Layout.ColumnCount - 1 , row_index);
                }
            }


            Command_Mapper_Table_Layout.ColumnCount = Command_Mapper_Table_Layout.ColumnCount + 1;
            TableLayoutColumnStyleCollection col_styles = Command_Mapper_Table_Layout.ColumnStyles;

            int col_index = 0;
            foreach (ColumnStyle col_style in col_styles)
            {
                if (true)
                {
                    col_style.SizeType = SizeType.Absolute;
                    col_style.Width = 125;
                }
                //else
                //{
                //    col_style.SizeType = SizeType.Absolute;
                //    //row_style.Height = ((float)(Command_Mapper_Table_Layout.Height-20)) / (Command_Mapper_Table_Layout.RowCount);
                //    col_style.Width = 150;
                //}
                col_index++;
            }
        }

        private void Command_Mapper_Update_Functions_Button_Click(object sender, EventArgs e)
        {
            DrvrCatCodeAutomationPanel.Functions_List_All_Modules.Clear();
            DrvrCatCodeAutomationPanel.Functions_Name_List_All_Modules.Clear();

            foreach (DrvrCatModule current_module in DrvrCatCodeAutomationPanel.Panel_Modules_List)
            {
                //
                if (current_module.Resources[0].Register_Offsets != null)
                {
                    //FIX
                    foreach (DrvrCatRegister current_register in current_module.Resources[0].Register_Offsets)
                    {
                        if (current_register.Bits !=null)
                        {
                            foreach (DrvrCatRegisterBit current_register_bit in current_register.Bits)
                            {
                                if (current_register_bit.Functions_List !=null)
                                {
                                    foreach (DrvrCatFunction current_function in current_register_bit.Functions_List)
                                    {
                                        if (current_function.Parameters != null)
                                        {
                                            if (current_function.Parameters.Count == 2)
                                            {
                                                if (current_function.Parameters.ElementAt(0).data_type.Equals("pCommand_Header") && current_function.Parameters.ElementAt(1).data_type.Equals("unsigned int"))
                                                {
                                                    DrvrCatCodeAutomationPanel.Functions_List_All_Modules.Add(current_function);
                                                    DrvrCatCodeAutomationPanel.Functions_Name_List_All_Modules.Add(current_function.Function_Name);
                                                }
                                            }
                                        }
                                    } 
                                }
                            } 
                        }
                    } 
                }

                if (current_module.Module_functions_list !=null)
                {
                    foreach (DrvrCatFunction current_function in current_module.Module_functions_list)
                    {
                        if (current_function.Parameters != null)
                        {
                            if (current_function.Parameters.Count == 2)
                            {
                                if (current_function.Parameters.ElementAt(0).data_type.Equals("pCommand_Header") && current_function.Parameters.ElementAt(1).data_type.Equals("unsigned int"))
                                {
                                    DrvrCatCodeAutomationPanel.Functions_List_All_Modules.Add(current_function);
                                    DrvrCatCodeAutomationPanel.Functions_Name_List_All_Modules.Add(current_function.Function_Name);
                                }
                            } 
                        }
                    } 
                }

            }

            //for (int row_index = 1; row_index <= (Command_Mapper_Table_Layout.RowCount-2); row_index++)
            //{
            //    for (int col_index = 1; col_index <= (Command_Mapper_Table_Layout.ColumnCount-2); col_index++)
            //    {
                    
            //    }
            //}

            foreach (Control current_control in Command_Mapper_Table_Layout.Controls)
            {
                if(current_control is ComboBox)
                {
                    ComboBox current_combo_box = (ComboBox)current_control;

                    String selected_function = current_combo_box.GetItemText(current_combo_box.SelectedItem);
                    current_combo_box.Items.Clear();

                    current_combo_box.Items.Add("Select function");
                    int current_function_index = 0;

                    foreach (String current_function_name in DrvrCatCodeAutomationPanel.Functions_Name_List_All_Modules)
                    {
                        current_combo_box.Items.Add(current_function_name);
                        if(selected_function.CompareTo(current_function_name)==0)
                        {
                            current_function_index = current_combo_box.Items.Count -1;
                        }
                    }

                    current_combo_box.SelectedIndex = current_function_index;

                }
            }


            return;
        }

        private void command_mapper_update_LUT_button_Click(object sender, EventArgs e)
        {
            //String Module_Name = "CommandManager";
            //if (Code_Automation_Panel.Firmware_Modules_List!=null)
            //{
            //    for (int module_index = 0; module_index < Code_Automation_Panel.Firmware_Modules_List.Count; module_index++)
            //    {
            //        Firmware_Module current_module = Code_Automation_Panel.Firmware_Modules_List.ElementAt(module_index);
            //        if (current_module.Module_Name.Equals(Module_Name))
            //        {
            //            current_module = null;
            //            break;
            //        }
            //    } 
            //}

            //Firmware_Module command_manager_module = new Firmware_Module(Module_Name);

            //CodeBuilder command_manager_code_buidler = new CodeBuilder();
            

            //String command_response_data_type = "command_response";
            //String command_response_variable_name = Properties.Settings.Default.Project_Name.ToLower().Replace(" ", "_") + "_"+ command_response_data_type;

            //int number_of_commands = Command_Mapper_Table_Layout.RowCount - 2;
            //int number_of_modules = Command_Mapper_Table_Layout.ColumnCount - 2;

            
            //command_manager_code_buidler.AppendLine("#define TOTAL_COMMANDS " + number_of_commands.ToString());
            //command_manager_code_buidler.AppendLine("#define TOTAL_MODULES " + number_of_modules.ToString());

            //command_manager_code_buidler.AppendLine("");
            //command_manager_code_buidler.AppendLine("");

            //command_manager_code_buidler.AppendLine(command_response_data_type + " " + command_response_variable_name + "[" + "TOTAL_COMMANDS" + "]" + "[" + "TOTAL_MODULES" + "]" + "=" + "{ \\");
            //command_manager_code_buidler.Increase_Indent(2);

            //for (int row_index = 1; row_index <= number_of_commands; row_index++)
            //{
            //    command_manager_code_buidler.Append("{");

            //    for (int col_index = 1; col_index <= number_of_modules; col_index++)
            //    {
            //        Control current_control = Command_Mapper_Table_Layout.GetControlFromPosition(col_index, row_index);

            //        if(current_control is ComboBox)
            //        {
            //            ComboBox current_function_combo_box = (ComboBox)current_control;
            //            if(current_function_combo_box.SelectedIndex > 0)
            //            {
            //                command_manager_code_buidler.Append(current_function_combo_box.Items[current_function_combo_box.SelectedIndex].ToString());
            //            }
            //            else
            //            {
            //                command_manager_code_buidler.Append("NULL");
            //            }
            //        }
            //        else
            //        {
            //            command_manager_code_buidler.Append("NULL");
            //        }

            //        if (col_index != number_of_modules)
            //        {
            //            command_manager_code_buidler.Append(",");
            //        }
            //    }

            //    command_manager_code_buidler.AppendLine("}, \\");
            //}

            //command_manager_code_buidler.AddStatement("}");
            //command_manager_code_buidler.Decrease_Indent(2);

            //command_manager_module.Code = String.Copy(command_manager_code_buidler.GetCode());



            //Function command_decode_function = new Function();

            //command_decode_function.Function_Name = Properties.Settings.Default.Project_Name.Trim().Replace(" ", "_").ToLower() + "_" + "command_decoder";
            //command_decode_function.Function_Description = "Decodes the packets and calls respective modules API from Command LUT";
            //command_decode_function.return_item.Function_Return_type = "hepta_status";
            //command_decode_function.return_item.Return_Description = "Function will return the status of command decoding and execution";
            //command_decode_function.return_item.return_values = new List<Function_Return_Value>();

            //Function_Return_Value success_return = new Function_Return_Value();
            //success_return.Return_Value = "HEPTA_SUCCESS";
            //success_return.Return_Context = "If command received is correct and executed successfully";

            //command_decode_function.return_item.return_values.Add(success_return);

            //Function_Return_Value failure_return = new Function_Return_Value();
            //failure_return.Return_Value = "HEPTA_FAILURE";
            //failure_return.Return_Context = "If command received is incorrect";

            //command_decode_function.return_item.return_values.Add(failure_return);


            //command_decode_function.Module_Index = 0;
            //command_decode_function.Module_Name = String.Copy(command_manager_module.Module_Name);


            //command_decode_function.Parameters = new List<Function_Parameter>();

            //Function_Parameter cmdhandler_param = new Function_Parameter();
            //cmdhandler_param.data_type = String.Copy("phepta_cmd_pck_header");
            //cmdhandler_param.parameter_description = String.Copy("Command packet");
            //cmdhandler_param.parameter_name = String.Copy("pCmdHeader");
            //command_decode_function.Parameters.Add(cmdhandler_param);

            //Function_Parameter packet_id_param = new Function_Parameter();
            //packet_id_param.data_type = String.Copy("hepta_u16");
            //packet_id_param.parameter_description = String.Copy("Command packet id");
            //packet_id_param.parameter_name = String.Copy("packet_id");
            //command_decode_function.Parameters.Add(packet_id_param);


            //Function_Parameter transport_layer_header_param = new Function_Parameter();
            //transport_layer_header_param.data_type = String.Copy("phepta_transport_pck_header *");
            //transport_layer_header_param.parameter_description = String.Copy("Pointer to the transport layer command header");
            //transport_layer_header_param.parameter_name = String.Copy("ptr_pRdWrTcpPacket");
            //command_decode_function.Parameters.Add(transport_layer_header_param);



            //CodeBuilder command_manager_function_buidler = new CodeBuilder();
            //command_manager_function_buidler.AddStatement("command_response current_command = NULL");
            
            //command_manager_function_buidler.AppendLine("if((pCmdHeader->packet_type < TOTAL_COMMANDS) && (pCmdHeader->module_type < TOTAL_MODULES))");

            //command_manager_function_buidler.Start_Block();

            //command_manager_function_buidler.AddStatement("current_command = " + command_response_variable_name + "[pCmdHeader->packet_type][pCmdHeader->module_type]");
            
            //command_manager_function_buidler.End_Block();

            //command_manager_function_buidler.AppendLine("if(current_command != NULL)");

            //command_manager_function_buidler.Start_Block();

            //command_manager_function_buidler.AddStatement("current_command(pCmdHeader,packet_id)");
            //command_manager_function_buidler.AddStatement("return HEPTA_SUCCESS");

            //command_manager_function_buidler.End_Block();


            //command_manager_function_buidler.AppendLine("else");

            //command_manager_function_buidler.Start_Block();

            //command_manager_function_buidler.AddStatement("return HEPTA_FAILURE");

            //command_manager_function_buidler.End_Block();




            //command_decode_function.Function_Statements = String.Copy(command_manager_function_buidler.GetCode());

            



            //CodeBuilder function_code_builder = new CodeBuilder();
            //function_code_builder.Define_Function_Code(command_decode_function);

            //command_decode_function.Code = String.Copy(function_code_builder.GetCode());

            //command_manager_module.Module_functions_list.Add(command_decode_function);


            //Code_Automation_Panel.Firmware_Modules_List.Add(command_manager_module);

            Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;

            command_mapper_update_firmware_module();

            Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
        }

        private void Add_Modules_List_Button_Click(object sender, EventArgs e)
        {
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;

            if (String.IsNullOrEmpty(FID_path_text.Text))
            {
                MessageBox.Show("Choose FID path");
                Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
                return;
            }


            DrvrCatExcelResourceTable Current_Sheet_Extract = new DrvrCatExcelResourceTable();
            String Table_Name;
            String Selected_Module_Name;

            DrvrCatModule Current_Module_RegMap = null;


            FID_Sheet_Module_Names.Items.Clear();
            FID_Sheet_Module_Names.Items.Add("---Select Module---");


            int selected_module_index = 0;

            DrvrCatCodeAutomationPanel.Panel_Modules_List.Clear();
            this.Reset_Commands_Table_Layout();


            this.Add_Command_Mapper_Module_Command("set");
            this.Add_Command_Mapper_Module_Command("get");
            this.Add_Command_Mapper_Module_Command("config");
            this.Add_Command_Mapper_Module_Command("service");



            for (int list_index = 0; list_index < FID_Parse_Modules_List.Items.Count; list_index++) 
            {
                 CheckState st = FID_Parse_Modules_List.GetItemCheckState(list_index);//(FID_Parse_Modules_List.Items.IndexOf(i));
                 if (st == CheckState.Checked)
                 {
                     Current_Module_RegMap = this.Get_Module_RegMap_from_Sheet((String)FID_Parse_Modules_List.Items[list_index], selected_module_index);

                     if (Current_Module_RegMap != null)
                     {
                         DrvrCatCodeAutomationPanel.Panel_Modules_List.Add(Current_Module_RegMap);
                         selected_module_index = selected_module_index + 1;
                         List<ComboBox> combo_box_list = this.Add_Command_Mapper_Module(Current_Module_RegMap.Module_Name.Trim().Replace(" ", "_").ToLower());

                         for (int combo_index = 0; combo_index < combo_box_list.Count; combo_index++)
                         {
                             ComboBox current_combo_box = combo_box_list.ElementAt(combo_index);
                             ComboBox.ObjectCollection current_list = current_combo_box.Items;
                             String function_name = null;

                             switch (combo_index)
                             {
                                 case 0:
                                     function_name = Properties.Settings.Default.Project_Name + "_" + Current_Module_RegMap.Module_Name.ToLower().Trim() + "_" + "reg_write";
                                     break;
                                 case 1:
                                     function_name = Properties.Settings.Default.Project_Name + "_" + Current_Module_RegMap.Module_Name.ToLower().Trim() + "_" + "reg_read";
                                     break;
                                 case 2:
                                     function_name = Properties.Settings.Default.Project_Name + "_" + Current_Module_RegMap.Module_Name.ToLower().Trim() + "_" + "config";
                                     break;
                                 case 3:
                                     function_name = Properties.Settings.Default.Project_Name + "_" + Current_Module_RegMap.Module_Name.ToLower().Trim() + "_" + "service";
                                     break;
                                 default:
                                     break;
                             }

                             if (function_name != null)
                             {
                                 int function_name_index = current_list.IndexOf(function_name);
                                 if (function_name_index >= 0)
                                 {
                                     current_combo_box.SelectedIndex = function_name_index;
                                 }

                                 //current_combo_box.SelectedText = function_name;
                             }
                         }

                         FID_Sheet_Module_Names.Items.Add(FID_Parse_Modules_List.Items[list_index]);
                     }
                     
                 }
            }

            this.command_mapper_update_firmware_module();

            FID_Sheet_Module_Names.SelectedIndex = 0;
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
        }

        private void command_mapper_update_firmware_module()
        {
            String Module_Name = "CommandManager";
            if (DrvrCatCodeAutomationPanel.Firmware_Modules_List != null)
            {
                for (int module_index = 0; module_index < DrvrCatCodeAutomationPanel.Firmware_Modules_List.Count; module_index++)
                {
                    DrvrCatFirmwareModule current_module = DrvrCatCodeAutomationPanel.Firmware_Modules_List.ElementAt(module_index);
                    if (current_module.Module_Name.Equals(Module_Name))
                    {
                        DrvrCatCodeAutomationPanel.Firmware_Modules_List.RemoveAt(module_index);
                        current_module = null;
                        break;
                    }
                }
            }

            DrvrCatFirmwareModule command_manager_module = new DrvrCatFirmwareModule(Module_Name);

            DrvrCatCodeBuilder command_manager_code_buidler = new DrvrCatCodeBuilder();


            String command_response_data_type = "command_response";
            String command_response_variable_name = Properties.Settings.Default.Project_Name.ToLower().Replace(" ", "_") + "_" + command_response_data_type;

            int number_of_commands = Command_Mapper_Table_Layout.RowCount - 2;
            int number_of_modules = Command_Mapper_Table_Layout.ColumnCount - 2;


            command_manager_code_buidler.AppendLine("#define TOTAL_COMMANDS " + number_of_commands.ToString());
            command_manager_code_buidler.AppendLine("#define TOTAL_MODULES " + number_of_modules.ToString());

            command_manager_code_buidler.AppendLine("");
            command_manager_code_buidler.AppendLine("");

            command_manager_code_buidler.AppendLine(command_response_data_type + " " + command_response_variable_name + "[" + "TOTAL_COMMANDS" + "]" + "[" + "TOTAL_MODULES" + "]" + "=" + "{ \\");
            command_manager_code_buidler.Increase_Indent(2);

            for (int row_index = 1; row_index <= number_of_commands; row_index++)
            {
                command_manager_code_buidler.Append("{");

                for (int col_index = 1; col_index <= number_of_modules; col_index++)
                {
                    Control current_control = Command_Mapper_Table_Layout.GetControlFromPosition(col_index, row_index);

                    if (current_control is ComboBox)
                    {
                        ComboBox current_function_combo_box = (ComboBox)current_control;
                        if (current_function_combo_box.SelectedIndex > 0)
                        {
                            command_manager_code_buidler.Append(current_function_combo_box.Items[current_function_combo_box.SelectedIndex].ToString());
                        }
                        else
                        {
                            command_manager_code_buidler.Append("NULL");
                        }
                    }
                    else
                    {
                        command_manager_code_buidler.Append("NULL");
                    }

                    if (col_index != number_of_modules)
                    {
                        command_manager_code_buidler.Append(",");
                    }
                }

                command_manager_code_buidler.AppendLine("}, \\");
            }

            command_manager_code_buidler.AddStatement("}");
            command_manager_code_buidler.Decrease_Indent(2);

            command_manager_module.Code = String.Copy(command_manager_code_buidler.GetCode());



            DrvrCatFunction command_decode_function = new DrvrCatFunction();

            command_decode_function.Function_Name = Properties.Settings.Default.Project_Name.Trim().Replace(" ","_").ToLower() + "_" + "command_decoder";
            command_decode_function.Function_Description = "Decodes the packets and calls respective modules API from Command LUT";
            command_decode_function.return_item.Function_Return_type = "int";
            command_decode_function.return_item.Return_Description = "Function will return the status of command decoding and execution";
            command_decode_function.return_item.return_values = new List<DrvrCatFunctionReturnValue>();

            DrvrCatFunctionReturnValue success_return = new DrvrCatFunctionReturnValue();
            success_return.Return_Value = "0";
            success_return.Return_Context = "If command received is correct and executed successfully";

            command_decode_function.return_item.return_values.Add(success_return);

            DrvrCatFunctionReturnValue failure_return = new DrvrCatFunctionReturnValue();
            failure_return.Return_Value = "-1";
            failure_return.Return_Context = "If command received is incorrect";

            command_decode_function.return_item.return_values.Add(failure_return);


            command_decode_function.Module_Index = 0;
            command_decode_function.Module_Name = String.Copy(command_manager_module.Module_Name);


            command_decode_function.Parameters = new List<DrvrCatFunctionParameter>();

            DrvrCatFunctionParameter cmdhandler_param = new DrvrCatFunctionParameter();
            cmdhandler_param.data_type = String.Copy("pCommand_Header");
            cmdhandler_param.parameter_description = String.Copy("Command packet");
            cmdhandler_param.parameter_name = String.Copy("pCmdHeader");
            command_decode_function.Parameters.Add(cmdhandler_param);

            DrvrCatFunctionParameter packet_id_param = new DrvrCatFunctionParameter();
            packet_id_param.data_type = String.Copy("unsigned int");
            packet_id_param.parameter_description = String.Copy("Command packet id");
            packet_id_param.parameter_name = String.Copy("packet_id");
            command_decode_function.Parameters.Add(packet_id_param);


            //Function_Parameter transport_layer_header_param = new Function_Parameter();
            //transport_layer_header_param.data_type = String.Copy("phepta_transport_pck_header *");
            //transport_layer_header_param.parameter_description = String.Copy("Pointer to the transport layer command header");
            //transport_layer_header_param.parameter_name = String.Copy("ptr_pRdWrTcpPacket");
            //command_decode_function.Parameters.Add(transport_layer_header_param);



            DrvrCatCodeBuilder command_manager_function_buidler = new DrvrCatCodeBuilder();
            command_manager_function_buidler.AddStatement("command_response current_command = NULL");

            command_manager_function_buidler.AppendLine("if((pCmdHeader->Operation_Type < TOTAL_COMMANDS) && (pCmdHeader->Module_Index < TOTAL_MODULES))");

            command_manager_function_buidler.Start_Block();

            command_manager_function_buidler.AddStatement("current_command = " + command_response_variable_name + "[pCmdHeader->Operation_Type][pCmdHeader->Module_Index]");

            command_manager_function_buidler.End_Block();

            command_manager_function_buidler.AppendLine("if(current_command != NULL)");

            command_manager_function_buidler.Start_Block();

            command_manager_function_buidler.AddStatement("current_command(pCmdHeader,packet_id)");
            command_manager_function_buidler.AddStatement("return 0");

            command_manager_function_buidler.End_Block();


            command_manager_function_buidler.AppendLine("else");

            command_manager_function_buidler.Start_Block();

            command_manager_function_buidler.AddStatement("return -1");

            command_manager_function_buidler.End_Block();




            command_decode_function.Function_Statements = String.Copy(command_manager_function_buidler.GetCode());





            DrvrCatCodeBuilder function_code_builder = new DrvrCatCodeBuilder();
            function_code_builder.Define_Function_Code(command_decode_function, "CommandManager");

            command_decode_function.Code = String.Copy(function_code_builder.GetCode());

            command_manager_module.Module_functions_list.Add(command_decode_function);


            DrvrCatCodeAutomationPanel.Firmware_Modules_List.Add(command_manager_module);
        }

        private DrvrCatModule Get_Module_RegMap_from_Sheet(String Module_Name, int selected_module_index)
        {
            String Selected_Module_Name;
            DrvrCatModule Current_Module_RegMap = null;

            Excel.Workbook xlWorkbook = xlopened_book;
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[Module_Name];
            MODULE_NAME = xlWorksheet.Name.ToString();
            Selected_Module_Name = xlWorksheet.Name.ToString();

            Current_Module_RegMap = new DrvrCatModule(selected_module_index, Selected_Module_Name);

            Excel.Range xlRange = xlWorksheet.UsedRange;
            Excel.ListObjects xlListObjects = xlWorksheet.ListObjects;

            int table_index = 0;
            foreach (Excel.ListObject current_list_object in xlListObjects)
            {
                String Table_Name,Resource_Name;
                DrvrCatExcelResourceTable Current_Sheet_Extract = new DrvrCatExcelResourceTable();

                Table_Name = current_list_object.DisplayName;
                Resource_Name = String.Copy(Table_Name);

                Resource_Name = Resource_Name.Replace(Selected_Module_Name + "_", "");

                
                DrvrCatModuleResource current_resource = new DrvrCatModuleResource(Resource_Name, table_index,Selected_Module_Name, selected_module_index);
                for (int Column_index = 0; Column_index < DrvrCatWorkSheetManager.Column_Heading_List.Count; Column_index++)
                {
                    String Column_Heading = DrvrCatWorkSheetManager.Column_Heading_List.ElementAt(Column_index);
                    switch (Column_index)
                    {
                        case 0:
                            Current_Sheet_Extract.Add_Register_Name_List(DrvrCatWorkSheetManager.Get_List_by_Table_Column_Heading(xlWorksheet, Table_Name, Column_Heading));
                            break;

                        case 1:
                            Current_Sheet_Extract.Add_Register_Address_List(DrvrCatWorkSheetManager.Get_List_by_Table_Column_Heading(xlWorksheet, Table_Name, Column_Heading));
                            break;

                        case 2:
                            Current_Sheet_Extract.Add_Register_Size_List(DrvrCatWorkSheetManager.Get_List_by_Table_Column_Heading(xlWorksheet, Table_Name, Column_Heading));
                            break;

                        case 3:
                            Current_Sheet_Extract.Add_Power_On_Rest_Value_List(DrvrCatWorkSheetManager.Get_List_by_Table_Column_Heading(xlWorksheet, Table_Name, Column_Heading));
                            break;

                        default:
                            break;
                    }
                }

                Current_Sheet_Extract.Add_Bit_definition_Range_List(DrvrCatWorkSheetManager.Get_Bit_Def_Range_List_from_Table(xlWorksheet, Table_Name));
                current_resource.Define_Register_Map_Struct(Current_Sheet_Extract);
                Current_Module_RegMap.Resources.Add(current_resource);
                table_index++;
            }

            Current_Module_RegMap.Module_functions_list = new List<DrvrCatFunction>();
            Current_Module_RegMap.Define_Register_Read_Function();
            Current_Module_RegMap.Define_Register_Write_Function();
            Current_Module_RegMap.Define_Config_Function();
            Current_Module_RegMap.Define_Service_Function();

            //Current_Module_RegMap.Define_Register_Read_API_Function();
            //Current_Module_RegMap.Define_Register_Write_API_Function();
            return Current_Module_RegMap;
        }

        private void Add_Command_Mapper_Module_Command(string Command_Name)
        {
            TextBox command_item = new TextBox();
            command_item.Dock = DockStyle.Fill;
            command_item.Text = String.Copy(Command_Name);
            command_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            //ToolTip bit_item_tooltip = new ToolTip();

            //bit_item_tooltip.ToolTipIcon = ToolTipIcon.None;
            //bit_item_tooltip.IsBalloon = false;
            //bit_item_tooltip.ShowAlways = true;

            //foreach (var value_description in bit.Value_Description)
            //{
            //    bit_value_tip_builder.AppendLine(Convert.ToString(value_description.configuration_value, 2) + "\t" + value_description.configuration_result);
            //}

            //bit_item_tooltip.SetToolTip(command_item, bit_value_tip_builder.ToString());

            Command_Mapper_Table_Layout.Controls.Add(command_item, 0, Command_Mapper_Table_Layout.RowCount - 1);

            if (Command_Mapper_Table_Layout.ColumnCount > 2)
            {
                for (int col_index = 1; col_index <= (Command_Mapper_Table_Layout.ColumnCount - 2); col_index++)
                {
                    ComboBox functions_combo_box = new ComboBox();
                    functions_combo_box.Items.Add("Select function");
                    foreach (String current_function_name in DrvrCatCodeAutomationPanel.Functions_Name_List_All_Modules)
                    {
                        functions_combo_box.Items.Add(current_function_name);
                    }
                    functions_combo_box.SelectedIndex = 0;
                    Command_Mapper_Table_Layout.Controls.Add(functions_combo_box, col_index, Command_Mapper_Table_Layout.RowCount - 1);
                }
            }


            Command_Mapper_Table_Layout.RowCount = Command_Mapper_Table_Layout.RowCount + 1;
            TableLayoutRowStyleCollection row_styles = Command_Mapper_Table_Layout.RowStyles;

            int row_index = 0;
            foreach (RowStyle row_style in row_styles)
            {
                if (true)
                {
                    row_style.SizeType = SizeType.Absolute;
                    row_style.Height = 25;
                }
                //else
                //{
                //    row_style.SizeType = SizeType.Absolute;
                //    //row_style.Height = ((float)(Command_Mapper_Table_Layout.Height-20)) / (Command_Mapper_Table_Layout.RowCount);
                //    row_style.Height = 20;
                //}
                row_index++;
            }
        }

        private List<ComboBox> Add_Command_Mapper_Module(string Module_Name)
        {
            List<ComboBox> combo_box_list = new List<ComboBox>();
            TextBox module_item = new TextBox();
            module_item.Dock = DockStyle.Fill;
            module_item.Text = String.Copy(Module_Name);
            module_item.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;

            //ToolTip bit_item_tooltip = new ToolTip();

            //bit_item_tooltip.ToolTipIcon = ToolTipIcon.None;
            //bit_item_tooltip.IsBalloon = false;
            //bit_item_tooltip.ShowAlways = true;

            //foreach (var value_description in bit.Value_Description)
            //{
            //    bit_value_tip_builder.AppendLine(Convert.ToString(value_description.configuration_value, 2) + "\t" + value_description.configuration_result);
            //}

            //bit_item_tooltip.SetToolTip(command_item, bit_value_tip_builder.ToString());

            Command_Mapper_Table_Layout.Controls.Add(module_item, Command_Mapper_Table_Layout.ColumnCount - 1, 0);

            if (Command_Mapper_Table_Layout.RowCount > 2)
            {
                for (int row_index = 1; row_index <= (Command_Mapper_Table_Layout.RowCount - 2); row_index++)
                {
                    ComboBox functions_combo_box = new ComboBox();
                    functions_combo_box.Items.Add("Select function");
                    foreach (String current_function_name in DrvrCatCodeAutomationPanel.Functions_Name_List_All_Modules)
                    {
                        functions_combo_box.Items.Add(current_function_name);
                    }
                    functions_combo_box.SelectedIndex = 0;
                    Command_Mapper_Table_Layout.Controls.Add(functions_combo_box, Command_Mapper_Table_Layout.ColumnCount - 1, row_index);
                    combo_box_list.Add(functions_combo_box);
                }
            }


            Command_Mapper_Table_Layout.ColumnCount = Command_Mapper_Table_Layout.ColumnCount + 1;
            TableLayoutColumnStyleCollection col_styles = Command_Mapper_Table_Layout.ColumnStyles;

            int col_index = 0;
            foreach (ColumnStyle col_style in col_styles)
            {
                if (true)
                {
                    col_style.SizeType = SizeType.Absolute;
                    col_style.Width = 125;
                }
                //else
                //{
                //    col_style.SizeType = SizeType.Absolute;
                //    //row_style.Height = ((float)(Command_Mapper_Table_Layout.Height-20)) / (Command_Mapper_Table_Layout.RowCount);
                //    col_style.Width = 150;
                //}
                col_index++;
            }

            return combo_box_list;
        }

        private void Reset_Commands_Table_Layout()
        {
            this.Command_Mapper_Table_Layout.Controls.Clear();
            this.Command_Mapper_Table_Layout.RowStyles.Clear();
            this.Command_Mapper_Table_Layout.AutoScroll = true;
            this.Command_Mapper_Table_Layout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.Command_Mapper_Table_Layout.ColumnCount = 2;
            this.Command_Mapper_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.Command_Mapper_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 748F));
            this.Command_Mapper_Table_Layout.Controls.Add(this.label18, 0, 0);
            this.Command_Mapper_Table_Layout.Location = new System.Drawing.Point(8, 6);
            this.Command_Mapper_Table_Layout.Name = "Command_Mapper_Table_Layout";
            this.Command_Mapper_Table_Layout.RowCount = 2;
            this.Command_Mapper_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.Command_Mapper_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Command_Mapper_Table_Layout.Size = new System.Drawing.Size(867, 320);
            this.Command_Mapper_Table_Layout.TabIndex = 0;
            return;
        }

        private void Command_Mapper_Clear_Table_Button_Click(object sender, EventArgs e)
        {
            this.Reset_Commands_Table_Layout();
        }

        private void Module_Function_Filter_by_Register_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;

            Module_Function_List_Box_Filter_by_Register_bit.Enabled = true;
            Module_Function_Filter_by_Register_Bit_Combobox.Items.Clear();
            Module_Function_Filter_by_Register_Bit_Combobox.Enabled = false;
            Module_Function_List_Box_Filter_by_Register_bit.Checked = false;
            List<DrvrCatFunction> Module_Functions_List_Box_Functions_List = (List<DrvrCatFunction>)Module_Functions_List_Box.Tag;

            //ComboBox Module_Function_Filter_by_Register_Combobox = (ComboBox)sender;
            DrvrCatRegister selected_register = null;

            //Module_RegMap Selected_Module_Regmap = Code_Automation_Panel.Get_ModuleRegmap_by_Module_Index(Module_Registers_List_Box.SelectedIndex);
            DrvrCatModule Selected_Module_Regmap = DrvrCatCodeAutomationPanel.Selected_Module_Regmap;

            //FIX
            selected_register = Selected_Module_Regmap.Resources[0].Register_Offsets.ElementAt(Module_Function_Filter_by_Register_Combobox.SelectedIndex);
            //Code_Automation_Panel.Selected_Register = selected_register;

            List<DrvrCatRegisterBit> register_bits = selected_register.Bits;
            Module_Functions_List_Box_Functions_List.Clear();

            if (register_bits!=null)
            {
                Module_Function_Filter_by_Register_Bit_Combobox.Items.Clear();
                foreach (DrvrCatRegisterBit bit in register_bits)
                {
                    if (bit!=null)
                    {
                        Module_Function_Filter_by_Register_Bit_Combobox.Items.Add(bit.Bit_Name);
                        if (bit.Functions_List != null)
                        {
                            Module_Functions_List_Box_Functions_List.AddRange(bit.Functions_List);
                        }
                    }
                } 
            }



    



            //String selected_regsiter_name = Module_Function_Filter_by_Register_Combobox.GetItemText(Module_Function_Filter_by_Register_Combobox.SelectedItem);

            

            //foreach (Register Register in Current_Module_RegMap.Register_Offsets)
            //{
            //    if (Register.Register_Name.Equals(selected_regsiter_name))
            //    {
            //        if (Register.Bits != null)
            //        {
            //            foreach (Register_Bit current_bit in Register.Bits)
            //            {
            //                if (current_bit.Functions_List != null)
            //                {
            //                    Module_Functions_List_Box_Functions_List.AddRange(current_bit.Functions_List);
            //                }
            //            }
            //        }
            //    }
            //}
            Module_Functions_List_Box_Update_Functions_List(Module_Functions_List_Box_Functions_List);
















            
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
            return;
        }

        private void Module_Function_Filter_by_Register_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;

            List<DrvrCatFunction> Module_Functions_List_Box_Functions_List = (List<DrvrCatFunction>)Module_Functions_List_Box.Tag;
            DrvrCatModule Current_Module_RegMap = DrvrCatCodeAutomationPanel.Selected_Module_Regmap;


            if(Module_Function_Filter_by_Register_Checkbox.Checked)
            {
                
                Module_Function_Filter_by_Register_Combobox.SelectedIndex = 0;
                Module_Function_Filter_by_Register_Combobox.Enabled = true;

                Module_Function_Filter_by_Register_Combobox_SelectedIndexChanged(Module_Function_Filter_by_Register_Combobox, null);

                Module_Function_List_Box_Filter_by_Register_bit.Enabled = true;
                Module_Function_Filter_by_Register_Bit_Combobox.Enabled = false;
                ////Module_Function_Filter_by_Register_Bit_Combobox.Items.Clear();
                Module_Function_List_Box_Filter_by_Register_bit.Checked = false;

                


                //String selected_regsiter_name = Module_Function_Filter_by_Register_Combobox.GetItemText(Module_Function_Filter_by_Register_Combobox.SelectedItem);

                //Module_Functions_List_Box_Functions_List.Clear();

                //foreach (Register Register in Current_Module_RegMap.Register_Offsets)
                //{
                //    if (Register.Register_Name.Equals(selected_regsiter_name))
                //    {
                //        if (Register.Bits != null)
                //        {
                //            foreach (Register_Bit current_bit in Register.Bits)
                //            {
                //                if (current_bit.Functions_List != null)
                //                {
                //                    Module_Functions_List_Box_Functions_List.AddRange(current_bit.Functions_List);
                //                }
                //            }
                //        }
                //    }
                //}
                //Module_Functions_List_Box_Update_Functions_List(Module_Functions_List_Box_Functions_List);


            }
            else
            {
                Module_Function_Filter_by_Register_Combobox.Enabled = false;
                //Module_Function_Filter_by_Register_Combobox.Items.Clear();
                Module_Function_List_Box_Filter_by_Register_bit.Enabled = false;
                Module_Function_Filter_by_Register_Bit_Combobox.Enabled = false;
                Module_Function_Filter_by_Register_Bit_Combobox.Items.Clear();
                Module_Function_List_Box_Filter_by_Register_bit.Checked = false;





                Module_Functions_List_Box_Functions_List.Clear();

                //FIX
                foreach (DrvrCatRegister Register in Current_Module_RegMap.Resources[0].Register_Offsets)
                {
                    if (Register.Bits != null)
                    {
                        foreach (DrvrCatRegisterBit current_bit in Register.Bits)
                        {
                            if (current_bit.Functions_List != null)
                            {
                                Module_Functions_List_Box_Functions_List.AddRange(current_bit.Functions_List);
                            }
                        }
                    }
                }
                Module_Functions_List_Box_Functions_List.AddRange(Current_Module_RegMap.Module_functions_list);

                Module_Functions_List_Box_Update_Functions_List(Module_Functions_List_Box_Functions_List);

            }

            Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
        }

        private void Module_Function_List_Box_Filter_by_Register_bit_CheckedChanged(object sender, EventArgs e)
        {
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;

            List<DrvrCatFunction> Module_Functions_List_Box_Functions_List = (List<DrvrCatFunction>)Module_Functions_List_Box.Tag;
            DrvrCatModule Current_Module_RegMap = DrvrCatCodeAutomationPanel.Selected_Module_Regmap;


            if (Module_Function_List_Box_Filter_by_Register_bit.Checked)
            {

                Module_Function_Filter_by_Register_Bit_Combobox.SelectedIndex = 0;
                Module_Function_Filter_by_Register_Bit_Combobox.Enabled = true;

                Module_Function_Filter_by_Register_Bit_Combobox_SelectedIndexChanged(Module_Function_Filter_by_Register_Combobox, null);

            }
            else
            {
                Module_Function_Filter_by_Register_Bit_Combobox.Enabled = false;
                //Module_Function_Filter_by_Register_Bit_Combobox.SelectedIndex = 0;
                //Module_Function_Filter_by_Register_Bit_Combobox.Items.Clear();
                Module_Function_Filter_by_Register_Combobox_SelectedIndexChanged(Module_Function_Filter_by_Register_Combobox, null);
            }

            Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
        }

        private void Module_Function_Filter_by_Register_Bit_Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form_Status_Label.Text = Properties.Resources.Status_Bar_Busy;

            List<DrvrCatFunction> Module_Functions_List_Box_Functions_List = (List<DrvrCatFunction>)Module_Functions_List_Box.Tag;

            //ComboBox Module_Function_Filter_by_Register_Combobox = (ComboBox)sender;
            DrvrCatRegister selected_register = null;
            DrvrCatRegisterBit selected_register_bit = null;


            //Module_RegMap Selected_Module_Regmap = Code_Automation_Panel.Get_ModuleRegmap_by_Module_Index(Module_Registers_List_Box.SelectedIndex);
            DrvrCatModule Selected_Module_Regmap = DrvrCatCodeAutomationPanel.Selected_Module_Regmap;

            //FIX
            selected_register = Selected_Module_Regmap.Resources[0].Register_Offsets.ElementAt(Module_Function_Filter_by_Register_Combobox.SelectedIndex);
            //Code_Automation_Panel.Selected_Register = selected_register;

            List<DrvrCatRegisterBit> register_bits = selected_register.Bits;

            selected_register_bit = register_bits.ElementAt(Module_Function_Filter_by_Register_Bit_Combobox.SelectedIndex);

            Module_Functions_List_Box_Functions_List.Clear();

            if (selected_register_bit != null)
            {
                if (selected_register_bit.Functions_List != null)
                {
                    Module_Functions_List_Box_Functions_List.AddRange(selected_register_bit.Functions_List);
                }
            }

            Module_Functions_List_Box_Update_Functions_List(Module_Functions_List_Box_Functions_List);


            Form_Status_Label.Text = Properties.Resources.Status_Bar_Ready;
            return;
        }

        private void Functions_Tab_Create_Function_Button_Click(object sender, EventArgs e)
        {
            List<String> Modules_Name_List = new List<String>();


            foreach (DrvrCatModule current_module in DrvrCatCodeAutomationPanel.Panel_Modules_List)
            {
                Modules_Name_List.Add(current_module.Module_Name);
            }

            foreach (DrvrCatFirmwareModule current_module in DrvrCatCodeAutomationPanel.Firmware_Modules_List)
            {
                Modules_Name_List.Add(current_module.Module_Name);
            }


            DrvrCatCreateFunctionForm create_function_form = new DrvrCatCreateFunctionForm(Modules_Name_List);

            if (create_function_form.ShowDialog(this) == DialogResult.OK)
            {
                DrvrCatFunction created_function = create_function_form.created_function;

                foreach (DrvrCatModule current_module in DrvrCatCodeAutomationPanel.Panel_Modules_List)
                {
                    if(created_function.Module_Name.CompareTo(current_module.Module_Name)==0)
                    {
                        current_module.Module_functions_list.Add(created_function);
                        return;
                    }
                }

                foreach (DrvrCatFirmwareModule current_module in DrvrCatCodeAutomationPanel.Firmware_Modules_List)
                {
                    if (created_function.Module_Name.CompareTo(current_module.Module_Name) == 0)
                    {
                        current_module.Module_functions_list.Add(created_function);
                        return;
                    }
                }
            }

        }

        private void Packet_Header_TableLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Packet_Fields_MouseDown(object sender, MouseEventArgs e)
        {
            Label selected_component = (Label)sender;
            int selected_position = Packet_Header_TableLayoutPanel.GetColumn(selected_component);

            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if ((selected_component == Packet_Header_String_Label) || (selected_component == Packet_Id_Label) || (selected_component == Packet_Length_Label))
                {
                    Packet_Remove_Context_Button.Enabled = false;
                }
                else
                {
                    Packet_Remove_Context_Button.Enabled = true;
                }

                Packet_Fields_Configure_Context_Menu.Show(selected_component,e.X,e.Y);
                return;
            }

            if (selected_component == Packet_Header_String_Label)
            {
                return;
            }


            selected_component.BorderStyle = BorderStyle.FixedSingle;
            selected_component.DoDragDrop(selected_position.ToString(), DragDropEffects.Copy | DragDropEffects.Move);
            //MessageBox.Show("Drag "+  Packet_Header_TableLayoutPanel.GetColumn(selected_component).ToString());
        }

        private void Packet_Header_TableLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            String Selected_Component_Index_String = e.Data.GetData(DataFormats.Text).ToString();
            int Selected_Component_Index = Convert.ToInt32(Selected_Component_Index_String);
            Control selected_control = Packet_Header_TableLayoutPanel.GetControlFromPosition(Selected_Component_Index, 0);
            ((Label)selected_control).BorderStyle = BorderStyle.None;


            Point parent_location_on_screen = Packet_Header_TableLayoutPanel.PointToScreen(Point.Empty);
            Control destination_control = Packet_Header_TableLayoutPanel.GetChildAtPoint(new Point(e.X - parent_location_on_screen.X, e.Y - parent_location_on_screen.Y));

            
            if (destination_control != null)
            {
                if(destination_control == Packet_Header_String_Label)
                {
                    MessageBox.Show("Header String should not be shifted for memory efficiency", "Incorrect Shifting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int Destination_Component_Index = Packet_Header_TableLayoutPanel.GetColumn(destination_control);
                Packet_Header_TableLayoutPanel.SetCellPosition(destination_control, new TableLayoutPanelCellPosition(Selected_Component_Index, 0));
                Packet_Header_TableLayoutPanel.SetCellPosition(selected_control, new TableLayoutPanelCellPosition(Destination_Component_Index, 0));
               // MessageBox.Show("Drop " + Packet_Header_TableLayoutPanel.GetColumn(destination_control).ToString());
                Refresh_Packet_Header_Fields();
            }
            else
            {
                MessageBox.Show("Dropped at border of a Cell. Place it over any cell", "Incorrect Shifting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Configure_Context_Button_Click(object sender, EventArgs e)
        {

            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    // Get the control that is displaying this context menu
                    Label selected_component = (Label)owner.SourceControl;
                    bool packet_field_changes_done = false;

                    if (selected_component != null)
                    {
                        if(selected_component == Packet_Header_String_Label)
                        {
                            packet_field_changes_done = Packet_Header_String_Label_Configure_Function();
                        }
                        else if(selected_component == Packet_Id_Label)
                        {
                            packet_field_changes_done = Packet_ID_Label_Configure_Function();
                        }
                        else if(selected_component == Packet_Length_Label)
                        {
                            packet_field_changes_done = Packet_Length_Label_Configure_Function();
                        }
                        else
                        {
                            packet_field_changes_done = Packet_Any_Field_Configure_Function(selected_component);
                        }
                    }

                    if(packet_field_changes_done)
                    {
                        Refresh_Packet_Header_Fields();
                    }

                }
            }          
        }

        private bool Packet_Any_Field_Configure_Function(Label selected_component)
        {
            
            bool ret = false;
            int number_of_bits;
            DrvrCatEthernetFieldCode current_ethernet_field_prop = (DrvrCatEthernetFieldCode)selected_component.Tag;


            DrvrCatInputForm Packet_Any_Field_Bit_Input_Form = new DrvrCatInputForm(current_ethernet_field_prop.Field_Name, "Enter the number of bits for " + current_ethernet_field_prop.Field_Name + " field");

            // Show testDialog as a modal dialog and determine if DialogResult = OK.

            if (Packet_Any_Field_Bit_Input_Form.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                
                if (int.TryParse(Packet_Any_Field_Bit_Input_Form.Input_String, out number_of_bits) == true)
                {
                    if (number_of_bits <= 64)
                    {
                        selected_component.Text = current_ethernet_field_prop.Field_Name + "\r\n" + number_of_bits + " bits";
                        current_ethernet_field_prop.number_of_bits = number_of_bits;    

                        //if (number_of_bits == 8)
                        //{
                        //    current_ethernet_field_prop.Code_String = "unsigned char " + current_ethernet_field_prop.Field_Name.Replace(" ","_");
                        //}
                        //else if (number_of_bits == 16)
                        if (number_of_bits == 16)
                        {
                            current_ethernet_field_prop.Code_String = "unsigned short " + current_ethernet_field_prop.Field_Name.Replace(" ", "_");
                        }
                        else if (number_of_bits == 32)
                        {
                            current_ethernet_field_prop.Code_String = "unsigned int " + current_ethernet_field_prop.Field_Name.Replace(" ", "_");
                        }
                        else if (number_of_bits == 64)
                        {
                            current_ethernet_field_prop.Code_String = "unsigned long " + current_ethernet_field_prop.Field_Name.Replace(" ", "_");
                        }
                        else if ((number_of_bits > 32) && (number_of_bits < 64))
                        {
                            current_ethernet_field_prop.Code_String = "unsigned long " + current_ethernet_field_prop.Field_Name.Replace(" ", "_") + ":" + number_of_bits;
                        }
                        else if ((number_of_bits > 0) && (number_of_bits < 32))
                        {
                            current_ethernet_field_prop.Code_String = "unsigned int " + current_ethernet_field_prop.Field_Name.Replace(" ", "_") + ":" + number_of_bits;
                        }
                        //else if ((number_of_bits > 8) && (number_of_bits < 16))
                        //{

                        //}
                        //else if ((number_of_bits > 1) && (number_of_bits < 16))
                        //{

                        //}

                        ret = true;
                    }
                    else
                    {
                        MessageBox.Show("Bit width more that 64", "Incorrect bit width", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {

            }
            Packet_Any_Field_Bit_Input_Form.Dispose();
            return ret;
        }

        private bool Packet_Length_Label_Configure_Function()
        {
            DrvrCatInputForm Packet_Label_Bit_Input_Form = new DrvrCatInputForm("Packet Length", "Enter the number of bits for packet Length field");
            bool ret = false;

            // Show testDialog as a modal dialog and determine if DialogResult = OK.

            if (Packet_Label_Bit_Input_Form.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                int number_of_bits;
                if (int.TryParse(Packet_Label_Bit_Input_Form.Input_String, out number_of_bits) == true)
                {
                    if(number_of_bits <= 64)
                    {
                        this.Packet_Length_Label.Text = "Length\r\n" + number_of_bits + " bits";
                        //this.Packet_Length_Label.Tag = number_of_bits;
                        DrvrCatEthernetFieldCode current_ethernet_field_prop = (DrvrCatEthernetFieldCode)this.Packet_Length_Label.Tag;
                        current_ethernet_field_prop.number_of_bits = number_of_bits;

                        //if(number_of_bits==8)
                        //{
                        //    current_ethernet_field_prop.Code_String = "unsigned char Length";
                        //}
                        if(number_of_bits==16)
                        {
                            current_ethernet_field_prop.Code_String = "unsigned short Length";
                        }
                        else if(number_of_bits == 32)
                        {
                            current_ethernet_field_prop.Code_String = "unsigned int Length";
                        }
                        else if(number_of_bits == 64)
                        {
                            current_ethernet_field_prop.Code_String = "unsigned long Length";
                        }
                        else if ((number_of_bits > 32) && (number_of_bits < 64))
                        {
                            current_ethernet_field_prop.Code_String = "unsigned long Length:"+number_of_bits;
                        }
                        else if ((number_of_bits > 0) && (number_of_bits < 32))
                        {
                            current_ethernet_field_prop.Code_String = "unsigned int Length:" + number_of_bits;
                        }
                        //else if ((number_of_bits > 8) && (number_of_bits < 16))
                        //{

                        //}
                        //else if ((number_of_bits > 1) && (number_of_bits < 16))
                        //{

                        //}

                    
                        this.Ethernet_Field_ToolTip.SetToolTip(this.Packet_Length_Label, "Number of bytes succeeding header. This includes Command and data.  Maximum "+ Math.Pow(2,number_of_bits).ToString() +" bytes of command and data transfer possible");
                        ret = true;
                    }
                    else
                    {
                        MessageBox.Show("Bit width more that 64", "Incorrect bit width", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {

            }
            Packet_Label_Bit_Input_Form.Dispose();
            return ret;
        }

        private bool Packet_ID_Label_Configure_Function()
        {
            DrvrCatInputForm Packet_ID_Bit_Input_Form = new DrvrCatInputForm("Packet ID", "Enter the number of bits for packet ID field");
            bool ret = false;

            // Show testDialog as a modal dialog and determine if DialogResult = OK.

            if (Packet_ID_Bit_Input_Form.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                int number_of_bits;
                if (int.TryParse(Packet_ID_Bit_Input_Form.Input_String, out number_of_bits) == true)
                {
                    if (number_of_bits<=64)
                    {
                        this.Packet_Id_Label.Text = "Id\r\n" + number_of_bits + " bits";
                        //this.Packet_Id_Label.Tag = number_of_bits;
                        DrvrCatEthernetFieldCode current_ethernet_field_prop = (DrvrCatEthernetFieldCode)this.Packet_Id_Label.Tag;
                        current_ethernet_field_prop.number_of_bits = number_of_bits;

                        //if (number_of_bits == 8)
                        //{
                        //    current_ethernet_field_prop.Code_String = "unsigned char Id";
                        //}
                        if (number_of_bits == 16)
                        {
                            current_ethernet_field_prop.Code_String = "unsigned short Id";
                        }
                        else if (number_of_bits == 32)
                        {
                            current_ethernet_field_prop.Code_String = "unsigned int Id";
                        }
                        else if (number_of_bits == 64)
                        {
                            current_ethernet_field_prop.Code_String = "unsigned long Id";
                        }
                        else if ((number_of_bits > 32) && (number_of_bits < 64))
                        {
                            current_ethernet_field_prop.Code_String = "unsigned long Id:" + number_of_bits;
                        }
                        else if ((number_of_bits > 0) && (number_of_bits < 32))
                        {
                            current_ethernet_field_prop.Code_String = "unsigned int Id:" + number_of_bits;
                        }

                        this.Ethernet_Field_ToolTip.SetToolTip(this.Packet_Id_Label, "Unique Id for each incomming command. Supports " + Math.Pow(2, number_of_bits).ToString() + " commands simultaenously.");
                        ret = true; 
                    }
                    else
                    {
                        MessageBox.Show("Bit width more that 64", "Incorrect bit width", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {

            }
            Packet_ID_Bit_Input_Form.Dispose();
            return ret;
        }

        private void Refresh_Packet_Header_Fields()
        {
            int packet_header_total_bits = 0;
            int number_of_fields = Packet_Header_TableLayoutPanel.ColumnCount;
            DrvrCatEthernetFieldCode current_ethernet_field_prop = null;
            DrvrCatCodeBuilder packet_header_struct_code = new DrvrCatCodeBuilder();

            packet_header_struct_code.AppendLine("typedef struct");
            packet_header_struct_code.Start_Block();
            for (int column_index = 0; column_index < number_of_fields; column_index++)
            {
                Control current_control = Packet_Header_TableLayoutPanel.GetControlFromPosition(column_index, 0);
                current_ethernet_field_prop = (DrvrCatEthernetFieldCode)current_control.Tag;
                packet_header_total_bits += (int)current_ethernet_field_prop.number_of_bits;
                packet_header_struct_code.AppendLine(current_ethernet_field_prop.Code_String + ";    /**< " + Ethernet_Field_ToolTip.GetToolTip(current_control) + "*/");
            }

            packet_header_struct_code.AppendLine("char pData[0];    /**< Points to the memory that has command header*/");
            packet_header_struct_code.End_Block("__attribute__((__packed__))Packet_Header,*pPacket_Header;");

            TableLayoutColumnStyleCollection column_styles = Packet_Header_TableLayoutPanel.ColumnStyles;

            foreach (ColumnStyle column_style in column_styles)
            {
                column_style.SizeType = SizeType.Percent;
                column_style.Width = ((float)100) / (Packet_Header_TableLayoutPanel.ColumnCount);
            }

            this.Packet_Header_Byte_Size_Label.Text = (Math.Ceiling((double)packet_header_total_bits / 8)).ToString();
            this.Packet_Header_Byte_Size_Label.Tag = packet_header_total_bits.ToString();
            this.Packet_Header_Code.Text = packet_header_struct_code.GetCode();

            Refresh_Packet_Command_Header_Byte();
        }

        private void Refresh_Packet_Command_Header_Byte()
        {
            int total_bits = int.Parse(Packet_Header_Byte_Size_Label.Tag.ToString()) + int.Parse(Command_Header_Byte_Size_Label.Tag.ToString());
            this.Packet_Command_Header_Byte_Size_Label.Text = (Math.Ceiling((double)total_bits / 8)).ToString();
        }

        private bool Packet_Header_String_Label_Configure_Function()
        {
            DrvrCatInputForm Header_String_Form = new DrvrCatInputForm("Header String","Enter the sting for packet header");
            bool ret = false;
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            
            if (Header_String_Form.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of Dialog's TextBox.
                if(Header_String_Form.Input_String.CompareTo(String.Empty) != 0)
                {
                    //MessageBox.Show(Header_String_Form.Header_String);
                    this.Packet_Header_String_Label.Text = "Header String\r\n\"" + Header_String_Form.Input_String + "\"\r\n" + Header_String_Form.Input_String.Length.ToString() + " bytes";
                    Ethernet_Packet_Header_String = String.Copy(Header_String_Form.Input_String);
                    //this.Packet_Header_String_Label.Tag = Header_String_Form.Input_String.Length * 8;
                    DrvrCatEthernetFieldCode current_ethernet_field_prop = (DrvrCatEthernetFieldCode)this.Packet_Header_String_Label.Tag;
                    current_ethernet_field_prop.number_of_bits = Header_String_Form.Input_String.Length * 8;
                    current_ethernet_field_prop.Code_String = "char Header_String[" + Header_String_Form.Input_String.Length.ToString() + "]";
                    ret = true;
                }
            }
            else
            {
                
            }
            Header_String_Form.Dispose();
            return ret;
        }

        private void Packet_Field_Add_Button_Click(object sender, EventArgs e)
        {
            DrvrCatEthernetFieldAddForm new_field_form = new DrvrCatEthernetFieldAddForm();
            DrvrCatEthernetFieldCode current_ethernet_field_prop = null;

            if (new_field_form.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of Dialog's TextBox.

                String Field_Name = String.Copy(new_field_form.Field_Name);
                String Field_Description = String.Copy(new_field_form.Field_Description);
                int Field_Bit_Width = new_field_form.Field_Bit_Width;

                    int number_of_fields = Packet_Header_TableLayoutPanel.ColumnCount;
                    for (int column_index = 0; column_index < number_of_fields; column_index++)
                    {
                        Control current_control = Packet_Header_TableLayoutPanel.GetControlFromPosition(column_index, 0);
                        current_ethernet_field_prop = (DrvrCatEthernetFieldCode)current_control.Tag;
                        if(current_ethernet_field_prop.Field_Name.CompareTo(Field_Name)==0)
                        {
                            MessageBox.Show("Field already exists at index "+ (column_index +1).ToString() , "Duplicate Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    
                    Label new_field_label = new Label();
                    new_field_label.Dock = DockStyle.Fill;
                    new_field_label.Text = Field_Name + "\r\n" + Field_Bit_Width.ToString() + " bits";
                    new_field_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    new_field_label.MouseDown += new MouseEventHandler(Packet_Fields_MouseDown);
                    new_field_label.ContextMenuStrip = Packet_Fields_Configure_Context_Menu;
                    Ethernet_Field_ToolTip.SetToolTip(new_field_label, Field_Description);

                    current_ethernet_field_prop = new DrvrCatEthernetFieldCode(Field_Name, "", Field_Bit_Width);

                    //if (Field_Bit_Width == 8)
                    //{
                    //    current_ethernet_field_prop.Code_String = "unsigned char " + Field_Name.Replace(" ","_");
                    //}
                    if (Field_Bit_Width == 16)
                    {
                        current_ethernet_field_prop.Code_String = "unsigned short " + Field_Name.Replace(" ", "_");
                    }
                    else if (Field_Bit_Width == 32)
                    {
                        current_ethernet_field_prop.Code_String = "unsigned int " + Field_Name.Replace(" ", "_");
                    }
                    else if (Field_Bit_Width == 64)
                    {
                        current_ethernet_field_prop.Code_String = "unsigned long " + Field_Name.Replace(" ", "_");
                    }
                    else if ((Field_Bit_Width > 32) && (Field_Bit_Width < 64))
                    {
                        current_ethernet_field_prop.Code_String = "unsigned long " + Field_Name.Replace(" ", "_") + ":" + Field_Bit_Width;
                    }
                    else if ((Field_Bit_Width > 0) && (Field_Bit_Width < 32))
                    {
                        current_ethernet_field_prop.Code_String = "unsigned int " + Field_Name.Replace(" ", "_") + ":" + Field_Bit_Width;
                    }

                    new_field_label.Tag = current_ethernet_field_prop;
                    Packet_Header_TableLayoutPanel.ColumnCount = Packet_Header_TableLayoutPanel.ColumnCount + 1;
                    Packet_Header_TableLayoutPanel.Controls.Add(new_field_label, Packet_Header_TableLayoutPanel.ColumnCount - 1, 0);
                    Packet_Header_TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (100 / Packet_Header_TableLayoutPanel.ColumnCount)));

                    Refresh_Packet_Header_Fields();
               
            }
        }

        private void Ethernet_Field_Remove_Context_Button_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    // Get the control that is displaying this context menu
                    Label selected_component = (Label)owner.SourceControl;
                    bool changes_done = false;

                    if (selected_component != null)
                    {
                        int removed_column_index = Packet_Header_TableLayoutPanel.GetColumn(selected_component);
                        Packet_Header_TableLayoutPanel.Controls.Remove(selected_component);

                        for (int column_index = removed_column_index+1; column_index < Packet_Header_TableLayoutPanel.ColumnCount; column_index++)
                        {
                            Control current_control = Packet_Header_TableLayoutPanel.GetControlFromPosition(column_index,0);
                            Packet_Header_TableLayoutPanel.SetColumn(current_control, column_index - 1);
                        }
                        Packet_Header_TableLayoutPanel.ColumnCount = Packet_Header_TableLayoutPanel.ColumnCount - 1;
                        Refresh_Packet_Header_Fields();
                    }
                }
            }          
        }

        private void Command_Fields_MouseDown(object sender, MouseEventArgs e)
        {
            Label selected_component = (Label)sender;
            int selected_position = Command_Header_TableLayoutPanel.GetColumn(selected_component);

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if ((selected_component == Command_Header_TransferType_Label) || (selected_component == Command_Header_OperationType_Label) || 
                    (selected_component == Command_Header_ModuleIndex_Label) || (selected_component == Command_Header_Address_Label) || (selected_component == Command_Header_Length_Label)
                    || (selected_component==Command_Header_Instance_Num_Label))
                {
                    Packet_Remove_Context_Button.Enabled = false;
                    Command_Remove_Context_Button.Enabled = false;
                }
                else
                {
                    Packet_Remove_Context_Button.Enabled = true;
                    Command_Remove_Context_Button.Enabled = false;
                }

                Packet_Fields_Configure_Context_Menu.Show(selected_component, e.X, e.Y);
                return;
            }

            selected_component.BorderStyle = BorderStyle.FixedSingle;
            selected_component.DoDragDrop(selected_position.ToString(), DragDropEffects.Copy | DragDropEffects.Move);
            //MessageBox.Show("Drag "+  Packet_Header_TableLayoutPanel.GetColumn(selected_component).ToString());
        }

        private void Command_Header_TableLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            String Selected_Component_Index_String = e.Data.GetData(DataFormats.Text).ToString();
            int Selected_Component_Index = Convert.ToInt32(Selected_Component_Index_String);
            Control selected_control = Command_Header_TableLayoutPanel.GetControlFromPosition(Selected_Component_Index, 0);
            ((Label)selected_control).BorderStyle = BorderStyle.None;


            Point parent_location_on_screen = Command_Header_TableLayoutPanel.PointToScreen(Point.Empty);
            Control destination_control = Command_Header_TableLayoutPanel.GetChildAtPoint(new Point(e.X - parent_location_on_screen.X, e.Y - parent_location_on_screen.Y));


            if (destination_control != null)
            {
                int Destination_Component_Index = Command_Header_TableLayoutPanel.GetColumn(destination_control);
                Command_Header_TableLayoutPanel.SetCellPosition(destination_control, new TableLayoutPanelCellPosition(Selected_Component_Index, 0));
                Command_Header_TableLayoutPanel.SetCellPosition(selected_control, new TableLayoutPanelCellPosition(Destination_Component_Index, 0));
                // MessageBox.Show("Drop " + Command_Header_TableLayoutPanel.GetColumn(destination_control).ToString());
                Refresh_Command_Header_Fields();
            }
            else
            {
                MessageBox.Show("Dropped at border of a Cell. Place it over any cell", "Incorrect Shifting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Refresh_Command_Header_Fields()
        {
            int command_header_total_bits = 0;
            int number_of_fields = Command_Header_TableLayoutPanel.ColumnCount;
            DrvrCatEthernetFieldCode current_ethernet_field_prop = null;
            DrvrCatCodeBuilder command_header_struct_code = new DrvrCatCodeBuilder();

            command_header_struct_code.AppendLine("typedef struct");
            command_header_struct_code.Start_Block();
            for (int column_index = 0; column_index < number_of_fields; column_index++)
            {
                Control current_control = Command_Header_TableLayoutPanel.GetControlFromPosition(column_index, 0);
                current_ethernet_field_prop = (DrvrCatEthernetFieldCode)current_control.Tag;
                command_header_total_bits += (int)current_ethernet_field_prop.number_of_bits;
                command_header_struct_code.AppendLine(current_ethernet_field_prop.Code_String + ";    /**< " + Ethernet_Field_ToolTip.GetToolTip(current_control) + "*/");
            }

            command_header_struct_code.AppendLine("char pData[0];    /**< Points to the memory that has data*/");
            command_header_struct_code.End_Block("__attribute__((__packed__))Command_Header,*pCommand_Header;");

            TableLayoutColumnStyleCollection column_styles = Command_Header_TableLayoutPanel.ColumnStyles;

            foreach (ColumnStyle column_style in column_styles)
            {
                column_style.SizeType = SizeType.Percent;
                column_style.Width = ((float)100) / (Command_Header_TableLayoutPanel.ColumnCount);
            }

            this.Command_Header_Byte_Size_Label.Text = (Math.Ceiling((double)command_header_total_bits / 8)).ToString();
            this.Command_Header_Byte_Size_Label.Tag = command_header_total_bits.ToString();
            this.Command_Header_Code.Text = command_header_struct_code.GetCode();

            Refresh_Packet_Command_Header_Byte();
        }

        private void Command_Header_TableLayoutPanel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Command_Field_Add_Button_Click(object sender, EventArgs e)
        {
            DrvrCatEthernetFieldAddForm new_field_form = new DrvrCatEthernetFieldAddForm();
            DrvrCatEthernetFieldCode current_ethernet_field_prop = null;

            if (new_field_form.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of Dialog's TextBox.

                String Field_Name = String.Copy(new_field_form.Field_Name);
                String Field_Description = String.Copy(new_field_form.Field_Description);
                int Field_Bit_Width = new_field_form.Field_Bit_Width;

                int number_of_fields = Command_Header_TableLayoutPanel.ColumnCount;
                for (int column_index = 0; column_index < number_of_fields; column_index++)
                {
                    Control current_control = Command_Header_TableLayoutPanel.GetControlFromPosition(column_index, 0);
                    current_ethernet_field_prop = (DrvrCatEthernetFieldCode)current_control.Tag;
                    if (current_ethernet_field_prop.Field_Name.CompareTo(Field_Name) == 0)
                    {
                        MessageBox.Show("Field already exists at index " + (column_index + 1).ToString(), "Duplicate Field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                Label new_field_label = new Label();
                new_field_label.Dock = DockStyle.Fill;
                new_field_label.Text = Field_Name + "\r\n" + Field_Bit_Width.ToString() + " bits";
                new_field_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                new_field_label.MouseDown += new MouseEventHandler(Packet_Fields_MouseDown);
                new_field_label.ContextMenuStrip =  Command_Fields_Configure_Context_Menu;
                Ethernet_Field_ToolTip.SetToolTip(new_field_label, Field_Description);

                current_ethernet_field_prop = new DrvrCatEthernetFieldCode(Field_Name, "", Field_Bit_Width);

                //if (Field_Bit_Width == 8)
                //{
                //    current_ethernet_field_prop.Code_String = "unsigned char " + Field_Name.Replace(" ","_");
                //}
                if (Field_Bit_Width == 16)
                {
                    current_ethernet_field_prop.Code_String = "unsigned short " + Field_Name.Replace(" ", "_");
                }
                else if (Field_Bit_Width == 32)
                {
                    current_ethernet_field_prop.Code_String = "unsigned int " + Field_Name.Replace(" ", "_");
                }
                else if (Field_Bit_Width == 64)
                {
                    current_ethernet_field_prop.Code_String = "unsigned long " + Field_Name.Replace(" ", "_");
                }
                else if ((Field_Bit_Width > 32) && (Field_Bit_Width < 64))
                {
                    current_ethernet_field_prop.Code_String = "unsigned long " + Field_Name.Replace(" ", "_") + ":" + Field_Bit_Width;
                }
                else if ((Field_Bit_Width > 0) && (Field_Bit_Width < 32))
                {
                    current_ethernet_field_prop.Code_String = "unsigned int " + Field_Name.Replace(" ", "_") + ":" + Field_Bit_Width;
                }

                new_field_label.Tag = current_ethernet_field_prop;
                Command_Header_TableLayoutPanel.ColumnCount = Command_Header_TableLayoutPanel.ColumnCount + 1;
                Command_Header_TableLayoutPanel.Controls.Add(new_field_label, Command_Header_TableLayoutPanel.ColumnCount - 1, 0);
                Command_Header_TableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (100 / Command_Header_TableLayoutPanel.ColumnCount)));

                Refresh_Command_Header_Fields();

            }
        }

        private void Command_Configure_Context_Button_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    // Get the control that is displaying this context menu
                    Label selected_component = (Label)owner.SourceControl;
                    bool command_field_changes_done = false;

                    if (selected_component != null)
                    {
                        if (selected_component == Command_Header_TransferType_Label)
                        {
                            command_field_changes_done = Packet_Any_Field_Configure_Function(selected_component);
                            //Ethernet_Field_Code current_ethernet_field_prop = (Ethernet_Field_Code)selected_component.Tag;
                            //double possiblities = Math.Pow(2, current_ethernet_field_prop.number_of_bits);
                        }
                        else if (selected_component == Command_Header_OperationType_Label)
                        {
                            command_field_changes_done = Packet_Any_Field_Configure_Function(selected_component);
                            DrvrCatEthernetFieldCode current_ethernet_field_prop = (DrvrCatEthernetFieldCode)selected_component.Tag;
                            double possiblities = Math.Pow(2, current_ethernet_field_prop.number_of_bits);

                            this.Ethernet_Field_ToolTip.SetToolTip(selected_component, "Operation to be performed e.g Read, Write and Config. Supports maximum " + possiblities.ToString() + " operations.");
                        }
                        else if (selected_component == Command_Header_ModuleIndex_Label)
                        {
                            command_field_changes_done = Packet_Any_Field_Configure_Function(selected_component);
                            DrvrCatEthernetFieldCode current_ethernet_field_prop = (DrvrCatEthernetFieldCode)selected_component.Tag;
                            double possiblities = Math.Pow(2, current_ethernet_field_prop.number_of_bits);

                            this.Ethernet_Field_ToolTip.SetToolTip(selected_component, "Index of module to configure.  Maximum " + possiblities.ToString() + " modules can be configured");
                        }
                        else if (selected_component == Command_Header_Address_Label)
                        {
                            command_field_changes_done = Packet_Any_Field_Configure_Function(selected_component);
                            DrvrCatEthernetFieldCode current_ethernet_field_prop = (DrvrCatEthernetFieldCode)selected_component.Tag;
                            double possiblities = Math.Pow(2, current_ethernet_field_prop.number_of_bits);

                            this.Ethernet_Field_ToolTip.SetToolTip(selected_component, "Offset address or index of configuration to be done. Maximum " + possiblities.ToString() + " address/offsets can be configured");
                        }
                        else if (selected_component == Command_Header_Length_Label)
                        {
                            command_field_changes_done = Packet_Any_Field_Configure_Function(selected_component);
                            DrvrCatEthernetFieldCode current_ethernet_field_prop = (DrvrCatEthernetFieldCode)selected_component.Tag;
                            double possiblities = Math.Pow(2, current_ethernet_field_prop.number_of_bits);

                            this.Ethernet_Field_ToolTip.SetToolTip(selected_component, "Number of data offsets succeeding command header.  Maximum " + possiblities.ToString() + " words of data transfer supported");
                        }
                        else if (selected_component == Command_Header_Instance_Num_Label)
                        {
                            command_field_changes_done = Packet_Any_Field_Configure_Function(selected_component);
                            DrvrCatEthernetFieldCode current_ethernet_field_prop = (DrvrCatEthernetFieldCode)selected_component.Tag;
                            double possiblities = Math.Pow(2, current_ethernet_field_prop.number_of_bits);

                            this.Ethernet_Field_ToolTip.SetToolTip(selected_component, "Instance of module to configure.  Maximum " + possiblities.ToString() + " instances of each modules can be configured" );
                        }
                        else
                        {
                            command_field_changes_done = Packet_Any_Field_Configure_Function(selected_component);
                        }
                    }

                    if (command_field_changes_done)
                    {
                        Refresh_Command_Header_Fields();
                    }

                }
            } 
        }

        private void Command_Remove_Context_Button_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                // Retrieve the ContextMenuStrip that owns this ToolStripItem
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    // Get the control that is displaying this context menu
                    Label selected_component = (Label)owner.SourceControl;
                    bool changes_done = false;

                    if (selected_component != null)
                    {
                        int removed_column_index = Command_Header_TableLayoutPanel.GetColumn(selected_component);
                        Command_Header_TableLayoutPanel.Controls.Remove(selected_component);

                        for (int column_index = removed_column_index + 1; column_index < Command_Header_TableLayoutPanel.ColumnCount; column_index++)
                        {
                            Control current_control = Command_Header_TableLayoutPanel.GetControlFromPosition(column_index, 0);
                            Command_Header_TableLayoutPanel.SetColumn(current_control, column_index - 1);
                        }
                        Command_Header_TableLayoutPanel.ColumnCount = Command_Header_TableLayoutPanel.ColumnCount - 1;
                        Refresh_Command_Header_Fields();
                    }
                }
            }          
        }

        private void Configuration_Add_Button_Click(object sender, EventArgs e)
        {
            String Configuration_Name = null;
            String Configuration_Description = null;

            if ((Configuration_Name_Text_Box.Text.Trim().Length > 0))
            {
                Configuration_Name = Configuration_Name_Text_Box.Text.Trim();
            }
            else
            {
                MessageBox.Show("Configuration Name field should be filled", "Incorrect Mandatory field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if ((Configuration_Description_Text_Box.Text.Trim().Length > 0))
            {
                Configuration_Description = Configuration_Description_Text_Box.Text.Trim();
            }
            else
            {
                MessageBox.Show("Configuration Description field should be filled", "Incorrect Mandatory field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string[] config_row = { Configuration_Name.Replace(" ", "_"), Configuration_Description.Trim() };
            ListViewItem config_listViewItem = new ListViewItem(config_row);
            Configurations_List_View.Items.Add(config_listViewItem);

            DrvrCatConfigServiceItem current_config = new DrvrCatConfigServiceItem(Configuration_Name.Replace(" ", "_"),Configuration_Description);

            DrvrCatCodeAutomationPanel.Selected_Module_Regmap.Config_List.Add(current_config);
            DrvrCatCodeAutomationPanel.Selected_Module_Regmap.Define_Config_List_Enumeration();
            Configuration_Enum_Text_Box.Text = DrvrCatCodeAutomationPanel.Selected_Module_Regmap.Config_List_Enumeration.Enumeration_Code;

            Configuration_Name_Text_Box.Text = String.Empty;
            Configuration_Description_Text_Box.Text = String.Empty;

            DrvrCatCodeAutomationPanel.Selected_Module_Regmap.Define_Config_Function();

        }

        private void Configuration_Remove_Button_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection Selected_Items = Configurations_List_View.SelectedItems;

            foreach (ListViewItem current_item in Selected_Items)
            {
                DrvrCatCodeAutomationPanel.Selected_Module_Regmap.Config_List.RemoveAt(current_item.Index);
                current_item.Remove();
            }

            DrvrCatCodeAutomationPanel.Selected_Module_Regmap.Define_Config_List_Enumeration();
            Configuration_Enum_Text_Box.Text = DrvrCatCodeAutomationPanel.Selected_Module_Regmap.Config_List_Enumeration.Enumeration_Code;

            Configuration_Name_Text_Box.Text = String.Empty;
            Configuration_Description_Text_Box.Text = String.Empty;

            DrvrCatCodeAutomationPanel.Selected_Module_Regmap.Define_Config_Function();
        }

        private void Service_Add_Button_Click(object sender, EventArgs e)
        {
            String Service_Name = null;
            String Service_Description = null;

            if ((Service_Name_Text_Box.Text.Trim().Length > 0))
            {
                Service_Name = Service_Name_Text_Box.Text.Trim();
            }
            else
            {
                MessageBox.Show("Service Name field should be filled", "Incorrect Mandatory field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if ((Service_Description_Text_Box.Text.Trim().Length > 0))
            {
                Service_Description = Service_Description_Text_Box.Text.Trim();
            }
            else
            {
                MessageBox.Show("Service Description field should be filled", "Incorrect Mandatory field", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            string[] service_row = { Service_Name.Replace(" ", "_"), Service_Description.Trim() };
            ListViewItem service_listViewItem = new ListViewItem(service_row);
            Service_List_View.Items.Add(service_listViewItem);

            DrvrCatConfigServiceItem current_service = new DrvrCatConfigServiceItem(Service_Name.Replace(" ", "_"), Service_Description);

            DrvrCatCodeAutomationPanel.Selected_Module_Regmap.Service_List.Add(current_service);
            DrvrCatCodeAutomationPanel.Selected_Module_Regmap.Define_Service_List_Enumeration();
            Service_Enum_Text_Box.Text = DrvrCatCodeAutomationPanel.Selected_Module_Regmap.Service_List_Enumeration.Enumeration_Code;

            Service_Name_Text_Box.Text = String.Empty;
            Service_Description_Text_Box.Text = String.Empty;

            DrvrCatCodeAutomationPanel.Selected_Module_Regmap.Define_Service_Function();
        }

        private void Service_Remove_Button_Click(object sender, EventArgs e)
        {

            ListView.SelectedListViewItemCollection Selected_Items = Service_List_View.SelectedItems;

            foreach (ListViewItem current_item in Selected_Items)
            {
                DrvrCatCodeAutomationPanel.Selected_Module_Regmap.Service_List.RemoveAt(current_item.Index);
                current_item.Remove();
            }

            DrvrCatCodeAutomationPanel.Selected_Module_Regmap.Define_Service_List_Enumeration();
            Service_Enum_Text_Box.Text = DrvrCatCodeAutomationPanel.Selected_Module_Regmap.Service_List_Enumeration.Enumeration_Code;

            Service_Name_Text_Box.Text = String.Empty;
            Service_Description_Text_Box.Text = String.Empty;

            DrvrCatCodeAutomationPanel.Selected_Module_Regmap.Define_Service_Function();
        }

        private void FID_path_open_dialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void FID_path_text_TextChanged(object sender, EventArgs e)
        {

        }
    }
}