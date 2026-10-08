using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class JugadorController : MonoBehaviour
{
    private Rigidbody rb;
    private int contador;
    private bool juegoTerminado = false;
    private float tiempoRestante;

    public Text textoContador, textoGanar, textoTimer;
    public float velocidad = 10f;
    public float tiempoInicial = 60f;
    public int totalColeccionables = 12;
    public string siguienteEscena = "MenuPrincipal";
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        contador = 0;
        tiempoRestante = tiempoInicial;
        textoGanar.text = "";
        setTextoContador();
        setTextoTimer();
    }

    void Update()
    {
        if (juegoTerminado) return;

        tiempoRestante -= Time.deltaTime;
        if (tiempoRestante <= 0f)
        {
            tiempoRestante = 0f;
            Perder();
        }
        setTextoTimer();
    }

    void FixedUpdate()
    {
        if (juegoTerminado) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rb.AddForce(new Vector3(h, 0f, v) * velocidad);
    }

    void OnTriggerEnter(Collider other)
    {
        if (juegoTerminado) return;

        if (other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);
            contador++;
            setTextoContador();

            if (contador >= totalColeccionables)
                Ganar();
        }
    }

    void setTextoContador()
    {
        textoContador.text = "Contador: " + contador;
    }

    void setTextoTimer()
    {
        textoTimer.text = "Tiempo: " + Mathf.CeilToInt(tiempoRestante);
    }

  void Ganar()
{
    juegoTerminado = true;
    textoGanar.text = "¡Ganaste!";
    Invoke("CargarSiguiente", 5f);
}

void Perder()
{
    juegoTerminado = true;
    textoGanar.text = "¡Perdiste!";
    Invoke("VolverAlMenu", 5f);
}

void CargarSiguiente()
{
    SceneManager.LoadScene(siguienteEscena);
}

void VolverAlMenu()
{
    SceneManager.LoadScene("MenuPrincipal");
}
}