using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonReinicio : MonoBehaviour
{
    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
