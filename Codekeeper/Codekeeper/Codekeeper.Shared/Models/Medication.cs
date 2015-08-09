using System;
using System.Collections.Generic;
using System.Text;

namespace Codekeeper.Models
{
    public class Medication
    {
        /// <summary>
        /// This property will store the number of times the medication was given to the patients
        /// </summary>
        public int NumberGiven { get; set; }
        
        /// <summary>
        /// This property will store the different times the medication was given to the patients 
        /// </summary>
        public Double TimeGiven { get; set; }

        /// <summary>
        /// This property will store the dosage of the medication given to the patients
        /// </summary>
        public Double DosageGiven { get; set; }

        /// <summary>
        /// This property will store the type of medication given to the patients
        /// </summary>
        public String MedicationType { get; set; }

    }
}
