using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Método para el botón Jugar
    public void Jugar()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Método para el botón Salir
    public void Salir()
    {
        Application.Quit();
        Debug.Log("El juego se cerró.");
    }

    // Método para el botón Créditos
    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }
}
