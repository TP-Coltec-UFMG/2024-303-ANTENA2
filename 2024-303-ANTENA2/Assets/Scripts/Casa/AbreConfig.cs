using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbreConfig : MonoBehaviour
{
    [SerializeField] private GameObject configuracoes;
    [SerializeField] private GameObject botao;
    // Start is called before the first frame update
    public void Configurar(){
        botao.SetActive(false);
        configuracoes.SetActive(true);
    }
    public void Voltar(){
        configuracoes.SetActive(false);
        botao.SetActive(true);
    }
}
