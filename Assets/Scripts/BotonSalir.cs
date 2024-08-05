using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonQuit : MonoBehaviour
{
    public void SalirDelJuego()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
