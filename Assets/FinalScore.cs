using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_finalScoreText;
    [SerializeField] private TimeScore m_timeScore;

    private void Start() {
        // Sum all scores
        float sum = 0;
        foreach (float score in TimeScore.scores) {
            sum += score;
        }
        m_finalScoreText.text = "Final Score: " + sum.ToString("F2");
    
    }
}
