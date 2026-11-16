using UnityEngine;
using UnityEngine.Events;

public class GameManagerObjetos : MonoBehaviour
{
    public static GameManagerObjetos Instancia { get; private set; }

    [SerializeField] private int totalObjetos = 8;
    public int Recogidos { get; private set; }

    public UnityEvent<int, int> alCambiarContador; // (recogidos, total)
    public UnityEvent alGanar;

    void Awake()
    {
        if (Instancia != null && Instancia != this) { Destroy(gameObject); return; }
        Instancia = this;
    }

    public void ObjetoRecogido()
    {
        Recogidos++;
        alCambiarContador?.Invoke(Recogidos, totalObjetos);
        if (Recogidos >= totalObjetos) alGanar?.Invoke();
    }
}