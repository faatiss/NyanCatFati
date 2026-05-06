using UnityEngine;

[CreateAssetMenu(fileName = "PersonajesData", menuName = "Scriptable Objects/Personajes")]
public class PersonajesData : ScriptableObject
{
    public string nombre;
    public Sprite sprite;
}