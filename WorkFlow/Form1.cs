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
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace WorkFlow
{

    public partial class Form1 : Form
    {
        private string path;
        private int sc;
        private int m;
        private uint L;
        private uint K;
        private float P;
        private float N;
        private float S;
        private float E;
        private LTPairs rootNode;
        private LTPairs rootNodeAnonymize;
        private List<List<LTClass>> Ttable;
        private List<UtilityClass> UtilityLoss;
        private List<List<LTClass>> V;
        private List<ScoreClass> ScoreArray;
        private List<UtilityClassNew> rawGraph;
        private List<UtilityClassNew> anonymizeGraph;
        private List<UtilityClassNew> FinalUL2;
        private double Ratio;
        public Form1()
        {
            InitializeComponent();
        }
        
        
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var FD = new OpenFileDialog();
            if (FD.ShowDialog() == DialogResult.OK)
            {
                label1.Text = FD.FileName;
                string er = Path.GetExtension(FD.FileName);
                if (er != ".txt" && er != ".csv")
                {
                    MessageBox.Show("Please browse a .txt file or .csv file!", "Error!");
                    label1.Text = "";
                }
            }
        }
        private void btnShowGraph_Click(object sender, EventArgs e)
        {
            string path = label1.Text;
            if (path == "")
            {
                MessageBox.Show("Please select a File!", "Error!");
                return;
            }
            GetFileBuildFlowGraph GF = new GetFileBuildFlowGraph();
            LTPairs rootNode;

            //Stopwatch sw = Stopwatch.StartNew();

            GF.GetFileGenerateFlowGraph(path,label14);

            //sw.Stop();
            //TimeSpan elapsedTime = sw.Elapsed;

           // MessageBox.Show(elapsedTime.ToString());
            rootNode = GF.rootNode;
            /*Ttable = GF.Ttable;
            WriteFile wf = new WriteFile();
            sw = Stopwatch.StartNew();
            wf.write(Ttable);
            sw.Stop();
            elapsedTime = sw.Elapsed;
            MessageBox.Show(elapsedTime.ToString());
            */
            

            
            listBox2.Items.Clear();
            string str = "";
            List<LTPairs> prev = null;
            PrintClass p = new PrintClass();
            if (rootNode != null)
            {
                p.print(rootNode, str, prev, listBox2);
                label7.Visible = true;

                UtilityLoss = new List<UtilityClass>();
                UtilityClass ULF = new UtilityClass(0, 0, 0, 0, 0, 0);


                List<UtilityClass> FinalUL = ULF.UF(UtilityLoss, rootNode);

                UtilityLoss = FinalUL.OrderBy(x => x.time).ThenBy(x => x.location).ToList();
                
                
                CompareClass comp = new CompareClass();
                List<UtilityClass> rootnode2 = UtilityLoss;
                //sw = Stopwatch.StartNew();
                comp.Compare(UtilityLoss, rootnode2);
                //sw.Stop();
                //elapsedTime = sw.Elapsed;
                //MessageBox.Show(elapsedTime.ToString());
                

                label15.Text = UtilityLoss.Count.ToString();
                label15.Visible = true;
                label16.Visible = true;
            }
        }
        private void btnTable_Click(object sender, EventArgs e)
        {
            string path = label1.Text;
            if (path == "")
            {
                return;
            }
            GetFileBuildFlowGraph GF = new GetFileBuildFlowGraph();
            List<List<LTClass>> Ttable;
            //Thread thread = new Thread(() => GF.GetFileGenerateFlowGraph(path));
            GF.GetFileGenerateFlowGraph(path,label14);
            Ttable = GF.Ttable;
            listBox4.Items.Clear();
            label14.Text = GF.numberOfRecords.ToString();
            string str = "";
            if (Ttable != null)
            {
                foreach (List<LTClass> ltclass in Ttable)
                {
                    foreach (LTClass row in ltclass)
                        if (row != ltclass[ltclass.Count - 1])
                            str = str + ("(L" + row.location.ToString() + ",T" + row.time.ToString() + ") --> ");
                        else
                            str = str + ("(L" + row.location.ToString() + ",T" + row.time.ToString() + ")");
                    listBox4.Items.Add(str);
                    str = "";
                }

                label14.Visible = true;
                label4.Visible = true;
                label13.Visible = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
           // MainProgram program = new MainProgram();

            //Thread othThread = new Thread(new ThreadStart(program.FlowAnonymization(label1, comboBox1, textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, listBox6, label14, listBox3, listBox5, label8, label10, label15, label16, label9,m)));
            //othThread.Start();
            
            InputClass INO = new InputClass();
            path = "";
            sc = -1;
            m = -1;
            INO.InF(label1, comboBox1, comboBox2);
            path = INO.path;
            sc = INO.sc;
            m = INO.m;
            if (path == "" || sc == -1 || m == -1)
                return;
            GetLKClass GLKO = new GetLKClass();
            GLKO.GetLKF(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6,m);
            L = GLKO.L;
            K = GLKO.K;
            P = GLKO.P;
            N = GLKO.N;
            E = GLKO.E;
            S = GLKO.S;
            if (m ==0)
            {

                if (K == 0 || L == 0 || P == -1 || N == -1 || E == -1 || S == -1)
                {
                    MessageBox.Show("Please enter the values correctly!", "Error!");
                    return;
                }
            }
            else
            {
                if (K == 0 || P == -1 || N == -1 || E == -1 || S == -1)
                {
                    MessageBox.Show("Please enter the values correctly!", "Error!");
                    return;
                }
            }
            GetFileBuildFlowGraph GF = new GetFileBuildFlowGraph();
            
            listBox6.Items.Clear();

            //Thread.CurrentThread.Name = "Main";

            Stopwatch sw = Stopwatch.StartNew();
            //Thread thread = new Thread(() => GF.GetFileGenerateFlowGraph(path));
            //thread.Start();
            //thread.Name = "Flowgraph";
            //thread.Join();
            GF.GetFileGenerateFlowGraph(path, label14);
            sw.Stop();
            rootNode = GF.rootNode;
            Ttable = GF.Ttable;
            label14.Text = GF.numberOfRecords.ToString();
            if (m == 1)
            {
                L = (uint) GF.LCounter;
            }
            GF = null;
            
            TimeSpan elapsedTime = sw.Elapsed;
            listBox6.Items.Add("Generating Flowgraph : "  + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() +  "  Seconds ");

            //MessageBox.Show("Flowgraph generation successful!");

            if (Ttable != null && rootNode != null)
            {
                //List<List<LTClass>> TtableRaw = Ttable;
                UtilityLoss = new List<UtilityClass>();
                UtilityClass ULF = new UtilityClass(0, 0, 0, 0, 0, 0);
                
                sw = Stopwatch.StartNew();

                List<UtilityClass> FinalUL = ULF.UF(UtilityLoss, rootNode);
                
                
                
                UtilityLoss = FinalUL.OrderBy(x => x.time).ThenBy(x => x.location).ToList();
                ULF = null;
                FinalUL = null;
                sw.Stop();
                elapsedTime = sw.Elapsed;
                listBox6.Items.Add("Calculating UtiliyLoss : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                //MessageBox.Show("Utility Loss successful!");

                MVS MVSO = new MVS();
                

                sw = Stopwatch.StartNew();
                
                MVSO.MVSF(UtilityLoss, rootNode,Ttable, L, K);
                V = MVSO.V;
                    sw.Stop();
                elapsedTime = sw.Elapsed;
                listBox6.Items.Add("Generating MVS : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                //MessageBox.Show("MVS successful!");
                
                MVSO = null;

                ScoreClass ScoreObj = new ScoreClass(0, 0, 0, 0);
                ScoreArray = new List<ScoreClass>();
                
                sw = Stopwatch.StartNew();

                switch (sc)
                {
                    case 0:
                        ScoreObj.ScoreFunctionNaiive(V, UtilityLoss,N,S);
                        ScoreArray = ScoreObj.ScoreArray;
                        
                        break;
                    case 1:
                        ScoreObj.ScoreFunction(V, UtilityLoss,N,E,S);
                        ScoreArray = ScoreObj.ScoreArray;
                        break;
                    case 2:
                        ScoreObj.ScoreFunctionULE1(V, UtilityLoss);
                        ScoreArray = ScoreObj.ScoreArray;
                        break;
                    case 3:
                        ScoreObj.ScoreFunctionPGE1(V, UtilityLoss,N,E,S);
                        ScoreArray = ScoreObj.ScoreArray;
                        break;
                }
                sw.Stop();
                elapsedTime = sw.Elapsed;
                listBox6.Items.Add("Score Function : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                //MessageBox.Show("Score Function successful!");

                ScoreObj = null;

                PrintDataClass PO = new PrintDataClass();
                BuildFlowTreeForVSClass BuildFlowGraph = new BuildFlowTreeForVSClass();
                AnonymizeAlgortimClass AnonymizeO = new AnonymizeAlgortimClass();
                
                sw = Stopwatch.StartNew();
                
                Ttable = AnonymizeO.AnonymizeF(Ttable, ScoreArray, V, L, K,sc,N,E,S,listBox6);
                
                sw.Stop();
                elapsedTime = sw.Elapsed;
                listBox6.Items.Add("Anonymization : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                //MessageBox.Show("Anonymization successful!");

                sw = Stopwatch.StartNew();
                
                PO.PrintF(listBox1, Ttable);
                PO = null;
                ScoreArray = null;
                V = null;
                
                AnonymizeO = null;

                sw.Stop();
                elapsedTime = sw.Elapsed;
             
                

                listBox6.Items.Add("Printing Anonymized Data : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                //MessageBox.Show("Printing Anonymized Data successful!");

                
                sw = Stopwatch.StartNew();
                WriteFile wf = new WriteFile();
                wf.write(Ttable);
                sw.Stop();
                elapsedTime = sw.Elapsed;
                listBox6.Items.Add("Writing Anonymized Data to file: " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                //MessageBox.Show("Writing Anonymized Data to file successful!");


                sw = Stopwatch.StartNew();



                rootNodeAnonymize = BuildFlowGraph.BuildFlowTreeForVSF(Ttable);
                BuildFlowGraph = null;
                
                string str = "";
                listBox3.Items.Clear();
                List<LTPairs> prev = null;
                PrintClass p1 = new PrintClass();
                if (rootNodeAnonymize.next[0] == null)
                    MessageBox.Show("ALL the records have been removed!", "Warning!");
                else
                {
                    
                    p1.print(rootNodeAnonymize, str, prev, listBox3);

                    sw.Stop();
                    elapsedTime = sw.Elapsed;
                    listBox6.Items.Add("Printing Anonymized Graph : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                    //MessageBox.Show("Printing Anonymized Graph successful!");

                    sw = Stopwatch.StartNew();

                    
                    rawGraph = new List<UtilityClassNew>();
                    anonymizeGraph = new List<UtilityClassNew>();
                    UtilityClassNew ULFF = new UtilityClassNew(0,0,0,0,0,0);
                    FinalUL2 = ULFF.UF(anonymizeGraph, rootNodeAnonymize);
                    anonymizeGraph = FinalUL2.OrderBy(x => x.time).ThenBy(x => x.location).ToList();
                    FinalUL2 = ULFF.UF(rawGraph, rootNode);
                    rawGraph = FinalUL2.OrderBy(x => x.time).ThenBy(x => x.location).ToList();
                    CompareClassNew compp = new CompareClassNew();
                    Ratio = compp.Compare(rawGraph, anonymizeGraph,P,N,E,S);

                    sw.Stop();
                    elapsedTime = sw.Elapsed;
                    listBox6.Items.Add("Comparison Part : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");


                    //MessageBox.Show("Comparison successful!");

                   // int NumberOfStations = 0;
                   /*foreach (ComparisonClass temp in Comp)
                    {
                        NumberOfStations++;
                        if (temp.flag == 0)
                            listBox5.Items.Add("(L" + temp.location + ",T" + temp.time + ")     Difference in number of Edges Out (" + temp.EdgesOut + ")       Difference in total nubmer Of Edges (" + temp.EdgeCounter + ")      Difference in number of Nodes (" + temp.Nodes + ")");
                        else
                            listBox5.Items.Add("(L" + temp.location + ",T" + temp.time + ")     is removed from the Graph!");
                    }*/
                    double raw = rawGraph.Count;
                    double anon = anonymizeGraph.Count;
                    listBox5.Items.Clear();
                    listBox5.Items.Add("Total similarity between the two Flowgraphs is:   " + Ratio.ToString());
                    double ul = Math.Round(((raw- anon)/raw), 2);
                    listBox5.Items.Add("Instance Utility Loss is: " + ul);

                    label10.Visible = true;
                    elapsedTime = sw.Elapsed;
                    label8.Visible = true;
                    label9.Visible = true;
                    label16.Visible = true;
                    label14.Visible = true;
                    label4.Visible = true;
                    label13.Visible = true;
                   // label12.Text = "Minutes " + elapsedTime.Minutes.ToString() + "  Seconds " + elapsedTime.Seconds.ToString();
                    label15.Text = rawGraph.Count.ToString();
                    ///////
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            label4.Visible= label13.Visible=label16.Visible=label7.Visible = label8.Visible = label9.Visible = label10.Visible = false;
            label14.Text = label15.Text = "";
            label14.Visible = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex == 1)
            {
                textBox1.Text = "";
                textBox1.ReadOnly = true;
            }
            else
            {
                textBox1.ReadOnly = false;
            }
        }
        
    }
}
