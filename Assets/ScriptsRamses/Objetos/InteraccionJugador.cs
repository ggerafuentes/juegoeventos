using UnityEngine;

public class InteraccionJugador : MonoBehaviour
{
    [SerializeField] private Camera camara;
    [SerializeField] private float distancia = 3f;
    [SerializeField] private KeyCode tecla = KeyCode.E;

    void Start()
    {
        if (camara == null) camara = GetComponentInChildren<Camera>();
        if (camara == null) camara = Camera.main;
    }

    void Update()
    {
        if (!Input.GetKeyDown(tecla)) return;

        Ray rayo = new Ray(camara.transform.position, camara.transform.forward);
        if (Physics.Raycast(rayo, out RaycastHit hit, distancia))
        {
            var objeto = hit.collider.GetComponentInParent<Coleccionable>();
            if (objeto != null) objeto.Agarrar();
        }
    }
}
