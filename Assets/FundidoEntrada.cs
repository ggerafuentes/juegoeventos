using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FundidoEntrada : MonoBehaviour
{
    [SerializeField] private float duracion = 2f;
    private CanvasGroup grupo;
    private float tiempo;

    void Awake()
    {
        grupo = GetComponent<CanvasGroup>();
        grupo.alpha = 1f;
        grupo.blocksRaycasts = false; // no bloquea los clics
    }

    void Update()
    {
        tiempo += Time.unscaledDeltaTime;
        grupo.alpha = Mathf.Clamp01(1f - tiempo / duracion);
        if (tiempo >= duracion) gameObject.SetActive(false);
    }
}