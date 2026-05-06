using UnityEngine;
using System.Collections.Generic;

public class PersonajesManager : MonoBehaviour
{
    public List<PersonajesData> personajes;
    public SpriteRenderer persona1;
    public SpriteRenderer persona2;
    public SpriteRenderer persona3;

    void Start()
    {
        persona1.sprite = personajes[0].sprite;
        persona2.sprite = personajes[1].sprite;
        persona3.sprite = personajes[2].sprite;
    }

    void Update()
    {

    }
}

