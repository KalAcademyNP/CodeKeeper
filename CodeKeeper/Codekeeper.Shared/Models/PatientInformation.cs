﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Codekeeper.Models
{
    public class PatientInformation
    {
        /// <summary>
        /// This property stores the first name of the patient
        /// </summary>
        public String FirstName { get; set; }

        /// <summary>
        /// this property stores the last name of the patient
        /// </summary>
        public String LastName { get; set; }

        /// <summary>
        /// this property stores the date of birth of the patient
        /// </summary>
        public DateTimeOffset DOB { get; set; }

        /// <summary>
        /// this property stores the gender type of the patient
        /// </summary>
        public String Gender { get; set; }

        /// <summary>
        /// this property stores the Social Security Number of the patient
        /// </summary>
        public string SSN { get; set; }

        /// <summary>
        /// this property stores the Address of the patient
        /// </summary>
        public String Address1 { get; set; }

        public String Address2 { get; set; }

        public String City { get; set; }

        public String State { get; set; }

        public int ZipCode { get; set; }

        /// <summary>
        /// this property stores the medical history of the patient
        /// </summary>

        public String History { get; set; }

        /// <summary>
        /// this property contain a list of all the medications the patients has taken-- could be long term and short term
        /// </summary>
        public String MedicationList { get; set; }

        /// <summary>
        /// this property will list out all the allergies the patient might have
        /// </summary>
        public String Allergies { get; set; }
    }
}
