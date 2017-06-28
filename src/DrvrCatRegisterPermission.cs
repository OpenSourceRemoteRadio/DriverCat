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

namespace Code_Automation_Tool
{
    public enum DrvrCatRegisterPermission
    {
        None = 0,
        Read_Only = 1,
        Write_Only = 2,
        Read_Write = 3,
    }

    public static class RegisterPermissionExtensions
    {
        public static DrvrCatRegisterPermission Get_Permission_by_String(this DrvrCatRegisterPermission Reg_Permission, String Permission_String)
        {
            if (Permission_String.ToLower().Equals("rw"))
            {
                return DrvrCatRegisterPermission.Read_Write;
            }
            else if (Permission_String.ToLower().Equals("r"))
            {
                return DrvrCatRegisterPermission.Read_Only;
            }
            else if (Permission_String.ToLower().Equals("w"))
            {
                return DrvrCatRegisterPermission.Write_Only;
            }
            else
            {
                return DrvrCatRegisterPermission.None;
            }
        }

        public static String Get_String_by_Permission(this DrvrCatRegisterPermission Reg_Permission/*, RegisterCategory category*/)
        {
            String Permission_String = String.Empty;
            switch (Reg_Permission)
            {
                case DrvrCatRegisterPermission.None:
                    Permission_String = String.Empty;
                    break;
                case DrvrCatRegisterPermission.Read_Only:
                    Permission_String = "r";
                    break;
                case DrvrCatRegisterPermission.Read_Write:
                    Permission_String = "rw";
                    break;
                case DrvrCatRegisterPermission.Write_Only:
                    Permission_String = "w";
                    break;
                default:
                    break;
            }
            return Permission_String;
        }
    }
}
