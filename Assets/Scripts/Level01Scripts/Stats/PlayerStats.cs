using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Player
{
    private int score;
    
    public void SetScore()
    {
        score++;
    }

    public int GetScore()
    {
        return score;
    }
}
