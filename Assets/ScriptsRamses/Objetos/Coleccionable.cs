using UnityEngine;
using UnityEngine.Audio;

public class Coleccionable : MonoBehaviour
{
    [SerializeField] private AudioClip sonidoAgarrar;
    [SerializeField] private AudioMixerGroup grupoEfectos;
    private bool yaAgarrado;

    public void Agarrar()
    {
        if (yaAgarrado) return;
        yaAgarrado = true;

        if (sonidoAgarrar != null)
            ReproductorSonido.Reproducir(sonidoAgarrar, transform.position, grupoEfectos);

        GameManagerObjetos.Instancia.ObjetoRecogido();
        Destroy(gameObject);
    }
}