using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    [SerializeField] int gameScore;
    [SerializeField] Text score;

    void OnEnable()
    {
        CargoCollector.collectedCargo += AddScore;
        score.text = "0";
    }

    void OnDisable()
    {
        CargoCollector.collectedCargo -= AddScore;
    }

    void AddScore(int amount)
    {
        gameScore += amount;
        score.text = "" + gameScore;
    }

}
