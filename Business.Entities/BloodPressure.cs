
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
        public BloodPressureCategory Category => Systolic < 120 && Diastolic < 80 ? BloodPressureCategory.Normal :
                                                  Systolic < 129 && Diastolic < 80 ? BloodPressureCategory.Elevated :
                                                  Systolic < 139 && Diastolic < 89 ? BloodPressureCategory.HypertensionStage1 :
                                                  Systolic < 180 && Diastolic < 110 ? BloodPressureCategory.HypertensionStage2 :
                                                  BloodPressureCategory.HypertensiveCrisis;
    }

}
