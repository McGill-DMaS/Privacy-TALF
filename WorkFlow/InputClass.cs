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

using System.Windows.Forms;

namespace WorkFlow
{
    class InputClass
    {
        public string path;
        public int sc;
        public int m;
        public void InF(Label label1, ComboBox combox1, ComboBox combobox2)
        {
            path = label1.Text;
            sc = combox1.SelectedIndex;
            m = combobox2.SelectedIndex;
            if (path == "")
            {
                MessageBox.Show("Please select a File!", "Error!");
                return;
            }
            if (sc== -1)
            {
                MessageBox.Show("Please select a score fucntion!", "Error!");
            }
            if( m==-1)
            {
                MessageBox.Show("Please select a method!", "Error!");
            }
        }
    }
}
