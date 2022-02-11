using UnityEngine;

namespace StatHelpers
{
    public static class Calculator
    {
        // Chooses randomly from a normal distribution between a given min and max value.
        public static float RandomGaussian(float min, float max)
        {
            float u, v, S;

            do
            {
                u = 2f * Random.value - 1f;
                v = 2f * Random.value - 1f;
                S = u * u + v * v;
            }
            while (S >= 1f);

            // Standard Normal Distribution.
            float std = u * Mathf.Sqrt(-2f * Mathf.Log(S) / S);

            // Normal Distribution centered between the min and max.
            float mean = Mean(min, max);
            float sigma = (max - mean) / 3f;
            return Mathf.Clamp(std * sigma + mean, min, max);
        }

        public static float Mean(float a, float b)
        {
            return (a + b) / 2f;
        }
    }

    
}

