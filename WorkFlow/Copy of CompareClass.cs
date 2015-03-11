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
    class CompareClassNew
    {
        public double Compare(List<UtilityClassNew> rawGraph, List<UtilityClassNew> anonymizGraph,float p,float n, float e, float s)
        {
            double EdgeCounter = 0;
            double EdgesOut = 0;
            double Nodes = 0;
            double EdgCAvg = 0;
            double EdgOutAvg = 0;
            double NodAvg = 0;
            double FinalRatio = 0;
            int EdgeOutZero = 0;
            int iVal = 0;
            double ProbCAvg = 0;
            double ProbC = 0;
            double ProbCSum = 0;
            double ProbCnt = 0;
            foreach (var temp in rawGraph)
            {
                for (int i = iVal; i < anonymizGraph.Count;i++)
                    {
                        if (temp.location == anonymizGraph[i].location && temp.time == anonymizGraph[i].time)
                        {

                            if (temp.EdgeCounter != 0)
                            {
                                EdgeCounter = (double)anonymizGraph[i].EdgeCounter / (double)temp.EdgeCounter;
                            }
                            else
                            {
                                EdgeCounter = 0;
                            }
                            EdgCAvg += EdgeCounter;
                            if (temp.EdgesOut != 0)
                            {
                                EdgesOut = (double)anonymizGraph[i].EdgesOut / (double)temp.EdgesOut;
                            }
                            else
                            {
                                EdgesOut = 0;
                                EdgeOutZero++;
                            }
                            EdgOutAvg += EdgesOut;
                            if (temp.Nodes != 0)
                            {
                                Nodes = (double)anonymizGraph[i].Nodes / (double)temp.Nodes;
                            }
                            else
                            {
                                Nodes = 0;
                            }
                            NodAvg += Nodes;
                            List<UtilityClassNew> list1 = new List<UtilityClassNew>();
                            if(temp.Next != null)
                            {
                                list1 = temp.Next.OrderBy(x => x.time).ThenBy(x => x.location).ToList();
                            }
                            List<UtilityClassNew> list2 = new List<UtilityClassNew>();
                            if (anonymizGraph[i].Next != null)
                            {
                                list2 = anonymizGraph[i].Next.OrderBy(x => x.time).ThenBy(x => x.location).ToList();
                            }
                            ProbC = 0;
                            ProbCSum = 0;
                            int tempcnt = 0;
                            foreach( var l in list1)
                            {
                                for (int k = tempcnt; k < list2.Count; k++)
                                {
                                    if(l.location == list2[k].location && l.time == list2[k].time)
                                    {
                                      if(l.Nodes<list2[k].Nodes)
                                      {
                                          ProbC = (double)l.Nodes/(double)list2[k].Nodes;
                                      }
                                      else
                                      {
                                          ProbC = (double) list2[k].Nodes/(double) l.Nodes;
                                      }
                                        tempcnt = k + 1;
                                        ProbCSum += ProbC;
                                        break;
                                    }
                                }
                            }
                            if(ProbCSum != 0)
                            {
                                ProbCSum = (ProbCSum / (double)list1.Count);
                                ProbCAvg += ProbCSum;
                                ProbCnt++;
                            }
                            iVal = i + 1;
                            break;
                        }
                    }
            }
            ProbCAvg = Math.Round(ProbCAvg/ProbCnt, 2);
            EdgCAvg = Math.Round(EdgCAvg / rawGraph.Count, 2);
            EdgOutAvg = Math.Round(EdgOutAvg / (rawGraph.Count-EdgeOutZero), 2);
            NodAvg = Math.Round(NodAvg / rawGraph.Count, 2);
            return FinalRatio = Math.Round((EdgCAvg*s) + (EdgOutAvg*e) + (NodAvg*n) + (ProbCAvg*p), 2);
        }
    }
}
