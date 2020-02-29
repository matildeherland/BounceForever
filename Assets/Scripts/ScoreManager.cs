using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum Scores
{
    NONE,
    COINS,
    SCORE,
}

public class ScoreManager : MonoBehaviour
{
    [System.Serializable]
    public class ValueText
    {
        public TextMeshProUGUI text;
        public int value;
    }

    [SerializeField] private ValueText score;
    [SerializeField] private ValueText coins;

    public void AddToType(Scores type, int toAdd)
    {
        switch (type)
        {
            case Scores.COINS:
                {
                    AddToValue(coins, toAdd);
                    break;
                }
            case Scores.SCORE:
                {
                    AddToValue(score, toAdd);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    private void AddToValue(ValueText valueText, int toAdd)
    {
        valueText.value += toAdd;
        valueText.text.text = valueText.value.ToString();
    }

    public void ResetValues()
    {
        score.value = 0;
        coins.value = 0;
        score.text.text = score.value.ToString();
        coins.text.text = coins.value.ToString();
    }

    public int GetScore()
    {
        return score.value;
    }
}
