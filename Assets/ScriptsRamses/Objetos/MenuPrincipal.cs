using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private string escenaJuego = "FirstPerson";

    void Start()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Jugar()
{
    StartCoroutine(CargarConRetraso());
}

private IEnumerator CargarConRetraso()
{
    yield return new WaitForSecondsRealtime(0.3f);
    SceneManager.LoadScene(escenaJuego);
}

    public void Salir()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}