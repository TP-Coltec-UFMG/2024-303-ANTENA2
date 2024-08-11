using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class DialogueUI : MonoBehaviour {
    [SerializeField] private Image background;
    [SerializeField] private TextMeshProUGUI legendas;

    public float speed = 10f;
    bool open = false;

    void Awake() {
        background = transform.GetChild(0).GetComponent<Image>();
        legendas = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    void Start() {

    }

    void Update() {
        if(open) {
            background.fillAmount = Mathf.Lerp(background.fillAmount, 1, speed * Time.deltaTime);
        } else {
            background.fillAmount = Mathf.Lerp(background.fillAmount, 0, speed * Time.deltaTime);
        }
    }
    public void Enable() {
        background.fillAmount = 0;
        open = true;
    }

    public void Disable() {
        open = false;
        legendas.text = "";
    }
}