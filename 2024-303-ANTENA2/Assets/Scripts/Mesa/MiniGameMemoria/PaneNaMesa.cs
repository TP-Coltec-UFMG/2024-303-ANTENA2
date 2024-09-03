using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaneNaMesa : MonoBehaviour {
    [SerializeField] GameObject Relogio;
    private PausaTempo pausaTempo;

    void Awake() {
        pausaTempo = Relogio.GetComponent<PausaTempo>();
    }
    public void desligaMesa() {
        pausaTempo.PausarJogo();
        GameHandler.Instance.PausarMensagens(true);
        Debug.Log("pausou");
    }
    public void ligaMesa() {
        pausaTempo.PausarJogo();
        GameHandler.Instance.PausarMensagens(false);
        Debug.Log("Despausou");
    }

}
