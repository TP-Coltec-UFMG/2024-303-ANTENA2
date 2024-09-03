using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGames : MonoBehaviour
{
    public static MiniGames Instance { get; private set; }

    private float _telinhaInitalXPos;
    [SerializeField] private Transform telinha;
    [SerializeField] private float telinhaToTheSidePosX;
    [SerializeField] private GameObject fiosGO;
    [SerializeField] private List<Wire> fios;
    [SerializeField] private PaneNaMesa paneNaMesa;
    public bool fiosOn;

    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        fiosGO.SetActive(false);
        _telinhaInitalXPos = telinha.position.x;
    }

    private void Update()
    {
        if (WiresLogic.Instance is not null && !WiresLogic.Instance.Ganhou) return;
        EndFios();
    }

    public void StartFios()
    {
        if (fiosOn) return;
        
        StartCoroutine(MoveTelinha(telinhaToTheSidePosX));
        fiosGO.SetActive(true);
        CameraFollow.Instance.Follow(CameraFollow.Locais.TVminigames, CameraFollow.TvMinigamesOrthoSize);
        fiosOn = true;
    }

    private void EndFios()
    {
        if (!fiosOn) return;
        
        CameraFollow.Instance.Follow(CameraFollow.Locais.Transmissao, null);
        StartCoroutine(MoveTelinha(-telinhaToTheSidePosX));
        ResetFios();
        fiosGO.SetActive(false);
        fiosOn = false;
        paneNaMesa.ligaMesa();
    }

    private void ResetFios()
    {
        fiosGO.SetActive(true);
        WiresLogic.Instance.ResetScore();
        foreach (Wire fio in fios)
        {
            fio.Reset();
        }
    }
    
    private IEnumerator MoveTelinha(float change)
    {
        float curXPos = telinha.position.x;
        float finalXPos = curXPos + change;
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
