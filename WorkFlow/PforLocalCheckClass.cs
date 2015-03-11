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
    class PforLocalSupCheckClass
    {
        public List<LTClass> P;
        public List<List<LTClass>> TpMinusTm;
        public List<int> mArray;
        public List<int> pArray;
        public List<int> PArray;
        public void PF(List<List<LTClass>> Ttable,LTClass p, List<LTClass> m)
        {
            P = new List<LTClass>();
            List<LTClass> NewP = new List<LTClass>();
            List<LTClass> Tm = new List<LTClass>();
            TpMinusTm = new List<List<LTClass>>();
            mArray = new List<int>();
            pArray = new List<int>();
            PArray = new List<int>();
            int mflags = 0;
            int pflag = 0;
            int counter = 0;
            int i = 0;
            int temp = 0;
            int Pcnt=-1;
            for (i = 0; i < Ttable.Count; i++)
            {
                Pcnt = -1;
                if (pflag == 1)
                    break;
                TpMinusTm.Add(new List<LTClass>());
                foreach (LTClass T in Ttable[i])
                {
                    Pcnt++;
                    P.Add(new LTClass(T.location, T.time, 0, 0));
                    TpMinusTm[counter].Add(new LTClass(T.location, T.time, 0, 0));
                    if (T.location == p.location && T.time == p.time)
                    {
                        pflag = 1;
                        pArray.Add(Pcnt);
                        PArray.Add(i);
                        PArray.Add(Pcnt);
                    }
                    if (mflags < m.Count)
                    {
                        if (T.location == m[mflags].location && T.time == m[mflags].time)
                        {
                            mflags++;
                        }
                    }
                }
                if (mflags == m.Count)
                {
                    mArray.Add(i);
                }
                    if (mflags != m.Count && pflag == 1)
                {
                    counter++;
                    pArray.RemoveAt(pArray.Count - 1);
                }
                else
                {
                    TpMinusTm.RemoveAt(counter);
                }
                if (pflag == 0)
                {
                    P.Clear();
                    NewP.Clear();
                }
            }
            mflags = 0;
            pflag = 0;
            for (int cnt = i; cnt < Ttable.Count; cnt++)
            {
                Pcnt = -1;
                TpMinusTm.Add(new List<LTClass>());
                foreach (LTClass T in Ttable[cnt])
                {
                    Pcnt++;
                    Tm.Add(new LTClass(T.location, T.time, 0, 0));
                    TpMinusTm[counter].Add(new LTClass(T.location, T.time, 0, 0));
                    if (T.location == p.location && T.time == p.time)
                    {
                        pflag = 1;
                        pArray.Add(Pcnt);
                        PArray.Add(cnt);
                        PArray.Add(Pcnt);
                    }
                    if (mflags < m.Count)
                    {
                        if (T.location == m[mflags].location && T.time == m[mflags].time)
                        {
                            mflags++;
                        }
                    }
                }
                if (mflags == m.Count)
                {
                    mArray.Add(cnt);
                }
                if (mflags != m.Count && pflag == 1)
                {
                    counter++;
                    pArray.RemoveAt(pArray.Count - 1);
                }
                else
                {
                    TpMinusTm.RemoveAt(counter);
                }
                if (pflag == 1)
                {
                    temp = 0;
                    for(int k=0; k<P.Count;k++)
                    {
                        for (int j = temp; j < Tm.Count; j++)
                        {
                            if (P[k].location == Tm[j].location && P[k].time == Tm[j].time)
                            {
                                temp = j + 1;
                                break;
                            }
                            else
                            {
                                if (P[k].time < Tm[j].time)
                                {
                                    P.RemoveAt(k);
                                    k--;
                                    break;
                                }
                                else
                                {
                                    if (Tm.Count == j + 1)
                                    {
                                        while (k<P.Count)
                                        {
                                            P.RemoveAt(k);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                pflag = 0;
                mflags = 0;
                Tm.Clear();
            }
            
            foreach (var VARIABLE in Ttable)
            {
                int c = 0;
                int flag = 0;
                pflag = 0;
                foreach (var T in VARIABLE)
                {
                    if (T.location == p.location && T.time == p.time)
                        pflag = 1;
                    foreach (var ltClass in NewP)
                    {
                        if (ltClass.location == T.location && ltClass.time == T.time)
                        {
                            flag = 1;
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        NewP.Add(new LTClass(T.location, T.time, 0, 0));
                        c++;
                    }
                    else
                    {
                        flag = 0;
                    }
                }
            if (pflag == 0)
                {
                    while (c > 0)
                    {
                        NewP.RemoveAt(NewP.Count - 1);
                        c--;
                    }

                }
            }
            P = NewP;
        }
    }
}
