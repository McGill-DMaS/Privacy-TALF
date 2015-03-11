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
    class CheckDuplicateClass
    {
        public int CheckF(List<List<LTClass>> Vprim, List<LTClass> V1)
        {
            int j = 0;
            int flag = 0;
            foreach (List<LTClass> VP1 in Vprim)
            {
                foreach (LTClass VP2 in VP1)
                {
                    if (VP2.location == V1[j].location && VP2.time == V1[j].time)
                        j++;
                }
                if (j == V1.Count)
                {
                    flag = 1;
                    break;
                }
                j = 0;
            }
            return flag;
        }
    }
}
