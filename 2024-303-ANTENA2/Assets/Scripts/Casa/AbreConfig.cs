using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbreConfig : MonoBehaviour
{
    [SerializeField] private GameObject configuracoes;
    
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
