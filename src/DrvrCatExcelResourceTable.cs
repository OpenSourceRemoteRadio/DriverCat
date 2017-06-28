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
using Excel = Microsoft.Office.Interop.Excel;

namespace Code_Automation_Tool
{
    class DrvrCatExcelResourceTable
    {
        private List<String> Register_Name_List;
        private List<String> Register_Address_List;
        private List<String> Register_Size_List;
        private List<String> Power_On_Rest_Value_List;
        private List<Excel.Range> Bit_definition_Range_List;
        public int Max_Item_Count = 0;


        public void Add_Register_Name_List(List<String> Name_List)
        {
            if (this.Register_Name_List == null)
            {
                this.Register_Name_List = new List<String>();
            }
            this.Register_Name_List.AddRange(Name_List);

            if (this.Register_Name_List.Count > this.Max_Item_Count)
            {
                this.Max_Item_Count = this.Register_Name_List.Count;
            }

        }

        public void Add_Register_Name_List(String Name)
        {
            if (this.Register_Name_List == null)
            {
                this.Register_Name_List = new List<String>();
            }
            this.Register_Name_List.Add(Name);

            if (this.Register_Name_List.Count > this.Max_Item_Count)
            {
                this.Max_Item_Count = this.Register_Name_List.Count;
            }
        }

        public void Add_Register_Address_List(List<String> Address_List)
        {
            if (this.Register_Address_List == null)
            {
                this.Register_Address_List = new List<String>();
            }
            this.Register_Address_List.AddRange(Address_List);

            if (this.Register_Address_List.Count > this.Max_Item_Count)
            {
                this.Max_Item_Count = this.Register_Address_List.Count;
            }
        }

        public void Add_Register_Address_List(String Address)
        {
            if (this.Register_Address_List == null)
            {
                this.Register_Address_List = new List<String>();
            }
            this.Register_Address_List.Add(Address);

            if (this.Register_Address_List.Count > this.Max_Item_Count)
            {
                this.Max_Item_Count = this.Register_Address_List.Count;
            }
        }

        public void Add_Register_Size_List(List<String> Size_List)
        {
            if (this.Register_Size_List == null)
            {
                this.Register_Size_List = new List<String>();
            }
            this.Register_Size_List.AddRange(Size_List);

            if (this.Register_Size_List.Count > this.Max_Item_Count)
            {
                this.Max_Item_Count = this.Register_Size_List.Count;
            }
        }

        public void Add_Register_Size_List(String Size)
        {
            if (this.Register_Size_List == null)
            {
                this.Register_Size_List = new List<String>();
            }
            this.Register_Size_List.Add(Size);

            if (this.Register_Size_List.Count > this.Max_Item_Count)
            {
                this.Max_Item_Count = this.Register_Size_List.Count;
            }
        }


        public void Add_Power_On_Rest_Value_List(List<String> POR_List)
        {
            if (this.Power_On_Rest_Value_List == null)
            {
                this.Power_On_Rest_Value_List = new List<String>();
            }
            this.Power_On_Rest_Value_List.AddRange(POR_List);

            if (this.Power_On_Rest_Value_List.Count > this.Max_Item_Count)
            {
                this.Max_Item_Count = this.Power_On_Rest_Value_List.Count;
            }
        }

        public void Add_Power_On_Rest_Value_List(String POR)
        {
            if (this.Power_On_Rest_Value_List == null)
            {
                this.Power_On_Rest_Value_List = new List<String>();
            }
            this.Power_On_Rest_Value_List.Add(POR);

            if (this.Power_On_Rest_Value_List.Count > this.Max_Item_Count)
            {
                this.Max_Item_Count = this.Power_On_Rest_Value_List.Count;
            }
        }

        public void Add_Bit_definition_Range_List(List<Excel.Range> Range_List)
        {
            if (this.Bit_definition_Range_List == null)
            {
                this.Bit_definition_Range_List = new List<Excel.Range>();
            }
            this.Bit_definition_Range_List.AddRange(Range_List);

            if (this.Bit_definition_Range_List.Count > this.Max_Item_Count)
            {
                this.Max_Item_Count = this.Bit_definition_Range_List.Count;
            }
        }

        public void Add_Bit_definition_Range_List(Excel.Range Range)
        {
            if (this.Bit_definition_Range_List == null)
            {
                this.Bit_definition_Range_List = new List<Excel.Range>();
            }
            this.Bit_definition_Range_List.Add(Range);

            if (this.Bit_definition_Range_List.Count > this.Max_Item_Count)
            {
                this.Max_Item_Count = this.Bit_definition_Range_List.Count;
            }
        }


        public List<String> Get_Register_Name_List()
        {
            return this.Register_Name_List;
        }

        public List<String> Get_Register_Address_List()
        {
            return this.Register_Address_List;
        }

        public List<String> Get_Register_Size_List()
        {
            return this.Register_Size_List;
        }

        public List<String> Get_Power_On_Rest_Value_List()
        {
            return this.Power_On_Rest_Value_List;
        }

        public List<Excel.Range> Get_Bit_definition_Range_List()
        {
            return this.Bit_definition_Range_List;
        }

    }
}
