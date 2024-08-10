using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WiresLogic : MonoBehaviour
{
    static public WiresLogic Instance;
    public int objectsCount;
    //public GameObject winText;
    private int onCount = 0;
    public bool Ganhou { get; private set; }
    private void Awake(){
        Instance = this;
    }
    public void SwitchChange(int points){
        onCount = onCount + points;
        if(onCount == objectsCount)
        {
            Ganhou = true;
        }
    }

    public void ResetScore()
    {
        onCount = 0;
        Ganhou = false;
    }
}
