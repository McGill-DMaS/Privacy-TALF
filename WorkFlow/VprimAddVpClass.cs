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
    class VprimAddVpClass
    {
        public List<List<LTClass>> VprimAddVpF(List<List<LTClass>> V,LTClass p)
        {
            List<List<LTClass>> Vprim = new List<List<LTClass>>();
            foreach (List<LTClass> temp in V)
            {
                foreach (LTClass temp2 in temp)
                {
                    if (temp2.location == p.location && temp2.time == p.time)
                    {
                        Vprim.Add(temp);
                        break;
                    }
                    else
                    {
                        if (temp2.time > p.time)
                            break;
                    }
                }
            }
            return Vprim;
        }
    }
}
