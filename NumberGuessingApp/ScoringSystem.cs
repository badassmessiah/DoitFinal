public static class ScoringSystem
{
    public static int CalculateScore(int max, int attempts)
    {
        int baseScore;
        switch(max)
        {
            case 15: baseScore = 100; break; // Easy
            case 25: baseScore = 200; break; // Medium
            case 50: baseScore = 300; break; // Hard
            default: baseScore = 0; break;
        }

        return baseScore * attempts;
    }
}
