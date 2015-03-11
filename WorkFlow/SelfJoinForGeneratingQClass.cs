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
    class SelfJoinForGeneratingQClass
    {
        public List<List<LTClass>> SelfJoinF(List<List<LTClass>> W,LTClass p)
        {
            List<List<LTClass>> Y = new List<List<LTClass>>();
            int j = 0;
            int flag = 0;
            int First = 0;
            for (int counter1 = 0; counter1 < W.Count; counter1++)
            {
                for (int counter2 = counter1 + 1; counter2 < W.Count; counter2++)
                {
                    List<LTClass> temp1 = W[counter1];
                    List<LTClass> temp2 = W[counter2];
                    int counter3 = 0;
                    while (temp1[counter3].location == temp2[counter3].location && temp1[counter3].time == temp2[counter3].time)
                    {
                        First = 1;
                        if (temp1[counter3].location == p.location && temp1[counter3].time == p.time)
                        {
                            flag = 1;
                        }
                        if (temp1.Count - 1 > counter3 && temp2.Count - 1 > counter3)

                            counter3++;
                        else
                        {
                            break;
                        }
                    }
                    if (First == 0)
                    {
                        if ((temp1[counter3].location == p.location && temp1[counter3].time == p.time) || (temp2[counter3].location == p.location && temp2[counter3].time == p.time))
                            flag = 1;
                    } 
                    if (flag == 1)
                        if ((counter3 == temp1.Count - 1 && temp1[counter3].time < temp2[counter3].time))
                        {
                            Y.Add(new List<LTClass>());
                            foreach (LTClass q1 in temp1)
                            {
                                Y[j].Add(new LTClass(q1.location, q1.time, 0, 0));
                            }
                            Y[j].Add(new LTClass(temp2[counter3].location, temp2[counter3].time, 0, 0));
                            j++;
                        }
                    flag = 0;
                    counter3 = 0;
                }
            }
            return Y;
        }
    }
}
