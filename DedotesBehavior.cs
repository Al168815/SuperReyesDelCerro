using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DedotesBehavior : MonoBehaviour
{
    private bool puedeGolpear, hit; // hit es una variable que va a averiguar si el jugador dió un input correctamente
    public float MargenError;
    private int contadorGolpes, contadorBeats, indiceFlecha;
    private int orientacionFlecha; // se usará todo el tiempo para indicar a que orientación va a estar cada flecha
    private CombateControl combatScript;
    enemyBehavior enemyScript;
    private GameObject ManagerDePuntuacion;
    private Queue<int> inputs = new Queue<int>();
    public int hp;
    //stetics
    //Este arreglo puede ser un poco confuso, aquí estan las especificaciones del mismo:
    //del 0 al 3 son poses de ataque
    //0: Idle
    //1: Uppercut
    //2: gancho
    //3: fallo
    public Sprite[] combatSprites;
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        ManagerDePuntuacion = GameObject.FindGameObjectWithTag("Manager_Puntuacion");
        combatScript = GameObject.FindGameObjectWithTag("GameController").GetComponent<CombateControl>();
        enemyScript = GameObject.FindGameObjectWithTag("enemy").GetComponent<enemyBehavior>();
        puedeGolpear = false;
        indiceFlecha = 0;
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(inputs.Count);
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
                    IntentarGolpe("down");
                }
                if (Input.GetKeyDown(KeyCode.A))
                {
                    contadorGolpes++;
                    IntentarGolpe("left");
                }
            }
        }
        if (combatScript.comprobarFase() == "punching")
        {
            contadorGolpes = 0; //esta linea en específico podría cambiar al momento de hacer el "punching"
        }
        
        
    }
    public void LlamarBeat() // Esta funcion se manda a llamar externamente cada beat
    {
        StartCoroutine(comprobarBeat());
        if (contadorBeats >= 4)
        {
            combatScript.CambioFase();
            contadorBeats = 1;
            indiceFlecha = 0;
        }
        else
        {
            contadorBeats++;
        }
        if (combatScript.comprobarFase() == "punching")
        {
            foreach (var item in GameObject.FindGameObjectsWithTag("arrow"))
            {
                item.GetComponent<FlechasJugdor>().desaparecer(indiceFlecha);
            }
            StartCoroutine(golpeVisual(inputs.Peek()));//****
            indiceFlecha++;
            inputs.Dequeue();
        }
    }
    IEnumerator comprobarBeat()
    {
        puedeGolpear = true;
        hit = false;
        yield return new WaitForSeconds(MargenError);
        if (!hit && combatScript.comprobarFase() == "tuTurno" && contadorGolpes < 4)
        {
            orientacionFlecha = 4;
            foreach (var item in GameObject.FindGameObjectsWithTag("arrow"))
            {
                item.GetComponent<FlechasJugdor>().CambioSprite(orientacionFlecha, indiceFlecha);
            }
            inputs.Enqueue(4);
            indiceFlecha++;
            contadorGolpes++;
        }//lógica que cambiará el índice de las flechas
        else
        {
            if (combatScript.comprobarFase() == "tuTurno")
            {
                
                /*foreach (var item in GameObject.FindGameObjectsWithTag("arrow"))
                {
                    item.GetComponent<FlechasJugdor>().CambioSprite(4, indiceFlecha);
                }*/
            }
        }
        //indiceFlecha++;
        puedeGolpear = false;
    }
    public void IntentarGolpe(string flecha)
    {
        if (puedeGolpear) // este if y la función en general puede optimizarse perfectamente, por favor no lo intentes, ya funciona
        {//GRITOS DE AUXILIO, SI OPTIMIZALO CONCHETUMADRE
            puedeGolpear = false;
            switch (flecha)
            {
                case "up":
                    orientacionFlecha = 0;
                    inputs.Enqueue(0);
                    break;
                case "right":
                    orientacionFlecha = 1;
                    inputs.Enqueue(1);
                    break;
                case "down":
                    orientacionFlecha = 2;
                    inputs.Enqueue(2);
                    break;
                case "left":
                    orientacionFlecha = 3;
                    inputs.Enqueue(3);
                    break;
                default:
                    break;
            }
            hit = true;
            Debug.Log("Succes");
        }
        else
        {
            Debug.Log("Fail");
            orientacionFlecha = 4;
            inputs.Enqueue(4);
        }
        foreach (var item in GameObject.FindGameObjectsWithTag("arrow"))
        {
            item.GetComponent<FlechasJugdor>().CambioSprite(orientacionFlecha, indiceFlecha);
        }
        indiceFlecha++;
    }
    public void resetImputs()
    {
        contadorGolpes = 0;
    }
    IEnumerator golpeVisual(int flecha)
    {
        switch (flecha)
        {
            case 0:
                render.sprite = combatSprites[1];
                enemyScript.recibirAtaque(0);
                break;
            case 1:
                render.sprite = combatSprites[2];
                enemyScript.recibirAtaque(1);
                break;
            case 2:
                render.sprite = combatSprites[1];
                transform.localScale = new Vector2(-0.75f, 0.75f);
                enemyScript.recibirAtaque(2);
                break;
            case 3:
                render.sprite = combatSprites[2];
                transform.localScale = new Vector2(-0.75f, 0.75f);
                enemyScript.recibirAtaque(3);
                break;
            case 4:
                render.sprite = combatSprites[3];
                enemyScript.recibirAtaque(4);
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(0.3f);
        render.sprite = combatSprites[0];
        transform.localScale = new Vector2(0.75f, 0.75f);
    }
}
