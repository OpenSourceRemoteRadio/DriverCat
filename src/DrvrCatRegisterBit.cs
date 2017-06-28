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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Automation_Tool
{
    class DrvrCatRegisterBit
    {
        public String Bit_Name;
        public int Module_Index;
        public String Module_Name;
        public int Address_offset;
        public int Bit_Position;
        public int Bit_Width;
        public String Bit_Description;
        public List<DrvrCatConfigurationAction> Value_Description;
        //public RegisterCategory Category;
        public DrvrCatRegisterPermission Permission;
        public String Code;
        public List<DrvrCatFunction> Functions_List;
        public String Bit_Struct_Member_Name;
        public DrvrCatEnumeration bit_values_enum;
        public String Register_Name;

        public DrvrCatRegisterBit()
        {
            this.Value_Description = new List<DrvrCatConfigurationAction>();
        }

        internal void Define_Configuration_Value_Description(String Register_Bit_Comment)
        {
            string[] comment_parse;
            string[] comment_lines;

            string bit_configuration;
            int bit_configuration_index;

            string bit_description;
            int bit_description_index;

            string bit_permission;
            int bit_permission_index;

            bit_permission_index = Register_Bit_Comment.IndexOf(Properties.Resources.Bit_Permission_Heading);
            bit_configuration_index = Register_Bit_Comment.IndexOf(Properties.Resources.Bit_Configuration_Heading);
            bit_description_index = Register_Bit_Comment.IndexOf(Properties.Resources.Bit_Description_Heading);

            if (bit_permission_index >= 0)
            {
                bit_permission = Register_Bit_Comment.Substring(0, bit_description_index);
                bit_permission = bit_permission.Remove(0, Properties.Resources.Bit_Permission_Heading.Length);
                bit_permission = bit_permission.Trim();
                this.Permission = this.Permission.Get_Permission_by_String(bit_permission);
            }

           
            if (bit_configuration_index >= 0)
            {
                bit_configuration = Register_Bit_Comment.Substring(bit_configuration_index);
                bit_configuration = bit_configuration.Remove(0, Properties.Resources.Bit_Configuration_Heading.Length);
                comment_lines = bit_configuration.Split(new char[] { '\n' }, StringSplitOptions.None);
                foreach (string current_comment_line in comment_lines)
                {
                    comment_parse = current_comment_line.Split(new char[] { ' ' }, 2);
                    if (comment_parse.Length == 2)
                    {
                        DrvrCatConfigurationAction Current_Configuration_Instance = new DrvrCatConfigurationAction();
                        Current_Configuration_Instance.configuration_value = Convert.ToUInt32(comment_parse[0], 2);
                        Current_Configuration_Instance.configuration_result = comment_parse[1].Replace("\r","");
                        this.Value_Description.Add(Current_Configuration_Instance);
                    }
                }
            }

            
            if (bit_description_index >= 0)
            {
                if (bit_configuration_index >= 0)
                {
                    bit_description = Register_Bit_Comment.Substring(bit_description_index, bit_configuration_index - bit_description_index);
                }
                else
                {
                    bit_description = Register_Bit_Comment.Substring(bit_description_index);
                }
                bit_description = bit_description.Remove(0, Properties.Resources.Bit_Description_Heading.Length);
                bit_description = bit_description.Trim();
                this.Bit_Description = bit_description;
            }
            return;
        }

        internal static void Define_Register_Bit_Code(List<DrvrCatRegisterBit> Register_Bit_List)
        {
            int reserved_instance = 0;
            int reserved_bit_width = 0;
            int reserved_start_index = 0;
            int reserved_list_items_to_delete = 0;
            int reserved_start_bit_position = 0;
            bool word_searched = false;


            while (!word_searched)
            {
                for (int Bit_Index = 0; Bit_Index < Register_Bit_List.Count; Bit_Index++)
                {
                    DrvrCatRegisterBit Register_Bit_List_Item = Register_Bit_List.ElementAt(Bit_Index);
                    if (Bit_Index == Register_Bit_List.Count - 1)
                    {
                        word_searched = true;
                    }

                    if (Equals(Register_Bit_List_Item.Bit_Name, DrvrCatWorkSheetManager.RESERVED_KEYWORD) || String.IsNullOrEmpty(Register_Bit_List_Item.Bit_Name))
                    {
                        if (reserved_bit_width == 0)
                        {
                            reserved_instance++;
                            reserved_start_index = Bit_Index;
                            reserved_start_bit_position = Register_Bit_List_Item.Bit_Position;
                            reserved_list_items_to_delete = 0;
                        }
                        reserved_list_items_to_delete++;
                        reserved_bit_width += Register_Bit_List_Item.Bit_Width;
                    }
                    else
                    {
                        if (reserved_bit_width > 0)
                        {
                            Register_Bit_List.RemoveRange(reserved_start_index, reserved_list_items_to_delete - 1);
                            Register_Bit_List_Item = Register_Bit_List.ElementAt(reserved_start_index);
                            Register_Bit_List_Item.Bit_Name = Properties.Settings.Default.Code_Reserved_Keyword + reserved_instance.ToString();
                            Register_Bit_List_Item.Bit_Position = reserved_start_bit_position;
                            Register_Bit_List_Item.Bit_Width = reserved_bit_width;
                            reserved_list_items_to_delete = 0;
                            reserved_bit_width = 0;
                            break;
                        }
                    }
                } 
            }

            if (reserved_bit_width > 0)
            {
                Register_Bit_List.RemoveRange(reserved_start_index, reserved_list_items_to_delete - 1);
                DrvrCatRegisterBit Register_Bit_List_Item = Register_Bit_List.ElementAt(reserved_start_index);
                Register_Bit_List_Item.Bit_Name = Properties.Settings.Default.Code_Reserved_Keyword + reserved_instance.ToString();
                Register_Bit_List_Item.Bit_Position = reserved_start_bit_position;
                Register_Bit_List_Item.Bit_Width = reserved_bit_width;
                reserved_list_items_to_delete = 0;
                reserved_bit_width = 0;
            }

            foreach (var Register_Bit_Item in Register_Bit_List)
            {
                Register_Bit_Item.Bit_Struct_Member_Name = String.Copy(Register_Bit_Item.Bit_Name.Replace("\n","").Replace("\r","").Trim().Replace(" ", "_"));
                Register_Bit_Item.Code = "unsigned int " + Register_Bit_Item.Bit_Struct_Member_Name + " : " + Register_Bit_Item.Bit_Width;
            }

            return;
        }

        internal static DrvrCatRegisterBit Get_Register_Bit_by_BitName(List<DrvrCatRegisterBit> Register_Bit_List, String Bit_Name)
        {
            DrvrCatRegisterBit Register_Bit_to_return = null;
            foreach (var current_bit in Register_Bit_List)
            {
                if (current_bit.Bit_Name.Equals(Bit_Name))
                {
                    Register_Bit_to_return = current_bit;
                    break;
                }
            }
            return Register_Bit_to_return;
        }

        internal void Define_Enumeration_Code()
        {
            if (this.Value_Description.Count > 0)
            {
                this.bit_values_enum = new DrvrCatEnumeration();
                this.bit_values_enum.Enumeration_Name = this.Module_Name.ToUpper().Trim().Replace(" ", "_") + "_" + this.Register_Name.Trim().Replace(" ", "_") + "_" + this.Bit_Name.Trim().Replace(" ", "_") + "_Enum_Def";
                this.bit_values_enum.Enumeration_Description = (this.Bit_Description!=null) ? String.Copy(this.Bit_Description) : "";
                for (int index = 0; index < this.Value_Description.Count; index++)
                {
                    DrvrCatConfigurationAction config_action = this.Value_Description.ElementAt(index);
                    this.bit_values_enum.Enumeration_members.Add(this.Module_Name.ToUpper().Trim().Replace(" ", "_") + "_" + this.Bit_Name.Trim().Replace(" ", "_") + "_" +config_action.configuration_result.Trim().Replace(" ", "_"));
                    this.bit_values_enum.Enumeration_values.Add(config_action.configuration_value);
                    this.bit_values_enum.Enumeration_member_description.Add(config_action.configuration_result);
                }
                DrvrCatCodeBuilder enum_code_builder = new DrvrCatCodeBuilder();
                enum_code_builder.Define_Bit_Typedef_Enumeration(this.bit_values_enum,this.Module_Name);
                this.bit_values_enum.Enumeration_Code =  String.Copy(enum_code_builder.GetCode());
            }
            return;
        }

        internal void Define_Function_Code(String Resource_Name, String Reg_Map_Struct_Definition_Name,String Register_Struct_Definition_Name,int Register_instance_count)
        {
            if (!(String.IsNullOrEmpty(this.Bit_Name) || String.IsNullOrWhiteSpace(this.Bit_Name) || this.Bit_Name.ToLower().Equals("reserved") || this.Bit_Struct_Member_Name.Contains(Properties.Settings.Default.Code_Reserved_Keyword)))// this.Value_Description.Count > 0)
            {
                this.Functions_List = new List<DrvrCatFunction>();

                if ((this.Permission == DrvrCatRegisterPermission.Write_Only) || (this.Permission == DrvrCatRegisterPermission.Read_Write))
                {
                    for (int index = 0; index < this.Value_Description.Count; index++)
                    {
                        DrvrCatConfigurationAction config_action = this.Value_Description.ElementAt(index);
                        DrvrCatFunction config_function_without_param = new DrvrCatFunction();
                        config_function_without_param.Module_Name = this.Module_Name;
                        config_function_without_param.Module_Index = this.Module_Index;

                        config_function_without_param.Function_Description = String.Copy("Configure " + config_action.configuration_result);

                        config_function_without_param.return_item.Function_Return_type = "void";
                        config_function_without_param.return_item.Return_Description = String.Empty;
                        config_function_without_param.Function_Name = String.Copy(Properties.Settings.Default.Project_Name.Trim().Replace(" ", "_") + "_" + this.Module_Name.ToLower().Trim().Replace(" ", "_") + "_" + this.Register_Name.ToLower().Trim().Replace(" ", "_") + "_" + this.Bit_Name.ToLower().Trim().Replace(" ", "_") + "_config_" + config_action.configuration_result.Trim().Replace(" ", "_"));

                        config_function_without_param.Parameters = new List<DrvrCatFunctionParameter>();
                        //Function_Parameter reg_map_address_param = new Function_Parameter();
                        //reg_map_address_param.data_type = "p" + Reg_Map_Struct_Definition_Name;
                        //String reg_map_ptr_name = this.Module_Name.Trim().Replace(" ", "_") + "_regmap_ptr";
                        //reg_map_address_param.parameter_name = reg_map_ptr_name;
                        //reg_map_address_param.parameter_description = "Remapped address of " + this.Module_Name + " register map ";
                        //config_function_without_param.Parameters.Add(reg_map_address_param);

                        String reg_map_ptr_name = Resource_Name.Trim().Replace(" ","_") + "_ptr";

                        DrvrCatFunctionParameter device_handler_param = new DrvrCatFunctionParameter();
                        device_handler_param.data_type = "pdevice_handler";
                        device_handler_param.parameter_name = this.Module_Name.Trim().Replace(" ", "_") + "_device_handler";
                        device_handler_param.parameter_description = "Device handler " + this.Module_Name + " required instance ";
                        config_function_without_param.Parameters.Add(device_handler_param);


                        if (Register_instance_count > 1)
                        {
                            DrvrCatFunctionParameter register_index_param = new DrvrCatFunctionParameter();
                            register_index_param.data_type = "unsigned int";
                            register_index_param.parameter_name = "register_index";
                            register_index_param.parameter_description = "Index of " + Register_Struct_Definition_Name + " need to configure";
                            config_function_without_param.Parameters.Add(register_index_param);
                        }


                        DrvrCatCodeBuilder function_statements_builder = new DrvrCatCodeBuilder();

                        function_statements_builder.AddStatement("p" + Reg_Map_Struct_Definition_Name + " resource_ptr = (p" + Reg_Map_Struct_Definition_Name + ") " + device_handler_param.parameter_name + "->reg_remap_addr[" + Properties.Settings.Default.Project_Name + "_" + this.Module_Name.ToLower().Trim() + "_" + Resource_Name.Trim().Replace(" ", "_").ToUpper() + "_RESOURCE_INDEX]");

                        if (Register_instance_count > 1)
                        {
                            function_statements_builder.AddStatement("resource_ptr" + "->" + Register_Struct_Definition_Name + "[" + "register_index" + "]" + ".reg." + this.Bit_Struct_Member_Name + " = " + this.bit_values_enum.Enumeration_members.ElementAt(index));
                        }
                        else
                        {
                            function_statements_builder.AddStatement("resource_ptr" + "->" + Register_Struct_Definition_Name + ".reg." + this.Bit_Struct_Member_Name + " = " + this.bit_values_enum.Enumeration_members.ElementAt(index));
                        }
                        function_statements_builder.AddStatement("return");
                        config_function_without_param.Function_Statements = String.Copy(function_statements_builder.GetCode());




                        DrvrCatCodeBuilder function_code_builder = new DrvrCatCodeBuilder();
                        function_code_builder.Define_Function_Code(config_function_without_param);
                        config_function_without_param.Code = String.Copy(function_code_builder.GetCode());
                        this.Functions_List.Add(config_function_without_param);
                    }

                    if (true)// this.Value_Description.Count > 1)
                    {
                        DrvrCatFunction config_function_with_param = new DrvrCatFunction();
                        config_function_with_param.Module_Name = this.Module_Name;
                        config_function_with_param.Module_Index = this.Module_Index;

                        config_function_with_param.Function_Description = String.Copy("Configure " + this.Bit_Name + " based on input parameter");

                        config_function_with_param.return_item.Function_Return_type = "void";
                        config_function_with_param.return_item.Return_Description = String.Empty;
                        config_function_with_param.Function_Name = String.Copy(Properties.Settings.Default.Project_Name.Trim().Replace(" ", "_") + "_" + this.Module_Name.ToLower().Trim().Replace(" ", "_") + "_" + this.Register_Name.ToLower().Trim().Replace(" ", "_") + "_config_" + this.Bit_Name.Trim().Replace(" ", "_"));

                        config_function_with_param.Parameters = new List<DrvrCatFunctionParameter>();
                        //Function_Parameter reg_map_address_param = new Function_Parameter();
                        //reg_map_address_param.data_type = "p" + Reg_Map_Struct_Definition_Name;
                        //String reg_map_ptr_name = this.Module_Name.Trim().Replace(" ", "_") + "_regmap_ptr";
                        //reg_map_address_param.parameter_name = reg_map_ptr_name;
                        //reg_map_address_param.parameter_description = "Remapped address of " + this.Module_Name + " register map ";
                        //config_function_without_param.Parameters.Add(reg_map_address_param);

                        String reg_map_ptr_name = Resource_Name.Trim().Replace(" ", "_") + "_ptr";

                        DrvrCatFunctionParameter device_handler_param = new DrvrCatFunctionParameter();
                        device_handler_param.data_type = "pdevice_handler";
                        device_handler_param.parameter_name = this.Module_Name.Trim().Replace(" ", "_") + "_device_handler";
                        device_handler_param.parameter_description = "Device handler " + this.Module_Name + " required instance ";
                        config_function_with_param.Parameters.Add(device_handler_param);


                        if (Register_instance_count > 1)
                        {
                            DrvrCatFunctionParameter register_index_param = new DrvrCatFunctionParameter();
                            register_index_param.data_type = "unsigned int";
                            register_index_param.parameter_name = "register_index";
                            register_index_param.parameter_description = "Index of " + Register_Struct_Definition_Name + " need to configure";
                            config_function_with_param.Parameters.Add(register_index_param);
                        }


                        DrvrCatFunctionParameter register_configuration_param = new DrvrCatFunctionParameter();
                        register_configuration_param.data_type = (this.bit_values_enum != null) ? this.bit_values_enum.Enumeration_Name : "unsigned int";
                        String input_configuration_name = this.Bit_Name.Trim().Replace(" ", "_") + "_configuration";
                        register_configuration_param.parameter_name = input_configuration_name;
                        register_configuration_param.parameter_description = "Input configuration of " + this.Bit_Name;
                        config_function_with_param.Parameters.Add(register_configuration_param);


                        DrvrCatCodeBuilder function_statements_builder = new DrvrCatCodeBuilder();

                        function_statements_builder.AddStatement("p" + Reg_Map_Struct_Definition_Name + " resource_ptr = (p" + Reg_Map_Struct_Definition_Name + ")" + device_handler_param.parameter_name + "->reg_remap_addr[" + Properties.Settings.Default.Project_Name + "_" + this.Module_Name.ToLower().Trim() + "_" + Resource_Name.Trim().Replace(" ", "_").ToUpper() + "_RESOURCE_INDEX]");

                        if (Register_instance_count > 1)
                        {
                            function_statements_builder.AddStatement("resource_ptr" + "->" + Register_Struct_Definition_Name + "[" + "register_index" + "]" + ".reg." + this.Bit_Struct_Member_Name + " = " + input_configuration_name);
                        }
                        else
                        {
                            function_statements_builder.AddStatement("resource_ptr" + "->" + Register_Struct_Definition_Name + ".reg." + this.Bit_Struct_Member_Name + " = " + input_configuration_name);
                        }


                        function_statements_builder.AddStatement("return");
                        config_function_with_param.Function_Statements = String.Copy(function_statements_builder.GetCode());


                        DrvrCatCodeBuilder function_code_builder = new DrvrCatCodeBuilder();
                        function_code_builder.Define_Function_Code(config_function_with_param);
                        config_function_with_param.Code = String.Copy(function_code_builder.GetCode());

                        this.Functions_List.Add(config_function_with_param);
                    }
                }

                if((this.Permission == DrvrCatRegisterPermission.Read_Only)  || (this.Permission == DrvrCatRegisterPermission.Read_Write))
                {
                    {
                        DrvrCatFunction status_function_enum_return = new DrvrCatFunction();
                        status_function_enum_return.Module_Name = this.Module_Name;
                        status_function_enum_return.Module_Index = this.Module_Index;

                        status_function_enum_return.Function_Description = String.Copy("Read " + this.Bit_Name);

                        status_function_enum_return.return_item.Function_Return_type = (this.bit_values_enum != null) ? this.bit_values_enum.Enumeration_Name : "unsigned int";

                        status_function_enum_return.return_item.Return_Description = "Returns current value of " + this.Bit_Name;

                        if (this.bit_values_enum != null)
                        {
                            if (this.bit_values_enum.Enumeration_members.Count > 0)
                            {
                                status_function_enum_return.return_item.return_values = new List<DrvrCatFunctionReturnValue>();
                                for (int return_index = 0; return_index < this.bit_values_enum.Enumeration_members.Count; return_index++)
                                {
                                    DrvrCatFunctionReturnValue return_item = new DrvrCatFunctionReturnValue();
                                    return_item.Return_Value = this.bit_values_enum.Enumeration_members.ElementAt(return_index);
                                    return_item.Return_Context = this.bit_values_enum.Enumeration_member_description.ElementAt(return_index);
                                    status_function_enum_return.return_item.return_values.Add(return_item);
                                }
                            }

                        }

                        status_function_enum_return.Function_Name = String.Copy(Properties.Settings.Default.Project_Name.Trim().Replace(" ", "_") + "_" + this.Module_Name.ToLower().Trim().Replace(" ", "_") + "_" + this.Register_Name.ToLower().Trim().Replace(" ", "_") + "_read_" + this.Bit_Name.Trim().Replace(" ", "_"));

                        status_function_enum_return.Parameters = new List<DrvrCatFunctionParameter>();
                        //Function_Parameter reg_map_address_param = new Function_Parameter();
                        //reg_map_address_param.data_type = "p" + Reg_Map_Struct_Definition_Name;
                        //String reg_map_ptr_name = this.Module_Name.Trim().Replace(" ", "_") + "_regmap_ptr";
                        //reg_map_address_param.parameter_name = reg_map_ptr_name;
                        //reg_map_address_param.parameter_description = "Remapped address of " + this.Module_Name + " register map ";
                        //config_function_without_param.Parameters.Add(reg_map_address_param);

                        String reg_map_ptr_name = Resource_Name.Trim().Replace(" ", "_") + "_ptr";

                        DrvrCatFunctionParameter device_handler_param = new DrvrCatFunctionParameter();
                        device_handler_param.data_type = "pdevice_handler";
                        device_handler_param.parameter_name = this.Module_Name.Trim().Replace(" ", "_") + "_device_handler";
                        device_handler_param.parameter_description = "Device handler " + this.Module_Name + " required instance ";
                        status_function_enum_return.Parameters.Add(device_handler_param);



                        if (Register_instance_count > 1)
                        {
                            DrvrCatFunctionParameter register_index_param = new DrvrCatFunctionParameter();
                            register_index_param.data_type = "unsigned int";
                            register_index_param.parameter_name = "register_index";
                            register_index_param.parameter_description = "Index of " + Register_Struct_Definition_Name + " need to get status";
                            status_function_enum_return.Parameters.Add(register_index_param);
                        }



                        DrvrCatCodeBuilder function_statements_builder = new DrvrCatCodeBuilder();
                        function_statements_builder.AddStatement("p" + Reg_Map_Struct_Definition_Name + " resource_ptr = (p" + Reg_Map_Struct_Definition_Name + ") " + device_handler_param.parameter_name + "->reg_remap_addr[" + Properties.Settings.Default.Project_Name + "_" + this.Module_Name.ToLower().Trim() + "_" + Resource_Name.Trim().Replace(" ", "_").ToUpper() + "_RESOURCE_INDEX]");

                        if (Register_instance_count > 1)
                        {
                            function_statements_builder.AddStatement("return " + "resource_ptr" + "->" + Register_Struct_Definition_Name + "[" + "register_index" + "]" + ".reg." + this.Bit_Struct_Member_Name);
                        }
                        else
                        {
                            function_statements_builder.AddStatement("return " + "resource_ptr" + "->" + Register_Struct_Definition_Name + ".reg." + this.Bit_Struct_Member_Name);
                        }


                        status_function_enum_return.Function_Statements = String.Copy(function_statements_builder.GetCode());


                        DrvrCatCodeBuilder function_code_builder = new DrvrCatCodeBuilder();
                        function_code_builder.Define_Function_Code(status_function_enum_return);
                        status_function_enum_return.Code = String.Copy(function_code_builder.GetCode());

                        this.Functions_List.Add(status_function_enum_return);
                    }

                    for (int index = 0; index < this.Value_Description.Count; index++)
                    {
                        DrvrCatConfigurationAction config_action = this.Value_Description.ElementAt(index);
                        DrvrCatFunction status_function_bool_return = new DrvrCatFunction();
                        status_function_bool_return.Module_Name = this.Module_Name;
                        status_function_bool_return.Module_Index = this.Module_Index;

                        status_function_bool_return.Function_Description = String.Copy("Check " + this.Bit_Name + " status is " + config_action.configuration_result);

                        status_function_bool_return.return_item.Function_Return_type = "bool";
                        status_function_bool_return.return_item.Return_Description = "Returns if " + this.Bit_Name + " is " + config_action.configuration_result;

                        status_function_bool_return.return_item.return_values = new List<DrvrCatFunctionReturnValue>();

                        DrvrCatFunctionReturnValue return_item_true = new DrvrCatFunctionReturnValue();
                        return_item_true.Return_Value = "true";
                        return_item_true.Return_Context = this.Bit_Name + " status is " + config_action.configuration_result;
                        status_function_bool_return.return_item.return_values.Add(return_item_true);

                        DrvrCatFunctionReturnValue return_item_false = new DrvrCatFunctionReturnValue();
                        return_item_false.Return_Value = "false";
                        return_item_false.Return_Context = this.Bit_Name + " status is not " + config_action.configuration_result;
                        status_function_bool_return.return_item.return_values.Add(return_item_false);


                        status_function_bool_return.Function_Name = String.Copy(Properties.Settings.Default.Project_Name.Trim().Replace(" ", "_") + "_" + this.Module_Name.ToLower().Trim().Replace(" ", "_") + "_" + this.Register_Name.ToLower().Trim().Replace(" ", "_") + "_is" + this.Bit_Name.Trim().Replace(" ", "_") + "_" + config_action.configuration_result.Trim().Replace(" ", "_"));

                        status_function_bool_return.Parameters = new List<DrvrCatFunctionParameter>();
                        //Function_Parameter reg_map_address_param = new Function_Parameter();
                        //reg_map_address_param.data_type = "p" + Reg_Map_Struct_Definition_Name;
                        //String reg_map_ptr_name = this.Module_Name.Trim().Replace(" ", "_") + "_regmap_ptr";
                        //reg_map_address_param.parameter_name = reg_map_ptr_name;
                        //reg_map_address_param.parameter_description = "Remapped address of " + this.Module_Name + " register map ";
                        //config_function_without_param.Parameters.Add(reg_map_address_param);

                        String reg_map_ptr_name = Resource_Name.Trim().Replace(" ", "_") + "_ptr";

                        DrvrCatFunctionParameter device_handler_param = new DrvrCatFunctionParameter();
                        device_handler_param.data_type = "pdevice_handler";
                        device_handler_param.parameter_name = this.Module_Name.Trim().Replace(" ", "_") + "_device_handler";
                        device_handler_param.parameter_description = "Device handler " + this.Module_Name + " required instance ";
                        status_function_bool_return.Parameters.Add(device_handler_param);

                        if (Register_instance_count > 1)
                        {
                            DrvrCatFunctionParameter register_index_param = new DrvrCatFunctionParameter();
                            register_index_param.data_type = "unsigned int";
                            register_index_param.parameter_name = "register_index";
                            register_index_param.parameter_description = "Index of " + Register_Struct_Definition_Name + " need to get status";
                            status_function_bool_return.Parameters.Add(register_index_param);
                        }


                        DrvrCatCodeBuilder function_statements_builder = new DrvrCatCodeBuilder();

                        function_statements_builder.AddStatement("p" + Reg_Map_Struct_Definition_Name + " resource_ptr = (p" + Reg_Map_Struct_Definition_Name + ") " + device_handler_param.parameter_name + "->reg_remap_addr[" + Properties.Settings.Default.Project_Name + "_" + this.Module_Name.ToLower().Trim() + "_" + Resource_Name.Trim().Replace(" ", "_").ToUpper() + "_RESOURCE_INDEX]");

                        if (Register_instance_count > 1)
                        {
                            function_statements_builder.AddStatement("return (" + "resource_ptr" + "->" + Register_Struct_Definition_Name + "[" + "register_index" + "]" + ".reg." + this.Bit_Struct_Member_Name + " == " + this.bit_values_enum.Enumeration_members.ElementAt(index) + ")");
                        }
                        else
                        {
                            function_statements_builder.AddStatement("return (" + "resource_ptr" + "->" + Register_Struct_Definition_Name + ".reg." + this.Bit_Struct_Member_Name + " == " + this.bit_values_enum.Enumeration_members.ElementAt(index) + ")");
                        }
                        status_function_bool_return.Function_Statements = String.Copy(function_statements_builder.GetCode());


                        DrvrCatCodeBuilder function_code_builder = new DrvrCatCodeBuilder();
                        function_code_builder.Define_Function_Code(status_function_bool_return);
                        status_function_bool_return.Code = String.Copy(function_code_builder.GetCode());
                        this.Functions_List.Add(status_function_bool_return);
                    }
                }

                       





            }
            return;
        }
    }
}
