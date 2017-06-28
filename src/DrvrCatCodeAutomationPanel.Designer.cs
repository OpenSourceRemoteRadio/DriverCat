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
using System.Windows.Forms;
namespace Code_Automation_Tool
{
    partial class DrvrCatCodeAutomationPanel
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
            this.components = new System.ComponentModel.Container();
            this.FID_path_text = new System.Windows.Forms.TextBox();
            this.Parse_FID_button = new System.Windows.Forms.Button();
            this.FID_path_open_dialog = new System.Windows.Forms.OpenFileDialog();
            this.FID_path_open_button = new System.Windows.Forms.Button();
            this.Code_Destination_Browser_dialog = new System.Windows.Forms.FolderBrowserDialog();
            this.File_Parse_Status_strip = new System.Windows.Forms.StatusStrip();
            this.Form_Status_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status_Version_Label = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status_Operation_Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.Tab_Control = new System.Windows.Forms.TabControl();
            this.FID_tab = new System.Windows.Forms.TabPage();
            this.Add_Modules_List_Button = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.FID_Parse_Modules_List = new System.Windows.Forms.CheckedListBox();
            this.Module_Register_Details_Tab = new System.Windows.Forms.TabPage();
            this.Module_Registers_List_Box_Heading = new System.Windows.Forms.Label();
            this.Module_Register_Category_Combo_Box = new System.Windows.Forms.ComboBox();
            this.Module_Register_Permission_Combo_Box = new System.Windows.Forms.ComboBox();
            this.Module_Register_POR_Text_Box = new System.Windows.Forms.TextBox();
            this.Module_Register_Address_Text_Box_Hex = new System.Windows.Forms.TextBox();
            this.Module_Register_Address_Text_Box = new System.Windows.Forms.TextBox();
            this.Module_Register_Name_Text_Box = new System.Windows.Forms.TextBox();
            this.Module_Register_Bit_Position_Text_Box = new System.Windows.Forms.TextBox();
            this.Module_Register_Def_Code_Text_Box = new System.Windows.Forms.TextBox();
            this.Module_Register_Bit_Description_Text_Box = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Module_Register_Delete_Button = new System.Windows.Forms.Button();
            this.Module_Register_Add_Button = new System.Windows.Forms.Button();
            this.Module_Registers_List_Box = new System.Windows.Forms.ListBox();
            this.FID_Sheet_Module_Names = new System.Windows.Forms.ComboBox();
            this.Active_Sheet_label = new System.Windows.Forms.Label();
            this.Module_Register_Bit_Table_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.Module_Function_Details_Tab = new System.Windows.Forms.TabPage();
            this.Module_Function_Filter_by_Register_Bit_Combobox = new System.Windows.Forms.ComboBox();
            this.Module_Function_Filter_by_Register_Combobox = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Module_Function_List_Box_Filter_by_Register_bit = new System.Windows.Forms.CheckBox();
            this.Code_Generate_Button = new System.Windows.Forms.Button();
            this.Module_Function_Filter_by_Register_Checkbox = new System.Windows.Forms.CheckBox();
            this.Selected_Function_Code_Text_Box = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Functions_Tab_Create_Function_Button = new System.Windows.Forms.Button();
            this.Module_Functions_List_Box = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Configs_And_Service_Tab = new System.Windows.Forms.TabPage();
            this.Service_Enum_Text_Box = new System.Windows.Forms.TextBox();
            this.Configuration_Enum_Text_Box = new System.Windows.Forms.TextBox();
            this.Service_List_View = new System.Windows.Forms.ListView();
            this.Service_List_Service_Name_Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Service_List_Service_Description_Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Configurations_List_View = new System.Windows.Forms.ListView();
            this.Configuration_List_Configuration_Name_Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Configuration_List_Configuration_Description_Column = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label25 = new System.Windows.Forms.Label();
            this.Service_Remove_Button = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.Service_Add_Button = new System.Windows.Forms.Button();
            this.Configuration_Remove_Button = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.Configuration_Add_Button = new System.Windows.Forms.Button();
            this.Service_Name_Text_Box = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.Service_Description_Text_Box = new System.Windows.Forms.TextBox();
            this.Configuration_Name_Text_Box = new System.Windows.Forms.TextBox();
            this.Configuration_Description_Text_Box = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.Ethernet_Format_Tab = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.Command_Header_Config_Panel = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.Command_Header_Code = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.Command_Header_Byte_Size_Label = new System.Windows.Forms.Label();
            this.Command_Field_Add_Button = new System.Windows.Forms.Button();
            this.Command_Header_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Command_Header_OperationType_Label = new System.Windows.Forms.Label();
            this.Command_Fields_Configure_Context_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Command_Configure_Context_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.Command_Remove_Context_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.Command_Header_TransferType_Label = new System.Windows.Forms.Label();
            this.Command_Header_ModuleIndex_Label = new System.Windows.Forms.Label();
            this.Command_Header_Address_Label = new System.Windows.Forms.Label();
            this.Command_Header_Length_Label = new System.Windows.Forms.Label();
            this.Command_Header_Instance_Num_Label = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Packet_Command_Header_Byte_Size_Label = new System.Windows.Forms.Label();
            this.Packet_Header_Config_Panel = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.Packet_Header_Code = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Packet_Header_Byte_Size_Label = new System.Windows.Forms.Label();
            this.Packet_Field_Add_Button = new System.Windows.Forms.Button();
            this.Packet_Header_TableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.Packet_Id_Label = new System.Windows.Forms.Label();
            this.Packet_Header_String_Label = new System.Windows.Forms.Label();
            this.Packet_Fields_Configure_Context_Menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Packet_Configure_Context_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.Packet_Remove_Context_Button = new System.Windows.Forms.ToolStripMenuItem();
            this.Packet_Length_Label = new System.Windows.Forms.Label();
            this.rrh_command_response_mapper_tab = new System.Windows.Forms.TabPage();
            this.Command_Mapper_Clear_Table_Button = new System.Windows.Forms.Button();
            this.command_mapper_update_LUT_button = new System.Windows.Forms.Button();
            this.Command_Mapper_Update_Functions_Button = new System.Windows.Forms.Button();
            this.Command_Mapper_Add_Module_Button = new System.Windows.Forms.Button();
            this.Command_Mapper_Add_Command_Button = new System.Windows.Forms.Button();
            this.Command_Mapper_Table_Layout = new System.Windows.Forms.TableLayoutPanel();
            this.label18 = new System.Windows.Forms.Label();
            this.Device_Tree_Details_Tab = new System.Windows.Forms.TabPage();
            this.Device_List_View = new System.Windows.Forms.ListView();
            this.Device_Name_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Device_Instance_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.driver_selected_node_delete_button = new System.Windows.Forms.Button();
            this.driver_tree_Node_add_button = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.Device_Driver_Generate_Button = new System.Windows.Forms.Button();
            this.device_driver_selected_node_treeview = new System.Windows.Forms.TreeView();
            this.device_tree_tree_view = new System.Windows.Forms.TreeView();
            this.device_tree_open_button = new System.Windows.Forms.Button();
            this.device_tree_path_text_box = new System.Windows.Forms.TextBox();
            this.devicetree_parse_button = new System.Windows.Forms.Button();
            this.BigCat_logo = new System.Windows.Forms.PictureBox();
            this.Form_Menu_Strip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.device_tree_open_dialog = new System.Windows.Forms.OpenFileDialog();
            this.Ethernet_Field_ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.File_Parse_Status_strip.SuspendLayout();
            this.Tab_Control.SuspendLayout();
            this.FID_tab.SuspendLayout();
            this.Module_Register_Details_Tab.SuspendLayout();
            this.Module_Function_Details_Tab.SuspendLayout();
            this.Configs_And_Service_Tab.SuspendLayout();
            this.Ethernet_Format_Tab.SuspendLayout();
            this.Command_Header_Config_Panel.SuspendLayout();
            this.Command_Header_TableLayoutPanel.SuspendLayout();
            this.Command_Fields_Configure_Context_Menu.SuspendLayout();
            this.Packet_Header_Config_Panel.SuspendLayout();
            this.Packet_Header_TableLayoutPanel.SuspendLayout();
            this.Packet_Fields_Configure_Context_Menu.SuspendLayout();
            this.rrh_command_response_mapper_tab.SuspendLayout();
            this.Command_Mapper_Table_Layout.SuspendLayout();
            this.Device_Tree_Details_Tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BigCat_logo)).BeginInit();
            this.Form_Menu_Strip.SuspendLayout();
            this.SuspendLayout();
            // 
            // FID_path_text
            // 
            this.FID_path_text.Location = new System.Drawing.Point(84, 22);
            this.FID_path_text.Name = "FID_path_text";
            this.FID_path_text.Size = new System.Drawing.Size(441, 20);
            this.FID_path_text.TabIndex = 0;
            this.FID_path_text.Text = "https://bigcatwireless.sharepoint.com/Hepta_RRH_RF/Shared%20Documents/03_Design/0" +
    "4_FID/WS-FID-000xx%20Hepta_Lime_RF.xlsm?web=1";
            this.FID_path_text.TextChanged += new System.EventHandler(this.FID_path_text_TextChanged);
            // 
            // Parse_FID_button
            // 
            this.Parse_FID_button.Location = new System.Drawing.Point(570, 22);
            this.Parse_FID_button.Name = "Parse_FID_button";
            this.Parse_FID_button.Size = new System.Drawing.Size(75, 23);
            this.Parse_FID_button.TabIndex = 1;
            this.Parse_FID_button.Text = "Parse FID";
            this.Parse_FID_button.UseVisualStyleBackColor = true;
            this.Parse_FID_button.Click += new System.EventHandler(this.Parse_FID_button_Click);
            // 
            // FID_path_open_dialog
            // 
            this.FID_path_open_dialog.DefaultExt = "xlsm";
            this.FID_path_open_dialog.FileOk += new System.ComponentModel.CancelEventHandler(this.FID_path_open_dialog_FileOk);
            // 
            // FID_path_open_button
            // 
            this.FID_path_open_button.Location = new System.Drawing.Point(522, 21);
            this.FID_path_open_button.Name = "FID_path_open_button";
            this.FID_path_open_button.Size = new System.Drawing.Size(26, 22);
            this.FID_path_open_button.TabIndex = 6;
            this.FID_path_open_button.Text = "...";
            this.FID_path_open_button.UseVisualStyleBackColor = true;
            this.FID_path_open_button.Click += new System.EventHandler(this.FID_path_open_button_Click);
            // 
            // Code_Destination_Browser_dialog
            // 
            this.Code_Destination_Browser_dialog.Description = "Select the destination folder to generate code";
            this.Code_Destination_Browser_dialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // File_Parse_Status_strip
            // 
            this.File_Parse_Status_strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Form_Status_Label,
            this.Status_Version_Label,
            this.Status_Operation_Progress});
            this.File_Parse_Status_strip.Location = new System.Drawing.Point(0, 446);
            this.File_Parse_Status_strip.Name = "File_Parse_Status_strip";
            this.File_Parse_Status_strip.Size = new System.Drawing.Size(967, 22);
            this.File_Parse_Status_strip.TabIndex = 15;
            this.File_Parse_Status_strip.Text = "Status_strip";
            // 
            // Form_Status_Label
            // 
            this.Form_Status_Label.Name = "Form_Status_Label";
            this.Form_Status_Label.Size = new System.Drawing.Size(73, 17);
            this.Form_Status_Label.Text = "Status : Busy";
            // 
            // Status_Version_Label
            // 
            this.Status_Version_Label.Name = "Status_Version_Label";
            this.Status_Version_Label.Size = new System.Drawing.Size(54, 17);
            this.Status_Version_Label.Text = "Version : ";
            // 
            // Status_Operation_Progress
            // 
            this.Status_Operation_Progress.Name = "Status_Operation_Progress";
            this.Status_Operation_Progress.Size = new System.Drawing.Size(100, 16);
            this.Status_Operation_Progress.Step = 1;
            this.Status_Operation_Progress.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "FID path";
            // 
            // Tab_Control
            // 
            this.Tab_Control.Controls.Add(this.FID_tab);
            this.Tab_Control.Controls.Add(this.Module_Register_Details_Tab);
            this.Tab_Control.Controls.Add(this.Module_Function_Details_Tab);
            this.Tab_Control.Controls.Add(this.Configs_And_Service_Tab);
            this.Tab_Control.Controls.Add(this.Ethernet_Format_Tab);
            this.Tab_Control.Controls.Add(this.rrh_command_response_mapper_tab);
            this.Tab_Control.Controls.Add(this.Device_Tree_Details_Tab);
            this.Tab_Control.Location = new System.Drawing.Point(0, 57);
            this.Tab_Control.Name = "Tab_Control";
            this.Tab_Control.SelectedIndex = 0;
            this.Tab_Control.Size = new System.Drawing.Size(968, 386);
            this.Tab_Control.TabIndex = 19;
            this.Tab_Control.SelectedIndexChanged += new System.EventHandler(this.Tab_Control_SelectedIndexChanged);
            // 
            // FID_tab
            // 
            this.FID_tab.Controls.Add(this.Add_Modules_List_Button);
            this.FID_tab.Controls.Add(this.label19);
            this.FID_tab.Controls.Add(this.FID_Parse_Modules_List);
            this.FID_tab.Controls.Add(this.FID_path_text);
            this.FID_tab.Controls.Add(this.Parse_FID_button);
            this.FID_tab.Controls.Add(this.FID_path_open_button);
            this.FID_tab.Controls.Add(this.label1);
            this.FID_tab.Location = new System.Drawing.Point(4, 22);
            this.FID_tab.Name = "FID_tab";
            this.FID_tab.Padding = new System.Windows.Forms.Padding(3);
            this.FID_tab.Size = new System.Drawing.Size(960, 360);
            this.FID_tab.TabIndex = 0;
            this.FID_tab.Text = "FID";
            this.FID_tab.UseVisualStyleBackColor = true;
            // 
            // Add_Modules_List_Button
            // 
            this.Add_Modules_List_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_Modules_List_Button.Location = new System.Drawing.Point(154, 319);
            this.Add_Modules_List_Button.Name = "Add_Modules_List_Button";
            this.Add_Modules_List_Button.Size = new System.Drawing.Size(91, 23);
            this.Add_Modules_List_Button.TabIndex = 10;
            this.Add_Modules_List_Button.Text = "Add";
            this.Add_Modules_List_Button.UseVisualStyleBackColor = true;
            this.Add_Modules_List_Button.Click += new System.EventHandler(this.Add_Modules_List_Button_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(24, 69);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 13);
            this.label19.TabIndex = 8;
            this.label19.Text = "Modules List";
            // 
            // FID_Parse_Modules_List
            // 
            this.FID_Parse_Modules_List.FormattingEnabled = true;
            this.FID_Parse_Modules_List.Location = new System.Drawing.Point(24, 90);
            this.FID_Parse_Modules_List.Name = "FID_Parse_Modules_List";
            this.FID_Parse_Modules_List.Size = new System.Drawing.Size(221, 214);
            this.FID_Parse_Modules_List.TabIndex = 7;
            // 
            // Module_Register_Details_Tab
            // 
            this.Module_Register_Details_Tab.Controls.Add(this.Module_Registers_List_Box_Heading);
            this.Module_Register_Details_Tab.Controls.Add(this.Module_Register_Category_Combo_Box);
            this.Module_Register_Details_Tab.Controls.Add(this.Module_Register_Permission_Combo_Box);
            this.Module_Register_Details_Tab.Controls.Add(this.Module_Register_POR_Text_Box);
            this.Module_Register_Details_Tab.Controls.Add(this.Module_Register_Address_Text_Box_Hex);
            this.Module_Register_Details_Tab.Controls.Add(this.Module_Register_Address_Text_Box);
            this.Module_Register_Details_Tab.Controls.Add(this.Module_Register_Name_Text_Box);
            this.Module_Register_Details_Tab.Controls.Add(this.Module_Register_Bit_Position_Text_Box);
            this.Module_Register_Details_Tab.Controls.Add(this.Module_Register_Def_Code_Text_Box);
            this.Module_Register_Details_Tab.Controls.Add(this.Module_Register_Bit_Description_Text_Box);
            this.Module_Register_Details_Tab.Controls.Add(this.label9);
            this.Module_Register_Details_Tab.Controls.Add(this.label8);
            this.Module_Register_Details_Tab.Controls.Add(this.label7);
            this.Module_Register_Details_Tab.Controls.Add(this.label6);
            this.Module_Register_Details_Tab.Controls.Add(this.label5);
            this.Module_Register_Details_Tab.Controls.Add(this.label4);
            this.Module_Register_Details_Tab.Controls.Add(this.label3);
            this.Module_Register_Details_Tab.Controls.Add(this.label2);
            this.Module_Register_Details_Tab.Controls.Add(this.Module_Register_Delete_Button);
            this.Module_Register_Details_Tab.Controls.Add(this.Module_Register_Add_Button);
            this.Module_Register_Details_Tab.Controls.Add(this.Module_Registers_List_Box);
            this.Module_Register_Details_Tab.Controls.Add(this.FID_Sheet_Module_Names);
            this.Module_Register_Details_Tab.Controls.Add(this.Active_Sheet_label);
            this.Module_Register_Details_Tab.Controls.Add(this.Module_Register_Bit_Table_Layout);
            this.Module_Register_Details_Tab.Location = new System.Drawing.Point(4, 22);
            this.Module_Register_Details_Tab.Name = "Module_Register_Details_Tab";
            this.Module_Register_Details_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Module_Register_Details_Tab.Size = new System.Drawing.Size(960, 360);
            this.Module_Register_Details_Tab.TabIndex = 4;
            this.Module_Register_Details_Tab.Text = "Register";
            this.Module_Register_Details_Tab.UseVisualStyleBackColor = true;
            // 
            // Module_Registers_List_Box_Heading
            // 
            this.Module_Registers_List_Box_Heading.AutoSize = true;
            this.Module_Registers_List_Box_Heading.Location = new System.Drawing.Point(30, 54);
            this.Module_Registers_List_Box_Heading.Name = "Module_Registers_List_Box_Heading";
            this.Module_Registers_List_Box_Heading.Size = new System.Drawing.Size(142, 13);
            this.Module_Registers_List_Box_Heading.TabIndex = 27;
            this.Module_Registers_List_Box_Heading.Text = "Registers in selected module";
            // 
            // Module_Register_Category_Combo_Box
            // 
            this.Module_Register_Category_Combo_Box.Enabled = false;
            this.Module_Register_Category_Combo_Box.FormattingEnabled = true;
            this.Module_Register_Category_Combo_Box.Items.AddRange(new object[] {
            "None",
            "Configuration",
            "Status"});
            this.Module_Register_Category_Combo_Box.Location = new System.Drawing.Point(733, 16);
            this.Module_Register_Category_Combo_Box.Name = "Module_Register_Category_Combo_Box";
            this.Module_Register_Category_Combo_Box.Size = new System.Drawing.Size(195, 21);
            this.Module_Register_Category_Combo_Box.TabIndex = 26;
            // 
            // Module_Register_Permission_Combo_Box
            // 
            this.Module_Register_Permission_Combo_Box.Enabled = false;
            this.Module_Register_Permission_Combo_Box.FormattingEnabled = true;
            this.Module_Register_Permission_Combo_Box.Items.AddRange(new object[] {
            "None",
            "Read Only",
            "Write Only",
            "Read/Write"});
            this.Module_Register_Permission_Combo_Box.Location = new System.Drawing.Point(408, 86);
            this.Module_Register_Permission_Combo_Box.Name = "Module_Register_Permission_Combo_Box";
            this.Module_Register_Permission_Combo_Box.Size = new System.Drawing.Size(195, 21);
            this.Module_Register_Permission_Combo_Box.TabIndex = 26;
            // 
            // Module_Register_POR_Text_Box
            // 
            this.Module_Register_POR_Text_Box.Enabled = false;
            this.Module_Register_POR_Text_Box.Location = new System.Drawing.Point(733, 52);
            this.Module_Register_POR_Text_Box.Name = "Module_Register_POR_Text_Box";
            this.Module_Register_POR_Text_Box.Size = new System.Drawing.Size(195, 20);
            this.Module_Register_POR_Text_Box.TabIndex = 25;
            // 
            // Module_Register_Address_Text_Box_Hex
            // 
            this.Module_Register_Address_Text_Box_Hex.Enabled = false;
            this.Module_Register_Address_Text_Box_Hex.Location = new System.Drawing.Point(505, 55);
            this.Module_Register_Address_Text_Box_Hex.Name = "Module_Register_Address_Text_Box_Hex";
            this.Module_Register_Address_Text_Box_Hex.Size = new System.Drawing.Size(98, 20);
            this.Module_Register_Address_Text_Box_Hex.TabIndex = 25;
            this.Module_Register_Address_Text_Box_Hex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Module_Register_Address_Text_Box_KeyDown);
            // 
            // Module_Register_Address_Text_Box
            // 
            this.Module_Register_Address_Text_Box.Location = new System.Drawing.Point(408, 55);
            this.Module_Register_Address_Text_Box.Name = "Module_Register_Address_Text_Box";
            this.Module_Register_Address_Text_Box.Size = new System.Drawing.Size(98, 20);
            this.Module_Register_Address_Text_Box.TabIndex = 25;
            this.Module_Register_Address_Text_Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Module_Register_Address_Text_Box_KeyDown);
            // 
            // Module_Register_Name_Text_Box
            // 
            this.Module_Register_Name_Text_Box.Enabled = false;
            this.Module_Register_Name_Text_Box.Location = new System.Drawing.Point(408, 24);
            this.Module_Register_Name_Text_Box.Name = "Module_Register_Name_Text_Box";
            this.Module_Register_Name_Text_Box.Size = new System.Drawing.Size(195, 20);
            this.Module_Register_Name_Text_Box.TabIndex = 25;
            // 
            // Module_Register_Bit_Position_Text_Box
            // 
            this.Module_Register_Bit_Position_Text_Box.Enabled = false;
            this.Module_Register_Bit_Position_Text_Box.Location = new System.Drawing.Point(744, 187);
            this.Module_Register_Bit_Position_Text_Box.Name = "Module_Register_Bit_Position_Text_Box";
            this.Module_Register_Bit_Position_Text_Box.Size = new System.Drawing.Size(184, 20);
            this.Module_Register_Bit_Position_Text_Box.TabIndex = 25;
            // 
            // Module_Register_Def_Code_Text_Box
            // 
            this.Module_Register_Def_Code_Text_Box.Location = new System.Drawing.Point(342, 187);
            this.Module_Register_Def_Code_Text_Box.Multiline = true;
            this.Module_Register_Def_Code_Text_Box.Name = "Module_Register_Def_Code_Text_Box";
            this.Module_Register_Def_Code_Text_Box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Module_Register_Def_Code_Text_Box.Size = new System.Drawing.Size(261, 155);
            this.Module_Register_Def_Code_Text_Box.TabIndex = 25;
            // 
            // Module_Register_Bit_Description_Text_Box
            // 
            this.Module_Register_Bit_Description_Text_Box.Enabled = false;
            this.Module_Register_Bit_Description_Text_Box.Location = new System.Drawing.Point(744, 220);
            this.Module_Register_Bit_Description_Text_Box.Multiline = true;
            this.Module_Register_Bit_Description_Text_Box.Name = "Module_Register_Bit_Description_Text_Box";
            this.Module_Register_Bit_Description_Text_Box.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Module_Register_Bit_Description_Text_Box.Size = new System.Drawing.Size(184, 122);
            this.Module_Register_Bit_Description_Text_Box.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(294, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Code";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(620, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Bit Position";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(620, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Bit description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(620, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Power On Reset";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(620, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Category";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(294, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Permission";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(294, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Register Name";
            // 
            // Module_Register_Delete_Button
            // 
            this.Module_Register_Delete_Button.Enabled = false;
            this.Module_Register_Delete_Button.Location = new System.Drawing.Point(177, 325);
            this.Module_Register_Delete_Button.Name = "Module_Register_Delete_Button";
            this.Module_Register_Delete_Button.Size = new System.Drawing.Size(75, 23);
            this.Module_Register_Delete_Button.TabIndex = 22;
            this.Module_Register_Delete_Button.Text = "Delete";
            this.Module_Register_Delete_Button.UseVisualStyleBackColor = true;
            // 
            // Module_Register_Add_Button
            // 
            this.Module_Register_Add_Button.Enabled = false;
            this.Module_Register_Add_Button.Location = new System.Drawing.Point(30, 325);
            this.Module_Register_Add_Button.Name = "Module_Register_Add_Button";
            this.Module_Register_Add_Button.Size = new System.Drawing.Size(75, 23);
            this.Module_Register_Add_Button.TabIndex = 21;
            this.Module_Register_Add_Button.Text = "Add";
            this.Module_Register_Add_Button.UseVisualStyleBackColor = true;
            // 
            // Module_Registers_List_Box
            // 
            this.Module_Registers_List_Box.FormattingEnabled = true;
            this.Module_Registers_List_Box.HorizontalScrollbar = true;
            this.Module_Registers_List_Box.Location = new System.Drawing.Point(30, 75);
            this.Module_Registers_List_Box.Name = "Module_Registers_List_Box";
            this.Module_Registers_List_Box.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.Module_Registers_List_Box.Size = new System.Drawing.Size(222, 238);
            this.Module_Registers_List_Box.TabIndex = 20;
            this.Module_Registers_List_Box.DoubleClick += new System.EventHandler(this.Module_Registers_List_Box_DoubleClick);
            // 
            // FID_Sheet_Module_Names
            // 
            this.FID_Sheet_Module_Names.FormattingEnabled = true;
            this.FID_Sheet_Module_Names.Location = new System.Drawing.Point(131, 21);
            this.FID_Sheet_Module_Names.Name = "FID_Sheet_Module_Names";
            this.FID_Sheet_Module_Names.Size = new System.Drawing.Size(121, 21);
            this.FID_Sheet_Module_Names.TabIndex = 18;
            this.FID_Sheet_Module_Names.SelectedIndexChanged += new System.EventHandler(this.FID_Sheet_Module_Names_SelectedIndexChanged);
            // 
            // Active_Sheet_label
            // 
            this.Active_Sheet_label.AutoSize = true;
            this.Active_Sheet_label.Location = new System.Drawing.Point(27, 24);
            this.Active_Sheet_label.Name = "Active_Sheet_label";
            this.Active_Sheet_label.Size = new System.Drawing.Size(42, 13);
            this.Active_Sheet_label.TabIndex = 16;
            this.Active_Sheet_label.Text = "Module";
            // 
            // Module_Register_Bit_Table_Layout
            // 
            this.Module_Register_Bit_Table_Layout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.Module_Register_Bit_Table_Layout.ColumnCount = 1;
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Module_Register_Bit_Table_Layout.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.AddColumns;
            this.Module_Register_Bit_Table_Layout.Location = new System.Drawing.Point(297, 116);
            this.Module_Register_Bit_Table_Layout.Name = "Module_Register_Bit_Table_Layout";
            this.Module_Register_Bit_Table_Layout.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Module_Register_Bit_Table_Layout.RowCount = 1;
            this.Module_Register_Bit_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Module_Register_Bit_Table_Layout.Size = new System.Drawing.Size(631, 60);
            this.Module_Register_Bit_Table_Layout.TabIndex = 19;
            // 
            // Module_Function_Details_Tab
            // 
            this.Module_Function_Details_Tab.Controls.Add(this.Module_Function_Filter_by_Register_Bit_Combobox);
            this.Module_Function_Details_Tab.Controls.Add(this.Module_Function_Filter_by_Register_Combobox);
            this.Module_Function_Details_Tab.Controls.Add(this.label12);
            this.Module_Function_Details_Tab.Controls.Add(this.Module_Function_List_Box_Filter_by_Register_bit);
            this.Module_Function_Details_Tab.Controls.Add(this.Code_Generate_Button);
            this.Module_Function_Details_Tab.Controls.Add(this.Module_Function_Filter_by_Register_Checkbox);
            this.Module_Function_Details_Tab.Controls.Add(this.Selected_Function_Code_Text_Box);
            this.Module_Function_Details_Tab.Controls.Add(this.button1);
            this.Module_Function_Details_Tab.Controls.Add(this.Functions_Tab_Create_Function_Button);
            this.Module_Function_Details_Tab.Controls.Add(this.Module_Functions_List_Box);
            this.Module_Function_Details_Tab.Controls.Add(this.label10);
            this.Module_Function_Details_Tab.Location = new System.Drawing.Point(4, 22);
            this.Module_Function_Details_Tab.Name = "Module_Function_Details_Tab";
            this.Module_Function_Details_Tab.Size = new System.Drawing.Size(960, 360);
            this.Module_Function_Details_Tab.TabIndex = 5;
            this.Module_Function_Details_Tab.Text = "Function";
            this.Module_Function_Details_Tab.UseVisualStyleBackColor = true;
            // 
            // Module_Function_Filter_by_Register_Bit_Combobox
            // 
            this.Module_Function_Filter_by_Register_Bit_Combobox.Enabled = false;
            this.Module_Function_Filter_by_Register_Bit_Combobox.FormattingEnabled = true;
            this.Module_Function_Filter_by_Register_Bit_Combobox.Location = new System.Drawing.Point(113, 88);
            this.Module_Function_Filter_by_Register_Bit_Combobox.Name = "Module_Function_Filter_by_Register_Bit_Combobox";
            this.Module_Function_Filter_by_Register_Bit_Combobox.Size = new System.Drawing.Size(139, 21);
            this.Module_Function_Filter_by_Register_Bit_Combobox.TabIndex = 31;
            this.Module_Function_Filter_by_Register_Bit_Combobox.SelectedIndexChanged += new System.EventHandler(this.Module_Function_Filter_by_Register_Bit_Combobox_SelectedIndexChanged);
            // 
            // Module_Function_Filter_by_Register_Combobox
            // 
            this.Module_Function_Filter_by_Register_Combobox.Enabled = false;
            this.Module_Function_Filter_by_Register_Combobox.FormattingEnabled = true;
            this.Module_Function_Filter_by_Register_Combobox.Location = new System.Drawing.Point(113, 65);
            this.Module_Function_Filter_by_Register_Combobox.Name = "Module_Function_Filter_by_Register_Combobox";
            this.Module_Function_Filter_by_Register_Combobox.Size = new System.Drawing.Size(139, 21);
            this.Module_Function_Filter_by_Register_Combobox.TabIndex = 30;
            this.Module_Function_Filter_by_Register_Combobox.SelectedIndexChanged += new System.EventHandler(this.Module_Function_Filter_by_Register_Combobox_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(27, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Filter by";
            // 
            // Module_Function_List_Box_Filter_by_Register_bit
            // 
            this.Module_Function_List_Box_Filter_by_Register_bit.AutoSize = true;
            this.Module_Function_List_Box_Filter_by_Register_bit.Enabled = false;
            this.Module_Function_List_Box_Filter_by_Register_bit.Location = new System.Drawing.Point(29, 92);
            this.Module_Function_List_Box_Filter_by_Register_bit.Name = "Module_Function_List_Box_Filter_by_Register_bit";
            this.Module_Function_List_Box_Filter_by_Register_bit.Size = new System.Drawing.Size(38, 17);
            this.Module_Function_List_Box_Filter_by_Register_bit.TabIndex = 1;
            this.Module_Function_List_Box_Filter_by_Register_bit.Text = "Bit";
            this.Module_Function_List_Box_Filter_by_Register_bit.UseVisualStyleBackColor = true;
            this.Module_Function_List_Box_Filter_by_Register_bit.CheckedChanged += new System.EventHandler(this.Module_Function_List_Box_Filter_by_Register_bit_CheckedChanged);
            // 
            // Code_Generate_Button
            // 
            this.Code_Generate_Button.Location = new System.Drawing.Point(860, 319);
            this.Code_Generate_Button.Name = "Code_Generate_Button";
            this.Code_Generate_Button.Size = new System.Drawing.Size(75, 23);
            this.Code_Generate_Button.TabIndex = 29;
            this.Code_Generate_Button.Text = "Generate";
            this.Code_Generate_Button.UseVisualStyleBackColor = true;
            this.Code_Generate_Button.Click += new System.EventHandler(this.Code_Generate_Button_Click);
            // 
            // Module_Function_Filter_by_Register_Checkbox
            // 
            this.Module_Function_Filter_by_Register_Checkbox.AutoSize = true;
            this.Module_Function_Filter_by_Register_Checkbox.Enabled = false;
            this.Module_Function_Filter_by_Register_Checkbox.Location = new System.Drawing.Point(29, 68);
            this.Module_Function_Filter_by_Register_Checkbox.Name = "Module_Function_Filter_by_Register_Checkbox";
            this.Module_Function_Filter_by_Register_Checkbox.Size = new System.Drawing.Size(65, 17);
            this.Module_Function_Filter_by_Register_Checkbox.TabIndex = 0;
            this.Module_Function_Filter_by_Register_Checkbox.Text = "Register";
            this.Module_Function_Filter_by_Register_Checkbox.UseVisualStyleBackColor = true;
            this.Module_Function_Filter_by_Register_Checkbox.CheckedChanged += new System.EventHandler(this.Module_Function_Filter_by_Register_Checkbox_CheckedChanged);
            // 
            // Selected_Function_Code_Text_Box
            // 
            this.Selected_Function_Code_Text_Box.Location = new System.Drawing.Point(268, 17);
            this.Selected_Function_Code_Text_Box.Name = "Selected_Function_Code_Text_Box";
            this.Selected_Function_Code_Text_Box.Size = new System.Drawing.Size(667, 296);
            this.Selected_Function_Code_Text_Box.TabIndex = 28;
            this.Selected_Function_Code_Text_Box.Text = "";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(177, 325);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Delete";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Functions_Tab_Create_Function_Button
            // 
            this.Functions_Tab_Create_Function_Button.Location = new System.Drawing.Point(30, 325);
            this.Functions_Tab_Create_Function_Button.Name = "Functions_Tab_Create_Function_Button";
            this.Functions_Tab_Create_Function_Button.Size = new System.Drawing.Size(75, 23);
            this.Functions_Tab_Create_Function_Button.TabIndex = 26;
            this.Functions_Tab_Create_Function_Button.Text = "Add";
            this.Functions_Tab_Create_Function_Button.UseVisualStyleBackColor = true;
            this.Functions_Tab_Create_Function_Button.Click += new System.EventHandler(this.Functions_Tab_Create_Function_Button_Click);
            // 
            // Module_Functions_List_Box
            // 
            this.Module_Functions_List_Box.FormattingEnabled = true;
            this.Module_Functions_List_Box.HorizontalScrollbar = true;
            this.Module_Functions_List_Box.Location = new System.Drawing.Point(30, 114);
            this.Module_Functions_List_Box.Name = "Module_Functions_List_Box";
            this.Module_Functions_List_Box.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.Module_Functions_List_Box.Size = new System.Drawing.Size(222, 199);
            this.Module_Functions_List_Box.TabIndex = 25;
            this.Module_Functions_List_Box.DoubleClick += new System.EventHandler(this.Module_Functions_List_Box_DoubleClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Module";
            // 
            // Configs_And_Service_Tab
            // 
            this.Configs_And_Service_Tab.Controls.Add(this.Service_Enum_Text_Box);
            this.Configs_And_Service_Tab.Controls.Add(this.Configuration_Enum_Text_Box);
            this.Configs_And_Service_Tab.Controls.Add(this.Service_List_View);
            this.Configs_And_Service_Tab.Controls.Add(this.Configurations_List_View);
            this.Configs_And_Service_Tab.Controls.Add(this.label25);
            this.Configs_And_Service_Tab.Controls.Add(this.Service_Remove_Button);
            this.Configs_And_Service_Tab.Controls.Add(this.label22);
            this.Configs_And_Service_Tab.Controls.Add(this.Service_Add_Button);
            this.Configs_And_Service_Tab.Controls.Add(this.Configuration_Remove_Button);
            this.Configs_And_Service_Tab.Controls.Add(this.label24);
            this.Configs_And_Service_Tab.Controls.Add(this.Configuration_Add_Button);
            this.Configs_And_Service_Tab.Controls.Add(this.Service_Name_Text_Box);
            this.Configs_And_Service_Tab.Controls.Add(this.label23);
            this.Configs_And_Service_Tab.Controls.Add(this.Service_Description_Text_Box);
            this.Configs_And_Service_Tab.Controls.Add(this.Configuration_Name_Text_Box);
            this.Configs_And_Service_Tab.Controls.Add(this.Configuration_Description_Text_Box);
            this.Configs_And_Service_Tab.Controls.Add(this.label28);
            this.Configs_And_Service_Tab.Controls.Add(this.label27);
            this.Configs_And_Service_Tab.Controls.Add(this.label21);
            this.Configs_And_Service_Tab.Location = new System.Drawing.Point(4, 22);
            this.Configs_And_Service_Tab.Name = "Configs_And_Service_Tab";
            this.Configs_And_Service_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Configs_And_Service_Tab.Size = new System.Drawing.Size(960, 360);
            this.Configs_And_Service_Tab.TabIndex = 10;
            this.Configs_And_Service_Tab.Text = "Config & Service";
            this.Configs_And_Service_Tab.UseVisualStyleBackColor = true;
            // 
            // Service_Enum_Text_Box
            // 
            this.Service_Enum_Text_Box.Location = new System.Drawing.Point(595, 194);
            this.Service_Enum_Text_Box.Multiline = true;
            this.Service_Enum_Text_Box.Name = "Service_Enum_Text_Box";
            this.Service_Enum_Text_Box.Size = new System.Drawing.Size(347, 147);
            this.Service_Enum_Text_Box.TabIndex = 32;
            // 
            // Configuration_Enum_Text_Box
            // 
            this.Configuration_Enum_Text_Box.Location = new System.Drawing.Point(595, 21);
            this.Configuration_Enum_Text_Box.Multiline = true;
            this.Configuration_Enum_Text_Box.Name = "Configuration_Enum_Text_Box";
            this.Configuration_Enum_Text_Box.Size = new System.Drawing.Size(347, 144);
            this.Configuration_Enum_Text_Box.TabIndex = 32;
            // 
            // Service_List_View
            // 
            this.Service_List_View.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.Service_List_View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Service_List_Service_Name_Column,
            this.Service_List_Service_Description_Column});
            this.Service_List_View.FullRowSelect = true;
            this.Service_List_View.GridLines = true;
            this.Service_List_View.Location = new System.Drawing.Point(316, 116);
            this.Service_List_View.MultiSelect = false;
            this.Service_List_View.Name = "Service_List_View";
            this.Service_List_View.Size = new System.Drawing.Size(262, 225);
            this.Service_List_View.TabIndex = 31;
            this.Service_List_View.UseCompatibleStateImageBehavior = false;
            this.Service_List_View.View = System.Windows.Forms.View.Details;
            // 
            // Service_List_Service_Name_Column
            // 
            this.Service_List_Service_Name_Column.Tag = "";
            this.Service_List_Service_Name_Column.Text = "Service";
            this.Service_List_Service_Name_Column.Width = 131;
            // 
            // Service_List_Service_Description_Column
            // 
            this.Service_List_Service_Description_Column.Tag = "";
            this.Service_List_Service_Description_Column.Text = "Description";
            this.Service_List_Service_Description_Column.Width = 125;
            // 
            // Configurations_List_View
            // 
            this.Configurations_List_View.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.Configurations_List_View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Configuration_List_Configuration_Name_Column,
            this.Configuration_List_Configuration_Description_Column});
            this.Configurations_List_View.FullRowSelect = true;
            this.Configurations_List_View.GridLines = true;
            this.Configurations_List_View.Location = new System.Drawing.Point(29, 116);
            this.Configurations_List_View.MultiSelect = false;
            this.Configurations_List_View.Name = "Configurations_List_View";
            this.Configurations_List_View.Size = new System.Drawing.Size(262, 225);
            this.Configurations_List_View.TabIndex = 31;
            this.Configurations_List_View.UseCompatibleStateImageBehavior = false;
            this.Configurations_List_View.View = System.Windows.Forms.View.Details;
            // 
            // Configuration_List_Configuration_Name_Column
            // 
            this.Configuration_List_Configuration_Name_Column.Tag = "";
            this.Configuration_List_Configuration_Name_Column.Text = "Configuration";
            this.Configuration_List_Configuration_Name_Column.Width = 131;
            // 
            // Configuration_List_Configuration_Description_Column
            // 
            this.Configuration_List_Configuration_Description_Column.Tag = "";
            this.Configuration_List_Configuration_Description_Column.Text = "Description";
            this.Configuration_List_Configuration_Description_Column.Width = 125;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(314, 53);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(43, 13);
            this.label25.TabIndex = 29;
            this.label25.Text = "Service";
            // 
            // Service_Remove_Button
            // 
            this.Service_Remove_Button.Location = new System.Drawing.Point(549, 76);
            this.Service_Remove_Button.Name = "Service_Remove_Button";
            this.Service_Remove_Button.Size = new System.Drawing.Size(29, 31);
            this.Service_Remove_Button.TabIndex = 27;
            this.Service_Remove_Button.Text = "x";
            this.Service_Remove_Button.UseVisualStyleBackColor = true;
            this.Service_Remove_Button.Click += new System.EventHandler(this.Service_Remove_Button_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(27, 56);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 13);
            this.label22.TabIndex = 29;
            this.label22.Text = "Configuration";
            // 
            // Service_Add_Button
            // 
            this.Service_Add_Button.Location = new System.Drawing.Point(549, 49);
            this.Service_Add_Button.Name = "Service_Add_Button";
            this.Service_Add_Button.Size = new System.Drawing.Size(29, 21);
            this.Service_Add_Button.TabIndex = 28;
            this.Service_Add_Button.Text = "+";
            this.Service_Add_Button.UseVisualStyleBackColor = true;
            this.Service_Add_Button.Click += new System.EventHandler(this.Service_Add_Button_Click);
            // 
            // Configuration_Remove_Button
            // 
            this.Configuration_Remove_Button.Location = new System.Drawing.Point(262, 79);
            this.Configuration_Remove_Button.Name = "Configuration_Remove_Button";
            this.Configuration_Remove_Button.Size = new System.Drawing.Size(29, 31);
            this.Configuration_Remove_Button.TabIndex = 27;
            this.Configuration_Remove_Button.Text = "x";
            this.Configuration_Remove_Button.UseVisualStyleBackColor = true;
            this.Configuration_Remove_Button.Click += new System.EventHandler(this.Configuration_Remove_Button_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(314, 80);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(60, 13);
            this.label24.TabIndex = 30;
            this.label24.Text = "Description";
            // 
            // Configuration_Add_Button
            // 
            this.Configuration_Add_Button.Location = new System.Drawing.Point(262, 52);
            this.Configuration_Add_Button.Name = "Configuration_Add_Button";
            this.Configuration_Add_Button.Size = new System.Drawing.Size(29, 21);
            this.Configuration_Add_Button.TabIndex = 28;
            this.Configuration_Add_Button.Text = "+";
            this.Configuration_Add_Button.UseVisualStyleBackColor = true;
            this.Configuration_Add_Button.Click += new System.EventHandler(this.Configuration_Add_Button_Click);
            // 
            // Service_Name_Text_Box
            // 
            this.Service_Name_Text_Box.Location = new System.Drawing.Point(394, 50);
            this.Service_Name_Text_Box.Name = "Service_Name_Text_Box";
            this.Service_Name_Text_Box.Size = new System.Drawing.Size(151, 20);
            this.Service_Name_Text_Box.TabIndex = 25;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(27, 83);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(60, 13);
            this.label23.TabIndex = 30;
            this.label23.Text = "Description";
            // 
            // Service_Description_Text_Box
            // 
            this.Service_Description_Text_Box.Location = new System.Drawing.Point(394, 77);
            this.Service_Description_Text_Box.Multiline = true;
            this.Service_Description_Text_Box.Name = "Service_Description_Text_Box";
            this.Service_Description_Text_Box.Size = new System.Drawing.Size(151, 30);
            this.Service_Description_Text_Box.TabIndex = 26;
            // 
            // Configuration_Name_Text_Box
            // 
            this.Configuration_Name_Text_Box.Location = new System.Drawing.Point(107, 53);
            this.Configuration_Name_Text_Box.Name = "Configuration_Name_Text_Box";
            this.Configuration_Name_Text_Box.Size = new System.Drawing.Size(151, 20);
            this.Configuration_Name_Text_Box.TabIndex = 25;
            // 
            // Configuration_Description_Text_Box
            // 
            this.Configuration_Description_Text_Box.Location = new System.Drawing.Point(107, 80);
            this.Configuration_Description_Text_Box.Multiline = true;
            this.Configuration_Description_Text_Box.Name = "Configuration_Description_Text_Box";
            this.Configuration_Description_Text_Box.Size = new System.Drawing.Size(151, 30);
            this.Configuration_Description_Text_Box.TabIndex = 26;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(592, 178);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(73, 13);
            this.label28.TabIndex = 24;
            this.label28.Text = "Service Enum";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(592, 5);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(99, 13);
            this.label27.TabIndex = 24;
            this.label27.Text = "Configuration Enum";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(27, 24);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(42, 13);
            this.label21.TabIndex = 24;
            this.label21.Text = "Module";
            // 
            // Ethernet_Format_Tab
            // 
            this.Ethernet_Format_Tab.Controls.Add(this.label16);
            this.Ethernet_Format_Tab.Controls.Add(this.Command_Header_Config_Panel);
            this.Ethernet_Format_Tab.Controls.Add(this.label26);
            this.Ethernet_Format_Tab.Controls.Add(this.label13);
            this.Ethernet_Format_Tab.Controls.Add(this.Packet_Command_Header_Byte_Size_Label);
            this.Ethernet_Format_Tab.Controls.Add(this.Packet_Header_Config_Panel);
            this.Ethernet_Format_Tab.Location = new System.Drawing.Point(4, 22);
            this.Ethernet_Format_Tab.Name = "Ethernet_Format_Tab";
            this.Ethernet_Format_Tab.Size = new System.Drawing.Size(960, 360);
            this.Ethernet_Format_Tab.TabIndex = 9;
            this.Ethernet_Format_Tab.Text = "Ethernet Format";
            this.Ethernet_Format_Tab.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 173);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(122, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Command Header Fields";
            // 
            // Command_Header_Config_Panel
            // 
            this.Command_Header_Config_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Command_Header_Config_Panel.Controls.Add(this.label17);
            this.Command_Header_Config_Panel.Controls.Add(this.Command_Header_Code);
            this.Command_Header_Config_Panel.Controls.Add(this.label20);
            this.Command_Header_Config_Panel.Controls.Add(this.Command_Header_Byte_Size_Label);
            this.Command_Header_Config_Panel.Controls.Add(this.Command_Field_Add_Button);
            this.Command_Header_Config_Panel.Controls.Add(this.Command_Header_TableLayoutPanel);
            this.Command_Header_Config_Panel.Enabled = false;
            this.Command_Header_Config_Panel.Location = new System.Drawing.Point(3, 189);
            this.Command_Header_Config_Panel.Name = "Command_Header_Config_Panel";
            this.Command_Header_Config_Panel.Size = new System.Drawing.Size(954, 137);
            this.Command_Header_Config_Panel.TabIndex = 11;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(668, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 13);
            this.label17.TabIndex = 10;
            this.label17.Text = "Code";
            // 
            // Command_Header_Code
            // 
            this.Command_Header_Code.Location = new System.Drawing.Point(671, 24);
            this.Command_Header_Code.Multiline = true;
            this.Command_Header_Code.Name = "Command_Header_Code";
            this.Command_Header_Code.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Command_Header_Code.Size = new System.Drawing.Size(272, 101);
            this.Command_Header_Code.TabIndex = 11;
            this.Command_Header_Code.WordWrap = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(5, 104);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(209, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "Total Command Header Size  (bytes)       :  ";
            // 
            // Command_Header_Byte_Size_Label
            // 
            this.Command_Header_Byte_Size_Label.AutoSize = true;
            this.Command_Header_Byte_Size_Label.Location = new System.Drawing.Point(384, 104);
            this.Command_Header_Byte_Size_Label.Name = "Command_Header_Byte_Size_Label";
            this.Command_Header_Byte_Size_Label.Size = new System.Drawing.Size(13, 13);
            this.Command_Header_Byte_Size_Label.TabIndex = 9;
            this.Command_Header_Byte_Size_Label.Tag = "53";
            this.Command_Header_Byte_Size_Label.Text = "8";
            // 
            // Command_Field_Add_Button
            // 
            this.Command_Field_Add_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Command_Field_Add_Button.Location = new System.Drawing.Point(623, 92);
            this.Command_Field_Add_Button.Name = "Command_Field_Add_Button";
            this.Command_Field_Add_Button.Size = new System.Drawing.Size(32, 31);
            this.Command_Field_Add_Button.TabIndex = 8;
            this.Command_Field_Add_Button.Text = "+";
            this.Command_Field_Add_Button.UseVisualStyleBackColor = true;
            this.Command_Field_Add_Button.Click += new System.EventHandler(this.Command_Field_Add_Button_Click);
            // 
            // Command_Header_TableLayoutPanel
            // 
            this.Command_Header_TableLayoutPanel.AllowDrop = true;
            this.Command_Header_TableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.Command_Header_TableLayoutPanel.ColumnCount = 6;
            this.Command_Header_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.Command_Header_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.Command_Header_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.Command_Header_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66666F));
            this.Command_Header_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.Command_Header_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.Command_Header_TableLayoutPanel.Controls.Add(this.Command_Header_OperationType_Label, 1, 0);
            this.Command_Header_TableLayoutPanel.Controls.Add(this.Command_Header_TransferType_Label, 0, 0);
            this.Command_Header_TableLayoutPanel.Controls.Add(this.Command_Header_ModuleIndex_Label, 2, 0);
            this.Command_Header_TableLayoutPanel.Controls.Add(this.Command_Header_Address_Label, 4, 0);
            this.Command_Header_TableLayoutPanel.Controls.Add(this.Command_Header_Length_Label, 5, 0);
            this.Command_Header_TableLayoutPanel.Controls.Add(this.Command_Header_Instance_Num_Label, 3, 0);
            this.Command_Header_TableLayoutPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Command_Header_TableLayoutPanel.Location = new System.Drawing.Point(6, 8);
            this.Command_Header_TableLayoutPanel.Name = "Command_Header_TableLayoutPanel";
            this.Command_Header_TableLayoutPanel.RowCount = 1;
            this.Command_Header_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Command_Header_TableLayoutPanel.Size = new System.Drawing.Size(649, 76);
            this.Command_Header_TableLayoutPanel.TabIndex = 0;
            this.Command_Header_TableLayoutPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.Command_Header_TableLayoutPanel_DragDrop);
            this.Command_Header_TableLayoutPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.Command_Header_TableLayoutPanel_DragEnter);
            // 
            // Command_Header_OperationType_Label
            // 
            this.Command_Header_OperationType_Label.AutoSize = true;
            this.Command_Header_OperationType_Label.ContextMenuStrip = this.Command_Fields_Configure_Context_Menu;
            this.Command_Header_OperationType_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Command_Header_OperationType_Label.Location = new System.Drawing.Point(112, 1);
            this.Command_Header_OperationType_Label.Name = "Command_Header_OperationType_Label";
            this.Command_Header_OperationType_Label.Size = new System.Drawing.Size(101, 74);
            this.Command_Header_OperationType_Label.TabIndex = 0;
            this.Command_Header_OperationType_Label.Text = "Operation Type\r\n4 bits";
            this.Command_Header_OperationType_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Ethernet_Field_ToolTip.SetToolTip(this.Command_Header_OperationType_Label, "Operation to be performed e.g Read, Write and Config. Supports maximum 16 operati" +
        "ons.");
            this.Command_Header_OperationType_Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Command_Fields_MouseDown);
            // 
            // Command_Fields_Configure_Context_Menu
            // 
            this.Command_Fields_Configure_Context_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Command_Configure_Context_Button,
            this.Command_Remove_Context_Button});
            this.Command_Fields_Configure_Context_Menu.Name = "Ethernet_Fields_Configure_Context_Menu";
            this.Command_Fields_Configure_Context_Menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Command_Fields_Configure_Context_Menu.ShowImageMargin = false;
            this.Command_Fields_Configure_Context_Menu.Size = new System.Drawing.Size(103, 48);
            // 
            // Command_Configure_Context_Button
            // 
            this.Command_Configure_Context_Button.Name = "Command_Configure_Context_Button";
            this.Command_Configure_Context_Button.Size = new System.Drawing.Size(102, 22);
            this.Command_Configure_Context_Button.Text = "Configure";
            this.Command_Configure_Context_Button.Click += new System.EventHandler(this.Command_Configure_Context_Button_Click);
            // 
            // Command_Remove_Context_Button
            // 
            this.Command_Remove_Context_Button.Name = "Command_Remove_Context_Button";
            this.Command_Remove_Context_Button.Size = new System.Drawing.Size(102, 22);
            this.Command_Remove_Context_Button.Text = "Remove";
            this.Command_Remove_Context_Button.Click += new System.EventHandler(this.Command_Remove_Context_Button_Click);
            // 
            // Command_Header_TransferType_Label
            // 
            this.Command_Header_TransferType_Label.AutoSize = true;
            this.Command_Header_TransferType_Label.ContextMenuStrip = this.Command_Fields_Configure_Context_Menu;
            this.Command_Header_TransferType_Label.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Command_Header_TransferType_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Command_Header_TransferType_Label.Location = new System.Drawing.Point(4, 1);
            this.Command_Header_TransferType_Label.Name = "Command_Header_TransferType_Label";
            this.Command_Header_TransferType_Label.Size = new System.Drawing.Size(101, 74);
            this.Command_Header_TransferType_Label.TabIndex = 0;
            this.Command_Header_TransferType_Label.Text = "TransferType\r\n1 bits";
            this.Command_Header_TransferType_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Ethernet_Field_ToolTip.SetToolTip(this.Command_Header_TransferType_Label, "This field specifies whether command is polling or service type. ");
            this.Command_Header_TransferType_Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Command_Fields_MouseDown);
            // 
            // Command_Header_ModuleIndex_Label
            // 
            this.Command_Header_ModuleIndex_Label.AutoSize = true;
            this.Command_Header_ModuleIndex_Label.ContextMenuStrip = this.Command_Fields_Configure_Context_Menu;
            this.Command_Header_ModuleIndex_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Command_Header_ModuleIndex_Label.Location = new System.Drawing.Point(220, 1);
            this.Command_Header_ModuleIndex_Label.Name = "Command_Header_ModuleIndex_Label";
            this.Command_Header_ModuleIndex_Label.Size = new System.Drawing.Size(101, 74);
            this.Command_Header_ModuleIndex_Label.TabIndex = 1;
            this.Command_Header_ModuleIndex_Label.Text = "Module Index\r\n8 bits";
            this.Command_Header_ModuleIndex_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Ethernet_Field_ToolTip.SetToolTip(this.Command_Header_ModuleIndex_Label, "Index of module to configure.  Maximum 256 modules can be configured");
            this.Command_Header_ModuleIndex_Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Command_Fields_MouseDown);
            // 
            // Command_Header_Address_Label
            // 
            this.Command_Header_Address_Label.AutoSize = true;
            this.Command_Header_Address_Label.ContextMenuStrip = this.Command_Fields_Configure_Context_Menu;
            this.Command_Header_Address_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Command_Header_Address_Label.Location = new System.Drawing.Point(435, 1);
            this.Command_Header_Address_Label.Name = "Command_Header_Address_Label";
            this.Command_Header_Address_Label.Size = new System.Drawing.Size(101, 74);
            this.Command_Header_Address_Label.TabIndex = 2;
            this.Command_Header_Address_Label.Text = "Address\r\n20 bits";
            this.Command_Header_Address_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Ethernet_Field_ToolTip.SetToolTip(this.Command_Header_Address_Label, "Offset address or index of configuration to be done. Maximum 1048576 address/offs" +
        "ets can be configured");
            this.Command_Header_Address_Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Command_Fields_MouseDown);
            // 
            // Command_Header_Length_Label
            // 
            this.Command_Header_Length_Label.AutoSize = true;
            this.Command_Header_Length_Label.ContextMenuStrip = this.Command_Fields_Configure_Context_Menu;
            this.Command_Header_Length_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Command_Header_Length_Label.Location = new System.Drawing.Point(543, 1);
            this.Command_Header_Length_Label.Name = "Command_Header_Length_Label";
            this.Command_Header_Length_Label.Size = new System.Drawing.Size(102, 74);
            this.Command_Header_Length_Label.TabIndex = 3;
            this.Command_Header_Length_Label.Text = "Length\r\n20 bits";
            this.Command_Header_Length_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Ethernet_Field_ToolTip.SetToolTip(this.Command_Header_Length_Label, "Number of data offsets succeeding command header.  Maximum 1048576 words of data " +
        "transfer supported");
            this.Command_Header_Length_Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Command_Fields_MouseDown);
            // 
            // Command_Header_Instance_Num_Label
            // 
            this.Command_Header_Instance_Num_Label.AutoSize = true;
            this.Command_Header_Instance_Num_Label.ContextMenuStrip = this.Command_Fields_Configure_Context_Menu;
            this.Command_Header_Instance_Num_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Command_Header_Instance_Num_Label.Location = new System.Drawing.Point(328, 1);
            this.Command_Header_Instance_Num_Label.Name = "Command_Header_Instance_Num_Label";
            this.Command_Header_Instance_Num_Label.Size = new System.Drawing.Size(100, 74);
            this.Command_Header_Instance_Num_Label.TabIndex = 4;
            this.Command_Header_Instance_Num_Label.Text = "Instance\r\n4 bits";
            this.Command_Header_Instance_Num_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Ethernet_Field_ToolTip.SetToolTip(this.Command_Header_Instance_Num_Label, "Instance of module to configure.  Maximum 16 instances of each modules can be con" +
        "figured");
            this.Command_Header_Instance_Num_Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Command_Fields_MouseDown);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(9, 338);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(353, 13);
            this.label26.TabIndex = 10;
            this.label26.Text = "Total Packet Header + Command Header Size  (bytes)       :  ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 13);
            this.label13.TabIndex = 10;
            this.label13.Text = "Packet Header Fields";
            // 
            // Packet_Command_Header_Byte_Size_Label
            // 
            this.Packet_Command_Header_Byte_Size_Label.AutoSize = true;
            this.Packet_Command_Header_Byte_Size_Label.Location = new System.Drawing.Point(388, 338);
            this.Packet_Command_Header_Byte_Size_Label.Name = "Packet_Command_Header_Byte_Size_Label";
            this.Packet_Command_Header_Byte_Size_Label.Size = new System.Drawing.Size(19, 13);
            this.Packet_Command_Header_Byte_Size_Label.TabIndex = 9;
            this.Packet_Command_Header_Byte_Size_Label.Text = "20";
            // 
            // Packet_Header_Config_Panel
            // 
            this.Packet_Header_Config_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Packet_Header_Config_Panel.Controls.Add(this.label15);
            this.Packet_Header_Config_Panel.Controls.Add(this.Packet_Header_Code);
            this.Packet_Header_Config_Panel.Controls.Add(this.label14);
            this.Packet_Header_Config_Panel.Controls.Add(this.Packet_Header_Byte_Size_Label);
            this.Packet_Header_Config_Panel.Controls.Add(this.Packet_Field_Add_Button);
            this.Packet_Header_Config_Panel.Controls.Add(this.Packet_Header_TableLayoutPanel);
            this.Packet_Header_Config_Panel.Enabled = false;
            this.Packet_Header_Config_Panel.Location = new System.Drawing.Point(3, 24);
            this.Packet_Header_Config_Panel.Name = "Packet_Header_Config_Panel";
            this.Packet_Header_Config_Panel.Size = new System.Drawing.Size(954, 137);
            this.Packet_Header_Config_Panel.TabIndex = 9;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(668, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Code";
            // 
            // Packet_Header_Code
            // 
            this.Packet_Header_Code.Location = new System.Drawing.Point(671, 24);
            this.Packet_Header_Code.Multiline = true;
            this.Packet_Header_Code.Name = "Packet_Header_Code";
            this.Packet_Header_Code.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Packet_Header_Code.Size = new System.Drawing.Size(272, 101);
            this.Packet_Header_Code.TabIndex = 11;
            this.Packet_Header_Code.WordWrap = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(5, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(196, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Total Packet Header Size  (bytes)       :  ";
            // 
            // Packet_Header_Byte_Size_Label
            // 
            this.Packet_Header_Byte_Size_Label.AutoSize = true;
            this.Packet_Header_Byte_Size_Label.Location = new System.Drawing.Point(384, 104);
            this.Packet_Header_Byte_Size_Label.Name = "Packet_Header_Byte_Size_Label";
            this.Packet_Header_Byte_Size_Label.Size = new System.Drawing.Size(19, 13);
            this.Packet_Header_Byte_Size_Label.TabIndex = 9;
            this.Packet_Header_Byte_Size_Label.Tag = "96";
            this.Packet_Header_Byte_Size_Label.Text = "12";
            // 
            // Packet_Field_Add_Button
            // 
            this.Packet_Field_Add_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Packet_Field_Add_Button.Location = new System.Drawing.Point(623, 90);
            this.Packet_Field_Add_Button.Name = "Packet_Field_Add_Button";
            this.Packet_Field_Add_Button.Size = new System.Drawing.Size(32, 31);
            this.Packet_Field_Add_Button.TabIndex = 8;
            this.Packet_Field_Add_Button.Text = "+";
            this.Packet_Field_Add_Button.UseVisualStyleBackColor = true;
            this.Packet_Field_Add_Button.Click += new System.EventHandler(this.Packet_Field_Add_Button_Click);
            // 
            // Packet_Header_TableLayoutPanel
            // 
            this.Packet_Header_TableLayoutPanel.AllowDrop = true;
            this.Packet_Header_TableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.Packet_Header_TableLayoutPanel.ColumnCount = 3;
            this.Packet_Header_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Packet_Header_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Packet_Header_TableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.Packet_Header_TableLayoutPanel.Controls.Add(this.Packet_Id_Label, 1, 0);
            this.Packet_Header_TableLayoutPanel.Controls.Add(this.Packet_Header_String_Label, 0, 0);
            this.Packet_Header_TableLayoutPanel.Controls.Add(this.Packet_Length_Label, 2, 0);
            this.Packet_Header_TableLayoutPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Packet_Header_TableLayoutPanel.Location = new System.Drawing.Point(6, 8);
            this.Packet_Header_TableLayoutPanel.Name = "Packet_Header_TableLayoutPanel";
            this.Packet_Header_TableLayoutPanel.RowCount = 1;
            this.Packet_Header_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Packet_Header_TableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.Packet_Header_TableLayoutPanel.Size = new System.Drawing.Size(649, 76);
            this.Packet_Header_TableLayoutPanel.TabIndex = 0;
            this.Packet_Header_TableLayoutPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.Packet_Header_TableLayoutPanel_DragDrop);
            this.Packet_Header_TableLayoutPanel.DragEnter += new System.Windows.Forms.DragEventHandler(this.Packet_Header_TableLayoutPanel_DragEnter);
            // 
            // Packet_Id_Label
            // 
            this.Packet_Id_Label.AutoSize = true;
            this.Packet_Id_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Packet_Id_Label.Location = new System.Drawing.Point(220, 1);
            this.Packet_Id_Label.Name = "Packet_Id_Label";
            this.Packet_Id_Label.Size = new System.Drawing.Size(209, 74);
            this.Packet_Id_Label.TabIndex = 0;
            this.Packet_Id_Label.Text = "Id\r\n16 bits";
            this.Packet_Id_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Ethernet_Field_ToolTip.SetToolTip(this.Packet_Id_Label, "Unique Id for each incomming command. Supports 65536 commands simultaenously.");
            this.Packet_Id_Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Packet_Fields_MouseDown);
            // 
            // Packet_Header_String_Label
            // 
            this.Packet_Header_String_Label.AutoSize = true;
            this.Packet_Header_String_Label.ContextMenuStrip = this.Packet_Fields_Configure_Context_Menu;
            this.Packet_Header_String_Label.Cursor = System.Windows.Forms.Cursors.Default;
            this.Packet_Header_String_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Packet_Header_String_Label.Location = new System.Drawing.Point(4, 1);
            this.Packet_Header_String_Label.Name = "Packet_Header_String_Label";
            this.Packet_Header_String_Label.Size = new System.Drawing.Size(209, 74);
            this.Packet_Header_String_Label.TabIndex = 0;
            this.Packet_Header_String_Label.Text = "Header String\r\n\"altera\"\r\n6 bytes";
            this.Packet_Header_String_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Ethernet_Field_ToolTip.SetToolTip(this.Packet_Header_String_Label, "This is the first field of Ethernet Packet. Incoming packets will be checked for " +
        "this string");
            this.Packet_Header_String_Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Packet_Fields_MouseDown);
            // 
            // Packet_Fields_Configure_Context_Menu
            // 
            this.Packet_Fields_Configure_Context_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Packet_Configure_Context_Button,
            this.Packet_Remove_Context_Button});
            this.Packet_Fields_Configure_Context_Menu.Name = "Ethernet_Fields_Configure_Context_Menu";
            this.Packet_Fields_Configure_Context_Menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.Packet_Fields_Configure_Context_Menu.ShowImageMargin = false;
            this.Packet_Fields_Configure_Context_Menu.Size = new System.Drawing.Size(103, 48);
            // 
            // Packet_Configure_Context_Button
            // 
            this.Packet_Configure_Context_Button.Name = "Packet_Configure_Context_Button";
            this.Packet_Configure_Context_Button.Size = new System.Drawing.Size(102, 22);
            this.Packet_Configure_Context_Button.Text = "Configure";
            this.Packet_Configure_Context_Button.Click += new System.EventHandler(this.Configure_Context_Button_Click);
            // 
            // Packet_Remove_Context_Button
            // 
            this.Packet_Remove_Context_Button.Name = "Packet_Remove_Context_Button";
            this.Packet_Remove_Context_Button.Size = new System.Drawing.Size(102, 22);
            this.Packet_Remove_Context_Button.Text = "Remove";
            this.Packet_Remove_Context_Button.Click += new System.EventHandler(this.Ethernet_Field_Remove_Context_Button_Click);
            // 
            // Packet_Length_Label
            // 
            this.Packet_Length_Label.AutoSize = true;
            this.Packet_Length_Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Packet_Length_Label.Location = new System.Drawing.Point(436, 1);
            this.Packet_Length_Label.Name = "Packet_Length_Label";
            this.Packet_Length_Label.Size = new System.Drawing.Size(209, 74);
            this.Packet_Length_Label.TabIndex = 1;
            this.Packet_Length_Label.Text = "Length\r\n32 bits";
            this.Packet_Length_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Ethernet_Field_ToolTip.SetToolTip(this.Packet_Length_Label, "Number of bytes succeeding header. This includes Command and data.  Maximum 42949" +
        "67296 bytes of command and data transfer possible");
            this.Packet_Length_Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Packet_Fields_MouseDown);
            // 
            // rrh_command_response_mapper_tab
            // 
            this.rrh_command_response_mapper_tab.Controls.Add(this.Command_Mapper_Clear_Table_Button);
            this.rrh_command_response_mapper_tab.Controls.Add(this.command_mapper_update_LUT_button);
            this.rrh_command_response_mapper_tab.Controls.Add(this.Command_Mapper_Update_Functions_Button);
            this.rrh_command_response_mapper_tab.Controls.Add(this.Command_Mapper_Add_Module_Button);
            this.rrh_command_response_mapper_tab.Controls.Add(this.Command_Mapper_Add_Command_Button);
            this.rrh_command_response_mapper_tab.Controls.Add(this.Command_Mapper_Table_Layout);
            this.rrh_command_response_mapper_tab.Location = new System.Drawing.Point(4, 22);
            this.rrh_command_response_mapper_tab.Name = "rrh_command_response_mapper_tab";
            this.rrh_command_response_mapper_tab.Padding = new System.Windows.Forms.Padding(3);
            this.rrh_command_response_mapper_tab.Size = new System.Drawing.Size(960, 360);
            this.rrh_command_response_mapper_tab.TabIndex = 8;
            this.rrh_command_response_mapper_tab.Text = "Command Mapper";
            this.rrh_command_response_mapper_tab.UseVisualStyleBackColor = true;
            // 
            // Command_Mapper_Clear_Table_Button
            // 
            this.Command_Mapper_Clear_Table_Button.Location = new System.Drawing.Point(882, 84);
            this.Command_Mapper_Clear_Table_Button.Name = "Command_Mapper_Clear_Table_Button";
            this.Command_Mapper_Clear_Table_Button.Size = new System.Drawing.Size(75, 23);
            this.Command_Mapper_Clear_Table_Button.TabIndex = 3;
            this.Command_Mapper_Clear_Table_Button.Text = "Clear";
            this.Command_Mapper_Clear_Table_Button.UseVisualStyleBackColor = true;
            this.Command_Mapper_Clear_Table_Button.Click += new System.EventHandler(this.Command_Mapper_Clear_Table_Button_Click);
            // 
            // command_mapper_update_LUT_button
            // 
            this.command_mapper_update_LUT_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.command_mapper_update_LUT_button.Location = new System.Drawing.Point(882, 113);
            this.command_mapper_update_LUT_button.Name = "command_mapper_update_LUT_button";
            this.command_mapper_update_LUT_button.Size = new System.Drawing.Size(75, 23);
            this.command_mapper_update_LUT_button.TabIndex = 2;
            this.command_mapper_update_LUT_button.Text = "Update";
            this.command_mapper_update_LUT_button.UseVisualStyleBackColor = true;
            this.command_mapper_update_LUT_button.Click += new System.EventHandler(this.command_mapper_update_LUT_button_Click);
            // 
            // Command_Mapper_Update_Functions_Button
            // 
            this.Command_Mapper_Update_Functions_Button.Location = new System.Drawing.Point(881, 34);
            this.Command_Mapper_Update_Functions_Button.Name = "Command_Mapper_Update_Functions_Button";
            this.Command_Mapper_Update_Functions_Button.Size = new System.Drawing.Size(74, 44);
            this.Command_Mapper_Update_Functions_Button.TabIndex = 1;
            this.Command_Mapper_Update_Functions_Button.Text = "Load Functions";
            this.Ethernet_Field_ToolTip.SetToolTip(this.Command_Mapper_Update_Functions_Button, "Functions of prototype void <function_name>(pCommand_Header ,unsigned int ); will" +
        " be searched in all modules");
            this.Command_Mapper_Update_Functions_Button.UseVisualStyleBackColor = true;
            this.Command_Mapper_Update_Functions_Button.Click += new System.EventHandler(this.Command_Mapper_Update_Functions_Button_Click);
            // 
            // Command_Mapper_Add_Module_Button
            // 
            this.Command_Mapper_Add_Module_Button.Enabled = false;
            this.Command_Mapper_Add_Module_Button.Location = new System.Drawing.Point(881, 6);
            this.Command_Mapper_Add_Module_Button.Name = "Command_Mapper_Add_Module_Button";
            this.Command_Mapper_Add_Module_Button.Size = new System.Drawing.Size(73, 22);
            this.Command_Mapper_Add_Module_Button.TabIndex = 1;
            this.Command_Mapper_Add_Module_Button.Text = "Add Module";
            this.Command_Mapper_Add_Module_Button.UseVisualStyleBackColor = true;
            this.Command_Mapper_Add_Module_Button.Click += new System.EventHandler(this.Command_Mapper_Add_Module_Button_Click);
            // 
            // Command_Mapper_Add_Command_Button
            // 
            this.Command_Mapper_Add_Command_Button.Location = new System.Drawing.Point(8, 332);
            this.Command_Mapper_Add_Command_Button.Name = "Command_Mapper_Add_Command_Button";
            this.Command_Mapper_Add_Command_Button.Size = new System.Drawing.Size(87, 22);
            this.Command_Mapper_Add_Command_Button.TabIndex = 1;
            this.Command_Mapper_Add_Command_Button.Text = "Add Command";
            this.Command_Mapper_Add_Command_Button.UseVisualStyleBackColor = true;
            this.Command_Mapper_Add_Command_Button.Click += new System.EventHandler(this.Command_Mapper_Add_Command_Button_Click);
            // 
            // Command_Mapper_Table_Layout
            // 
            this.Command_Mapper_Table_Layout.AutoScroll = true;
            this.Command_Mapper_Table_Layout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.Command_Mapper_Table_Layout.ColumnCount = 2;
            this.Command_Mapper_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 125F));
            this.Command_Mapper_Table_Layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 877F));
            this.Command_Mapper_Table_Layout.Controls.Add(this.label18, 0, 0);
            this.Command_Mapper_Table_Layout.Location = new System.Drawing.Point(8, 6);
            this.Command_Mapper_Table_Layout.Name = "Command_Mapper_Table_Layout";
            this.Command_Mapper_Table_Layout.RowCount = 2;
            this.Command_Mapper_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.Command_Mapper_Table_Layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.Command_Mapper_Table_Layout.Size = new System.Drawing.Size(867, 320);
            this.Command_Mapper_Table_Layout.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(119, 25);
            this.label18.TabIndex = 0;
            this.label18.Text = "Command \\ Module";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Device_Tree_Details_Tab
            // 
            this.Device_Tree_Details_Tab.Controls.Add(this.Device_List_View);
            this.Device_Tree_Details_Tab.Controls.Add(this.driver_selected_node_delete_button);
            this.Device_Tree_Details_Tab.Controls.Add(this.driver_tree_Node_add_button);
            this.Device_Tree_Details_Tab.Controls.Add(this.label11);
            this.Device_Tree_Details_Tab.Controls.Add(this.Device_Driver_Generate_Button);
            this.Device_Tree_Details_Tab.Controls.Add(this.device_driver_selected_node_treeview);
            this.Device_Tree_Details_Tab.Controls.Add(this.device_tree_tree_view);
            this.Device_Tree_Details_Tab.Controls.Add(this.device_tree_open_button);
            this.Device_Tree_Details_Tab.Controls.Add(this.device_tree_path_text_box);
            this.Device_Tree_Details_Tab.Controls.Add(this.devicetree_parse_button);
            this.Device_Tree_Details_Tab.Location = new System.Drawing.Point(4, 22);
            this.Device_Tree_Details_Tab.Name = "Device_Tree_Details_Tab";
            this.Device_Tree_Details_Tab.Padding = new System.Windows.Forms.Padding(3);
            this.Device_Tree_Details_Tab.Size = new System.Drawing.Size(960, 360);
            this.Device_Tree_Details_Tab.TabIndex = 6;
            this.Device_Tree_Details_Tab.Text = "Drivers";
            this.Device_Tree_Details_Tab.UseVisualStyleBackColor = true;
            // 
            // Device_List_View
            // 
            this.Device_List_View.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.Device_List_View.CheckBoxes = true;
            this.Device_List_View.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Device_Name_List,
            this.Device_Instance_List});
            this.Device_List_View.FullRowSelect = true;
            this.Device_List_View.GridLines = true;
            this.Device_List_View.Location = new System.Drawing.Point(19, 59);
            this.Device_List_View.MultiSelect = false;
            this.Device_List_View.Name = "Device_List_View";
            this.Device_List_View.Size = new System.Drawing.Size(299, 295);
            this.Device_List_View.TabIndex = 24;
            this.Device_List_View.UseCompatibleStateImageBehavior = false;
            this.Device_List_View.View = System.Windows.Forms.View.Details;
            // 
            // Device_Name_List
            // 
            this.Device_Name_List.Tag = "Device";
            this.Device_Name_List.Text = "Device";
            this.Device_Name_List.Width = 170;
            // 
            // Device_Instance_List
            // 
            this.Device_Instance_List.Tag = "Instance";
            this.Device_Instance_List.Text = "Instance";
            this.Device_Instance_List.Width = 125;
            // 
            // driver_selected_node_delete_button
            // 
            this.driver_selected_node_delete_button.Enabled = false;
            this.driver_selected_node_delete_button.Location = new System.Drawing.Point(630, 216);
            this.driver_selected_node_delete_button.Name = "driver_selected_node_delete_button";
            this.driver_selected_node_delete_button.Size = new System.Drawing.Size(34, 23);
            this.driver_selected_node_delete_button.TabIndex = 8;
            this.driver_selected_node_delete_button.Text = "X";
            this.driver_selected_node_delete_button.UseVisualStyleBackColor = true;
            this.driver_selected_node_delete_button.Visible = false;
            this.driver_selected_node_delete_button.Click += new System.EventHandler(this.driver_selected_node_delete_button_Click);
            // 
            // driver_tree_Node_add_button
            // 
            this.driver_tree_Node_add_button.Enabled = false;
            this.driver_tree_Node_add_button.Location = new System.Drawing.Point(630, 177);
            this.driver_tree_Node_add_button.Name = "driver_tree_Node_add_button";
            this.driver_tree_Node_add_button.Size = new System.Drawing.Size(34, 23);
            this.driver_tree_Node_add_button.TabIndex = 7;
            this.driver_tree_Node_add_button.Text = ">>";
            this.driver_tree_Node_add_button.UseVisualStyleBackColor = true;
            this.driver_tree_Node_add_button.Visible = false;
            this.driver_tree_Node_add_button.Click += new System.EventHandler(this.driver_tree_Node_add_button_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Device instances";
            // 
            // Device_Driver_Generate_Button
            // 
            this.Device_Driver_Generate_Button.Location = new System.Drawing.Point(573, 15);
            this.Device_Driver_Generate_Button.Name = "Device_Driver_Generate_Button";
            this.Device_Driver_Generate_Button.Size = new System.Drawing.Size(75, 23);
            this.Device_Driver_Generate_Button.TabIndex = 5;
            this.Device_Driver_Generate_Button.Text = "Generate";
            this.Device_Driver_Generate_Button.UseVisualStyleBackColor = true;
            this.Device_Driver_Generate_Button.Click += new System.EventHandler(this.Device_Driver_Generate_Button_Click);
            // 
            // device_driver_selected_node_treeview
            // 
            this.device_driver_selected_node_treeview.Enabled = false;
            this.device_driver_selected_node_treeview.Location = new System.Drawing.Point(677, 64);
            this.device_driver_selected_node_treeview.Name = "device_driver_selected_node_treeview";
            this.device_driver_selected_node_treeview.Size = new System.Drawing.Size(269, 293);
            this.device_driver_selected_node_treeview.TabIndex = 4;
            this.device_driver_selected_node_treeview.Visible = false;
            // 
            // device_tree_tree_view
            // 
            this.device_tree_tree_view.Enabled = false;
            this.device_tree_tree_view.Location = new System.Drawing.Point(324, 59);
            this.device_tree_tree_view.Name = "device_tree_tree_view";
            this.device_tree_tree_view.Size = new System.Drawing.Size(300, 293);
            this.device_tree_tree_view.TabIndex = 3;
            this.device_tree_tree_view.Visible = false;
            // 
            // device_tree_open_button
            // 
            this.device_tree_open_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.device_tree_open_button.Location = new System.Drawing.Point(317, 16);
            this.device_tree_open_button.Name = "device_tree_open_button";
            this.device_tree_open_button.Size = new System.Drawing.Size(27, 23);
            this.device_tree_open_button.TabIndex = 2;
            this.device_tree_open_button.Text = "...";
            this.device_tree_open_button.UseVisualStyleBackColor = true;
            this.device_tree_open_button.Click += new System.EventHandler(this.device_tree_open_button_Click);
            // 
            // device_tree_path_text_box
            // 
            this.device_tree_path_text_box.Location = new System.Drawing.Point(19, 17);
            this.device_tree_path_text_box.Name = "device_tree_path_text_box";
            this.device_tree_path_text_box.Size = new System.Drawing.Size(300, 20);
            this.device_tree_path_text_box.TabIndex = 1;
            // 
            // devicetree_parse_button
            // 
            this.devicetree_parse_button.Location = new System.Drawing.Point(362, 17);
            this.devicetree_parse_button.Name = "devicetree_parse_button";
            this.devicetree_parse_button.Size = new System.Drawing.Size(53, 22);
            this.devicetree_parse_button.TabIndex = 0;
            this.devicetree_parse_button.Text = "Parse";
            this.devicetree_parse_button.UseVisualStyleBackColor = true;
            this.devicetree_parse_button.Click += new System.EventHandler(this.devicetree_parse_button_Click);
            // 
            // BigCat_logo
            // 
            this.BigCat_logo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BigCat_logo.Image = global::Code_Automation_Tool.Properties.Resources.bigcat_logo;
            this.BigCat_logo.Location = new System.Drawing.Point(776, 8);
            this.BigCat_logo.Name = "BigCat_logo";
            this.BigCat_logo.Size = new System.Drawing.Size(183, 66);
            this.BigCat_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BigCat_logo.TabIndex = 20;
            this.BigCat_logo.TabStop = false;
            this.BigCat_logo.Click += new System.EventHandler(this.BigCat_logo_Click);
            // 
            // Form_Menu_Strip
            // 
            this.Form_Menu_Strip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.Form_Menu_Strip.Location = new System.Drawing.Point(0, 0);
            this.Form_Menu_Strip.Name = "Form_Menu_Strip";
            this.Form_Menu_Strip.Size = new System.Drawing.Size(967, 24);
            this.Form_Menu_Strip.TabIndex = 23;
            this.Form_Menu_Strip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GenerateToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // GenerateToolStripMenuItem
            // 
            this.GenerateToolStripMenuItem.Name = "GenerateToolStripMenuItem";
            this.GenerateToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.GenerateToolStripMenuItem.Text = "&Generate";
            this.GenerateToolStripMenuItem.Click += new System.EventHandler(this.Code_Generate_Button_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.preferencesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.editToolStripMenuItem.Text = "&Tools";
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.preferencesToolStripMenuItem.Text = "&Options";
            this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.preferencesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.feedbackToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // feedbackToolStripMenuItem
            // 
            this.feedbackToolStripMenuItem.Name = "feedbackToolStripMenuItem";
            this.feedbackToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.feedbackToolStripMenuItem.Text = "&Feedback";
            this.feedbackToolStripMenuItem.Click += new System.EventHandler(this.feedbackToolStripMenuItem_Click);
            // 
            // device_tree_open_dialog
            // 
            this.device_tree_open_dialog.DefaultExt = "dts";
            this.device_tree_open_dialog.FileName = "soc_system.dts";
            // 
            // drvr_cat_code_automation_panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(967, 468);
            this.Controls.Add(this.BigCat_logo);
            this.Controls.Add(this.Tab_Control);
            this.Controls.Add(this.File_Parse_Status_strip);
            this.Controls.Add(this.Form_Menu_Strip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MainMenuStrip = this.Form_Menu_Strip;
            this.MaximizeBox = false;
            this.Name = "drvr_cat_code_automation_panel";
            this.Text = "Code Automation Tool";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Driver_Code_Generation_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Application_Code_Generation_FormClosing);
            this.Load += new System.EventHandler(this.Application_Code_Generation_Panel_Load);
            this.File_Parse_Status_strip.ResumeLayout(false);
            this.File_Parse_Status_strip.PerformLayout();
            this.Tab_Control.ResumeLayout(false);
            this.FID_tab.ResumeLayout(false);
            this.FID_tab.PerformLayout();
            this.Module_Register_Details_Tab.ResumeLayout(false);
            this.Module_Register_Details_Tab.PerformLayout();
            this.Module_Function_Details_Tab.ResumeLayout(false);
            this.Module_Function_Details_Tab.PerformLayout();
            this.Configs_And_Service_Tab.ResumeLayout(false);
            this.Configs_And_Service_Tab.PerformLayout();
            this.Ethernet_Format_Tab.ResumeLayout(false);
            this.Ethernet_Format_Tab.PerformLayout();
            this.Command_Header_Config_Panel.ResumeLayout(false);
            this.Command_Header_Config_Panel.PerformLayout();
            this.Command_Header_TableLayoutPanel.ResumeLayout(false);
            this.Command_Header_TableLayoutPanel.PerformLayout();
            this.Command_Fields_Configure_Context_Menu.ResumeLayout(false);
            this.Packet_Header_Config_Panel.ResumeLayout(false);
            this.Packet_Header_Config_Panel.PerformLayout();
            this.Packet_Header_TableLayoutPanel.ResumeLayout(false);
            this.Packet_Header_TableLayoutPanel.PerformLayout();
            this.Packet_Fields_Configure_Context_Menu.ResumeLayout(false);
            this.rrh_command_response_mapper_tab.ResumeLayout(false);
            this.Command_Mapper_Table_Layout.ResumeLayout(false);
            this.Command_Mapper_Table_Layout.PerformLayout();
            this.Device_Tree_Details_Tab.ResumeLayout(false);
            this.Device_Tree_Details_Tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BigCat_logo)).EndInit();
            this.Form_Menu_Strip.ResumeLayout(false);
            this.Form_Menu_Strip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FID_path_text;
        private System.Windows.Forms.Button Parse_FID_button;
        private System.Windows.Forms.OpenFileDialog FID_path_open_dialog;
        private System.Windows.Forms.Button FID_path_open_button;
        private System.Windows.Forms.FolderBrowserDialog Code_Destination_Browser_dialog;
        private System.Windows.Forms.StatusStrip File_Parse_Status_strip;
        private System.Windows.Forms.ToolStripStatusLabel Form_Status_Label;
        private System.Windows.Forms.ToolStripProgressBar Status_Operation_Progress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl Tab_Control;
        private System.Windows.Forms.TabPage FID_tab;
        private System.Windows.Forms.PictureBox BigCat_logo;
        private System.Windows.Forms.MenuStrip Form_Menu_Strip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feedbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel Status_Version_Label;
        private System.Windows.Forms.TabPage Module_Register_Details_Tab;
        private System.Windows.Forms.ComboBox FID_Sheet_Module_Names;
        private System.Windows.Forms.Label Active_Sheet_label;
        private System.Windows.Forms.TableLayoutPanel Module_Register_Bit_Table_Layout;
        private System.Windows.Forms.ListBox Module_Registers_List_Box;
        private System.Windows.Forms.Button Module_Register_Delete_Button;
        private System.Windows.Forms.Button Module_Register_Add_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Module_Register_Bit_Description_Text_Box;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Module_Register_Bit_Position_Text_Box;
        private System.Windows.Forms.TextBox Module_Register_Def_Code_Text_Box;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox Module_Register_POR_Text_Box;
        private System.Windows.Forms.TextBox Module_Register_Address_Text_Box;
        private System.Windows.Forms.TextBox Module_Register_Name_Text_Box;
        private System.Windows.Forms.ComboBox Module_Register_Category_Combo_Box;
        private System.Windows.Forms.ComboBox Module_Register_Permission_Combo_Box;
        private System.Windows.Forms.TabPage Module_Function_Details_Tab;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Functions_Tab_Create_Function_Button;
        private System.Windows.Forms.ListBox Module_Functions_List_Box;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.RichTextBox Selected_Function_Code_Text_Box;
        private System.Windows.Forms.Button Code_Generate_Button;
        private System.Windows.Forms.TabPage Device_Tree_Details_Tab;
        private System.Windows.Forms.Button devicetree_parse_button;
        private System.Windows.Forms.OpenFileDialog device_tree_open_dialog;
        private System.Windows.Forms.TextBox device_tree_path_text_box;
        private System.Windows.Forms.Button device_tree_open_button;
        private System.Windows.Forms.TreeView device_tree_tree_view;
        private System.Windows.Forms.Button Device_Driver_Generate_Button;
        private System.Windows.Forms.TreeView device_driver_selected_node_treeview;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button driver_tree_Node_add_button;
        private System.Windows.Forms.Button driver_selected_node_delete_button;
        private System.Windows.Forms.TabPage rrh_command_response_mapper_tab;
        private System.Windows.Forms.TableLayoutPanel Command_Mapper_Table_Layout;
        private System.Windows.Forms.Button Command_Mapper_Add_Module_Button;
        private System.Windows.Forms.Button Command_Mapper_Add_Command_Button;
        private System.Windows.Forms.Button Command_Mapper_Update_Functions_Button;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button command_mapper_update_LUT_button;
        private System.Windows.Forms.CheckedListBox FID_Parse_Modules_List;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button Add_Modules_List_Button;
        private System.Windows.Forms.Button Command_Mapper_Clear_Table_Button;
        private System.Windows.Forms.ToolStripMenuItem GenerateToolStripMenuItem;
        private System.Windows.Forms.Label Module_Registers_List_Box_Heading;
        private System.Windows.Forms.TextBox Module_Register_Address_Text_Box_Hex;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox Module_Function_List_Box_Filter_by_Register_bit;
        private System.Windows.Forms.CheckBox Module_Function_Filter_by_Register_Checkbox;
        private System.Windows.Forms.ComboBox Module_Function_Filter_by_Register_Bit_Combobox;
        private System.Windows.Forms.ComboBox Module_Function_Filter_by_Register_Combobox;
        private System.Windows.Forms.TabPage Ethernet_Format_Tab;
        private System.Windows.Forms.TableLayoutPanel Packet_Header_TableLayoutPanel;
        private System.Windows.Forms.Label Packet_Id_Label;
        private System.Windows.Forms.Label Packet_Length_Label;
        private ToolTip Ethernet_Field_ToolTip;
        private Label Packet_Header_String_Label;
        private Button Packet_Field_Add_Button;
        private Panel Packet_Header_Config_Panel;
        private Label label13;
        private ContextMenuStrip Packet_Fields_Configure_Context_Menu;
        private ToolStripMenuItem Packet_Configure_Context_Button;
        private Label Packet_Header_Byte_Size_Label;
        private Label label14;
        private Label label15;
        private TextBox Packet_Header_Code;
        private ToolStripMenuItem Packet_Remove_Context_Button;
        private Label label16;
        private Panel Command_Header_Config_Panel;
        private Label label17;
        private TextBox Command_Header_Code;
        private Label label20;
        private Label Command_Header_Byte_Size_Label;
        private Button Command_Field_Add_Button;
        private TableLayoutPanel Command_Header_TableLayoutPanel;
        private Label Command_Header_OperationType_Label;
        private Label Command_Header_TransferType_Label;
        private Label Command_Header_ModuleIndex_Label;
        private Label label26;
        private Label Packet_Command_Header_Byte_Size_Label;
        private Label Command_Header_Address_Label;
        private Label Command_Header_Length_Label;
        private ContextMenuStrip Command_Fields_Configure_Context_Menu;
        private ToolStripMenuItem Command_Configure_Context_Button;
        private ToolStripMenuItem Command_Remove_Context_Button;
        private Label Command_Header_Instance_Num_Label;
        private ListView Device_List_View;
        private ColumnHeader Device_Name_List;
        private ColumnHeader Device_Instance_List;
        private TabPage Configs_And_Service_Tab;
        private Label label21;
        private TextBox Service_Enum_Text_Box;
        private TextBox Configuration_Enum_Text_Box;
        private ListView Service_List_View;
        private ColumnHeader Service_List_Service_Name_Column;
        private ColumnHeader Service_List_Service_Description_Column;
        private ListView Configurations_List_View;
        private ColumnHeader Configuration_List_Configuration_Name_Column;
        private ColumnHeader Configuration_List_Configuration_Description_Column;
        private Label label25;
        private Button Service_Remove_Button;
        private Label label22;
        private Button Service_Add_Button;
        private Button Configuration_Remove_Button;
        private Label label24;
        private Button Configuration_Add_Button;
        private TextBox Service_Name_Text_Box;
        private Label label23;
        private TextBox Service_Description_Text_Box;
        private TextBox Configuration_Name_Text_Box;
        private TextBox Configuration_Description_Text_Box;
        private Label label28;
        private Label label27;
    }
}

