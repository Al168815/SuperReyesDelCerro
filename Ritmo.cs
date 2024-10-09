using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ritmo : MonoBehaviour
{
    [SerializeField] private float BPM;
    [SerializeField] private AudioSource musica;
    [SerializeField] private Intervalos[] intervalos;

    // Update is called once per frame
    void Update()
    {
        foreach (var inter in intervalos)
        {
            float TiempoSample = (musica.timeSamples / (musica.clip.frequency * inter.ObtenerLongitudIntervalo(BPM)));
            inter.RevisarIntervaloNuevo(TiempoSample);
        }
    }
    [System.Serializable]
    public class Intervalos
    {
        [SerializeField] private float pasos;
        [SerializeField] private UnityEvent trigger;
        private int ultimoIntervalo;
        public float ObtenerLongitudIntervalo(float bpm)
        {
            return 60 / (bpm * pasos);
        }
        public void RevisarIntervaloNuevo (float intervalo)
        {
            if (Mathf.FloorToInt(intervalo) != ultimoIntervalo)
            {
                ultimoIntervalo = Mathf.FloorToInt(intervalo);
                trigger.Invoke();
            }
        }
    }
}
