using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraLookAt : MonoBehaviour
{
    private CinemachineVirtualCamera _cvc;
    private float _cvcOrthoSizeDefault;
    [SerializeField] private Locais currentFollow;
    [SerializeField] private Transform transmissaoTransform;
    [SerializeField] private Transform maletaTransform;
    private const float TvMinigamesOrthoSize = .5f;
    [SerializeField] private Transform tvMinigamesTransform;


    private void Start()
    {
        _cvc = GetComponent<CinemachineVirtualCamera>();
        _cvcOrthoSizeDefault = _cvc.m_Lens.OrthographicSize;
    }

    private void Update()
    {
        HandleInput();
    }

    private IEnumerator ChangeOrthoSize(float orthoSize)
    {
        float curOrthoSize = _cvc.m_Lens.OrthographicSize;
        const float duration = .5f;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            _cvc.m_Lens.OrthographicSize = Mathf.Lerp(curOrthoSize, orthoSize, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        _cvc.m_Lens.OrthographicSize = orthoSize;
    }
    
    public void Follow(Locais local, float? orthoSize)
    {
        StartCoroutine(ChangeOrthoSize(orthoSize ?? _cvcOrthoSizeDefault));
        currentFollow = local;

        _cvc.Follow = currentFollow switch
        {
            Locais.Transmissao => transmissaoTransform,
            Locais.Maleta => maletaTransform,
            Locais.TVminigames => tvMinigamesTransform,
            _ => _cvc.Follow
        };
    }

    private void HandleInput()
    {
        #region Teste TVminigame

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentFollow == Locais.TVminigames)
                Follow(Locais.Transmissao, null);
            else
                Follow(Locais.TVminigames, TvMinigamesOrthoSize);
        }
        
        #endregion
        
        switch (currentFollow)
        {
            case Locais.Transmissao:
                if (Input.GetAxisRaw("Horizontal") > 0) // Pediu pra olhar pra direita
                    Follow(Locais.Maleta, null);
                break;
            
            case Locais.Maleta:
                if (Input.GetAxisRaw("Horizontal") < 0) // Pediu pra olhar pra esquerda
                    Follow(Locais.Transmissao, null);
                break;
        }
    }

    public enum Locais
    {
        Transmissao,
        Maleta,
        TVminigames
    }
}
