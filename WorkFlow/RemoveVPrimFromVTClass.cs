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
    class RemoveVPrimFromVTClass
    {
        public List<List<LTClass>> RemoveF(List<List<LTClass>> V, List<List<LTClass>> Vprim)
        {
            int j = 0;
            int k = 0;
            int flag = 0;
            while (k < Vprim.Count)
            {
                for (int counter = 0; counter < V.Count; counter++)
                {
                    List<LTClass> temp2 = Vprim[k];
                    List<LTClass> temp = V[counter];
                    j = 0;
                    if (temp.Count == temp2.Count)
                    {
                        while (temp[j].location == temp2[j].location && temp[j].time == temp2[j].time)
                        {
                            j++;
                            if (j == temp.Count)
                            {
                                V.Remove(temp);
                                flag = 1;
                                break;
                            }
                        }
                    }
                    if (flag == 1)
                    {
                        flag = 0;
                        break;
                    }
                }
                k++;
            }
            return V;
        }
    
    }
}
