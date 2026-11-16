using UnityEngine;

public class AnimacionLlave : MonoBehaviour
{
    [SerializeField] private float velocidadGiro = 60f;
    [SerializeField] private float alturaFlote = 0.1f;
    [SerializeField] private float velocidadFlote = 2f;

    private Vector3 posicionInicial;
    private float fase;

    void Start()
    {
        posicionInicial = transform.localPosition;
        fase = Random.Range(0f, 6.28f); // para que no floten todas sincronizadas
    }

    void Update()
    {
        transform.Rotate(0f, velocidadGiro * Time.deltaTime, 0f, Space.World);

        float y = Mathf.Sin(Time.time * velocidadFlote + fase) * alturaFlote;
        transform.localPosition = posicionInicial + new Vector3(0f, y, 0f);
    }
}