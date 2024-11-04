using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombateControl : MonoBehaviour
{
    public enum FaseCombate {inputing, punching, oponent, dodging}
    public FaseCombate fase;
    int inputs, falis, hits;

    private enemyBehavior scriptEnemigo;
    public float hpMaxEne, hpMaxJug;

    public Image barraVidaEnemiga;
    // Start is called before the first frame update
    void Start()
    {
        scriptEnemigo = GameObject.FindGameObjectWithTag("enemy").GetComponent<enemyBehavior>();
        fase = FaseCombate.inputing;
    }

    // Update is called once per frame
    void Update()
    {
        barraVidaEnemiga.fillAmount = scriptEnemigo.hp / hpMaxEne;
    }
    public void CambioFase()
    {
        switch (fase)
        {
            case FaseCombate.inputing://El jugador mete inputs
                fase = FaseCombate.punching;
                break;
            case FaseCombate.punching:// Es cuando suelta inputs
                fase = FaseCombate.oponent;
                break;
            case FaseCombate.oponent://El oponente metiendo inputs
                fase = FaseCombate.dodging;
                break;
            case FaseCombate.dodging://El jugador bloquea inputs de oponente
                fase = FaseCombate.inputing;
                break;
            default:
                break;
        }
        Debug.Log(fase);
    }
    public string comprobarFase()
    {
        string current = "";
        switch (fase)
        {
            case FaseCombate.inputing:
                current = "tuTurno";
                break;
            case FaseCombate.punching:
                current = "punching";
                break;
            case FaseCombate.oponent:
                current = "oponenteTurno";
                break;
            case FaseCombate.dodging:
                current = "";
                break;
            default:
                break;
        }
        return current;
    }
    public void fallar()
    {
        falis++;
    }
    public void golpe()
    {
        hits++;
    }
    public void inputear()
    {
        inputs++;
    }
}
