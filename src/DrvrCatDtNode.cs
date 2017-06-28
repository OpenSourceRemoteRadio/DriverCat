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
    class DrvrCatDtNode
    {
        public String Name;
        public String Group;
        public List<String> compatible_string_list;
        public List<DrvrCatDtInterrupt> interrupt_list;
        public List<DrvrCatDtNode> child_nodes;
        public DrvrCatDtNode parent_node;


        public DrvrCatDtNode(String Name,String Group,DrvrCatDtNode parent_node)
        {
            this.Name = String.Copy(Name);
            this.Group = String.Copy(Group);
            this.parent_node = parent_node;
        }

        public List<DrvrCatDtNode> Get_Similar_Device_Node_List(List<DrvrCatDtNode> device_node_list)
        {
            List<DrvrCatDtNode> list_to_return = new List<DrvrCatDtNode>();
            foreach (DrvrCatDtNode current_node in device_node_list)
	        {
		        //if(current_node.Group.Equals(group_name))
                if(this.Equals(current_node))
                {
                    list_to_return.Add(current_node);
                }
	        }
            return list_to_return;
        }

        public override bool Equals(Object obj)
        {
            DrvrCatDtNode DT_Node_Obj = obj as DrvrCatDtNode;
            if (DT_Node_Obj == null)
            {
                return false;
            }
            else
            {
                if(Group.Equals(DT_Node_Obj.Group)==false)
                {
                    return false;
                }

                if (compatible_string_list != null)
                {
                    if (DT_Node_Obj.compatible_string_list==null)
                    {
                        return false;
                    }

                    if (compatible_string_list.Count != DT_Node_Obj.compatible_string_list.Count)
                    {
                        return false;
                    }

                    for (int index = 0; index < compatible_string_list.Count; index++)
                    {
                        if(compatible_string_list.ElementAt(index).Equals(DT_Node_Obj.compatible_string_list.ElementAt(index))==false)
                        {   
                            return false;
                        }
                    }
                }

                return true;

            }
        }

        public override int GetHashCode()
        {
            return this.Group.GetHashCode();
        }

    }
}
