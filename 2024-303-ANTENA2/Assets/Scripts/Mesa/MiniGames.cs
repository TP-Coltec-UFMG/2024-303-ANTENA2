using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGames : MonoBehaviour
{
    public static MiniGames Instance { get; private set; }

    private float _telinhaInitalXPos;
    [SerializeField] private Transform telinha;
    [SerializeField] private Transform telinhaToTheSide;
    [SerializeField] private GameObject fios;

    
    private void Awake()
    {
        Instance ??= this;
    }

    private void Start()
    {
        fios.SetActive(false);
        _telinhaInitalXPos = telinha.position.x;
    }

    private void Update()
    {
        if (WiresLogic.Instance is not null && !WiresLogic.Instance.Ganhou) return;
        EndFios();
    }

    public void StartFios()
    {
        CameraFollow.Instance.Follow(CameraFollow.Locais.TVminigames, CameraFollow.TvMinigamesOrthoSize);
        StartCoroutine(MoveTelinha(telinhaToTheSide.position.x));
        fios.SetActive(true);
    }

    private void EndFios()
    {
        CameraFollow.Instance.Follow(CameraFollow.Locais.Transmissao, null);
        StartCoroutine(MoveTelinha(_telinhaInitalXPos));
        fios.SetActive(false);
    }

    private IEnumerator MoveTelinha(float finalXPos)
    {
        float curXPos = telinha.position.x;
        const float duration = .5f;
        float elapsed = 0f;
        Vector3 pos = telinha.position;
        while (elapsed < duration)
        {
            pos = telinha.position;
            float newX = Mathf.Lerp(curXPos, finalXPos, elapsed / duration);
            pos.x = newX;
            telinha.position = pos;
            elapsed += Time.deltaTime;
            yield return null;
        }

        pos.x = finalXPos;
        telinha.position = pos;
    }
}
