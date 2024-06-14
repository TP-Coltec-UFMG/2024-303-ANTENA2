using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class Camera : MonoBehaviour
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
        switch (currentFollow)
        {
            case Locais.Transmissao:
                _cvc.Follow = transmissaoTransform;
                
                if (Input.GetAxisRaw("Horizontal") > 0) // Pediu pra olhar pra direita
                    currentFollow = Locais.Maleta;

                break;
            
            case Locais.Maleta:
                _cvc.Follow = maletaTransform;

                if (Input.GetAxisRaw("Horizontal") < 0) // Pediu pra olhar pra esquerda
                    currentFollow = Locais.Transmissao;

                break;
        }
    }

    private enum Locais
    {
        Transmissao,
        Maleta
    }
}
