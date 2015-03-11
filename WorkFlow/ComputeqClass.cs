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
    class ComputeqClass
    {

        public Boolean ComputeqF(List<List<LTClass>> TpMinusTm, List<List<LTClass>> Q, uint K)
        {        
            BuildTreeForMVSClass BuildTreeO = new BuildTreeForMVSClass();
            MVSTreeCounterClass VSO = new MVSTreeCounterClass();
            MVSTreeRemoveCheckedClass RemoveChecked = new MVSTreeRemoveCheckedClass();
            WVforLocalSuppClass WVO = new WVforLocalSuppClass();
            Boolean valid = true;
            BuildTreeO.BuildTreeForMVS(Q);
            MVSTreeClass MVSTree = BuildTreeO.rootNode;
            if (MVSTree.next[0] == null)
                return true;
            foreach (List<LTClass> RowCnt in TpMinusTm)
                {
                    foreach (LTClass Seq in RowCnt)
                    {
                        MVSTree = VSO.VSF(Seq, MVSTree);
                    }
                    MVSTree = RemoveChecked.RemoveF(MVSTree,MVSTree);
                }
            return (WVO.VFinder(MVSTree, K, valid));
        }
    }
}
