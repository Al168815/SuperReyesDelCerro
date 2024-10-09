using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borrarSonido : MonoBehaviour
{
    public AudioSource ASObjeto;
    // Start is called before the first frame update
    void Start()
    {
        ASObjeto = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ASObjeto.isPlaying) //Verifica si el sonido se terminó de repeoducir (atención al "!")
        {
            Destroy(this.gameObject);
        }
    }
}
