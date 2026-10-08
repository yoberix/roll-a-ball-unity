using UnityEngine;

public class Rotador : MonoBehaviour
{
    void Update()
    {
        // Rota el elemento una cantidad distinta en cada eje, en cada intervalo de tiempo
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}