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
    class DrvrCatDoxygen
    {
        //internal static readonly int Function_Comment = 1;
        //internal static readonly int Structure_Comment = 2;
        //internal static readonly int Structure_Member_Comment = 2;

        private static readonly String Comment_Start = "/**";
        private static readonly String Comment_End = "*/";
        private static readonly String InGroup_Keyword = "@ingroup";
        private static readonly String Define_Group_Keyword = "@defgroup";
        private static readonly String Brief_Description_Keyword = "@brief";
        private static readonly String Struct_Member_Keyword = "<";
        private static readonly String Function_parameter_Keyword = "@param";
        private static readonly String Function_return_val_Keyword = "@retval";
        private static readonly String File_Name_Keyword = "@file";
        private static readonly String File_Author_Keyword = "@author";

        internal static string Generate_Structure_Comment(String description, String Group_Name)
        {
            StringBuilder Structure_Comment_Builder = new StringBuilder();
            Structure_Comment_Builder.Append(Comment_Start);

            if(!String.IsNullOrEmpty(Group_Name))
            {
                DrvrCatDoxygen.Append_New_Comment_Line(Structure_Comment_Builder);
                Structure_Comment_Builder.Append(DrvrCatDoxygen.InGroup_Keyword + " " + Group_Name);
            }

            if(!String.IsNullOrEmpty(description))
            {
                DrvrCatDoxygen.Append_New_Comment_Line(Structure_Comment_Builder);
                Structure_Comment_Builder.Append(DrvrCatDoxygen.Brief_Description_Keyword + " " + description);
            }

            DrvrCatDoxygen.Append_New_Comment_Line(Structure_Comment_Builder);
            Structure_Comment_Builder.Append(Comment_End);

            return Structure_Comment_Builder.ToString();
        }

        private static void Append_New_Comment_Line(StringBuilder Comment_Builder)
        {
            Comment_Builder.AppendLine();
            Comment_Builder.Append(" * ");
            return;
        }

        internal static String Generate_Structure_Member_Comment(String Member_description)
        {
            StringBuilder Structure_Member_Comment_Builder = new StringBuilder();
            Structure_Member_Comment_Builder.Append(Comment_Start);

            if (!String.IsNullOrEmpty(Member_description))
            {
                Structure_Member_Comment_Builder.Append(DrvrCatDoxygen.Struct_Member_Keyword + " " + Member_description);
            }
            else
            {
                return String.Empty;
            }

            Structure_Member_Comment_Builder.Append(Comment_End);

            return Structure_Member_Comment_Builder.ToString();
        }

        internal static string Generate_Enumeration_Comment(String enum_description, String Group_Name)
        {
            return Generate_Structure_Comment(enum_description, Group_Name);
        }

        internal static String Generate_Enumeration_Member_Comment(String Member_description)
        {
            return Generate_Structure_Member_Comment(Member_description);
        }

        internal static string Generate_Function_Comment(DrvrCatFunction function_to_define, String Group_Name)
        {
            StringBuilder Function_Comment_Builder = new StringBuilder();
            Function_Comment_Builder.Append(Comment_Start);

            if (!String.IsNullOrEmpty(Group_Name))
            {
                DrvrCatDoxygen.Append_New_Comment_Line(Function_Comment_Builder);
                Function_Comment_Builder.Append(DrvrCatDoxygen.InGroup_Keyword + " " + Group_Name);
            }

            if (!String.IsNullOrEmpty(function_to_define.Function_Description))
            {
                DrvrCatDoxygen.Append_New_Comment_Line(Function_Comment_Builder);
                Function_Comment_Builder.Append(DrvrCatDoxygen.Brief_Description_Keyword + " " + function_to_define.Function_Description);
            }

            if (function_to_define.Parameters != null)
            {
                foreach (DrvrCatFunctionParameter parameters in function_to_define.Parameters)
                {
                    DrvrCatDoxygen.Append_New_Comment_Line(Function_Comment_Builder);
                    Function_Comment_Builder.Append(DrvrCatDoxygen.Function_parameter_Keyword + " " + parameters.parameter_name + " " + parameters.parameter_description);
                } 
            }

            if (function_to_define.return_item.return_values != null)
            {
                foreach (DrvrCatFunctionReturnValue returns in function_to_define.return_item.return_values)
                {
                    DrvrCatDoxygen.Append_New_Comment_Line(Function_Comment_Builder);
                    Function_Comment_Builder.Append(DrvrCatDoxygen.Function_return_val_Keyword + " " + returns.Return_Value + " " + returns.Return_Context);
                }
            }

            DrvrCatDoxygen.Append_New_Comment_Line(Function_Comment_Builder);
            Function_Comment_Builder.Append(Comment_End);

            return Function_Comment_Builder.ToString();
        }

        internal static String Generate_File_Comment(String file_name, String Group_Name,String file_description,bool define_group)
        {
            StringBuilder file_comment_builder = new StringBuilder();

            file_comment_builder.Append(Comment_Start);
            DrvrCatDoxygen.Append_New_Comment_Line(file_comment_builder);
            file_comment_builder.Append(DrvrCatDoxygen.File_Name_Keyword + " " + file_name);
            DrvrCatDoxygen.Append_New_Comment_Line(file_comment_builder);
            file_comment_builder.Append(DrvrCatDoxygen.File_Author_Keyword + " " + Properties.Settings.Default.Code_Author);
            DrvrCatDoxygen.Append_New_Comment_Line(file_comment_builder);
            if (Group_Name.Equals(String.Empty) != true)
            {
                file_comment_builder.Append(((define_group) ? (DrvrCatDoxygen.Define_Group_Keyword) : (DrvrCatDoxygen.InGroup_Keyword)) + " " + Group_Name + ((define_group) ? (" " + Group_Name.ToUpper().Replace("_", " ")) : (String.Empty)));
                DrvrCatDoxygen.Append_New_Comment_Line(file_comment_builder);
            }
            file_comment_builder.Append(DrvrCatDoxygen.Brief_Description_Keyword + " " + file_description);
            DrvrCatDoxygen.Append_New_Comment_Line(file_comment_builder);
            file_comment_builder.Append(Comment_End);

            return file_comment_builder.ToString();
        }

        internal static String Generate_File_Comment(String file_name, String file_description)
        {
            StringBuilder file_comment_builder = new StringBuilder();

            file_comment_builder.Append(Comment_Start);
            DrvrCatDoxygen.Append_New_Comment_Line(file_comment_builder);
            file_comment_builder.Append(DrvrCatDoxygen.File_Name_Keyword + " " + file_name);
            DrvrCatDoxygen.Append_New_Comment_Line(file_comment_builder);
            file_comment_builder.Append(DrvrCatDoxygen.File_Author_Keyword + " " + Properties.Settings.Default.Code_Author);
            DrvrCatDoxygen.Append_New_Comment_Line(file_comment_builder);
            file_comment_builder.Append(DrvrCatDoxygen.Brief_Description_Keyword + " " + file_description);
            DrvrCatDoxygen.Append_New_Comment_Line(file_comment_builder);
            file_comment_builder.Append(Comment_End);

            return file_comment_builder.ToString();
        }
    }
}
