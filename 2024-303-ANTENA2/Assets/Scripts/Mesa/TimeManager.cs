using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour {
    [Header("Clock UI")]
    [SerializeField] private TMP_Text clockText;
    [Header("Time in a day")]
    [SerializeField] private float timeInADay = 86400f;
    [Header("How fast Time Should Pass")]
    [SerializeField] private float timeScale = 2.0f;
    private float elapseTime;

    private void Start() {
        elapseTime = 9 * 3600f; //horário que começa o turno
    }

    private void Update() {
        elapseTime += Time.deltaTime * timeScale;
        elapseTime %= timeInADay;
        UpdateClockUI();
    }

    void UpdateClockUI(){
        int hours = Mathf.FloorToInt(elapseTime / 3600f);
        int minutes = Mathf.FloorToInt((elapseTime - hours * 3600f) / 60f);
        int seconds = Mathf.FloorToInt((elapseTime - hours * 3600f) - ( minutes * 60f));

        string clockString = string.Format("{00:00}:{01:00}", hours, minutes);
        clockText.text = clockString;
    }
}