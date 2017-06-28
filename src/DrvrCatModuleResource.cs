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
using Excel = Microsoft.Office.Interop.Excel;
using System.Text.RegularExpressions;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.Deployment.Application;
using System.Xml;

namespace Code_Automation_Tool
{
    class DrvrCatModuleResource
    {
        public int Resource_Index;
        public String Resource_Name;
        public int Module_index;
        public String Module_Name;
        public List<DrvrCatRegister> Register_Offsets;
        public List<DrvrCatRegister> Register_Offsets_no_repeat;
        public String Code;

        public DrvrCatModuleResource(String Resource_Name, int Resource_Index, String Module_Name, int Module_index)
        {
            this.Resource_Index = Resource_Index;
            this.Resource_Name = String.Copy(Resource_Name);
            this.Module_index = Module_index;
            this.Module_Name = String.Copy(Module_Name);
            this.Register_Offsets = new List<DrvrCatRegister>();
            this.Register_Offsets_no_repeat = new List<DrvrCatRegister>();
        }


        internal void Define_Register_Map_Struct(DrvrCatExcelResourceTable Current_Sheet_Extract)
        {
            List<String> Name_List = new List<String>();
            List<String> Address_Offset_List = new List<String>();
            List<String> Size_List = new List<String>();
            List<String> POR_List = new List<String>();
            List<Excel.Range> Bit_Def_Range_List = new List<Excel.Range>();
            List<DrvrCatRegister> Register_Offsets_Unsorted = new List<DrvrCatRegister>();

            Name_List.AddRange(Current_Sheet_Extract.Get_Register_Name_List());
            Address_Offset_List.AddRange(Current_Sheet_Extract.Get_Register_Address_List());
            Size_List.AddRange(Current_Sheet_Extract.Get_Register_Size_List());
            POR_List.AddRange(Current_Sheet_Extract.Get_Power_On_Rest_Value_List());
            Bit_Def_Range_List.AddRange(Current_Sheet_Extract.Get_Bit_definition_Range_List());

            for (int Register_Index = 0; Register_Index < Current_Sheet_Extract.Max_Item_Count; Register_Index++)
            {
                DrvrCatRegister Register_Instance = new DrvrCatRegister();
                Register_Instance.Module_index = this.Module_index;
                Register_Instance.Module_Name = this.Module_Name;

                Register_Instance.Register_Name = Name_List.ElementAt(Register_Index);
                Register_Instance.Register_Description = "Definition of " + Register_Instance.Register_Name;
                Register_Instance.Address_offset = Int32.Parse(Address_Offset_List.ElementAt(Register_Index), System.Globalization.NumberStyles.HexNumber)/4;
                Register_Instance.Register_Size_in_bytes = Int32.Parse(Size_List.ElementAt(Register_Index));
                if (POR_List.ElementAt(Register_Index) != null)
                {
                    Register_Instance.Power_On_Reset_Value = UInt32.Parse(POR_List.ElementAt(Register_Index));
                }

                Register_Instance.Define_Register_Offset_Structure(Bit_Def_Range_List.ElementAt(Register_Index));
                Register_Offsets_Unsorted.Add(Register_Instance);
            }

            Register_Offsets.AddRange(Register_Offsets_Unsorted.OrderBy(register => register.Address_offset).ToList());

            Define_Register_Code();
            return;
        }


