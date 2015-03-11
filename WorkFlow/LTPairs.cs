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
   public class LTPairs
    {
        public int location;
        public int time;
        public int counter;
        public List<LTPairs> next;
        public LTPairs prev;
        public LTPairs(int location,int time, int counter, LTPairs next, LTPairs prev)
        {
            this.location = location;
            this.time = time;
            this.counter = counter;
            this.next = new List<LTPairs>();
            this.next.Add(next);
            this.prev = prev;
        }
    }
}
