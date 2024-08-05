using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonInicio : MonoBehaviour
{
    public string nombreEscenaPrincipal = "NombreDeTuEscenaPrincipal";
    public void CargarEscenaPrincipal()
    {
        SceneManager.LoadScene(nombreEscenaPrincipal);
    }
}

