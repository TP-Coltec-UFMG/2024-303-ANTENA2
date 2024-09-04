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

    private List<MensagemNova> _mensagemNovas = new();
    
    private int _numMensagensDisplay;

    private static MensagensChegando Instance;


    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        overflow.SetActive(/* if */ _numMensagensDisplay >= slots.Length);
    }

    public void AddMensagem(MensagemSO mensagem)
    {
        if (_numMensagensDisplay >= slots.Length) return;
        
        MensagemNova mensagemNovaObj = Instantiate(mensagemNova, slots[_numMensagensDisplay].transform);
        _mensagemNovas.Add(mensagemNovaObj);
        mensagemNovaObj.SetMensagem(mensagem);
        _numMensagensDisplay++;
    }

    public void RemoveMensagem(MensagemSO mensagem)
    {
        int slotsIndex = _mensagemNovas.FindIndex(match => match.Mensagem == mensagem);
        Destroy(slots[slotsIndex].GetComponentInChildren<MensagemNova>().gameObject);
        _mensagemNovas.RemoveAt(slotsIndex);

        for (int i = slotsIndex; i < _numMensagensDisplay - 1; i++)
        {
            GameObject newChild = slots[i + 1].GetComponentInChildren<MensagemNova>().gameObject;
            newChild.transform.SetParent(slots[i].transform, false);
        }

        _numMensagensDisplay--;
    }

    public static void HideMessages(bool state)
    {
        foreach (GameObject slot in Instance.slots)
        {
            slot.GetComponentInChildren<MensagemNova>()?.Hide(state);
        }
    }
}
