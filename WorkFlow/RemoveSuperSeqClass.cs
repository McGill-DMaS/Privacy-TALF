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
    class RemoveSuperSeqClass
    {
        public List<List<LTClass>> RemoveSupSeqF(List<List<LTClass>> Y, List<List<LTClass>> V)
        {
            int j = 0;
            int flag = 0;
            if (V.Count != 0)
            {
                for (int counter = 0; counter < Y.Count; counter++)
                {
                    foreach (List<LTClass> temp2 in V)
                    {
                        List<LTClass> temp3= Y[counter];
                        for(int i=0;i<temp3.Count;i++)
                        {
                            if (temp3[i].location == temp2[j].location && temp3[i].time == temp2[j].time)
                            {
                                j++;
                                if (j == temp2.Count)
                                {
                                    Y.RemoveAt(counter);
                                    counter--;
                                    flag = 1;
                                    break;
                                }
                            }
                            if(temp3[i].time>temp2[j].time)
                                break;
                            if (temp2.Count - j > temp3.Count - i)
                                break;
                        }
                        j = 0;
                        if (flag == 1)
                        {
                            flag = 0;
                            break;
                        }
                    }
                }
            }
            return Y;
        }
    }
}
