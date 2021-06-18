
namespace Business.Entities
{
    public record EndTidalCarbonDioxide(int Level)
    {
        public int LowThreshhold => 35;
        public int HighThreshhold => 45;
    }
}
