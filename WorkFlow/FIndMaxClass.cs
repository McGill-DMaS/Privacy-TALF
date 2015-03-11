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
    class FIndMaxClass
    {
        public LTClass FindMaxF(List<ScoreClass> ScoreArray)
        {
            LTClass p = new LTClass(0, 0, 0, 0);
            double max = 0;
            foreach (ScoreClass temp in ScoreArray)
            {
                if (temp.Score > max)
                {
                    max = temp.Score;
                    p.location = temp.location;
                    p.time = temp.time;
                }
            }
            return p;
        }
    }
}
