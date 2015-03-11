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
    class UtilityClassNew
    {
        public int location;
        public int time;
        public int EdgesOut;
        public int Nodes;
        public int EdgeCounter;
        public int flag;
        public List<UtilityClassNew> Next; 
        public UtilityClassNew(int location, int time, int counter, int EdgesOut, int Nodes,int flag)
        {
            this.location = location;
            this.time = time;
            this.EdgeCounter = counter;
            this.EdgesOut = EdgesOut;
            this.Nodes = Nodes;
            this.flag = flag;
        }
        public List<UtilityClassNew> UF(List<UtilityClassNew> Utility, LTPairs tempNode)
        {
            foreach (LTPairs temp in tempNode.next)
            {
                int flag = 0;
                int flag2 = 0;
                if (temp == null)
                    return null;
                foreach (UtilityClassNew temp2 in Utility)
                {
                    if (temp2.location == temp.location && temp2.time == temp.time)
                    {
                        temp2.Nodes++;
                        temp2.EdgeCounter = temp2.EdgeCounter + temp.counter;
                        if (temp.next[0]!= null)
                            temp2.EdgesOut = temp2.EdgesOut + temp.next.Count;
                        for (int i = 0; i < temp.next.Count; i++)
                        {
                            if (temp2.Next != null && temp.next[i]!= null)
                            {
                                foreach (var Variable in temp2.Next)
                                {
                                    if (temp.next[i].location == Variable.location && temp.next[i].time == Variable.time)
                                    {
                                        Variable.Nodes++;
                                        flag2 = 1;
                                        break;
                                    }
                                }
                            }
                            if (flag2 == 0 && temp.next[i]!=null)
                            {
                                if(temp2.Next==null)
                                    temp2.Next = new List<UtilityClassNew>();
                                temp2.Next.Add(new UtilityClassNew(temp.next[i].location, temp.next[i].time,0,0,1,0));
                            }
                            else
                            {
                                flag2 = 0;
                            }
                        }
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                    if (temp.next[0] != null)
                    {
                        Utility.Add(new UtilityClassNew(temp.location, temp.time, temp.counter, temp.next.Count, 1,0));
                        Utility[Utility.Count-1].Next = new List<UtilityClassNew>();
                        foreach (var Variable in temp.next)
                        {
                            Utility[Utility.Count - 1].Next.Add(
                                (new UtilityClassNew(Variable.location, Variable.time, 0, 0, 1, 0)));
                        }
                    }
                    else
                    {
                        Utility.Add(new UtilityClassNew(temp.location, temp.time, temp.counter, 0, 1,0));
                    }
                UF(Utility, temp);
            }
            return Utility;
        }
    }
}
