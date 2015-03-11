using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkFlow
{
    class VS
    {
        public List<LTClass> VSF(List<LTClass> LQ, LTPairs tempNode, LTPairs rootNode, int i)
        {
            for (int j = 0; j < tempNode.next.Count; j++)
            {
                if (tempNode.next[j] == null)
                    return null;
                if (j != 0 && LQ.Count > i && i != 0)
                    if (tempNode.next[j - 1].location == LQ[i - 1].location && tempNode.next[j - 1].time == LQ[i - 1].time)
                        i--;
                if (LQ.Count > i)
                {
                    if (tempNode.next[j].location == LQ[i].location && tempNode.next[j].time == LQ[i].time)
                    {
                        LQ[i].TempT = tempNode.next[j].counter;
                        int min = LQ.Min(x => x.TempT);
                        if (min != 0 && LQ.Count == i + 1)
                        {
                            foreach (LTClass temp3 in LQ)
                            {
                                temp3.T = temp3.T + min;
                            }
                        }
                        i++;
                    }
                }
                this.VSF(LQ, tempNode.next[j], rootNode, i);
                if (tempNode.next[j].prev == rootNode)
                {
                    foreach (LTClass temp3 in LQ)
                    {
                        temp3.TempT = 0;
                    }
                }
            }
            return LQ;
        }
    }
}
