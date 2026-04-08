using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public int puntos = 10;

    void OnCollisionEnter2D(Collision2D colision)
    {
        // Solo reaccionar si colisiona con el Player (la pelota)
        if (colision.gameObject.CompareTag("Player"))
        {
            if (GestorJuego.instancia != null)
            {
                // Sumar puntos
                GestorJuego.instancia.AgregarPuntos(puntos);

                // Notificar que un enemigo fue eliminado
                GestorJuego.instancia.EnemigoEliminado();
            }

            // Destruir este enemigo
            Destroy(gameObject);
        }
    }
}