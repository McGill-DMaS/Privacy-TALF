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
    class CheckLocalSupClass
    {
        public List<int> mArray;
        public List<int> pArray;
        public List<int> PArray;
        public Boolean valid;
        public void LocalSupFunction(List<List<LTClass>> Ttable, List<List<LTClass>> V, uint L, uint K, LTClass p, List<LTClass> m)
        {
            List<LTClass> P = new List<LTClass>();
            List<List<LTClass>> TpMinusTm = new List<List<LTClass>>();
            List<List<LTClass>> Vprim = new List<List<LTClass>>();
            List<List<LTClass>> VtMinusp = new List<List<LTClass>>();
            List<List<LTClass>> Q = new List<List<LTClass>>();
            PforLocalSupCheckClass PFO = new PforLocalSupCheckClass();
            ComputeqClass CMPQO = new ComputeqClass();
            RemoveSuperSeqClass RemovSupSeqO = new RemoveSuperSeqClass();
            VprimClass VPO = new VprimClass();
            RemoveVprimFromPClass RemVPO = new RemoveVprimFromPClass();
            GenerateQClass GQO = new GenerateQClass();
            PFO.PF(Ttable, p, m);
            P= PFO.P;
            TpMinusTm = PFO.TpMinusTm;
            mArray = PFO.mArray;
            pArray = PFO.pArray;
            PArray = PFO.PArray;
            VPO.VprimF(V, p);
            Vprim = VPO.Vprim;
            VtMinusp = VPO.VtMinusp;
            P = RemVPO.RemoveVprimFromPF(P, Vprim, p);
            Q = GQO.GenerateQF(P, L, p);
            Q = RemovSupSeqO.RemoveSupSeqF(Q, VtMinusp);
            valid = CMPQO.ComputeqF(TpMinusTm, Q, K);
        }
    }
}
