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
using Excel = Microsoft.Office.Interop.Excel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_Automation_Tool
{
    class DrvrCatModule
    {
        public int Module_Index;
        public String Module_Name;
        public List<DrvrCatModuleResource> Resources;
        public List<DrvrCatFunction> Module_functions_list;
        public List<String> Instances_Name_List;
        public List<DrvrCatConfigServiceItem> Config_List =  new List<DrvrCatConfigServiceItem>();
        public List<DrvrCatConfigServiceItem> Service_List =  new List<DrvrCatConfigServiceItem>();
        public DrvrCatEnumeration Config_List_Enumeration = new DrvrCatEnumeration();
        public DrvrCatEnumeration Service_List_Enumeration = new DrvrCatEnumeration();


        public DrvrCatModule(int module_index,String module_name)
        {
            this.Module_Index = module_index;
            this.Module_Name = module_name;
            this.Resources = new List<DrvrCatModuleResource>();
            Instances_Name_List = new List<string>();
        }



        internal static DrvrCatModule Get_ModuleRegmap_by_Module_Index(List<DrvrCatModule> Module_Regmap_List,int module_index)
        {
            DrvrCatModule Module_Regmap_to_return = null;
            foreach (var module in Module_Regmap_List)
            {
                if (module_index == module.Module_Index)
                {
                    Module_Regmap_to_return = module;
                    break;
                }
            }
            return Module_Regmap_to_return;
        }

        internal void Define_Register_Read_Function()
        {
            DrvrCatFunction register_read_function = new DrvrCatFunction();

            register_read_function.Function_Name = Properties.Settings.Default.Project_Name + "_" + this.Module_Name.ToLower().Trim() + "_" + "reg_read";
            register_read_function.Function_Description = "Register read command handler";
            register_read_function.return_item.Function_Return_type = "void";
            register_read_function.return_item.Return_Description = "Function will not return anything";

            register_read_function.Module_Index = this.Module_Index;
            register_read_function.Module_Name = String.Copy(this.Module_Name);

            register_read_function.Parameters = new List<DrvrCatFunctionParameter>();

            DrvrCatFunctionParameter cmdhandler_param = new DrvrCatFunctionParameter();
            cmdhandler_param.data_type = String.Copy("pCommand_Header");
            cmdhandler_param.parameter_description = String.Copy("Command packet");
            cmdhandler_param.parameter_name = String.Copy("pCmdHeader");
            register_read_function.Parameters.Add(cmdhandler_param);

            DrvrCatFunctionParameter packet_id_param = new DrvrCatFunctionParameter();
            packet_id_param.data_type = String.Copy("unsigned int");
            packet_id_param.parameter_description = String.Copy("Command packet id");
            packet_id_param.parameter_name = String.Copy("packet_id");
            register_read_function.Parameters.Add(packet_id_param);



            DrvrCatCodeBuilder register_read_fn_builder = new DrvrCatCodeBuilder();
            register_read_fn_builder.AddStatement("int read_count");
            register_read_fn_builder.AddStatement("pdevice_handler pdev = " + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") +
                        "_" + this.Module_Name.ToLower().Trim() + "_get_handler(pCmdHeader->Instance)");
            register_read_fn_builder.AddStatement("unsigned int Length = pCmdHeader->Length");
            register_read_fn_builder.AddStatement("unsigned int *pData = (unsigned int *)pCmdHeader->pData");
            register_read_fn_builder.AddStatement("unsigned int offset = pCmdHeader->Address");
            register_read_fn_builder.AddStatement("unsigned int resource_index = pCmdHeader->Resource");
            register_read_fn_builder.AddStatement("bus_address resource = pdev->reg_remap_addr[resource_index]");


            register_read_fn_builder.AppendLine("if(pdev!=NULL)");

            register_read_fn_builder.Start_Block();


            register_read_fn_builder.AppendLine("for(read_count=0;read_count<Length;read_count++)");
            register_read_fn_builder.Start_Block();


            register_read_fn_builder.AddStatement("pData[read_count] = (resource[offset+read_count] ) & (pCmdHeader->Bit_Mask) ");

            register_read_fn_builder.End_Block();
            register_read_fn_builder.AddStatement("return");


            register_read_fn_builder.End_Block();

            register_read_function.Function_Statements = String.Copy(register_read_fn_builder.GetCode());

            DrvrCatCodeBuilder function_code_builder = new DrvrCatCodeBuilder();
            function_code_builder.Define_Function_Code(register_read_function);

            register_read_function.Code = String.Copy(function_code_builder.GetCode());


            this.Module_functions_list.Add(register_read_function);

            DrvrCatCodeAutomationPanel.Functions_List_All_Modules.Add(register_read_function);
            DrvrCatCodeAutomationPanel.Functions_Name_List_All_Modules.Add(register_read_function.Function_Name);

            return;
        }

        internal void Define_Register_Write_Function()
        {
            DrvrCatFunction register_write_function = new DrvrCatFunction();

            register_write_function.Function_Name = Properties.Settings.Default.Project_Name + "_" + this.Module_Name.ToLower().Trim() + "_" + "reg_write";
            register_write_function.Function_Description = "Register write command handler";
            register_write_function.return_item.Function_Return_type = "void";
            register_write_function.return_item.Return_Description = "Function will not return anything";

            register_write_function.Module_Index = this.Module_Index;
            register_write_function.Module_Name = String.Copy(this.Module_Name);

            register_write_function.Parameters = new List<DrvrCatFunctionParameter>();

            DrvrCatFunctionParameter cmdhandler_param = new DrvrCatFunctionParameter();
            cmdhandler_param.data_type = String.Copy("pCommand_Header");
            cmdhandler_param.parameter_description = String.Copy("Command packet");
            cmdhandler_param.parameter_name = String.Copy("pCmdHeader");
            register_write_function.Parameters.Add(cmdhandler_param);

            DrvrCatFunctionParameter packet_id_param = new DrvrCatFunctionParameter();
            packet_id_param.data_type = String.Copy("unsigned int");
            packet_id_param.parameter_description = String.Copy("Command packet id");
            packet_id_param.parameter_name = String.Copy("packet_id");
            register_write_function.Parameters.Add(packet_id_param);



            DrvrCatCodeBuilder register_write_fn_builder = new DrvrCatCodeBuilder();
            register_write_fn_builder.AddStatement("int write_count");
            register_write_fn_builder.AddStatement("pdevice_handler pdev = " + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") +
                        "_" + this.Module_Name.ToLower().Trim() + "_get_handler(pCmdHeader->Instance)");
            register_write_fn_builder.AddStatement("unsigned int Length = pCmdHeader->Length");
            register_write_fn_builder.AddStatement("unsigned int *pData = (unsigned int *)pCmdHeader->pData");
            register_write_fn_builder.AddStatement("unsigned int offset = pCmdHeader->Address");
            register_write_fn_builder.AddStatement("unsigned int read_data=0");
            register_write_fn_builder.AddStatement("unsigned int resource_index = pCmdHeader->Resource");
            register_write_fn_builder.AddStatement("bus_address resource = pdev->reg_remap_addr[resource_index]");
            

            register_write_fn_builder.AppendLine("if(pdev!=NULL)");

            register_write_fn_builder.Start_Block();


            register_write_fn_builder.AppendLine("for(write_count=0;write_count<Length;write_count++)");
            register_write_fn_builder.Start_Block();
            register_write_fn_builder.AppendLine("read_data = 0;");
            register_write_fn_builder.AppendLine("if (pCmdHeader->Bit_Mask != 0)");
            register_write_fn_builder.Start_Block();
            register_write_fn_builder.AppendLine("read_data = resource[offset+write_count];");
            register_write_fn_builder.AppendLine("read_data = read_data & (~(pCmdHeader->Bit_Mask));");
            register_write_fn_builder.End_Block();


            register_write_fn_builder.AddStatement("resource[offset+write_count] = (read_data) | pData[write_count]");

            register_write_fn_builder.End_Block();
            register_write_fn_builder.AddStatement("return");


            register_write_fn_builder.End_Block();

            register_write_function.Function_Statements = String.Copy(register_write_fn_builder.GetCode());

            DrvrCatCodeBuilder function_code_builder = new DrvrCatCodeBuilder();
            function_code_builder.Define_Function_Code(register_write_function);

            register_write_function.Code = String.Copy(function_code_builder.GetCode());



            this.Module_functions_list.Add(register_write_function);


            DrvrCatCodeAutomationPanel.Functions_List_All_Modules.Add(register_write_function);
            DrvrCatCodeAutomationPanel.Functions_Name_List_All_Modules.Add(register_write_function.Function_Name);

            return;
        }

        internal void Define_Register_Read_API_Function()
        {
            DrvrCatFunction register_read_function = new DrvrCatFunction();

            register_read_function.Function_Name = Properties.Settings.Default.Project_Name + "_" + this.Module_Name.ToLower().Trim() + "_" + "reg_read_api";
            register_read_function.Function_Description = "Register read internal API. Cannot be called as command handler";
            register_read_function.return_item.Function_Return_type = "void";
            register_read_function.return_item.Return_Description = "Function will not return anything";

            register_read_function.Module_Index = this.Module_Index;
            register_read_function.Module_Name = String.Copy(this.Module_Name);

            register_read_function.Parameters = new List<DrvrCatFunctionParameter>();

            DrvrCatFunctionParameter instance_num_param = new DrvrCatFunctionParameter();
            instance_num_param.data_type = String.Copy("unsigned int");
            instance_num_param.parameter_description = String.Copy("Instance number of the module");
            instance_num_param.parameter_name = String.Copy("instant_num");
            register_read_function.Parameters.Add(instance_num_param);

            DrvrCatFunctionParameter address_param = new DrvrCatFunctionParameter();
            address_param.data_type = String.Copy("unsigned int ");
            address_param.parameter_description = String.Copy("Address of the register to read. Start address incase of buffer read");
            address_param.parameter_name = String.Copy("offset");
            register_read_function.Parameters.Add(address_param);


            DrvrCatFunctionParameter length_param = new DrvrCatFunctionParameter();
            length_param.data_type = String.Copy("unsigned int ");
            length_param.parameter_description = String.Copy("Number of address to be read");
            length_param.parameter_name = String.Copy("Length");
            register_read_function.Parameters.Add(length_param);

            DrvrCatFunctionParameter data_param = new DrvrCatFunctionParameter();
            data_param.data_type = String.Copy("unsigned int *");
            data_param.parameter_description = String.Copy("Pointer to the buffer to be filled with read data");
            data_param.parameter_name = String.Copy("pData");
            register_read_function.Parameters.Add(data_param);




            DrvrCatCodeBuilder register_read_fn_builder = new DrvrCatCodeBuilder();
            register_read_fn_builder.AddStatement("int read_count");
            register_read_fn_builder.AddStatement("pdevice_handler pdev = " + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") +
                        "_" +this.Module_Name.ToLower().Trim() + "_get_handler(instant_num)");
            


            register_read_fn_builder.AppendLine("if(pdev!=NULL)");

            register_read_fn_builder.Start_Block();


            register_read_fn_builder.AppendLine("for(read_count=0;read_count<Length;read_count++)");
            register_read_fn_builder.Start_Block();


            register_read_fn_builder.AddStatement("pData[read_count] = pdev->reg_remap_addr[offset+read_count]");

            register_read_fn_builder.End_Block();
            register_read_fn_builder.AddStatement("return");


            register_read_fn_builder.End_Block();

            register_read_function.Function_Statements = String.Copy(register_read_fn_builder.GetCode());

            this.Module_functions_list.Add(register_read_function);

            return;
        }

        internal void Define_Register_Write_API_Function()
        {
            DrvrCatFunction register_write_function = new DrvrCatFunction();

            register_write_function.Function_Name = Properties.Settings.Default.Project_Name + "_" + this.Module_Name.ToLower().Trim() + "_" + "reg_write_api";
            register_write_function.Function_Description = "Register write internal API. Cannot be called as command handler";
            register_write_function.return_item.Function_Return_type = "void";
            register_write_function.return_item.Return_Description = "Function will not return anything";

            register_write_function.Module_Index = this.Module_Index;
            register_write_function.Module_Name = String.Copy(this.Module_Name);

            register_write_function.Parameters = new List<DrvrCatFunctionParameter>();


            DrvrCatFunctionParameter instance_num_param = new DrvrCatFunctionParameter();
            instance_num_param.data_type = String.Copy("unsigned int");
            instance_num_param.parameter_description = String.Copy("Instance number of the module");
            instance_num_param.parameter_name = String.Copy("instant_num");
            register_write_function.Parameters.Add(instance_num_param);

            DrvrCatFunctionParameter address_param = new DrvrCatFunctionParameter();
            address_param.data_type = String.Copy("unsigned int");
            address_param.parameter_description = String.Copy("Address of the register to write. Start address incase of buffer write");
            address_param.parameter_name = String.Copy("offset");
            register_write_function.Parameters.Add(address_param);


            DrvrCatFunctionParameter length_param = new DrvrCatFunctionParameter();
            length_param.data_type = String.Copy("unsigned int");
            length_param.parameter_description = String.Copy("Number of address to be written");
            length_param.parameter_name = String.Copy("Length");
            register_write_function.Parameters.Add(length_param);

            DrvrCatFunctionParameter data_param = new DrvrCatFunctionParameter();
            data_param.data_type = String.Copy("unsigned int *");
            data_param.parameter_description = String.Copy("Pointer to the buffer which has write data");
            data_param.parameter_name = String.Copy("pData");
            register_write_function.Parameters.Add(data_param);



            DrvrCatCodeBuilder register_write_fn_builder = new DrvrCatCodeBuilder();
            register_write_fn_builder.AddStatement("int write_count");
            register_write_fn_builder.AddStatement("pdevice_handler pdev =  " + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") +
                        "_" + this.Module_Name.ToLower().Trim() + "_get_handler(instant_num)");


            register_write_fn_builder.AppendLine("if(pdev!=NULL)");

            register_write_fn_builder.Start_Block();


            register_write_fn_builder.AppendLine("for(write_count=0;write_count<Length;write_count++)");
            register_write_fn_builder.Start_Block();




            register_write_fn_builder.AddStatement("pdev->reg_remap_addr[offset+write_count] = pData[write_count]");

            register_write_fn_builder.End_Block();
            register_write_fn_builder.AddStatement("return");


            register_write_fn_builder.End_Block();

            register_write_function.Function_Statements = String.Copy(register_write_fn_builder.GetCode());

            this.Module_functions_list.Add(register_write_function);

            return;
        }

        internal void Define_Config_Function()
        {
            DrvrCatFunction config_function = new DrvrCatFunction();

            config_function.Function_Name = Properties.Settings.Default.Project_Name + "_" + this.Module_Name.ToLower().Trim() + "_" + "config";
            config_function.Function_Description = "Config command handler";
            config_function.return_item.Function_Return_type = "void";
            config_function.return_item.Return_Description = "Function will not return anything";

            config_function.Module_Index = this.Module_Index;
            config_function.Module_Name = String.Copy(this.Module_Name);

            config_function.Parameters = new List<DrvrCatFunctionParameter>();

            DrvrCatFunctionParameter cmdhandler_param = new DrvrCatFunctionParameter();
            cmdhandler_param.data_type = String.Copy("pCommand_Header");
            cmdhandler_param.parameter_description = String.Copy("Command packet");
            cmdhandler_param.parameter_name = String.Copy("pCmdHeader");
            config_function.Parameters.Add(cmdhandler_param);

            DrvrCatFunctionParameter packet_id_param = new DrvrCatFunctionParameter();
            packet_id_param.data_type = String.Copy("unsigned int");
            packet_id_param.parameter_description = String.Copy("Command packet id");
            packet_id_param.parameter_name = String.Copy("packet_id");
            config_function.Parameters.Add(packet_id_param);



            DrvrCatCodeBuilder config_fn_builder = new DrvrCatCodeBuilder();
            config_fn_builder.AddStatement("pdevice_handler pdev = " + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") +
                        "_" + this.Module_Name.ToLower().Trim() + "_get_handler(pCmdHeader->Instance)");
            config_fn_builder.AddStatement("unsigned int Length = pCmdHeader->Length");
            config_fn_builder.AddStatement("unsigned int *pData = (unsigned int *)pCmdHeader->pData");
            config_fn_builder.AddStatement("unsigned int config_id = pCmdHeader->Address");


            config_fn_builder.AppendLine("if(pdev!=NULL)");

            config_fn_builder.Start_Block();

            //config_fn_builder.AppendLine("//TODO ");

            config_fn_builder.AppendLine("switch(config_id) //Check for config ID");
            config_fn_builder.Start_Block();

            foreach (DrvrCatConfigServiceItem current_config in this.Config_List)
            {
                config_fn_builder.AppendLine("case " + current_config.Enumeration_Code_Name  + ":");
                config_fn_builder.Increase_Indent(1);
                config_fn_builder.AddStatement("//" + current_config.Enumeration_Code_Name + "_Config_Handler" + "(pCmdHeader,packet_id) //Generate function" );
                config_fn_builder.AddStatement("break");
                config_fn_builder.Decrease_Indent(1); 
            }

            config_fn_builder.End_Block();

            config_fn_builder.End_Block();

            config_function.Function_Statements = String.Copy(config_fn_builder.GetCode());

            for (int function_index = 0; function_index < this.Module_functions_list.Count; function_index++)
            {
                DrvrCatFunction current_function = this.Module_functions_list[function_index];
                if(current_function.Function_Name.Equals(config_function.Function_Name))
                {
                    this.Module_functions_list.RemoveAt(function_index);
                }
            }


            DrvrCatCodeBuilder function_code_builder = new DrvrCatCodeBuilder();
            function_code_builder.Define_Function_Code(config_function);

            config_function.Code = String.Copy(function_code_builder.GetCode());



            this.Module_functions_list.Add(config_function);

            DrvrCatCodeAutomationPanel.Functions_List_All_Modules.Add(config_function);
            DrvrCatCodeAutomationPanel.Functions_Name_List_All_Modules.Add(config_function.Function_Name);

            return;
        }

        internal void Define_Service_Function()
        {
            DrvrCatFunction service_function = new DrvrCatFunction();

            service_function.Function_Name = Properties.Settings.Default.Project_Name + "_" + this.Module_Name.ToLower().Trim() + "_" + "service";
            service_function.Function_Description = "Service command handler";
            service_function.return_item.Function_Return_type = "void";
            service_function.return_item.Return_Description = "Function will not return anything";

            service_function.Module_Index = this.Module_Index;
            service_function.Module_Name = String.Copy(this.Module_Name);

            service_function.Parameters = new List<DrvrCatFunctionParameter>();

            DrvrCatFunctionParameter cmdhandler_param = new DrvrCatFunctionParameter();
            cmdhandler_param.data_type = String.Copy("pCommand_Header");
            cmdhandler_param.parameter_description = String.Copy("Command packet");
            cmdhandler_param.parameter_name = String.Copy("pCmdHeader");
            service_function.Parameters.Add(cmdhandler_param);

            DrvrCatFunctionParameter packet_id_param = new DrvrCatFunctionParameter();
            packet_id_param.data_type = String.Copy("unsigned int");
            packet_id_param.parameter_description = String.Copy("Command packet id");
            packet_id_param.parameter_name = String.Copy("packet_id");
            service_function.Parameters.Add(packet_id_param);



            DrvrCatCodeBuilder service_fn_builder = new DrvrCatCodeBuilder();
            service_fn_builder.AddStatement("pdevice_handler pdev = " + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") +
                        "_" + this.Module_Name.ToLower().Trim() + "_get_handler(pCmdHeader->Instance)");
            service_fn_builder.AddStatement("unsigned int Enable = pCmdHeader->Length");
            service_fn_builder.AddStatement("unsigned int *pData = (unsigned int *)pCmdHeader->pData");
            service_fn_builder.AddStatement("unsigned int service_id = pCmdHeader->Address");

            service_fn_builder.AppendLine("if(pdev!=NULL)");

            service_fn_builder.Start_Block();

            service_fn_builder.AppendLine("if(service_id >= " + Properties.Settings.Default.Project_Name + "_" + this.Module_Name.ToLower().Trim() + "_" + "SERVICE_COUNT" + ")");
            service_fn_builder.Start_Block();
            service_fn_builder.AddStatement("pCmdHeader->Length = 0");
            service_fn_builder.AddStatement("return");
            service_fn_builder.End_Block();
            service_fn_builder.AppendLine("else");
            service_fn_builder.Start_Block();

            service_fn_builder.AppendLine("if(pCmdHeader->Length == 1)");
            service_fn_builder.Start_Block();
            service_fn_builder.AppendLine("if(pdev->service_id_array[service_id] == ((unsigned int)-1))");
            service_fn_builder.Start_Block();
            service_fn_builder.AddStatement("pdev->service_id_array[service_id] = packet_id");
            service_fn_builder.End_Block();
            service_fn_builder.AppendLine("else");
            service_fn_builder.Start_Block();
            service_fn_builder.AddStatement("pCmdHeader->Length = 0");
            service_fn_builder.AddStatement("return");
            service_fn_builder.End_Block();
            service_fn_builder.End_Block();
            service_fn_builder.AppendLine("else");
            service_fn_builder.Start_Block();
            service_fn_builder.AppendLine("if(pdev->service_id_array[service_id] != ((unsigned int)-1))");
            service_fn_builder.Start_Block();
            service_fn_builder.AddStatement("send_service_ack_disable(&" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_socket_manager" + ",pdev->service_id_array[service_id],pCmdHeader->Module_Index)");
            service_fn_builder.End_Block();
            service_fn_builder.End_Block();


            service_fn_builder.End_Block();
           

            service_fn_builder.AppendLine("switch(service_id) //Check for config ID");
            service_fn_builder.Start_Block();

            foreach (DrvrCatConfigServiceItem current_service in this.Service_List)
            {
                service_fn_builder.AppendLine("case " + current_service.Enumeration_Code_Name + ":");
                service_fn_builder.Increase_Indent(1);
                //service_fn_builder.AppendLine("if(pCmdHeader->Length ==1)");
                //service_fn_builder.Start_Block();
                //service_fn_builder.AddStatement("pdev->service_id_array[" + current_service.Enumeration_Code_Name + "] = packet_id");
                
                
                service_fn_builder.AddStatement("//" + current_service.Enumeration_Code_Name + "_Service_Handler" + "(pCmdHeader,packet_id) //Generate function");
                service_fn_builder.AddStatement("break");
                service_fn_builder.Decrease_Indent(1);
            }

            service_fn_builder.End_Block();

            service_fn_builder.End_Block();

            service_function.Function_Statements = String.Copy(service_fn_builder.GetCode());

            for (int function_index = 0; function_index < this.Module_functions_list.Count; function_index++)
            {
                DrvrCatFunction current_function = this.Module_functions_list[function_index];
                if (current_function.Function_Name.Equals(service_function.Function_Name))
                {
                    this.Module_functions_list.RemoveAt(function_index);
                }
            }

            DrvrCatCodeBuilder function_code_builder = new DrvrCatCodeBuilder();
            function_code_builder.Define_Function_Code(service_function);

            service_function.Code = String.Copy(function_code_builder.GetCode());


            this.Module_functions_list.Add(service_function);

            DrvrCatCodeAutomationPanel.Functions_List_All_Modules.Add(service_function);
            DrvrCatCodeAutomationPanel.Functions_Name_List_All_Modules.Add(service_function.Function_Name);

            return;
        }

        internal void Define_Config_List_Enumeration()
        {
            this.Config_List_Enumeration.Enumeration_Name = Properties.Settings.Default.Project_Name.Trim().Replace(" ", "_") + "_" + this.Module_Name.Trim().Replace(" ", "_") + "_" + "Config" + "_Enum_Def";
            this.Config_List_Enumeration.Enumeration_Description = this.Module_Name + " config command enumeration";
            this.Config_List_Enumeration.Enumeration_members.Clear();
            this.Config_List_Enumeration.Enumeration_member_description.Clear();
            this.Config_List_Enumeration.Enumeration_values.Clear();

            for (int config_index = 0; config_index < this.Config_List.Count; config_index++)
            {
                this.Config_List_Enumeration.Enumeration_members.Add(Properties.Settings.Default.Project_Name.Trim().Replace(" ", "_") + "_"+ this.Module_Name.Trim().Replace(" ", "_") + "_" + this.Config_List[config_index].Config_Service_Name) ;
                this.Config_List_Enumeration.Enumeration_values.Add((uint)config_index);
                this.Config_List_Enumeration.Enumeration_member_description.Add(this.Config_List[config_index].Description);
                this.Config_List[config_index].Enumeration_Code_Name = this.Config_List_Enumeration.Enumeration_members[config_index];
            }

            DrvrCatCodeBuilder enum_code_builder = new DrvrCatCodeBuilder();
            enum_code_builder.Define_Bit_Typedef_Enumeration(this.Config_List_Enumeration, this.Module_Name);
            this.Config_List_Enumeration.Enumeration_Code = String.Copy(enum_code_builder.GetCode());
        }

        internal void Define_Service_List_Enumeration()
        {
            this.Service_List_Enumeration.Enumeration_Name = Properties.Settings.Default.Project_Name.Trim().Replace(" ", "_") + "_" + this.Module_Name.Trim().Replace(" ", "_") + "_" + "Service" + "_Enum_Def";
            this.Service_List_Enumeration.Enumeration_Description = this.Module_Name + " service command enumeration";
            this.Service_List_Enumeration.Enumeration_members.Clear();
            this.Service_List_Enumeration.Enumeration_member_description.Clear();
            this.Service_List_Enumeration.Enumeration_values.Clear();

            for (int service_index = 0; service_index < this.Service_List.Count; service_index++)
            {
                this.Service_List_Enumeration.Enumeration_members.Add(Properties.Settings.Default.Project_Name.Trim().Replace(" ", "_") + "_" + this.Module_Name.Trim().Replace(" ", "_") + "_" + this.Service_List[service_index].Config_Service_Name);
                this.Service_List_Enumeration.Enumeration_values.Add((uint)service_index);
                this.Service_List_Enumeration.Enumeration_member_description.Add(this.Service_List[service_index].Description);
                this.Service_List[service_index].Enumeration_Code_Name = this.Service_List_Enumeration.Enumeration_members[service_index];
            }

            DrvrCatCodeBuilder enum_code_builder = new DrvrCatCodeBuilder();
            enum_code_builder.Define_Bit_Typedef_Enumeration(this.Service_List_Enumeration, this.Module_Name);
            this.Service_List_Enumeration.Enumeration_Code = String.Copy(enum_code_builder.GetCode());
        }
    }
}
