//******************************************************************************//
// Copyright 2013 Moein Ghasemzadeh and Benjamin C. M. Fung                     //
//                                                                              //
// Licensed under the Apache License, Version 2.0 (the "License");              //
// you may not use this file except in compliance with the License.             //
// You may obtain a copy of the License at                                      //
//                                                                              //
//      http://www.apache.org/licenses/LICENSE-2.0                              //
//                                                                              //
// Unless required by applicable law or agreed to in writing, software          //
// distributed under the License is distributed on an "AS IS" BASIS,            //
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.     //
// See the License for the specific language governing permissions and          //
// limitations under the License.                                               //
//******************************************************************************//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkFlow
{
    class MVSTreeRemoveCheckedClass
    {
        public MVSTreeClass RemoveF(MVSTreeClass tempNode,MVSTreeClass MVSTree)
        {
            for (int j = 0; j < tempNode.next.Count; j++)
            {
                if (tempNode.next[j].Cheked == true)
                {
                    tempNode.next[j].Cheked = false;
                    if (tempNode.next[j].next[0] != null)
                        this.RemoveF(tempNode.next[j],MVSTree);
                    else 
                    {
                        if (tempNode.next[j].TempCounter == 0)
                        {
                            MVSTreeClass prev = tempNode.next[j];
                            while (prev!= MVSTree && prev.TempCounter==0)
                            {
                                prev.TempCounter = 1;
                                prev = prev.prev;
                            }
                        }
                    }
                }
            }
            return tempNode;
        }
    }
}
