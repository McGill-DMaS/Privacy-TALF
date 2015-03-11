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
    class UpdateScoreClass
    {
        public List<ScoreClass> UpdateScoreF(List<List<LTClass>> Ttable, List<List<LTClass>> V,int sc, float n, float e, float s)
        {
            List<ScoreClass> ScoreArray = new List<ScoreClass>();
            LTPairs rootNode;
            BuildFlowTreeForVSClass BuildFlowGraph = new BuildFlowTreeForVSClass();
            List<UtilityClass> UtilityLoss = new List<UtilityClass>();
            UtilityClass ULF = new UtilityClass(0, 0, 0, 0, 0,0);
            rootNode = BuildFlowGraph.BuildFlowTreeForVSF(Ttable);
            List<UtilityClass> FinalUL = ULF.UF(UtilityLoss, rootNode);
            UtilityLoss = FinalUL;
            UtilityLoss = FinalUL.OrderBy(x => x.time).ThenBy(x => x.location).ToList();
            ScoreClass ScoreObj = new ScoreClass(0, 0, 0, 0);
            switch (sc)
            {
                case 0:
                    ScoreObj.ScoreFunctionNaiive(V, UtilityLoss,n,s);
                    ScoreArray = ScoreObj.ScoreArray;
                    break;
                case 1:
                    ScoreObj.ScoreFunction(V, UtilityLoss,n,e,s);
                    ScoreArray = ScoreObj.ScoreArray;
                    break;
                case 2:
                    ScoreObj.ScoreFunctionULE1(V, UtilityLoss);
                    ScoreArray = ScoreObj.ScoreArray;
                    break;
                case 3:
                    ScoreObj.ScoreFunctionPGE1(V, UtilityLoss,n,e,s);
                    ScoreArray = ScoreObj.ScoreArray;
                    break;
            }
            return ScoreArray;
        }
    }
}
