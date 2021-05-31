
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
        public BloodPressureCategory Category => this switch
        {
            BloodPressure { Systolic: < 120, Diastolic: < 80  } => BloodPressureCategory.Normal,
            BloodPressure { Systolic: < 129, Diastolic: < 80  } => BloodPressureCategory.Elevated,
            BloodPressure { Systolic: < 139, Diastolic: < 89  } => BloodPressureCategory.HypertensionStage1,
            BloodPressure { Systolic: < 180, Diastolic: < 110 } => BloodPressureCategory.HypertensionStage2,
            _ => BloodPressureCategory.HypertensiveCrisis,
        };
    }

}
