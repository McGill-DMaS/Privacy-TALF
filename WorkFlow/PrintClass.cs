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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace WorkFlow
{
    class PrintClass
    {
        public int print(LTPairs tempNode, string str, List<LTPairs> prev,ListBox listBox3)
        {
            foreach (LTPairs temp in tempNode.next)
            {

                if (temp == null)
                {
                    prev.Reverse();
                    foreach (LTPairs temp3 in prev)
                        if (temp3 != prev[prev.Count - 1])
                            str = str + ("(L" + temp3.location.ToString() + ",T" + temp3.time.ToString() + ")  " + temp3.counter.ToString() + " Time(s)" + " --> ");
                        else
                            str = str + ("(L" + temp3.location.ToString() + ",T" + temp3.time.ToString() + ")  " + temp3.counter.ToString() + " Time(s)");
                    listBox3.Items.Add(str);
                    str = "";
                    return 0;
                }
                if (temp.next[0] == null)
                {
                    prev = new List<LTPairs>();
                    LTPairs temp2 = temp;
                    while (temp2.prev != null)
                    {
                        prev.Add(temp2);
                        temp2 = temp2.prev;
                    }
                }
                this.print(temp, str, prev,listBox3);
            }
            return 1;
        }
    }
}
