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
    class RemoveVprimFromPClass
    {
        public List<LTClass> RemoveVprimFromPF(List<LTClass> P, List<List<LTClass>> Vprim, LTClass p)
        {
            int cnt = 0;
            foreach (List<LTClass> temp in Vprim)
            {
                foreach (LTClass temp2 in temp)
                {
                    for (int i = cnt; i < P.Count; i++)
                    {
                        if (temp2.location == P[i].location && temp2.time == P[i].time && temp2.location != p.location && temp2.time != p.time)
                        {
                            P.Remove(temp2);
                            break;
                        }
                        if (temp2.time < P[i].time)
                        {
                            cnt = i;
                            break;
                        }
                    }
                }
                cnt = 0;
                if (P.Count == 1) break;
            }
            return P;
        }
    }
}
