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
    class MVSTreeCounterClass
    {
        public MVSTreeClass VSF(LTClass Q, MVSTreeClass tempNode)
        {
            for (int j = 0; j < tempNode.next.Count; j++)
            {
                if (tempNode.next[j].location == Q.location && tempNode.next[j].time == Q.time)
                {
                    tempNode.next[j].Cheked = true;
                    if (tempNode.next[j].next[0] == null)
                    {
                        tempNode.next[j].counter++;
                        break;
                    }
                }
                else    
                {
                    if (tempNode.next[j].Cheked && tempNode.next[j].next[0]!=null)
                        this.VSF(Q, tempNode.next[j]);
                }
                if (j >= tempNode.next.Count - 1)
                    break;
                if (tempNode.next[j + 1].time > Q.time)
                    break;
            }
            return tempNode;
        }
    }
}
