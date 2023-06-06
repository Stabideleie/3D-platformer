using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoringSystem : MonoBehaviour
{
    public static ScoringSystem instance;

    public TMP_Text scoreText;
    public TMP_Text melonText;
    public int theScore;
    public int melonScore;
    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        //scoreText.text = "fruit count: " + theScore;
    }
    public void addScore(int addScore)
    {
        theScore += addScore;
        scoreText.text = "Fruit count: " + theScore;
    }
    public void addMelonScore(int addScore)
    {
        melonScore += addScore;
        melonText.text = "Melon count: " + melonScore;
    }
}
