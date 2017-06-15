using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropBoxHeightWeightPrototype
{
    public class MainViewModel
    {
     
        public virtual string outputTextBox { get; set; }
        public virtual int outputFeet { get; set; }
        public virtual int outputInches { get; set; }
        public virtual bool AdvancedFormat { get; set; } = true;
        public virtual bool inInches { get; set; }
        public virtual bool inCentimeters { get; set; }
        public void btnPressed(string character)
        {
            outputTextBox += character;
        }

        public void btnClear()
        {
            outputTextBox = string.Empty;
        }

        public void btnBackspace()
        {
            string temp = outputTextBox;
            if(temp.Length>0)
                outputTextBox = temp.Substring(0, temp.Length - 1);
        }
        public void OnoutputTextBoxChanged()
        {
            
        }
        public void OnoutputFeetChanged()
        {
            int value = outputFeet * 12 + outputInches;
            outputTextBox = value.ToString();
        }
        public void OnoutputInchesChanged()
        {
            int value = outputFeet * 12 + outputInches;
            outputTextBox = value.ToString();
        }
    }
}
