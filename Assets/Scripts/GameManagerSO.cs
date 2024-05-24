using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameManagerSO", menuName = "ScriptableObjects/GameManagerScriptableObject", order = 1)]
public class GameManagerSO : ScriptableObject
{
    int currentScore;

    public int playerScore
    {
        get { return currentScore; }
        private set { currentScore = value; }
    }

    public void IncreasePlayerScore(int amt)
    {
        playerScore += amt;
    }
}
