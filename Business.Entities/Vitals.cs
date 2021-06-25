
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
        public bool BradyCardia => BradyCardiaThreshold.HasValue && CurrentHeartRate > BradyCardiaThreshold.Value;

        public int? BradyCardiaThreshold => this switch
        {
            Vitals { Age: { IsCurrentlyPremature: true, Is0To3MonthsOfAge: true } }  => 120,
            Vitals { Age: { IsCurrentlyPremature: false, Is0To3MonthsOfAge: true } } => 100,
            Vitals { Age: { Is3To6MonthsOfAge: true } }                              => 90,
            Vitals { Age: { Is6To12MonthsOfAge: true } }                             => 80,
            Vitals { Age: { Is1To3YearsOfAge: true } }                               => 70,
            Vitals { Age: { Is3To6YearsOfAge: true } }                               => 65,
            Vitals { Age: { Is6To12YearsOfAge: true } }                              => 60,
            Vitals { Age: { IsGreaterThan12YearsOfAge: true } }                      => 55,
            _ => null
        };


        public bool TachyCardia => TachyCardiaThreshold.HasValue && CurrentHeartRate <= TachyCardiaThreshold.Value;

        public int? TachyCardiaThreshold => this switch
        {
            Vitals { Age: { IsCurrentlyPremature: true, Is0To3MonthsOfAge: true } }  => 170,
            Vitals { Age: { IsCurrentlyPremature: false, Is0To3MonthsOfAge: true } } => 150,
            Vitals { Age: { Is3To6MonthsOfAge: true, Is6To12MonthsOfAge: true } }    => 120,
            Vitals { Age: { Is1To3YearsOfAge: true, Is3To6YearsOfAge: true } }       => 110,
            Vitals { Age: { Is6To12YearsOfAge: true } }                              => 95,
            Vitals { Age: { IsGreaterThan12YearsOfAge: true } }                      => 85,
            _ => null
        };

        public int LowRespiratoryRateThreshold => 10;
        public int HighRespiratoryRateThreshold => 20;
    }

}
