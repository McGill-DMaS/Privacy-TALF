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
    class VPrimForAnonymizeAlgortihmClass
    {
        public List<List<LTClass>> VprimF(List<List<LTClass>> Ttable, List<List<LTClass>> V, LTClass p, List<LTClass> m,List<int> mArray)
        {
            List<List<LTClass>> Vprim = new List<List<LTClass>>();
            MVSTMandTMPrimClass MVO = new MVSTMandTMPrimClass();
            
            
            if (mArray.Count == 0)
            {
                foreach (List<LTClass> list in Ttable)
                {
                    int CounterForM = 0;
                    foreach (LTClass ltClass in list)
                    {
                        if (m[CounterForM].location == ltClass.location && m[CounterForM].time == ltClass.time)
                        {
                            CounterForM++;
                            if (CounterForM == m.Count)
                            {
                                Vprim = MVO.TmTmprimF(V, list, Vprim, p);
                                break;
                            }
                        }
                        if (ltClass.time > m[CounterForM].time)
                            break;
                    }
                }
            }
            else
            {
                foreach (int i in mArray)
                {
                    Vprim = MVO.TmTmprimF(V, Ttable[i], Vprim, p);

                }
            }
            return Vprim;
        
        }
    
    }
}
