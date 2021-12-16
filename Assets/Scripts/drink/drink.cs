using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drink
{
    public string constellation {get; set;}

    List<ingredient> ingredients;
    int happinessScore;

    void CalculateScore() {
        int score = 10
        happinessScore = score;
    }

    int GetScore() {
        return happinessScore;
    }
}
