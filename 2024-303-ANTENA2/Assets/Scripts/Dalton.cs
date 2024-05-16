using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dalton : MonoBehaviour
{
    public void protanopia() {
        Colorblind.Type = 1;
    }
    
    public void tritanopia() {
        Colorblind.Type = 3;
    }
    
    public void deuteranopia() {
        Colorblind.Type = 2;
    }
    
    public void semFiltro() {
        Colorblind.Type = 0;
    }
}
