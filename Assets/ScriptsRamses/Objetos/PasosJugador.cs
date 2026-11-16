using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PasosJugador : MonoBehaviour
{
    [SerializeField] private AudioClip[] pasos;
    [SerializeField] private float intervalo = 0.5f;       
    [SerializeField] private float velocidadMinima = 0.5f; 
    [SerializeField] private float distanciaSuelo = 1.3f;
    [SerializeField, Range(0f, 1f)] private float volumen = 0.6f;

    private AudioSource fuente;
    private Vector3 ultimaPosicion;
    private float temporizador;

    void Awake()
    {
        fuente = GetComponent<AudioSource>();
        fuente.playOnAwake = false;
        fuente.spatialBlend = 0f;
        ultimaPosicion = transform.position;
    }

    void Update()
    {
        if (pasos == null || pasos.Length == 0 || Time.deltaTime <= 0f) return;

        Vector3 delta = transform.position - ultimaPosicion;
        delta.y = 0f;
        float velocidad = delta.magnitude / Time.deltaTime;
        ultimaPosicion = transform.position;

        bool enSuelo = Physics.Raycast(transform.position, Vector3.down, distanciaSuelo);

        if (velocidad > velocidadMinima && enSuelo)
        {
            temporizador -= Time.deltaTime;
            if (temporizador <= 0f)
            {
                AudioClip clip = pasos[Random.Range(0, pasos.Length)];
                fuente.pitch = Random.Range(0.9f, 1.1f);
                fuente.PlayOneShot(clip, volumen);
                temporizador = intervalo;
            }
        }
        else
        {
            temporizador = 0f; 
        }
    }
}