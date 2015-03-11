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


namespace WorkFlow
{
    class MVSTMandTMPrimClass
    {
        public List<List<LTClass>> TmTmprimF(List<List<LTClass>> V, List<LTClass> temp, List<List<LTClass>> Vprim, LTClass p)
        {
            int j = 0;
            int flag = 0;
          
            foreach (List<LTClass> V1 in V)
            {
                foreach (LTClass temp3 in temp)
                {
                    if (temp3.location == V1[j].location && temp3.time == V1[j].time)
                    {
                        if (V1[j].location == p.location && V1[j].time == p.time)
                            flag = 1;
                        else
                        {
                            if (temp3.time > p.time && flag==0)
                                break;
                        }
                        j++;
                        if (j == V1.Count)
                        {
                            if (flag == 1)
                            {
                                //if (CheckO.CheckF(Vprim, V1) == 0)
                                {
                                    if (!Vprim.Contains(V1))
                                    {
                                       Vprim.Add(V1);
                                    }
                                }

                            }
                            break;
                        }
                    }
                    else
                        if (temp3.time > V1[j].time)
                        {
                            break;
                        }
                }
                flag = 0;
                j = 0;
            }
            return Vprim;
        }
    }
}
