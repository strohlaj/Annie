
namespace Business.Entities
{
    public enum BloodPressureCategory
    {
        Normal,
        Elevated,
        HypertensionStage1,
        HypertensionStage2,
        HypertensiveCrisis
    }

    // mm Hg for both Systolic and Diastolic
    public record BloodPressure(int Systolic, int Diastolic)
    {
        // May Change based on type of procedure
        public int MeanArterialPressureLowThreshhold => 65;
        public int MeanArterialPressureHighThreshhold => 105;
        // calculate mean arterial pressure to determine treatment  - gives MAP (overally profusion)
        public BloodPressureCategory Category => this switch
        {
            BloodPressure { Systolic: < 120, Diastolic: < 80  } => BloodPressureCategory.Normal,
            BloodPressure { Systolic: < 129, Diastolic: < 80  } => BloodPressureCategory.Elevated,
            BloodPressure { Systolic: < 139, Diastolic: < 89  } => BloodPressureCategory.HypertensionStage1,
            BloodPressure { Systolic: < 180, Diastolic: < 110 } => BloodPressureCategory.HypertensionStage2,
            _ => BloodPressureCategory.HypertensiveCrisis,
        };

        // Measurement of Perfusion (getting blood to organs) 
        // Quick and dirty way to see if you have adquate perfusion
        public int MeanArterialPressure => (Diastolic * 2 + Systolic) / 3;
        public bool LowMAP => MeanArterialPressure <= MeanArterialPressureLowThreshhold;
        public bool HighMAP => MeanArterialPressure > MeanArterialPressureHighThreshhold;
    }

}
