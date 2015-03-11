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
   
    class VprimClass
    {
        public List<List<LTClass>> Vprim;
        public List<List<LTClass>> VtMinusp;
        public void VprimF(List<List<LTClass>> V, LTClass p)
        {
            Vprim = new List<List<LTClass>>();
            VtMinusp = new List<List<LTClass>>();
            int flag = 0;
            foreach (List<LTClass> temp in V)
            {
                if (temp.Count == 1)
                {
                    Vprim.Add(temp);
                }
                else
                {
                    foreach (LTClass temp2 in temp)
                    {
                        if (temp2.location == p.location && temp2.time == p.time)
                        {
                            flag = 1;
                            Vprim.Add(temp);
                            break;
                        }
                        else
                        {
                            if (p.time < temp2.time)
                                break;
                        }
                    }
                    if (flag == 0)
                    {
                        VtMinusp.Add(temp);
                    }
                    else
                    {
                        flag = 0;
                    }
                }
            }
        }
    }
}
