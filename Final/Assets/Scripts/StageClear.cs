using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StageClear : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TimeData timeData;

    private void Start() {
        int minutes = timeData.minutes;
        int seconds = timeData.seconds;
        int milliseconds = timeData.milliseconds;

        string timerString = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        timerText.text = timerString;
    }
}
