using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropiedadesCorazon : MonoBehaviour
{
    private Vector2 escalaInicial;
    public float velocidadEncogimiento;
    private float x, y;
    // Start is called before the first frame update
    void Start()
    {
        escalaInicial = transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        x = transform.localScale.x;
        y = transform.localScale.y;
        x -= velocidadEncogimiento * Time.deltaTime;
        y -= velocidadEncogimiento * Time.deltaTime;
        transform.localScale = new Vector2(x, y);
        if (x <= escalaInicial.x)
        {
            transform.localScale = escalaInicial;
        }
    }
    public void beat()
    {
        StartCoroutine(trueBeat());
    }
    IEnumerator trueBeat()
    {
        Vector2 nuevaEscala = new Vector2(1.5f, 1.5f);
        transform.localScale = nuevaEscala;
        yield return new WaitForSeconds (0.1f);
        //transform.localScale = escalaInicial;
    }
}
