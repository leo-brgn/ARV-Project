using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScore : MonoBehaviour
{
    // This is a Legacy text component that updates with time
    public UnityEngine.UI.Text timeText;
    public static float timeScore = 0.0f;
    // Create list of scores
    public static List<float> scores = new List<float>();

    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        timeScore += Time.deltaTime;
        timeText.text = "Time elapsed: " + timeScore.ToString("F2");
    }

    // Get if scene has changed
    public void LevelFinished() {
        scores.Add(timeScore);
        timeScore = 0.0f;
    }
}
