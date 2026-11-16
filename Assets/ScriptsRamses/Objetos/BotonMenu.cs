using UnityEngine;
using UnityEngine.EventSystems;

public class BotonMenu : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private AudioSource fuente;
    [SerializeField] private AudioClip sonidoHover;
    [SerializeField] private AudioClip sonidoClick;
    [SerializeField] private float escalaHover = 1.1f;
    [SerializeField] private float velocidad = 10f;

    private Vector3 escalaInicial;
    private Vector3 escalaObjetivo;

    void Awake()
    {
        escalaInicial = transform.localScale;
        escalaObjetivo = escalaInicial;
    }

    void OnEnable()
    {
        transform.localScale = escalaInicial;
        escalaObjetivo = escalaInicial;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, escalaObjetivo, velocidad * Time.unscaledDeltaTime);
    }

    public void OnPointerEnter(PointerEventData datos)
    {
        escalaObjetivo = escalaInicial * escalaHover;
        if (fuente != null && sonidoHover != null) fuente.PlayOneShot(sonidoHover);
    }

    public void OnPointerExit(PointerEventData datos)
    {
        escalaObjetivo = escalaInicial;
    }

    public void OnPointerClick(PointerEventData datos)
    {
        if (fuente != null && sonidoClick != null) fuente.PlayOneShot(sonidoClick);
    }
}