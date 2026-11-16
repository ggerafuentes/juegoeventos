using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIJuego : MonoBehaviour
{
    [SerializeField] private TMP_Text textoContador;
    [SerializeField] private GameObject panelVictoria;
    [SerializeField] private MonoBehaviour[] desactivarAlGanar; // control del jugador
    [SerializeField] private string escenaMenu = "MenuPrincipal";

    void Start()
    {
        Time.timeScale = 1f;
        panelVictoria.SetActive(false);
        ActualizarContador(0, 8);
    }

    public void ActualizarContador(int recogidos, int total)
    {
        textoContador.text = recogidos + "/" + total;
    }

    public void MostrarVictoria()
    {
        panelVictoria.SetActive(true);

        foreach (var componente in desactivarAlGanar)
            if (componente != null) componente.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void VolverAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(escenaMenu);
    }
}