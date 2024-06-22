using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraLookAt : MonoBehaviour
{
    private CinemachineVirtualCamera _cvc;
    [SerializeField] private Locais currentFollow;
    [SerializeField] private Transform transmissaoTransform;
    [SerializeField] private Transform maletaTransform;


    private void Start()
    {
        _cvc = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        HandleInput();
    }

    public void LookAt(Locais local)
    {
        currentFollow = local;

        _cvc.Follow = currentFollow switch
        {
            Locais.Transmissao => transmissaoTransform,
            Locais.Maleta => maletaTransform,
            _ => _cvc.Follow
        };
    }

    private void HandleInput()
    {
        switch (currentFollow)
        {
            case Locais.Transmissao:
                if (Input.GetAxisRaw("Horizontal") > 0) // Pediu pra olhar pra direita
                    LookAt(Locais.Maleta);
                break;
            
            case Locais.Maleta:
                if (Input.GetAxisRaw("Horizontal") < 0) // Pediu pra olhar pra esquerda
                    LookAt(Locais.Transmissao);
                break;
        }
    }

    public enum Locais
    {
        Transmissao,
        Maleta
    }
}
