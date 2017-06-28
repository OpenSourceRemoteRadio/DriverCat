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
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Code_Automation_Tool
{
    class DrvrCatCodeBuilder
    {
        private Int32 Tab_Indent;
        private StringBuilder Code;

        public DrvrCatCodeBuilder()
        {
            this.Tab_Indent = 0;
            this.Code = new StringBuilder();
        }

        public void Increase_Indent(int count)
        {
            this.Tab_Indent += (Int32)(Properties.Settings.Default.Code_Tab_Size * count);
            return;
        }

        public void Decrease_Indent(int count)
        {
            this.Tab_Indent -= (Int32)(Properties.Settings.Default.Code_Tab_Size * count);

            if (this.Tab_Indent < 0)
            {
                this.Tab_Indent = 0;
            }
            return;
        }

        public void Clear_Indent()
        {
            this.Tab_Indent = 0;
            return;
        }

        internal void AppendLine(String Add_String)
        {
            this.Code.AppendLine("".PadLeft(this.Tab_Indent) + Add_String);
            return;
        }

        internal void Append(String Add_String)
        {
            this.Code.Append("".PadLeft(this.Tab_Indent) + Add_String);
            return;
        }

        internal void Start_Block()
        {
            this.Code.AppendLine("{".PadLeft(this.Tab_Indent));
            this.Increase_Indent(1);
            return;
        }

        internal void AddStatement(String statement)
        {
            this.Code.AppendLine("".PadLeft(this.Tab_Indent) + statement + ";");
            return;
        }

        internal void End_Block(String block_name)
        {
            this.Decrease_Indent(1);
            this.Code.AppendLine("}".PadLeft(this.Tab_Indent) + block_name);
            return;
        }

        internal void End_Block()
        {
            this.Decrease_Indent(1);
            this.Code.AppendLine("}".PadLeft(this.Tab_Indent));
            return;
        }

        internal String GetCode()
        {
            return this.Code.ToString();
        }

        internal void Define_32bit_register_struct(DrvrCatRegister Register_Instance)
        {
            String Group_Name = Properties.Settings.Default.Project_Name.ToLower() + "_" + Register_Instance.Module_Name.ToLower();
            String Doxygen_Comment = String.Empty;

            this.Clear_Indent();

            if (Properties.Settings.Default.Generate_Doxygen_Comments)
            {
                Doxygen_Comment = String.Copy(DrvrCatDoxygen.Generate_Structure_Comment(Register_Instance.Register_Description, Group_Name));
                this.AppendLine(Doxygen_Comment);
                this.AppendLine();
                this.AppendLine();
            }

            this.AppendLine("typedef union");
            this.Start_Block();
            this.AppendLine("struct");
            this.Start_Block();

            foreach (var Register_Bit_Item in Register_Instance.Bits)
            {
                String bit_comment = String.Empty;
                if (Properties.Settings.Default.Generate_Doxygen_Comments)
                {
                    bit_comment = String.Copy(DrvrCatDoxygen.Generate_Structure_Member_Comment(Register_Bit_Item.Bit_Description));
                }
                this.AddStatement(Register_Bit_Item.Code, bit_comment);
            }

            this.End_Block("reg;");
            this.AddStatement("unsigned int value");
            this.End_Block(Register_Instance.Struct_Definition_Name + ",*p" + Register_Instance.Struct_Definition_Name + ";");
        }

        private void AddStatement(String Statement, String comment)
        {
            this.Code.Append("".PadLeft(this.Tab_Indent) + Statement + ";");
            if (comment != null)
            {
                this.Code.AppendLine("\t" + comment);
            }
            else
            {
                this.Code.AppendLine();
            }
            return;
        }

        private void AppendLine()
        {
            this.Code.AppendLine();
            return;
        }

        internal void Define_Bit_Typedef_Enumeration(DrvrCatEnumeration enum_object, String Module_Name)
        {
            String Group_Name = Properties.Settings.Default.Project_Name.ToLower() + "_" + Module_Name.ToLower();

            Define_Bit_Typedef_Enumeration(enum_object, String.Empty, Group_Name);
        }

        internal void Define_Bit_Typedef_Enumeration(DrvrCatEnumeration enum_object, String Module_Name,String Group_Name)
        {
            String Doxygen_Comment = String.Empty;

            this.Clear_Indent();

            if (Properties.Settings.Default.Generate_Doxygen_Comments)
            {
                Doxygen_Comment = String.Copy(DrvrCatDoxygen.Generate_Enumeration_Comment(enum_object.Enumeration_Description, Group_Name));
                this.AppendLine(Doxygen_Comment);
                this.AppendLine();
                this.AppendLine();
            }

            this.AppendLine("typedef enum");
            this.Start_Block();

            for (int enum_member_index = 0; enum_member_index < enum_object.Enumeration_members.Count; enum_member_index++)
            {
                this.Append(enum_object.Enumeration_members.ElementAt(enum_member_index) + "=" + enum_object.Enumeration_values.ElementAt(enum_member_index) + ",");
                String bit_comment = String.Empty;
                if (Properties.Settings.Default.Generate_Doxygen_Comments)
                {
                    bit_comment = String.Copy(DrvrCatDoxygen.Generate_Enumeration_Member_Comment(enum_object.Enumeration_member_description.ElementAt(enum_member_index)));
                    this.AppendLine(bit_comment);
                }
                else
                {
                    this.AppendLine();
                }
            }

            this.End_Block(enum_object.Enumeration_Name + ";");
        }

        internal void Define_Function_Code(DrvrCatFunction function_to_define)
        {
            String Group_Name = Properties.Settings.Default.Project_Name.ToLower() + "_" + function_to_define.Module_Name.ToLower();

            Define_Function_Code(function_to_define, Group_Name);

        }

        internal void Define_Function_Code(DrvrCatFunction function_to_define, String Group_Name)
        {
            String Doxygen_Comment = String.Empty;

            this.Clear_Indent();

            if (Properties.Settings.Default.Generate_Doxygen_Comments)
            {
                Doxygen_Comment = String.Copy(DrvrCatDoxygen.Generate_Function_Comment(function_to_define, Group_Name));
                this.AppendLine(Doxygen_Comment);
                this.AppendLine();
                this.AppendLine();
            }

            StringBuilder function_prototype_builder = new StringBuilder();

            function_prototype_builder.Append(function_to_define.return_item.Function_Return_type + " " + function_to_define.Function_Name + "(");

            if (function_to_define.Parameters != null)
            {
                for (int param_index = 0; param_index < function_to_define.Parameters.Count; param_index++)
                {
                    DrvrCatFunctionParameter parameters = function_to_define.Parameters.ElementAt(param_index);
                    function_prototype_builder.Append(parameters.data_type + " " + parameters.parameter_name);
                    if (param_index != (function_to_define.Parameters.Count - 1))
                    {
                        function_prototype_builder.Append(",");
                    }
                }
            }

            function_prototype_builder.Append(")");
            this.AppendLine(function_prototype_builder.ToString());
            function_prototype_builder.Append(";");

            function_to_define.Function_Prototype = String.Copy(function_prototype_builder.ToString());

            this.Start_Block();

            this.AppendStatements(function_to_define.Function_Statements);

            this.End_Block();
            return;
        }

        private void AppendStatements(String statements)
        {
            String each_statement = String.Empty;
            StringReader strReader = new StringReader(statements);

            while (true)
            {
                each_statement = strReader.ReadLine();
                if (each_statement != null)
                {
                    this.Code.Append("".PadLeft(this.Tab_Indent) + each_statement);
                    this.Code.AppendLine();
                }
                else
                {
                    break;
                }
            }
        }

        internal static String Write_Module_Code(DrvrCatModule current_regmap, String Include_Directorty, String Source_Directorty)
        {
            if (current_regmap != null)
            {
                String previous_reg_name = String.Empty;
                String Group_Name = Properties.Settings.Default.Project_Name.ToLower() + "_" + current_regmap.Module_Name.ToLower();
                String inc_file_name = Properties.Settings.Default.Project_Name.ToLower() + "_" + current_regmap.Module_Name.ToLower() + ".h";
                String src_file_name = Properties.Settings.Default.Project_Name.ToLower() + "_" + current_regmap.Module_Name.ToLower() + ".c";

                String inc_file_path = Include_Directorty + "\\" + inc_file_name;
                String src_file_path = Source_Directorty + "\\" + src_file_name;


                String inc_Doxygen_Comment = String.Empty;
                String src_Doxygen_Comment = String.Empty;

                StreamWriter inc_file_stream = new StreamWriter(inc_file_path, false);
                StreamWriter src_file_stream = new StreamWriter(src_file_path, false);

                inc_file_stream.WriteLine(Properties.Settings.Default.License_Message);
                src_file_stream.WriteLine(Properties.Settings.Default.License_Message);

                if (Properties.Settings.Default.Generate_Doxygen_Comments)
                {
                    inc_Doxygen_Comment = String.Copy(DrvrCatDoxygen.Generate_File_Comment(inc_file_name, Group_Name, "Header file for " + current_regmap.Module_Name + " module", true));
                    src_Doxygen_Comment = String.Copy(DrvrCatDoxygen.Generate_File_Comment(src_file_name, Group_Name, "Application file for " + current_regmap.Module_Name + " module", false));

                    inc_file_stream.WriteLine(inc_Doxygen_Comment);
                    inc_file_stream.WriteLine();
                    src_file_stream.WriteLine(src_Doxygen_Comment);
                    src_file_stream.WriteLine();
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

                inc_file_stream.WriteLine("#include <stdio.h>		\n#define _GNU_SOURCE \n#define __USE_GNU	 \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <sys/select.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <netdb.h>       \n#include <signal.h>      \n#include <unistd.h>      \n#include <stdio.h>       \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <sys/mman.h>    \n#include <netdb.h>       \n#include <sys/stat.h>    \n#include <fcntl.h>       \n#include <pthread.h>     \n#include <sys/ioctl.h>   \n#include <stdbool.h>\n");

                src_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include public/global Header files"));

                src_file_stream.WriteLine("#include <stdio.h>		\n#define _GNU_SOURCE \n#define __USE_GNU	 \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <sys/select.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <netdb.h>       \n#include <signal.h>      \n#include <unistd.h>      \n#include <stdio.h>       \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <sys/mman.h>    \n#include <netdb.h>       \n#include <sys/stat.h>    \n#include <fcntl.h>       \n#include <pthread.h>     \n#include <sys/ioctl.h>   \n#include <stdbool.h>\n");


                inc_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include private Header files"));

                inc_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_")  + "_protocol.h" + "\"");
                inc_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ","_") +"_firmware.h" + "\"");
                //inc_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ","_") + "_datatype.h" + "\"");
                inc_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_command_format.h" + "\"");

                


                src_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include private Header files"));
                src_file_stream.WriteLine("#include \"" + inc_file_name + "\"");

                src_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ","_") + "_protocol.h" + "\"");
                src_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ","_") + "_firmware.h" + "\"");
                //src_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ","_") + "_datatype.h" + "\"");
                src_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_command_format.h" + "\"");

                src_file_stream.WriteLine("extern socket_manager_header " + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_socket_manager;");


                src_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Device handler Function definition"));

                //src_file_stream.WriteLine("device_handler " + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") +
                //    "_" + current_regmap.Module_Name.ToLower().Trim() + "_get_handler(unsigned int instance_num)");
                //src_file_stream.WriteLine("{");
                //src_file_stream.WriteLine(Properties.Resources.device_handler_function.Replace("module_name",current_regmap.Module_Name.ToLower().Trim()));

                DrvrCatFunction device_handler_function = new DrvrCatFunction();

                device_handler_function.Module_Index = current_regmap.Module_Index;
                device_handler_function.Module_Name = current_regmap.Module_Name;
                device_handler_function.Function_Description = "Driver handler function. Interacts with " + current_regmap.Module_Name + " driver and gets address map information";
                device_handler_function.Function_Name = Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") +
                        "_" + current_regmap.Module_Name.ToLower().Trim() + "_get_handler";


                device_handler_function.Parameters = new List<DrvrCatFunctionParameter>();
                DrvrCatFunctionParameter instance_num_parameter = new DrvrCatFunctionParameter();
                instance_num_parameter.data_type = "unsigned int";
                instance_num_parameter.parameter_name = "instance_num";
                instance_num_parameter.parameter_description = "Instance number of the " + current_regmap.Module_Name + " module for which handler is to be returned";
                device_handler_function.Parameters.Add(instance_num_parameter);
                

                device_handler_function.return_item.Function_Return_type = "pdevice_handler";
                device_handler_function.return_item.Return_Description = "Returns the handler for the requested instance of " + current_regmap.Module_Name  + " module";
                device_handler_function.return_item.return_values = new List<DrvrCatFunctionReturnValue>();
                DrvrCatFunctionReturnValue retval_handler = new DrvrCatFunctionReturnValue();
                retval_handler.Return_Value = "Handler Pointer";
                retval_handler.Return_Context = "Requested Instance of " + current_regmap.Module_Name + " module exits";

                DrvrCatFunctionReturnValue retval_null = new DrvrCatFunctionReturnValue();
                retval_null.Return_Value = "NULL";
                retval_null.Return_Context = "Requested Instance of " + current_regmap.Module_Name + " module doesnot exit";
                device_handler_function.return_item.return_values.Add(retval_handler);
                device_handler_function.return_item.return_values.Add(retval_null);
                
                String device_function_handler_statement =  String.Copy(Properties.Resources.device_handler_function.Replace("module_name", current_regmap.Module_Name.ToLower().Trim().Replace(" ","_")));
                device_function_handler_statement = device_function_handler_statement.Replace("project_name", Properties.Settings.Default.Project_Name.Replace(" ", "_"));

                device_handler_function.Function_Statements = device_function_handler_statement;

                DrvrCatCodeBuilder device_handler_function_builder = new DrvrCatCodeBuilder();
                device_handler_function_builder.Define_Function_Code(device_handler_function);
                src_file_stream.WriteLine(device_handler_function_builder.GetCode());

                function_declaration_builder.AppendLine(device_handler_function.Function_Prototype);

                //src_file_stream.WriteLine(CodeBuilder.Section_Header_Comment("Register Read/Write Function definition"));
                //src_file_stream.WriteLine(Properties.Resources.reg_read_write_function.Replace("module_name", current_regmap.Module_Name.ToLower().Trim()));


                //IRQ Handler

                src_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("ISR Function definition"));

                DrvrCatFunction device_isr_thread_function = new DrvrCatFunction();

                device_isr_thread_function.Module_Index = current_regmap.Module_Index;
                device_isr_thread_function.Module_Name = current_regmap.Module_Name;
                device_isr_thread_function.Function_Description = "Interrupt Service Routine. Interacts with " + current_regmap.Module_Name + " UIO driver and gets interrupt status";
                device_isr_thread_function.Function_Name = Properties.Settings.Default.Project_Name.Trim().Replace(" ", "_") +
                        "_" + current_regmap.Module_Name.ToLower().Trim() + "_isr_thread";


                device_isr_thread_function.Parameters = new List<DrvrCatFunctionParameter>();
                DrvrCatFunctionParameter handler_parameter = new DrvrCatFunctionParameter();
                handler_parameter.data_type = "void *";
                handler_parameter.parameter_name = current_regmap.Module_Name.ToLower().Trim() + "_handler_ptr";
                handler_parameter.parameter_description = "Device handler of the " + current_regmap.Module_Name + " module";
                device_isr_thread_function.Parameters.Add(handler_parameter);


                device_isr_thread_function.return_item.Function_Return_type = "void *";
                device_isr_thread_function.return_item.Return_Description = "Returns NULL";

                String isr_thread_function_statement = String.Copy(Properties.Resources.isr_thread_function_statement.Replace("module_name", current_regmap.Module_Name.ToLower().Trim().Replace(" ", "_")));
                isr_thread_function_statement = isr_thread_function_statement.Replace("project_name", Properties.Settings.Default.Project_Name.Replace(" ", "_"));

                device_isr_thread_function.Function_Statements = isr_thread_function_statement;

                DrvrCatCodeBuilder device_isr_function_builder = new DrvrCatCodeBuilder();
                device_isr_function_builder.Define_Function_Code(device_isr_thread_function);
                src_file_stream.WriteLine(device_isr_function_builder.GetCode());

                function_declaration_builder.AppendLine(device_isr_thread_function.Function_Prototype);



                DrvrCatFunction device_isr_register_function = new DrvrCatFunction();

                device_isr_register_function.Module_Index = current_regmap.Module_Index;
                device_isr_register_function.Module_Name = current_regmap.Module_Name;
                device_isr_register_function.Function_Description = "Interrupt Service Register API. Register callback function for " + current_regmap.Module_Name + " interrupt";
                device_isr_register_function.Function_Name = Properties.Settings.Default.Project_Name.Trim().Replace(" ", "_") +
                        "_" + current_regmap.Module_Name.ToLower().Trim() + "_register_isr";


                device_isr_register_function.Parameters = new List<DrvrCatFunctionParameter>();
                //Function_Parameter handler_parameter = new Function_Parameter();
                //handler_parameter.data_type = "void *";
                //handler_parameter.parameter_name = current_regmap.Module_Name.ToLower().Trim() + "_handler_ptr";
                //handler_parameter.parameter_description = "Device handler of the " + current_regmap.Module_Name + " module";
                device_isr_register_function.Parameters.Add(handler_parameter);

                DrvrCatFunctionParameter callback_function_parameter = new DrvrCatFunctionParameter();
                callback_function_parameter.data_type = "isr_callback";
                callback_function_parameter.parameter_name = "callback_function";
                callback_function_parameter.parameter_description = "Callback function for " + current_regmap.Module_Name + " IRQ";
                device_isr_register_function.Parameters.Add(callback_function_parameter);

                DrvrCatFunctionParameter callback_argument_parameter = new DrvrCatFunctionParameter();
                callback_argument_parameter.data_type = "void *";
                callback_argument_parameter.parameter_name = "callback_argument";
                callback_argument_parameter.parameter_description = "Argument to be passed to " + current_regmap.Module_Name + " ISR callback function";
                device_isr_register_function.Parameters.Add(callback_argument_parameter);


                device_isr_register_function.return_item.Function_Return_type = "void *";
                device_isr_register_function.return_item.Return_Description = "Returns NULL";

                String isr_register_function_statement = String.Copy(Properties.Resources.isr_register_function_statement.Replace("module_name", current_regmap.Module_Name.ToLower().Trim().Replace(" ", "_")));
                isr_register_function_statement = isr_register_function_statement.Replace("project_name", Properties.Settings.Default.Project_Name.Replace(" ", "_"));

                device_isr_register_function.Function_Statements = isr_register_function_statement;

                DrvrCatCodeBuilder device_isr_register_function_builder = new DrvrCatCodeBuilder();
                device_isr_register_function_builder.Define_Function_Code(device_isr_register_function);
                src_file_stream.WriteLine(device_isr_register_function_builder.GetCode());

                function_declaration_builder.AppendLine(device_isr_register_function.Function_Prototype);






                src_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("User defined Function definition"));

                inc_file_stream.WriteLine();


                for (int instance_index = 0; instance_index < current_regmap.Instances_Name_List.Count; instance_index++)
                {
                    inc_file_stream.WriteLine("#define " + Properties.Settings.Default.Project_Name + "_" + current_regmap.Module_Name.ToLower().Trim() + "_" + current_regmap.Instances_Name_List[instance_index].Trim().Replace(" ", "_").ToUpper() + "_INSTANCE_INDEX " + instance_index.ToString());
                }


                foreach (DrvrCatModuleResource current_resource in current_regmap.Resources)
                {
                    inc_file_stream.WriteLine("#define " + Properties.Settings.Default.Project_Name + "_" + current_regmap.Module_Name.ToLower().Trim() + "_" + current_resource.Resource_Name.Trim().Replace(" ", "_").ToUpper() + "_RESOURCE_INDEX " + current_resource.Resource_Index.ToString());
                    if (current_resource.Register_Offsets != null)
                    {
                        foreach (DrvrCatRegister register_instance in current_resource.Register_Offsets)
                        {
                            if (register_instance != null)
                            {
                                if (!previous_reg_name.ToLower().Equals(register_instance.Register_Name.ToLower()))
                                {
                                    previous_reg_name = String.Copy(register_instance.Register_Name);

                                    if (register_instance.Code != null)
                                    {
                                        register_definition_builder.AppendLine(register_instance.Code);
                                    }

                                    foreach (DrvrCatRegisterBit register_bit in register_instance.Bits)
                                    {
                                        if (register_bit != null)
                                        {
                                            if (register_bit.bit_values_enum != null)
                                            {
                                                if (register_bit.bit_values_enum.Enumeration_Code != null)
                                                {
                                                    enum_definition_builder.AppendLine(register_bit.bit_values_enum.Enumeration_Code);
                                                }
                                            }

                                            if (register_bit.Functions_List != null)
                                            {
                                                foreach (DrvrCatFunction curr_function in register_bit.Functions_List)
                                                {
                                                    function_declaration_builder.AppendLine(curr_function.Function_Prototype);
                                                    src_file_stream.WriteLine(curr_function.Code);
                                                }
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                inc_file_stream.WriteLine();

                inc_file_stream.WriteLine("#define " + Properties.Settings.Default.Project_Name + "_" + current_regmap.Module_Name.ToLower().Trim() + "_" + "CONFIG_COUNT " + current_regmap.Config_List.Count.ToString());
                inc_file_stream.WriteLine("#define " + Properties.Settings.Default.Project_Name + "_" + current_regmap.Module_Name.ToLower().Trim() + "_" + "SERVICE_COUNT " + current_regmap.Service_List.Count.ToString());


                src_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Custom Function definition"));

                foreach (DrvrCatFunction curr_function in current_regmap.Module_functions_list)
                {
                    function_declaration_builder.AppendLine(curr_function.Function_Prototype);
                    src_file_stream.WriteLine(curr_function.Code);
                }

                
                inc_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Enumeration definitions"));

                if (current_regmap.Config_List.Count > 0)
                {
                    inc_file_stream.WriteLine(current_regmap.Config_List_Enumeration.Enumeration_Code);
                }
                if (current_regmap.Service_List.Count > 0)
                {
                    inc_file_stream.WriteLine(current_regmap.Service_List_Enumeration.Enumeration_Code);
                }

                inc_file_stream.WriteLine(enum_definition_builder.ToString());

                inc_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Register bit map definitions"));
                inc_file_stream.WriteLine(register_definition_builder.ToString());

                foreach (DrvrCatModuleResource current_resource in current_regmap.Resources)
                {
                    if (current_resource.Code != null)
                    {
                        inc_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment(current_resource.Resource_Name + " Register map definition"));
                        inc_file_stream.WriteLine(current_resource.Code);
                    }
                }
                

                inc_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Function declaration"));
                inc_file_stream.WriteLine(function_declaration_builder.ToString());

                inc_file_stream.WriteLine("#ifdef __cplusplus");
                inc_file_stream.WriteLine("}/* close the extern \"C\" { */");
                inc_file_stream.WriteLine("#endif");

                inc_file_stream.WriteLine("#endif");

                inc_file_stream.Close();
                src_file_stream.Close();

                return inc_file_name;
            }
            return String.Empty;
        }

        internal static String Section_Header_Comment(String Section_Header)
        {
            String Section_Heading_Comments_StartLine = "/******************************************************************************";
            String Section_Heading_Comments_EndLine = "******************************************************************************/";
            StringBuilder comments_builder = new StringBuilder();
            comments_builder.AppendLine(Section_Heading_Comments_StartLine);
            comments_builder.AppendLine(" * " + Section_Header);
            comments_builder.AppendLine(Section_Heading_Comments_EndLine);
            return comments_builder.ToString();
        }

        internal static void Write_Firmware_Module_Code(DrvrCatFirmwareModule current_module, string Include_Directorty, string Source_Directorty, List<String> module_inc_file_list)
        {
            if (current_module != null)
            {
                String Group_Name = Properties.Settings.Default.Project_Name.ToLower() + "_" + current_module.Module_Name.ToLower();
                String inc_file_name = Properties.Settings.Default.Project_Name.ToLower() + "_" + current_module.Module_Name.ToLower() + ".h";
                String src_file_name = Properties.Settings.Default.Project_Name.ToLower() + "_" + current_module.Module_Name.ToLower() + ".c";

                String inc_file_path = Include_Directorty + "\\" + inc_file_name;
                String src_file_path = Source_Directorty + "\\" + src_file_name;


                String inc_Doxygen_Comment = String.Empty;
                String src_Doxygen_Comment = String.Empty;

                StreamWriter inc_file_stream = new StreamWriter(inc_file_path, false);
                StreamWriter src_file_stream = new StreamWriter(src_file_path, false);


                if (Properties.Settings.Default.Generate_Doxygen_Comments)
                {
                    inc_Doxygen_Comment = String.Copy(DrvrCatDoxygen.Generate_File_Comment(inc_file_name, Group_Name, "Header file for " + current_module.Module_Name + " module", true));
                    src_Doxygen_Comment = String.Copy(DrvrCatDoxygen.Generate_File_Comment(src_file_name, Group_Name, "Application file for " + current_module.Module_Name + " module", false));

                    inc_file_stream.WriteLine(inc_Doxygen_Comment);
                    inc_file_stream.WriteLine();
                    src_file_stream.WriteLine(src_Doxygen_Comment);
                    src_file_stream.WriteLine();
                }

                //StringBuilder enum_definition_builder = new StringBuilder();
                //StringBuilder register_definition_builder = new StringBuilder();
                StringBuilder function_declaration_builder = new StringBuilder();

                String define_string = inc_file_name.Trim().Replace(".", "_").ToUpper() + "_";

                inc_file_stream.WriteLine("#ifndef " + define_string);
                inc_file_stream.WriteLine("#define " + define_string);


                inc_file_stream.WriteLine("#ifdef __cplusplus");
                inc_file_stream.WriteLine("extern \"C\"");
                inc_file_stream.WriteLine("{");
                inc_file_stream.WriteLine("#endif");


                inc_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include public/global Header files"));

                inc_file_stream.WriteLine("#include <stdio.h>		\n#define _GNU_SOURCE \n#define __USE_GNU	 \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <sys/select.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <netdb.h>       \n#include <signal.h>      \n#include <unistd.h>      \n#include <stdio.h>       \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <sys/mman.h>    \n#include <netdb.h>       \n#include <sys/stat.h>    \n#include <fcntl.h>       \n#include <pthread.h>     \n#include <sys/ioctl.h>   \n#include <stdbool.h>\n");

                src_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include public/global Header files"));

                src_file_stream.WriteLine("#include <stdio.h>		\n#define _GNU_SOURCE \n#define __USE_GNU	 \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <sys/select.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <netdb.h>       \n#include <signal.h>      \n#include <unistd.h>      \n#include <stdio.h>       \n#include <stdlib.h>      \n#include <string.h>      \n#include <unistd.h>      \n#include <sys/types.h>   \n#include <sys/socket.h>  \n#include <netinet/in.h>  \n#include <arpa/inet.h>   \n#include <sys/mman.h>    \n#include <netdb.h>       \n#include <sys/stat.h>    \n#include <fcntl.h>       \n#include <pthread.h>     \n#include <sys/ioctl.h>   \n#include <stdbool.h>\n");


                inc_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include private Header files"));




                inc_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_protocol.h" + "\"");
                inc_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_firmware.h" + "\"");
                inc_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_command_format.h" + "\"");

                



                

                src_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Include private Header files"));
                src_file_stream.WriteLine("#include \"" + inc_file_name + "\"");

                 



                src_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_protocol.h" + "\"");
                src_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_firmware.h" + "\"");
                src_file_stream.WriteLine("#include \"" + Properties.Settings.Default.Project_Name.ToLower().Trim().Replace(" ", "_") + "_command_format.h" + "\"");












                //private module header

                foreach (String inc_module_name in module_inc_file_list)
                {
                    if(inc_module_name.Length > 0)
                    {
                        src_file_stream.WriteLine("#include \"" + inc_module_name + "\"");
                    }
                }
                
                src_file_stream.WriteLine("");
                src_file_stream.WriteLine("");

                if (current_module.Code != null)
                {
                    src_file_stream.WriteLine(current_module.Code);
                }

                
                src_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Custom Function definition"));

                foreach (DrvrCatFunction curr_function in current_module.Module_functions_list)
                {
                    function_declaration_builder.AppendLine(curr_function.Function_Prototype);
                    src_file_stream.WriteLine(curr_function.Code);
                }

           
                inc_file_stream.WriteLine(DrvrCatCodeBuilder.Section_Header_Comment("Function declaration"));
                inc_file_stream.WriteLine(function_declaration_builder.ToString());


                inc_file_stream.WriteLine("#ifdef __cplusplus");
                inc_file_stream.WriteLine("}/* close the extern \"C\" { */");
                inc_file_stream.WriteLine("#endif");


                inc_file_stream.WriteLine("#endif");

                inc_file_stream.Close();
                src_file_stream.Close();

            }
        }
    }
}