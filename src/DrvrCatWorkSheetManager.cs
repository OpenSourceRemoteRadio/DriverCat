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
using Excel = Microsoft.Office.Interop.Excel;

namespace Code_Automation_Tool
{
    class DrvrCatWorkSheetManager
    {

        public static List<String> Column_Heading_List = new List<String>()
        {
            "Register name",
            "FPGA Addr offset (in HEX)",
            "Register Size in bytes",
            "POR",
        };

        public static readonly int REGISTER_BIT_SIZE = 32;
        public static readonly String RESERVED_KEYWORD = "RESERVED";


        /// <summary>
        /// Get contents in the specified column of the table
        /// </summary>
        /// <param name="xlWorksheet"></param>
        /// <param name="Table_Name"></param>
        /// <param name="Column_Heading"></param>
        /// <returns></returns>
        internal static List<String> Get_List_by_Table_Column_Heading(Microsoft.Office.Interop.Excel._Worksheet xlWorksheet, String Table_Name, String Column_Heading)
        {
            List<String> Content_List = new List<String>();

            Excel.Range xlRange = xlWorksheet.Range[Table_Name + "[" + Column_Heading +"]"];

            for (int range_row_index = 1; range_row_index <= xlRange.Rows.Count; range_row_index++)
            {
                Content_List.Add(Convert.ToString(xlRange.Cells[range_row_index, 1].Value2));
            }

            return Content_List;
        }

        internal static String GetExcelColumnNamebyNumber(int columnNumber)
        {
            int dividend = columnNumber;
            String columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        internal static int GetExcelColumnNumberbyName(String columnName)
        {
            if (string.IsNullOrEmpty(columnName)) throw new ArgumentNullException("columnName");

            columnName = columnName.ToUpperInvariant();

            int sum = 0;

            for (int i = 0; i < columnName.Length; i++)
            {
                sum *= 26;
                sum += (columnName[i] - 'A' + 1);
            }

            return sum;
        }

        internal static List<Excel.Range> Get_Bit_Def_Range_List_from_Table(Excel._Worksheet xlWorksheet, String Table_Name)
        {
            List<Excel.Range> Bit_Def_Range_List = new List<Excel.Range>();
            Excel.Range Table_Range = xlWorksheet.Range[Table_Name];
            Excel.Range Bit_Def_Range = null;
            int Table_Row_Count;
            int Table_Column_Count;

            Table_Row_Count = Table_Range.Rows.Count;
            Table_Column_Count = Table_Range.Columns.Count;

            Bit_Def_Range = Table_Range.Offset[0, Table_Column_Count].Resize[Table_Row_Count, DrvrCatWorkSheetManager.REGISTER_BIT_SIZE];

            for (int Row_Index = 1; Row_Index <= Bit_Def_Range.Rows.Count; Row_Index++)
            {
                Excel.Range Bit_Definition_Row_Range = Bit_Def_Range.Rows[Row_Index];
                Bit_Def_Range_List.Add(Bit_Definition_Row_Range);
            }

            return Bit_Def_Range_List;
        }
    }
}
