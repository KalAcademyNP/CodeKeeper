using System;
using System.Collections.Generic;
using System.Text;

namespace Codekeeper.Models
{
    public enum ResuscitationType
    {
        IV,
        IO
    }
    public class Resuscitation
    {

        public string TimeRecorded { get; set; }
        public ResuscitationType TypeOfResuscitation { get; set; }
        public string Placed { get; set; }
        public int Amount { get; set; }

    }
}
