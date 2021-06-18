using System;
using System.Collections.Generic;
using System.Diagnostics;
using Business.Entities;

namespace Annie
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var normalBloodPressure = new BloodPressure(110, 75);
            var elevatedBloodPressure = new BloodPressure(128, 76);
            var hypertensionStage1 = new BloodPressure(135, 85);
            var hypertensionStage2 = new BloodPressure(142, 92);
            var hypertensiveCrisis = new BloodPressure(182, 115);


            var normalMap = new BloodPressure(98, 60);
            var lowMap = new BloodPressure(82, 41);
            var highMap = new BloodPressure(153, 96);

            // Debug.Assert(false);
            Debug.Assert(lowMap.LowMAP);
            Debug.Assert(highMap.HighMAP);
            Debug.Assert(!normalMap.HighMAP && !normalMap.LowMAP);



            /* Basic Unit tests to test blood pressure category */
            Debug.Assert(normalBloodPressure.Category == BloodPressureCategory.Normal);
            Debug.Assert(elevatedBloodPressure.Category == BloodPressureCategory.Elevated);
            Debug.Assert(hypertensionStage1.Category == BloodPressureCategory.HypertensionStage1);
            Debug.Assert(hypertensionStage2.Category == BloodPressureCategory.HypertensionStage2);
            Debug.Assert(hypertensiveCrisis.Category == BloodPressureCategory.HypertensiveCrisis);


            // initial Vitals
            var patientAaron = new Vitals(86, 65.7m, normalBloodPressure, new Age(new DateTime(1991, 06, 28)), new EndTidalCarbonDioxide(40), 97, 16);
            Debug.Assert(!patientAaron.BradyCardia);
            Debug.Assert(patientAaron.TachyCardia);
            // Todo create and begin simulation logic.

        }
        static List<Drug> GetAllDrugsSupply()
        {
            return new List<Drug>
            {
                new Drug("Midazolam",       5),
                new Drug("Lidocaine",       5),
                new Drug("Fentanyl",        5),
                new Drug("Propofol",        5),
                new Drug("Rocuronium",      5),
                new Drug("Succinylcholine", 5),
                new Drug("Ondansetron",     5),    
                new Drug("Dexamethason",    5),
                new Drug("Labetalol",       5),
                new Drug("Hydralazine",     5),
                new Drug("Phenylephrine",   5),
                new Drug("Ephedrine",       5),
                new Drug("Atropine",        5),
                new Drug("Glycopyrrolate",  5),
                new Drug("Neostigmine",     5),
                new Drug("Sugammadex",      5),
                new Drug("Sevolflurane",    5),
                new Drug("Desflurane",      5),
                new Drug("Isoflurane",      5),
                new Drug("NitrousOxide",    5)
            };
        }
    }
}
