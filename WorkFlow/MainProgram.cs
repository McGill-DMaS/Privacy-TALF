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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WorkFlow
{
    public class MainProgram
    {

        public void FlowAnonymization(Label label1, ComboBox comboBox1, TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, TextBox textBox5, TextBox textBox6, ListBox listBox6, Label label14, ListBox listBox3, ListBox listBox5, Label label8, Label label10, Label label15, Label label16, Label label9,ComboBox combobox2,int m)
        {
            InputClass INO = new InputClass();
            string path = "";
            int sc = -1;
            INO.InF(label1, comboBox1,combobox2);
            path = INO.path;
            sc = INO.sc;
            if (path == "" || sc == -1)
                return;
            GetLKClass GLKO = new GetLKClass();
            uint L;
            uint K;
            float P;
            float N;
            float S;
            float E;
            GLKO.GetLKF(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6,m);
            L = GLKO.L;
            K = GLKO.K;
            P = GLKO.P;
            N = GLKO.N;
            E = GLKO.E;
            S = GLKO.S;
            if (K == 0 || L == 0 || P == -1 || N == -1 || E == -1 || S == -1)
            {
                MessageBox.Show("Please enter the values correctly!", "Error!");
                return;
            }
            GetFileBuildFlowGraph GF = new GetFileBuildFlowGraph();
            LTPairs rootNode;
            LTPairs rootNodeAnonymize;
            List<List<LTClass>> Ttable;
            listBox6.Items.Clear();
            Stopwatch sw = Stopwatch.StartNew();
            GF.GetFileGenerateFlowGraph(path,label14);
            rootNode = GF.rootNode;
            Ttable = GF.Ttable;
            sw.Stop();
            TimeSpan elapsedTime = sw.Elapsed;
            listBox6.Items.Add("Generating Flowgraph : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

            if (Ttable != null && rootNode != null)
            {
                //List<List<LTClass>> TtableRaw = Ttable;
                List<UtilityClass> UtilityLoss = new List<UtilityClass>();
                UtilityClass ULF = new UtilityClass(0, 0, 0, 0, 0, 0);

                sw = Stopwatch.StartNew();

                List<UtilityClass> FinalUL = ULF.UF(UtilityLoss, rootNode);
                UtilityLoss = FinalUL.OrderBy(x => x.time).ThenBy(x => x.location).ToList();

                sw.Stop();
                elapsedTime = sw.Elapsed;
                listBox6.Items.Add("Calculating UtiliyLoss : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                MVS MVSO = new MVS();
                List<List<LTClass>> V;

                sw = Stopwatch.StartNew();

                MVSO.MVSF(UtilityLoss, rootNode, Ttable, L, K);
                V = MVSO.V;
                sw.Stop();
                elapsedTime = sw.Elapsed;
                listBox6.Items.Add("Generating MVS : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                ScoreClass ScoreObj = new ScoreClass(0, 0, 0, 0);
                List<ScoreClass> ScoreArray = new List<ScoreClass>();

                sw = Stopwatch.StartNew();

                switch (sc)
                {
                    case 0:
                        ScoreObj.ScoreFunctionNaiive(V, UtilityLoss,N,S);
                        ScoreArray = ScoreObj.ScoreArray;
                        break;
                    case 1:
                        ScoreObj.ScoreFunction(V, UtilityLoss, N, E, S);
                        ScoreArray = ScoreObj.ScoreArray;
                        break;
                    case 2:
                        ScoreObj.ScoreFunctionULE1(V, UtilityLoss);
                        ScoreArray = ScoreObj.ScoreArray;
                        break;
                    case 3:
                        ScoreObj.ScoreFunctionPGE1(V, UtilityLoss, N, E, S);
                        ScoreArray = ScoreObj.ScoreArray;
                        break;
                }
                sw.Stop();
                elapsedTime = sw.Elapsed;
                listBox6.Items.Add("Score Function : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                PrintDataClass PO = new PrintDataClass();
                BuildFlowTreeForVSClass BuildFlowGraph = new BuildFlowTreeForVSClass();
                AnonymizeAlgortimClass AnonymizeO = new AnonymizeAlgortimClass();

                sw = Stopwatch.StartNew();

                Ttable = AnonymizeO.AnonymizeF(Ttable, ScoreArray, V, L, K, sc, N, E, S,listBox6);

                sw.Stop();
                elapsedTime = sw.Elapsed;
                listBox6.Items.Add("Anonymization : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                sw = Stopwatch.StartNew();

                //PO.PrintF(listBox1, Ttable);

                sw.Stop();
                elapsedTime = sw.Elapsed;
                listBox6.Items.Add("Printing Anonymized Data : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                sw = Stopwatch.StartNew();

                rootNodeAnonymize = BuildFlowGraph.BuildFlowTreeForVSF(Ttable);
                string str = "";
                listBox3.Items.Clear();
                List<LTPairs> prev = null;
                PrintClass p1 = new PrintClass();
                if (rootNodeAnonymize.next[0] == null)
                    MessageBox.Show("ALL the records have been removed!", "Warning!");
                else
                {

                    //p1.print(rootNodeAnonymize, str, prev, listBox3);

                    sw.Stop();
                    elapsedTime = sw.Elapsed;
                    listBox6.Items.Add("Printing Anonymized Graph : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                    sw = Stopwatch.StartNew();


                    List<UtilityClassNew> rawGraph = new List<UtilityClassNew>();
                    List<UtilityClassNew> anonymizeGraph = new List<UtilityClassNew>();
                    UtilityClassNew ULFF = new UtilityClassNew(0, 0, 0, 0, 0, 0);
                    List<UtilityClassNew> FinalUL2 = ULFF.UF(anonymizeGraph, rootNodeAnonymize);
                    anonymizeGraph = FinalUL2.OrderBy(x => x.time).ThenBy(x => x.location).ToList();
                    FinalUL2 = ULFF.UF(rawGraph, rootNode);
                    rawGraph = FinalUL2.OrderBy(x => x.time).ThenBy(x => x.location).ToList();
                    CompareClassNew compp = new CompareClassNew();
                    double Ratio = compp.Compare(rawGraph, anonymizeGraph, P, N, E, S);

                    sw.Stop();
                    elapsedTime = sw.Elapsed;
                    listBox6.Items.Add("Comparison Part : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                    // int NumberOfStations = 0;
                    /* foreach (ComparisonClass temp in Comp)
                     {
                         NumberOfStations++;
                         if (temp.flag == 0)
                             listBox5.Items.Add("(L" + temp.location + ",T" + temp.time + ")     Difference in number of Edges Out (" + temp.EdgesOut + ")       Difference in total nubmer Of Edges (" + temp.EdgeCounter + ")      Difference in number of Nodes (" + temp.Nodes + ")");
                         else
                             listBox5.Items.Add("(L" + temp.location + ",T" + temp.time + ")     is removed from the Graph!");
                     }*/
                    listBox5.Items.Clear();
                    listBox5.Items.Add("Total similarity between the two Flowgraphs is:   " + Ratio.ToString());

                    label10.Visible = true;
                    elapsedTime = sw.Elapsed;
                    label8.Visible = true;
                    label9.Visible = true;
                    label16.Visible = true;
                    // label12.Text = "Minutes " + elapsedTime.Minutes.ToString() + "  Seconds " + elapsedTime.Seconds.ToString();
                    label15.Text = rawGraph.Count.ToString();
                    ///////
                }
            }
        
        }

    }
}
