using System;

namespace Business.Entities
{
    // CurrentHeartRate in Bpm, Weight in Kgs
    public record Vitals(int CurrentHeartRate, decimal Weight, BloodPressure BloodPressure);
}
