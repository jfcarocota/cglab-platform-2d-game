using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class Score : MonoBehaviour
{
    Text scoreTxt;
    [SerializeField]
    int currentScore = 0;

    void Awake()
    {
        scoreTxt = GetComponent<Text>();    
    }

    public void AddPoints(int points)
    {
        currentScore += points;
        scoreTxt.text = $"Score:{currentScore} points";
    }
}
