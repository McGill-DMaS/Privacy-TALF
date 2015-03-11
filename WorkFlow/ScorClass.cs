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
    class ScoreClass
    {
        public int location;
        public int time;
        public double PrivGain;
        public double Score;
        public List<ScoreClass> ScoreArray;
        public ScoreClass(int location, int time, int PrivGain, double Score)
        {
            this.location = location;
            this.time = time;
            this.PrivGain = PrivGain;
            this.Score = Score;
        }
        public void ScoreFunction(List<List<LTClass>> V, List<UtilityClass> UtilityLoss,float n, float e, float s)
        {
            ScoreArray = new List<ScoreClass>();
            int flag = 0;
            int i = 0;
            foreach (UtilityClass P in UtilityLoss)
            {
                foreach (List<LTClass> temp in V)
                {
                    foreach (LTClass temp2 in temp)
                    {
                        if (temp2.location == P.location && temp2.time == P.time)
                        {
                            foreach (ScoreClass S in ScoreArray)
                            {
                                if (S.location == P.location && S.time == P.time)
                                {
                                    S.PrivGain++;
                                    flag = 1;
                                    break;
                                }
                            }
                            if (flag == 0)
                            {
                                ScoreArray.Add(new ScoreClass(P.location, P.time,1,0));
                                flag=1;
                            }
                            break;
                        }
                    }
                }
                if (flag == 1)
                {
                    ScoreArray[i].Score = (ScoreArray[i].PrivGain)/(P.Nodes*n+ P.EdgesOut*e + P.EdgeCounter*s);
                    ScoreArray[i].Score = Math.Round(ScoreArray[i].Score, 3);
                }
                else
                {
                    ScoreArray.Add(new ScoreClass(P.location, P.time, 0, 0));
                }
                flag = 0;
                i++;
            }
        }
        public void ScoreFunctionNaiive(List<List<LTClass>> V, List<UtilityClass> UtilityLoss, float n, float s)
        {
            ScoreArray = new List<ScoreClass>();
            int flag = 0;
            int i = 0;
            Random rand = new Random();
            foreach (UtilityClass P in UtilityLoss)
            {
                foreach (List<LTClass> temp in V)
                {
                    foreach (LTClass temp2 in temp)
                    {
                        if (temp2.location == P.location && temp2.time == P.time)
                        {
                            foreach (ScoreClass S in ScoreArray)
                            {
                                if (S.location == P.location && S.time == P.time)
                                {
                                    S.PrivGain++;
                                    flag = 1;
                                    break;
                                }
                            }
                            if (flag == 0)
                            {
                                ScoreArray.Add(new ScoreClass(P.location, P.time, 1, 0));
                                flag = 1;
                            }
                            break;
                        }
                    }
                }
                if (flag == 1)
                {
                    ScoreArray[i].Score = 1;
                    //ScoreArray[i].Score = rand.Next(1,50);
                    //ScoreArray[i].Score = (double)(1) / (P.Nodes*n + P.EdgeCounter*s);
                    //ScoreArray[i].Score = (ScoreArray[i].PrivGain) / (P.Nodes);
                    //ScoreArray[i].Score = (ScoreArray[i].PrivGain) / (P.EdgeCounter);
                    //ScoreArray[i].Score = Math.Round(ScoreArray[i].Score, 3);
                }

                else
                {
                    ScoreArray.Add(new ScoreClass(P.location, P.time, 0, 0));
                }
                flag = 0;
                i++;
            }
        }
        public void ScoreFunctionULE1(List<List<LTClass>> V, List<UtilityClass> UtilityLoss)
        {
            ScoreArray = new List<ScoreClass>();
            int flag = 0;
            int i = 0;
            foreach (UtilityClass P in UtilityLoss)
            {
                foreach (List<LTClass> temp in V)
                {
                    foreach (LTClass temp2 in temp)
                    {
                        if (temp2.location == P.location && temp2.time == P.time)
                        {
                            foreach (ScoreClass S in ScoreArray)
                            {
                                if (S.location == P.location && S.time == P.time)
                                {
                                    S.PrivGain++;
                                    flag = 1;
                                    break;
                                }
                            }
                            if (flag == 0)
                            {
                                ScoreArray.Add(new ScoreClass(P.location, P.time, 1, 0));
                                flag = 1;
                            }
                            break;
                        }
                    }
                }
                if (flag == 1)
                {
                    ScoreArray[i].Score = (ScoreArray[i].PrivGain) / (1);
                    ScoreArray[i].Score = Math.Round(ScoreArray[i].Score, 3);
                }

                else
                {
                    ScoreArray.Add(new ScoreClass(P.location, P.time, 0, 0));
                }
                flag = 0;
                i++;
            }
        }
        public void ScoreFunctionPGE1(List<List<LTClass>> V, List<UtilityClass> UtilityLoss, float n, float e, float s)
        {
            ScoreArray = new List<ScoreClass>();
            int flag = 0;
            int i = 0;
            foreach (UtilityClass P in UtilityLoss)
            {
                foreach (List<LTClass> temp in V)
                {
                    foreach (LTClass temp2 in temp)
                    {
                        if (temp2.location == P.location && temp2.time == P.time)
                        {
                            foreach (ScoreClass S in ScoreArray)
                            {
                                if (S.location == P.location && S.time == P.time)
                                {
                                    S.PrivGain++;
                                    flag = 1;
                                    break;
                                }
                            }
                            if (flag == 0)
                            {
                                ScoreArray.Add(new ScoreClass(P.location, P.time, 1, 0));
                                flag = 1;
                            }
                            break;
                        }
                    }
                }
                if (flag == 1)
                {
                    ScoreArray[i].Score = (1) / (P.Nodes * n + P.EdgesOut * e + P.EdgeCounter * s);
                    ScoreArray[i].Score = Math.Round(ScoreArray[i].Score, 3);
                }

                else
                {
                    ScoreArray.Add(new ScoreClass(P.location, P.time, 0, 0));
                }
                flag = 0;
                i++;
            }
        }
    }
}