        private void Define_Register_Code()
        {
            StringBuilder Register_Structure_Definition_Block = new StringBuilder();
            DrvrCatCodeBuilder Module_Register_Map_Struct = new DrvrCatCodeBuilder();
            int expected_register_address_offset = 0;
            int reserved_reg_instance = 0;
            int register_size = 0;
            List<DrvrCatRegister> Register_Offset_with_Reserved_Reg = new List<DrvrCatRegister>();

            String Module_Resource_Struct_Name = Properties.Settings.Default.Project_Name.ToLower() + "_" + Module_Name.ToLower() + "_"  + this.Resource_Name.Trim().Replace(" ","_") ;

            Module_Register_Map_Struct.AppendLine("typedef struct");
            Module_Register_Map_Struct.Start_Block();

            for (int Register_Index = 0; Register_Index < Register_Offsets.Count; Register_Index++)
            {
                DrvrCatRegister Register_Instance = Register_Offsets.ElementAt(Register_Index);

                if (expected_register_address_offset != Register_Instance.Address_offset)
                {
                    int no_of_reserved_reg = Register_Instance.Address_offset - expected_register_address_offset;
                    reserved_reg_instance++;

                    Module_Register_Map_Struct.AddStatement("volatile unsigned int Resrvd" + reserved_reg_instance.ToString() + "[" + no_of_reserved_reg + "]");

                    for (int repeat_index = 0; repeat_index < no_of_reserved_reg; repeat_index++)
                    {
                        DrvrCatRegister reserved_register = new DrvrCatRegister();
                        reserved_register.Register_Name = "RESERVED";
                        reserved_register.Module_index = Register_Instance.Module_index;
                        reserved_register.Module_Name = Register_Instance.Module_Name;
                        reserved_register.Address_offset = expected_register_address_offset + repeat_index;
                        reserved_register.Register_Size_in_bytes = 4;
                        Register_Offset_with_Reserved_Reg.Add(reserved_register);
                    }
                    expected_register_address_offset = Register_Instance.Address_offset;
                }


                DrvrCatRegisterBit.Define_Register_Bit_Code(Register_Instance.Bits);
                //Register_Bit.Define_Register_Bit_Functions_List(Register_Instance.Bits,Register_Instance.Struct_Definition_Name);


                DrvrCatCodeBuilder Register_Offset_Def_Code = new DrvrCatCodeBuilder();



                String Register_Struct_Name = Register_Instance.Module_Name.Replace(" ", "") + "_" + Register_Instance.Register_Name.Replace(" ", "") + "_Def";
                Register_Instance.Struct_Definition_Name = Register_Struct_Name;

                Register_Offset_Def_Code.Define_32bit_register_struct(Register_Instance);
                Register_Instance.Code = String.Copy(Register_Offset_Def_Code.GetCode());
                register_size = Register_Instance.Register_Size_in_bytes / 4;


                String Regmap_definition_member_name = Register_Instance.Register_Name.Replace(" ", "");

                foreach (DrvrCatRegisterBit bit in Register_Instance.Bits)
                {
                    bit.Define_Enumeration_Code();
                    bit.Define_Function_Code(Resource_Name,Module_Resource_Struct_Name, Regmap_definition_member_name, register_size);
                }


                Register_Structure_Definition_Block.Append(Register_Instance.Code);
                Register_Structure_Definition_Block.AppendLine().AppendLine();


                if (register_size == 1)
                {
                    Module_Register_Map_Struct.AddStatement("volatile " + Register_Struct_Name + " " + Regmap_definition_member_name);
                    Register_Offset_with_Reserved_Reg.Add(Register_Instance);
                }
                else if (register_size > 1)
                {
                    Module_Register_Map_Struct.AddStatement("volatile " + Register_Struct_Name + " " + Regmap_definition_member_name + "[" + register_size + "]");
                    for (int repeat_index = 0; repeat_index < register_size; repeat_index++)
                    {
                        DrvrCatRegister duplicate_register = new DrvrCatRegister(Register_Instance);
                        duplicate_register.Address_offset += repeat_index;
                        Register_Offset_with_Reserved_Reg.Add(duplicate_register);
                    }
                }

                expected_register_address_offset += register_size;
            }

            Register_Offsets_no_repeat.AddRange(Register_Offsets);
            Register_Offsets.Clear();
            Register_Offsets.AddRange(Register_Offset_with_Reserved_Reg);


            Module_Register_Map_Struct.End_Block(Module_Resource_Struct_Name + ",*p" + Module_Resource_Struct_Name + ";");

            this.Code = String.Copy(Module_Register_Map_Struct.GetCode());
        }

    }
}