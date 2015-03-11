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
    class CompareClass
    {
        public double Compare(List<UtilityClass> rawGraph, List<UtilityClass> anonymizGraph)
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
            foreach (UtilityClass temp in rawGraph)
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
                            iVal = i + 1;
                            break;
                        }
                    }
            }
            EdgCAvg = Math.Round(EdgCAvg / rawGraph.Count, 2);
            EdgOutAvg = Math.Round(EdgOutAvg / (rawGraph.Count-EdgeOutZero), 2);
            NodAvg = Math.Round(NodAvg / rawGraph.Count, 2);
            return FinalRatio = Math.Round((EdgCAvg * 0.2) + (EdgOutAvg * 0.3) + (NodAvg * 0.5),2);
        }
    }
}
