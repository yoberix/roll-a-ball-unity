using UnityEngine;

public class ObstaculoMovil : MonoBehaviour
{
    public Vector3 direccion = new Vector3(1, 0, 0);
    public float distancia = 5f;
    public float velocidad = 2f;
    private Vector3 inicio;

    void Start()
    {
        inicio = transform.position;
    }

    void Update()
    {
        transform.position = inicio + direccion.normalized * Mathf.Sin(Time.time * velocidad) * distancia;
    }
}