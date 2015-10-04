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

        public DateTime TimeRecorded { get; set; }
        public ResuscitationType TypeOfResuscitation { get; set; }

    }
}
