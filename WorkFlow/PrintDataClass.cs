﻿//******************************************************************************//
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
    class PrintDataClass
    {
        public void PrintF(ListBox listBox1, List<List<LTClass>> Ttable)
        {
            listBox1.Items.Clear();
            string str = "";
            foreach (List<LTClass> ltclass in Ttable)
            {
                foreach (LTClass row in ltclass)
                    if (row != ltclass[ltclass.Count - 1])
                        str = str + ("(L" + row.location.ToString() + ",T" + row.time.ToString() + ") --> ");
                    else
                        str = str + ("(L" + row.location.ToString() + ",T" + row.time.ToString() + ")");
                listBox1.Items.Add(str);
                str = "";

            }
        }
    }
}
