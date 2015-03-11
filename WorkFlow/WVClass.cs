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
    class WVClass
    {
        public List<List<List<LTClass>>> VFinder(MVSTreeClass tempNode, List<List<List<LTClass>>> WV,uint K, List<LTClass> prev)
        {
            foreach (MVSTreeClass temp in tempNode.next)
            {
                if (temp.TempCounter != 0)
                {
                    prev.Add(new LTClass(temp.location, temp.time, 0, 0));
                    if (temp.next[0] == null && temp.counter != 0)
                    {
                        List<LTClass> prev2 = new List<LTClass>();
                        prev2 = prev.Distinct().ToList();
                        if (temp.counter >= K)
                        {
                            WV[0].Add(prev2);
                        }
                        else
                        {
                            WV[1].Add(prev2);
                        }
                    }
                    if (temp.next[0] != null)
                        this.VFinder(temp, WV, K, prev);
                    prev.RemoveAt(prev.Count - 1);
                }
            }
            return WV;
        }
    }
}