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

using System.Collections.Generic;

namespace WorkFlow
{
    class UtilityClass
    {
        public int location;
        public int time;
        public int EdgesOut;
        public int Nodes;
        public int EdgeCounter;
        public int flag;
        public UtilityClass(int location, int time, int counter, int EdgesOut, int Nodes,int flag)
        {
            this.location = location;
            this.time = time;
            this.EdgeCounter = counter;
            this.EdgesOut = EdgesOut;
            this.Nodes = Nodes;
            this.flag = flag;
        }
        public List<UtilityClass> UF(List<UtilityClass> Utility, LTPairs tempNode)
        {
            foreach (LTPairs temp in tempNode.next)
            {
                int flag = 0;
                if (temp == null)
                    return null;
                foreach (UtilityClass temp2 in Utility)
                {
                    if (temp2.location == temp.location && temp2.time == temp.time)
                    {
                        temp2.Nodes++;
                        temp2.EdgeCounter = temp2.EdgeCounter + temp.counter;
                        if (temp.next[0]!= null)
                            temp2.EdgesOut = temp2.EdgesOut + temp.next.Count;
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                    if (temp.next[0] != null)
                    {
                        Utility.Add(new UtilityClass(temp.location, temp.time, temp.counter, temp.next.Count, 1,0));
                    }
                    else
                    {
                        Utility.Add(new UtilityClass(temp.location, temp.time, temp.counter, 0, 1,0));
                    }
                UF(Utility, temp);
            }
            return Utility;
        }
    }
}
