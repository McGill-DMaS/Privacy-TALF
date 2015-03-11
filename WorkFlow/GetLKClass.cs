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
using System.Windows.Forms;
namespace WorkFlow
{
    class GetLKClass
    {
        public uint L;
        public uint K;
        public float P;
        public float N;
        public float E;
        public float S;
        public void GetLKF(TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, TextBox textBox5, TextBox textBox6,int m)
        {
            L = 0;
            K = 0;
            P = -1;
            N = -1;
            E = -1;
            S = -1;
            if (m == 0)
            {
                try
                {
                    L = UInt32.Parse(textBox1.Text);
                }
                catch
                {
                }

            }
            try
            {
                K = UInt32.Parse(textBox2.Text);
                P = float.Parse(textBox3.Text);
                N = float.Parse(textBox4.Text);
                E = float.Parse(textBox5.Text);
                S = float.Parse(textBox6.Text);
            }
            catch
            {
                //MessageBox.Show("Please enter the value for L and K correctly!", "Error!");
            };
        }
    }
}
