using UnityEngine;

public class CamaraController : MonoBehaviour
{
    // Referencia a nuestro jugador
    public GameObject jugador;

    // Diferencia entre la posición de la cámara y la del jugador
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - jugador.transform.position;
    }

    // Se ejecuta después de procesar todo; es más exacto para la cámara
    void LateUpdate()
    {
        transform.position = jugador.transform.position + offset;
    }
}