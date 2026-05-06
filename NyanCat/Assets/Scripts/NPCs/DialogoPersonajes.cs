using UnityEngine;

public class DialogoPersonajes : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        private Controles misControles;
    public GameObject 

    private void Awake()
    {
        misControles = new Controles();
    }

    private void OnEnable()
    {
        misControles.PajarosVScerdos.Enable();
        misControles.PajarosVScerdos.Presionado.started += Presiono;//Suscripción
        misControles.PajarosVScerdos.Presionado.canceled += Solto;
    }

    private void Presiono(InputAction.CallbackContext handler)
    {
        Vector2 pixelesACoord = Camera.main.ScreenToWorldPoint(misControles.PajarosVScerdos.Posicion.ReadValue<Vector2>());
        RaycastHit2D golpeo = Physics2D.Raycast(pixelesACoord, pixelesACoord);
        if (golpeo)
        {
            print("Le pegue a algo, Yohoo");
            interfazDialogos
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
