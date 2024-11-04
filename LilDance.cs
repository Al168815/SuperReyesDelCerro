using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LilDance : MonoBehaviour
{
    private Vector2 escalaInicial;
    public float velocidadCrecimiento;
    private float y;
    // Start is called before the first frame update
    void Start()
    {
        escalaInicial = transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        y = transform.localScale.y;
        y += velocidadCrecimiento * Time.deltaTime;
        transform.localScale = new Vector2(transform.localScale.x, y);
        if (y >= escalaInicial.y)
        {
            transform.localScale = escalaInicial;
        }
    }
    public void dance()
    {
        Vector2 nuevaEscala = new Vector2(1, 0.9f);
        transform.localScale = nuevaEscala;
    }
}
