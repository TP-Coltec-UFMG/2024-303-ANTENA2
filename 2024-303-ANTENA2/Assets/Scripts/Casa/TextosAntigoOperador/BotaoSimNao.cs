using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoSimNao : MonoBehaviour {
    [SerializeField] GameObject textBox;
    [SerializeField] GameObject fundoPreto;
    public void Sim() {
        textBox.SetActive(false);
        fundoPreto.SetActive(true);
    }
    public void Nao() {
        textBox.SetActive(false);
    }
    public void fechaFundo() {
        fundoPreto.SetActive(false);
    }
}
