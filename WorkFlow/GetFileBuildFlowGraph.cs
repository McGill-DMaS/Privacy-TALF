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
using System.Windows.Forms;
using System.IO;

namespace WorkFlow
{
    class GetFileBuildFlowGraph
    {
        public List<List<LTClass>> Ttable;
        public LTPairs rootNode;
        public long LCounter;
        public int numberOfRecords; 
        public void GetFileGenerateFlowGraph(string path,Label label14)
        {
            rootNode = new LTPairs(0, 0, 0, null, null);
            int i = 0;
            int location = 0;
            int time = 0;
            LCounter = 0;
            //ProgBar progbar = new ProgBar(path);
            ///////////////////////////
            numberOfRecords = 0;
            /////////////////////////
            LTPairs tempNode = rootNode;
            Ttable = new List<List<LTClass>>();
            List<LTClass> Trow = new List<LTClass>();
            int r = 0;
            //progbar.Show();
            StreamReader objReader = new StreamReader(path);
            string sLine = "";
            string LastTime = "";
            while (sLine != null)
            {
                sLine = objReader.ReadLine();
                if (sLine != null)
                {
                    Ttable.Add(new List<LTClass>());
                    //progbar.progressBar1.Value = progbar.progressBar1.Value + 1;
                    numberOfRecords++;
                    /////////////////////////////
                    string[] arrText2 = sLine.Split(',');
                    if (arrText2.Length > LCounter)
                    {
                        LCounter = arrText2.LongLength;
                    }
                    foreach (string Output1 in arrText2)
                    {
                        string[] arrText3 = Output1.Split('.');
                        foreach (string Output2 in arrText3)
                        {
                            string[] arrText4 = Output2.Split(':');
                            LastTime = arrText4[0];
                            arrText4 = null;
                        }
                        try
                        {
                            location = Int32.Parse(arrText3[0].Substring(1));
                            time = Int32.Parse(LastTime.Substring(1));
                            Ttable[r].Add(new LTClass(location, time, 0, 0));
                        }
                        catch
                        { 
                        MessageBox.Show("The Database format in not correct!","Error!");
                        Ttable = null;
                        rootNode = null;
                        return;
                        }
                        if (Output1 == arrText2[0])
                        {
                            i = 0;
                            tempNode = rootNode;
                            foreach (LTPairs tempNode2 in tempNode.next)
                            {
                                if (tempNode2 != null)
                                    if (tempNode.next[i].location != location || tempNode.next[i].time != time)
                                    {
                                        i++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                            }
                            if (tempNode.next.Count == i)
                                tempNode.next.Add(null);
                            if (tempNode.next[i] == null)
                            {
                                tempNode.next[i] = new LTPairs(location, time, 1, null, tempNode);
                            }
                            else
                            {
                                tempNode.next[i].counter++;
                            }
                            tempNode = tempNode.next[i];
                        }
                        else
                        {
                            i = 0;
                            foreach (LTPairs tempNode2 in tempNode.next)
                            {
                                if (tempNode2 != null)
                                    if (tempNode.next[i].location != location || tempNode.next[i].time != time)
                                    {
                                        i++;
                                    }
                                    else
                                    {
                                        break;
                                    }
                            }
                            if (tempNode.next.Count == i)
                                tempNode.next.Add(null);
                            if (tempNode.next[i] == null)
                            {
                                tempNode.next[i] = new LTPairs(location, time, 1, null, tempNode);
                            }
                            else
                            {
                                tempNode.next[i].counter++;
                            }
                            tempNode = tempNode.next[i];
                        }
                        arrText3 = null;
                    }
                    arrText2 = null;
                }
                r++;
            }
            objReader.Close();
            //progbar.label2.Text = "Completed!  " + progbar.progressBar1.Value.ToString() + " records";
            label14.Text = numberOfRecords.ToString();
        }
        
    }
}
