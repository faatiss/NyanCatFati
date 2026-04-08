using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GestorJuego : MonoBehaviour
{
    public static GestorJuego instancia;

    public int puntaje = 0;
    public int disparos = 3;

    [Header("UI")]
    public TextMeshProUGUI textoPuntaje;
    public TextMeshProUGUI textoDisparos;

    [Header("UI Game Over")]
    public GameObject panelGameOver;
    public TextMeshProUGUI textoGameOver;

    [Header("UI Victoria")]
    public GameObject textoGanaste;
    public int enemigosRestantes = 3;

    bool juegoTerminado = false;

    void Awake()
    {
        instancia = this;
    }

    void Start()
    {
        ActualizarUI();
        if (panelGameOver != null)
            panelGameOver.SetActive(false);
        if (textoGanaste != null)
            textoGanaste.SetActive(false);
    }

    public void AgregarPuntos(int puntos)
    {
        puntaje += puntos;
        ActualizarUI();
    }

    public void UsarDisparo()
    {
        if (juegoTerminado) return;

        disparos--;
        if (disparos < -1) disparos = -1;
        ActualizarUI();

        if (disparos <= -1 && enemigosRestantes > -1)
        {
            MostrarGameOver();
        }
    }

    void ActualizarUI()
    {
        if (textoPuntaje != null)
            textoPuntaje.text = "Puntos: " + puntaje;
        if (textoDisparos != null)
            textoDisparos.text = "Tiros: " + disparos;
    }

    void MostrarGameOver()
    {
        juegoTerminado = true;
        if (panelGameOver != null)
            panelGameOver.SetActive(true);
        if (textoGameOver != null)
            textoGameOver.text = "¡Perdiste!";
        Debug.Log("¡Perdiste!");
        Time.timeScale = 0f;
    }

    public void EnemigoEliminado()
    {
        if (juegoTerminado) return;

        enemigosRestantes--;

        if (enemigosRestantes <= 0)
        {
            MostrarVictoria();
        }
    }

    void MostrarVictoria()
    {
        juegoTerminado = true;
        if (textoGanaste != null)
            textoGanaste.SetActive(true);
        Debug.Log("¡Ganaste!");
        Time.timeScale = 0f;
    }

    public void ReiniciarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}