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
    public enum DrvrCatRegisterCategory
    {
        None = 0,
        Configuration = 1,
        Status = 2
    }
    
    public static class RegisterCategoryExtensions
    {
        public static DrvrCatRegisterCategory Get_Category_by_String(this DrvrCatRegisterCategory Reg_Category,String Category_String)
        {
            if(Category_String.ToLower().Equals("configuration"))
            {
                return DrvrCatRegisterCategory.Configuration;
            }
            else if (Category_String.ToLower().Equals("status"))
            {
                return DrvrCatRegisterCategory.Status;
            }
            else
            {
                return DrvrCatRegisterCategory.None;
            }
        }

        public static String Get_String_by_Category(this DrvrCatRegisterCategory Reg_Category/*, RegisterCategory category*/)
        {
            String Category_String = String.Empty;
            switch (Reg_Category)
            {
                case DrvrCatRegisterCategory.None:
                    Category_String = String.Empty;
                    break;
                case DrvrCatRegisterCategory.Configuration:
                    Category_String = "Configuration";
                    break;
                case DrvrCatRegisterCategory.Status:
                    Category_String = "Status";
                    break;
                default:
                    break;
            }
            return Category_String;
        }
    }
}
