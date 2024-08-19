using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbreConfig : MonoBehaviour
{
    [SerializeField] private GameObject configuracoes;
    [SerializeField] private GameObject botao;
    [SerializeField] private GameObject casa;
    [SerializeField] private GameObject boneco;
    // Start is called before the first frame update
    public void Configurar(){
        //casa.SetActive(false);
        //botao.SetActive(false);
        //boneco.SetActive(false);
        configuracoes.SetActive(true);
    }
    public void Voltar(){
        configuracoes.SetActive(false);
        //boneco.SetActive(true);
        //casa.SetActive(true);
        //botao.SetActive(true);
    }
}
