using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DedotesBehavior : MonoBehaviour
{
    private bool puedeGolpear;
    [SerializeField]
    private float MargenError;
    private int contadorGolpes, contadorBeats;
    private CombateControl combatScript;
    private GameObject ManagerDePuntuacion;
    // Start is called before the first frame update
    void Start()
    {
        ManagerDePuntuacion = GameObject.FindGameObjectWithTag("Manager_Puntuacion");
        combatScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<CombateControl>();
        puedeGolpear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (combatScript.comprobarFase() == "tuTurno")
        {
            if (contadorGolpes >= 4)
            {
                //Esta condicional es mero debug
                if (Input.GetKeyDown(KeyCode.W))
                {
                    Debug.Log("Nu-uh");
                }

            }
            else
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    contadorGolpes++;
                    IntentarGolpe("up");
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    contadorGolpes++;
                    IntentarGolpe("right");
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    contadorGolpes++;
                    IntentarGolpe("Right");
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    contadorGolpes++;
                    IntentarGolpe("Left");
                }
            }
        }
        
        
    }
    public void LlamarBeat()
    {
        StartCoroutine(comprobarBeat());
        if (contadorBeats >= 4)
        {
            combatScript.CambioFase();
            contadorBeats = 1;
        }
        else
        {
            contadorBeats++;
        }
    }
    IEnumerator comprobarBeat()
    {
        puedeGolpear = true;
        yield return new WaitForSeconds(MargenError);
        puedeGolpear = false;
    }
    public void IntentarGolpe(string flecha)
    {
        if (puedeGolpear)
        {
            puedeGolpear = false;
            Debug.Log("Succes");
        }
        else
        {
            Debug.Log("Fail");
        }
    }
}
