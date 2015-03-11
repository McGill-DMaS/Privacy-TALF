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
using System.Diagnostics;
using System.Windows.Forms;
namespace WorkFlow
{
    class AnonymizeAlgortimClass
    {
        public List<List<LTClass>> AnonymizeF(List<List<LTClass>> Ttable, List<ScoreClass> ScoreArray, List<List<LTClass>> V, uint L, uint K,int sc,float n, float e, float s,ListBox listbox6)
        {
            FIndMaxClass finMaxO = new FIndMaxClass();
            MforPClass MforPO = new MforPClass();
            List<LTClass> m = new List<LTClass>();
            LTClass p = new LTClass(0, 0, 0, 0);
            VPrimForAnonymizeAlgortihmClass VprimO = new VPrimForAnonymizeAlgortihmClass();
            CheckLocalSupClass ChkLoSupO = new CheckLocalSupClass();
            List<List<LTClass>> Vprim = new List<List<LTClass>>();
            SuppresPfromTmClass SuppO = new SuppresPfromTmClass();
            VprimAddVpClass VPO = new VprimAddVpClass();
            SuppresAllPfromTClass SuppAllPO = new SuppresAllPfromTClass();
            UpdateScoreClass UpdateScoreO = new UpdateScoreClass();
            RemoveVPrimFromVTClass RemO = new RemoveVPrimFromVTClass();
            Boolean valid = true;
            List<int> mArray = new List<int>();
            List<int> pArray = new List<int>();
            List<int> PArray = new List<int>();
            //ProgBar PF = new ProgBar();
            //PF.Show();

            int Vcounter = 0;
            int VCounter2 = 0;
            p = finMaxO.FindMaxF(ScoreArray);
            int counter = 0;
            double a = 0;
            double b = 0;
            while (p.location != 0 && V.Count !=0)
            {
                Vcounter = V.Count;    
                m = MforPO.MforPF(V, p);
                counter++;
                //b = counter % 500;
                //if ((b == a))
                //{
                 //   MessageBox.Show(V.Count.ToString(), "V");
                   // MessageBox.Show(p.location.ToString() + p.time.ToString(), "P");
                   // MessageBox.Show(valid.ToString(), "valid");
                //}
                
                ChkLoSupO.LocalSupFunction(Ttable, V, L, K, p, m);
                mArray = ChkLoSupO.mArray;
                PArray = ChkLoSupO.PArray;
                pArray = ChkLoSupO.pArray;
                valid = ChkLoSupO.valid;
                if (valid)
                {
                    //Stopwatch sw = new Stopwatch();
                    //sw = Stopwatch.StartNew();
                    Vprim = VprimO.VprimF(Ttable, V, p, m, mArray);

                    //sw.Stop();
                    //TimeSpan elapsedTime = sw.Elapsed;
                    //PF.listBox1.Items.Add("Generating Flowgraph : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds " + elapsedTime.Milliseconds.ToString() + " Milliseconds");
                     
                    Ttable = SuppO.SupPF(Ttable, m, p,mArray,pArray);
                    
               }
               else
                {
                    
                    Vprim = VPO.VprimAddVpF(V, p);
                    Ttable = SuppAllPO.SupPF(Ttable, p,PArray);
                   
                }
                
                V = RemO.RemoveF(V, Vprim);
               
                if (V.Count!=0)
                {
                    ScoreArray = UpdateScoreO.UpdateScoreF(Ttable, V,sc,n,e,s);
                }
                p = finMaxO.FindMaxF(ScoreArray);
                VCounter2 = Vcounter;
                if (V.Count == Vcounter)
                {
                    MessageBox.Show("Stop! V is the same!");
                }

            }
            
            return Ttable;
        }
    }
}
