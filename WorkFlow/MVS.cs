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
using System.Windows.Forms;

namespace WorkFlow
{
    class MVS
    {
        public List<List<LTClass>> V;
        public void MVSF(List<UtilityClass> UtilityLoss, LTPairs rootNode,List<List<LTClass>>Ttable, uint L, uint K)
        {
            List<List<LTClass>> Y = new List<List<LTClass>>();
            V = new List<List<LTClass>>();
            List<List<LTClass>> W = new List<List<LTClass>>();
            MVSTreeClass MVSTree = new MVSTreeClass(0, 0, 1, 1,true, null, null);
            MVSTree.next.Remove(null);
            RemoveSuperSeqClass RemSupSeqO = new RemoveSuperSeqClass();
            SelfJoinClass SelfJoinO = new SelfJoinClass();
            BuildTreeForMVSClass BuildTreeO = new BuildTreeForMVSClass();
            int i = 0;
            foreach (UtilityClass DistinctPairs in UtilityLoss)
            {
                MVSTree.next.Add(new MVSTreeClass(DistinctPairs.location, DistinctPairs.time, 0, 0,false, null, MVSTree));
            }
            MVSTreeCounterClass VSO = new MVSTreeCounterClass();
            MVSTreeRemoveCheckedClass RemoveChecked = new MVSTreeRemoveCheckedClass();
            List<List<List<LTClass>>> WV = new List<List<List<LTClass>>>();
            WV.Add(W);
            WV.Add(V);
            List<LTClass> prev = new List<LTClass>();
            WVClass WVO = new WVClass();
            //ProgBar PF = new ProgBar();
            //PF.Show();
            while (i < L && MVSTree.next[0]!=null)
            {
                //Stopwatch sw = Stopwatch.StartNew();

                foreach (List<LTClass> RowCnt in Ttable)
                {
                    foreach (LTClass Seq in RowCnt)
                    {
                        MVSTree = VSO.VSF(Seq, MVSTree);
                    }
                    MVSTree = RemoveChecked.RemoveF(MVSTree,MVSTree);
                }
                /*sw.Stop();
                TimeSpan elapsedTime = sw.Elapsed;
                PF.listBox1.Items.Add("Generating Flowgraph : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                sw = Stopwatch.StartNew();
                */
                //MessageBox.Show("L= " + i + " done!");
                
                WV = WVO.VFinder(MVSTree, WV, K, prev);
                
                //elapsedTime = sw.Elapsed;
                //PF.listBox1.Items.Add("Generating Flowgraph : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                V = WV[1];
                W = WV[0];
                //sw.Stop();
                // MessageBox.Show(sw.Elapsed.ToString());
                if (i < L - 1)
                {
                    Y.Clear();
                    Y.Add(new List<LTClass>());
                    
                    //sw = Stopwatch.StartNew();
                    SelfJoinO.SelfJoinF(W);
                    Y = SelfJoinO.Y;
                    /*elapsedTime = sw.Elapsed;
                    PF.listBox1.Items.Add("Generating Flowgraph : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");
                    
                    sw = Stopwatch.StartNew();
                    */
                    Y = RemSupSeqO.RemoveSupSeqF(Y, V);
                    //elapsedTime = sw.Elapsed;
                    //PF.listBox1.Items.Add("Generating Flowgraph : " + elapsedTime.Minutes.ToString() + " Minutes " + elapsedTime.Seconds.ToString() + "  Seconds ");

                    BuildTreeO.BuildTreeForMVS(Y);
                    MVSTree = BuildTreeO.rootNode;
                }
                i++;
                WV[0] = new List<List<LTClass>>();
            }           
        }
    }
}
