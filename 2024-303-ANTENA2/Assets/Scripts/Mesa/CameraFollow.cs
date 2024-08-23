using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance { get; private set; }
    public static bool CoroutineRunning;
    
    private CinemachineVirtualCamera _cvc;
    private float _cvcOrthoSizeDefault;
    [SerializeField] private Locais currentFollow;
    [SerializeField] private Transform transmissaoTransform;
    [SerializeField] private Transform maletaTransform;
    public static readonly float TvMinigamesOrthoSize = .5f;
    [SerializeField] private Transform tvMinigamesTransform;


    private void Awake()
    {
        Instance = this;
    }

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
        CoroutineRunning = true;
        float curOrthoSize = _cvc.m_Lens.OrthographicSize;
        const float duration = 1f;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            _cvc.m_Lens.OrthographicSize = Mathf.Lerp(curOrthoSize, orthoSize, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        CoroutineRunning = false;

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

    public bool IsOnZoom() {
        return _cvc.m_Lens.OrthographicSize != _cvcOrthoSizeDefault;
    }

    public enum Locais
    {
        Transmissao,
        Maleta,
        TVminigames
    }
}
