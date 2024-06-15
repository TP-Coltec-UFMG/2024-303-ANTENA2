using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MensagensChegando : MonoBehaviour
{
    [SerializeField] private MensagemNova mensagemNova;
    [SerializeField] private GameObject[] slots;
    [SerializeField] private GameObject overflow;

    private int _numMensagensDisplay;
    

    private void Update()
    {
        overflow.SetActive(/* if */ _numMensagensDisplay >= slots.Length);
    }

    public void AddMensagem(MensagemSO mensagem)
    {
        if (_numMensagensDisplay >= slots.Length) return;
        
        MensagemNova mensagemNovaObj = Instantiate(mensagemNova, slots[_numMensagensDisplay].transform);
        mensagemNovaObj.SetMensagem(mensagem);
        _numMensagensDisplay++;
    }
}
