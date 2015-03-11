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
    class GenerateQClass
    {
        public List<List<LTClass>> GenerateQF(List<LTClass> P, uint L, LTClass p)
        {
            List<List<LTClass>> Q = new List<List<LTClass>>();
            SelfJoinForGeneratingQClass SelO = new SelfJoinForGeneratingQClass();
            int j = 0;
            for (j = 0; j < P.Count; j++)
            {
                Q.Add(new List<LTClass>());
                Q[j].Add(new LTClass(P[j].location, P[j].time, 0, 0));
            }
            j = 0;
            while (j < L - 1)
            {
                Q = SelO.SelfJoinF(Q,p);
                j++;
            }  
            return Q;
        }
    }
}
