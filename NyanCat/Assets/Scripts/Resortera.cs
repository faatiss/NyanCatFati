using UnityEngine;
using UnityEngine.InputSystem;

public class Resortera : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 posInicial;
    private LineRenderer linea;
    private Controles inputactions;
    public float fuerza = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
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
        inputactions = new Controles();
    }

    private void OnEnable()
    {
        inputactions.PajarosVScerdos.Enable();
        inputactions.PajarosVScerdos.Presionado.started += LePico;
        inputactions.PajarosVScerdos.Posicion.ReadValue<Vector2>();


       // inputactions.PajarosVScerdos.izquierdo += DejoDePicar;
        inputactions.PajarosVScerdos.barra.ReadValue<Vector2>();

    }

void LePico (InputAction.CallbackContext handler)
    {
        print("Le picó al clic de la izquierda");
    }
 void DejoDePicar (InputAction.CallbackContext handler)
    {
        print("Le dejó de picar al clic de la izquierda");
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

        Destroy(linea.gameObject); 
        Destroy(gameObject);       
    }
}