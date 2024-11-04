using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechasJugdor : MonoBehaviour
{
    public int index;
    private bool valid;
    //-----------------------
    public Sprite[] sprites;
    // �ndice 0: Arriba
    // �ndice 1: Derecha
    // �ndice 2: Abajo
    // �ndice 3: Izquierda
    // �ndice 4: Error 
    //----------------------
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        render.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambioSprite(int orientacion, int indice)
    {
        if (indice == index)
        {
            render.enabled = true;
            render.sprite = sprites[orientacion];
        }
    }
    public void desaparecer(int indice)
    {
        if (indice == index)
        {
            render.enabled = false;
        }
    }
    public bool succesfull()
    {
        return valid;
    }
}
