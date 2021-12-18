using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drink
{
    public string constellation {get; set;}
    int happinessScore;

    void CalculateScore(List<ingredient> ingredients;) {
        int score = 10;
        happinessScore = score;
    }

    int GetScore() {
        return happinessScore;
    }
}
