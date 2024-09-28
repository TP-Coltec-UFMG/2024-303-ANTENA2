using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MensagensChegando : MonoBehaviour
{
    [SerializeField] private MensagemNova mensagemNova;
    [SerializeField] public GameObject[] slots;
    [SerializeField] private GameObject overflow;
    public AudioSource mensagemChegando;

    private List<MensagemNova> _mensagemNovas = new();
    
    private int _numMensagensDisplay = 0;

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

        Debug.Log(slots.Length);
        Debug.Log(Instance.slots[_numMensagensDisplay].name);

        MensagemNova mensagemNovaObj = Instantiate(mensagemNova, Instance.slots[_numMensagensDisplay].transform);
        _numMensagensDisplay++;
        Debug.Log(_numMensagensDisplay);
        _mensagemNovas.Add(mensagemNovaObj);
        mensagemNovaObj.SetMensagem(mensagem);
        mensagemChegando.Play();
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
        Debug.Log(_numMensagensDisplay);
    }

    public static void HideMessages(bool state)
    {
        foreach (GameObject slot in Instance.slots)
        {
            slot.GetComponentInChildren<MensagemNova>()?.Hide(state);
        }
    }
}
