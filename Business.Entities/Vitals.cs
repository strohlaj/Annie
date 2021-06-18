
namespace Business.Entities
{
    // CurrentHeartRate in Bpm, Weight in Kgs, Bloodpressure(Diastolic/Systolic & Map), Age in years, Etcd, SPO2 as %, Breaths/minute
    public record Vitals(int CurrentHeartRate, decimal Weight, BloodPressure BloodPressure, Age Age, EndTidalCarbonDioxide Etcd, int PeripheralOxygenSaturation, int RepiratoryRate)
    {
        // Premature heart rate thresholds 120 -> 170 bpm
        // 0-3 months: 100 -> 150
        // 3-6 months: 90 -> 120
        // 6-12 months: 80 -> 120
        // 1-3 years: 70 -> 110
        // 3-6 years: 65 -> 110
        // 6-12 years: 60 -> 95
        // > 12 years: 55 -> 85
        // low bp
        public bool BradyCardia => this switch
        {
            Vitals { Age: { IsCurrentlyPremature: true, Is0To3MonthsOfAge: true }, CurrentHeartRate: < 120 }  => true,
            Vitals { Age: { IsCurrentlyPremature: false, Is0To3MonthsOfAge: true }, CurrentHeartRate: < 100 } => true,
            Vitals { Age: { Is3To6MonthsOfAge: true }, CurrentHeartRate: < 90 }                               => true,
            Vitals { Age: { Is6To12MonthsOfAge: true }, CurrentHeartRate: < 80 }                              => true,
            Vitals { Age: { Is1To3YearsOfAge: true }, CurrentHeartRate: < 70 }                                => true,
            Vitals { Age: { Is3To6YearsOfAge: true }, CurrentHeartRate: < 65 }                                => true,
            Vitals { Age: { Is6To12YearsOfAge: true }, CurrentHeartRate: < 60 }                               => true,
            Vitals { Age: { IsGreaterThan12YearsOfAge: true }, CurrentHeartRate: < 55 }                       => true,
            _ => false
        };

        public bool TachyCardia => this switch
        {
            Vitals { Age: { IsCurrentlyPremature: true, Is0To3MonthsOfAge: true }, CurrentHeartRate: > 170 }  => true,
            Vitals { Age: { IsCurrentlyPremature: false, Is0To3MonthsOfAge: true }, CurrentHeartRate: > 150 } => true,
            Vitals { Age: { Is3To6MonthsOfAge: true, Is6To12MonthsOfAge: true }, CurrentHeartRate: > 120 }    => true,
            Vitals { Age: { Is1To3YearsOfAge: true, Is3To6YearsOfAge: true }, CurrentHeartRate: > 110 }       => true,
            Vitals { Age: { Is6To12YearsOfAge: true }, CurrentHeartRate: > 95 }                               => true,
            Vitals { Age: { IsGreaterThan12YearsOfAge: true }, CurrentHeartRate: > 85 }                       => true,
            _ => false
        };

        // Configurable based on age.

        public int LowRespiratoryRateThreshold => 10;
        public int HighRespiratoryRateThreshold => 20;
    }

}
