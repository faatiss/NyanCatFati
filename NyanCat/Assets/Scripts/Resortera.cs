using UnityEngine;

public class Resortera : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 posInicial;
    private LineRenderer linea;
    private Controles InputActions
    public float fuerza = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Evita que caiga al inicio
        posInicial = transform.position;

        GameObject lineaObj = new GameObject("LineaResortera");
        linea = lineaObj.AddComponent<LineRenderer>();
        linea.positionCount = 2;
        linea.startWidth = 0.05f;
        linea.endWidth = 0.05f;
        linea.material = new Material(Shader.Find("Sprites/Default"));
        linea.SetPosition(0, posInicial);
        linea.SetPosition(1, posInicial);
    }

    private void Awake()
    {
        InputActions = new Controles();
    }

    void OnMouseDown()
    {
        rb.isKinematic = true;
    }

    void OnMouseDrag()
    {
        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouse;
        linea.SetPosition(1, mouse);
    }

    void OnMouseUp()
    {
        rb.isKinematic = false;
        rb.gravityScale = 1;

        Vector2 direccion = posInicial - (Vector2)transform.position;
        rb.linearVelocity = direccion * fuerza;

        linea.SetPosition(1, posInicial);

        if (GestorJuego.instancia != null)
            GestorJuego.instancia.UsarDisparo();

        Invoke("RecrearPelota", 4f);
    }

    void RecrearPelota()
    {
        GameObject nuevaPelota = Instantiate(gameObject, posInicial, Quaternion.identity);
        nuevaPelota.GetComponent<Rigidbody2D>().gravityScale = 0;

        Resortera resorteraNueva = nuevaPelota.GetComponent<Resortera>();
        resorteraNueva.CancelInvoke("RecrearPelota");

        Destroy(linea.gameObject); // destruimos solo la línea del objeto original
        Destroy(gameObject);       // destruimos la pelota original
    }
}