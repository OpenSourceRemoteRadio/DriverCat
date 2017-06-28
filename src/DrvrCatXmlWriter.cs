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
using System.Xml;

namespace Code_Automation_Tool
{
    class DrvrCatXmlWriter
    {
        internal static void Create_XML_Document(String save_path_name, List<DrvrCatModule> module_list)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(save_path_name, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Modules");
                foreach (DrvrCatModule current_regmap in module_list)
                {
                    writer.WriteStartElement("Module");
                    //writer.WriteElementString("Name", current_regmap.Module_Name);
                    writer.WriteAttributeString("Name", current_regmap.Module_Name);
                    writer.WriteAttributeString("Index", current_regmap.Module_Index.ToString());

                    writer.WriteStartElement("Resources");
                    foreach (DrvrCatModuleResource current_resource in current_regmap.Resources)
                    {
                        writer.WriteStartElement("Resource");
                        writer.WriteAttributeString("Name", current_resource.Resource_Name);
                        writer.WriteAttributeString("Index", current_resource.Resource_Index.ToString());
                        writer.WriteStartElement("Registers");

                        if (current_resource.Register_Offsets != null)
                        {
                            if (current_resource.Register_Offsets.Count > 0)
                            {
                                bool register_found = false;
                                foreach (DrvrCatRegister current_register in current_resource.Register_Offsets_no_repeat)
                                {
                                    if (current_register.Register_Name.Equals("RESERVED") == false)
                                    {
                                        register_found = true;
                                        writer.WriteStartElement("Register");
                                        writer.WriteAttributeString("Name", current_register.Register_Name);
                                        writer.WriteAttributeString("Address", current_register.Address_offset.ToString());
                                        writer.WriteAttributeString("Size_in_bytes", current_register.Register_Size_in_bytes.ToString());
                                        writer.WriteStartElement("Register_Description");
                                        writer.WriteString(current_register.Register_Description);
                                        writer.WriteEndElement();

                                        writer.WriteStartElement("Bits");
                                        if (current_register.Bits != null)
                                        {
                                            if (current_register.Bits.Count > 0)
                                            {
                                                bool bits_found = false;
                                                foreach (DrvrCatRegisterBit current_register_bit in current_register.Bits)
                                                {
                                                    if (current_register_bit.Bit_Name.Contains("Resrvd") == false)
                                                    {
                                                        bits_found = true;
                                                        writer.WriteStartElement("Bit");
                                                        writer.WriteAttributeString("Name", current_register_bit.Bit_Name);
                                                        writer.WriteAttributeString("Position", current_register_bit.Bit_Position.ToString());
                                                        writer.WriteAttributeString("Width", current_register_bit.Bit_Width.ToString());
                                                        writer.WriteAttributeString("Permission", current_register_bit.Permission.Get_String_by_Permission());

                                                        writer.WriteStartElement("Bit_Description");
                                                        writer.WriteString(current_register_bit.Bit_Description);
                                                        writer.WriteEndElement();

                                                        writer.WriteStartElement("Configurations");
                                                        if (current_register_bit.Value_Description != null)
                                                        {
                                                            if (current_register_bit.Value_Description.Count > 0)
                                                            {
                                                                foreach (DrvrCatConfigurationAction current_configuration in current_register_bit.Value_Description)
                                                                {
                                                                    writer.WriteStartElement("Configuration");
                                                                    writer.WriteAttributeString("Result", current_configuration.configuration_result);
                                                                    writer.WriteAttributeString("Value", current_configuration.configuration_value.ToString());
                                                                    writer.WriteEndElement();
                                                                }
                                                            }
                                                            else
                                                            {
                                                                writer.WriteComment("No configurations for this bit");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            writer.WriteComment("No configurations for this bit");
                                                        }

                                                        writer.WriteEndElement();
                                                        writer.WriteEndElement();
                                                    }
                                                }

                                                if (bits_found == false)
                                                {
                                                    writer.WriteComment("No bits for this register");
                                                }

                                            }
                                            else
                                            {
                                                writer.WriteComment("No bits for this register");
                                            }
                                        }
                                        else
                                        {
                                            writer.WriteComment("No bits for this register");
                                        }

                                        writer.WriteEndElement();
                                        writer.WriteEndElement();

                                    }
                                }


                                if (register_found == false)
                                {
                                    writer.WriteComment("No registers for this module");
                                }

                            }
                            else
                            {
                                writer.WriteComment("No registers for this module");
                            }

                            //writer.WriteEndElement();
                            //writer.WriteEndElement();
                        }
                        else
                        {
                            writer.WriteComment("No registers for this module");
                        }

                        writer.WriteEndElement();//registers


                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    writer.WriteStartElement("Instances");
                    foreach (String current_instance in current_regmap.Instances_Name_List)
                    {
                        writer.WriteStartElement("Instance");
                        writer.WriteAttributeString("Name", current_instance);
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();

                    writer.WriteStartElement("Configurations");

                    foreach (DrvrCatConfigServiceItem current_config in current_regmap.Config_List)
                    {
                        writer.WriteStartElement("Configuration");
                        writer.WriteAttributeString("Name", current_config.Config_Service_Name);
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();

                    writer.WriteStartElement("Services");

                    foreach (DrvrCatConfigServiceItem current_service in current_regmap.Service_List)
                    {
                        writer.WriteStartElement("Service");
                        writer.WriteAttributeString("Name", current_service.Config_Service_Name);
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();



                    writer.WriteEndElement();


                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
            return;
        }

        internal static void Create_Commands_List_XML_Document(String code_save_path, TableLayoutPanel Command_Mapper_Table_Layout)
        {

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;

            using (System.Xml.XmlWriter writer = System.Xml.XmlWriter.Create(code_save_path, settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("Commands");





                int number_of_commands = Command_Mapper_Table_Layout.RowCount - 2;
                int number_of_modules = Command_Mapper_Table_Layout.ColumnCount - 2;

                for (int row_index = 1; row_index <= number_of_commands; row_index++)
                {
                    int col_index = 0;
                    writer.WriteStartElement("command");

                    //for (int col_index = 1; col_index <= number_of_modules; col_index++)
                    //{
                    Control current_control = Command_Mapper_Table_Layout.GetControlFromPosition(col_index, row_index);

                    if (current_control is TextBox)
                    {
                        TextBox current_function_text_box = (TextBox)current_control;

                        writer.WriteAttributeString("Name", current_function_text_box.Text);

                    }
                    //}

                    writer.WriteEndElement();

                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
