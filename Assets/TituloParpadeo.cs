using UnityEngine;
using TMPro;

public class TituloParpadeo : MonoBehaviour
{
    [SerializeField] private float velocidad = 3f;
    [SerializeField, Range(0f, 1f)] private float alphaMinimo = 0.4f;

    private TMP_Text texto;

    void Awake()
    {
        texto = GetComponent<TMP_Text>();
    }

    void Update()
    {
        float ruido = Mathf.PerlinNoise(Time.unscaledTime * velocidad, 0f);
        Color color = texto.color;
        color.a = Mathf.Lerp(alphaMinimo, 1f, ruido);
        texto.color = color;
    }
}