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
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Code_Automation_Tool
{
    class DrvrCatRegister
    {
        public String Register_Name;
        public int Module_index;
        public String Module_Name;
        public int Address_offset;
        public int Register_Size_in_bytes;
        public UInt32 Power_On_Reset_Value;
        public List<DrvrCatRegisterBit> Bits;
        public String Register_Description;
        public String Code;
        public String Struct_Definition_Name;

        public DrvrCatRegister()
        {
            this.Bits = new List<DrvrCatRegisterBit>();
        }

        public DrvrCatRegister(DrvrCatRegister duplicate)
        {
            this.Register_Name = String.Copy(duplicate.Register_Name);
            this.Module_index = duplicate.Module_index;
            this.Module_Name = String.Copy(duplicate.Module_Name);
            this.Address_offset = duplicate.Address_offset;
            this.Register_Size_in_bytes = duplicate.Register_Size_in_bytes;
            this.Power_On_Reset_Value = duplicate.Power_On_Reset_Value;
            this.Bits = new List<DrvrCatRegisterBit>(); ;
            this.Bits.AddRange(duplicate.Bits);
            if (duplicate.Register_Description != null)
            {
                this.Register_Description = String.Copy(duplicate.Register_Description);
            }
            if (duplicate.Code != null)
            {
                this.Code = String.Copy(duplicate.Code);
            }
            if (duplicate.Struct_Definition_Name != null)
            {
                this.Struct_Definition_Name = String.Copy(duplicate.Struct_Definition_Name);
            }
        }

        public void Define_Register_Offset_Structure(Excel.Range Bit_Definition_Rnage)
        {  
            int current_bit_width;

            for (int current_bit_col = 1; current_bit_col <= DrvrCatWorkSheetManager.REGISTER_BIT_SIZE; current_bit_col += current_bit_width)
            {
                Excel.Range Current_Bit_Range;
                DrvrCatRegisterBit Current_Bit_Instance = new DrvrCatRegisterBit();

                Current_Bit_Range = Bit_Definition_Rnage.Cells[1, current_bit_col];
                current_bit_width = Current_Bit_Range.MergeArea.Columns.Count;

                int current_bit_least_position = DrvrCatWorkSheetManager.REGISTER_BIT_SIZE - (current_bit_col + current_bit_width) + 1;

                if (Current_Bit_Range.MergeCells)
                {
                    Current_Bit_Range = Current_Bit_Range.MergeArea.Cells[1, 1];
                }

                Current_Bit_Instance.Bit_Name = Convert.ToString(Current_Bit_Range.Value2);
                Current_Bit_Instance.Bit_Name = (Current_Bit_Instance.Bit_Name!=null) ? Current_Bit_Instance.Bit_Name.Replace("\n","").Replace("\r","").Trim() : null;
                Current_Bit_Instance.Register_Name = this.Register_Name;
                Current_Bit_Instance.Module_Index = this.Module_index;
                Current_Bit_Instance.Module_Name = this.Module_Name;
                Current_Bit_Instance.Address_offset = this.Address_offset;
                Current_Bit_Instance.Bit_Position = current_bit_least_position;
                Current_Bit_Instance.Bit_Width = current_bit_width;
                if (Current_Bit_Range.Comment != null)
                {
                    Current_Bit_Instance.Define_Configuration_Value_Description(Current_Bit_Range.Comment.Text());
                }

                this.Bits.Add(Current_Bit_Instance);
            }

            this.Bits.Reverse();
            return;
            
        }
    }
}


