using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    public float hp;
    public Sprite[] combatSprites;
    private SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void recibirAtaque(int indice)
    {
        StartCoroutine(cambiarSprite2(indice));
    }
    IEnumerator cambiarSprite2(int index)
    {
        if (index != 4)
        {
            hp -= 3;
        }
        switch (index)
        {
            case 0:
                render.sprite = combatSprites[3];
                break;
            case 1:
                render.sprite = combatSprites[3];
                break;
            case 2:
                render.sprite = combatSprites[3];
                transform.localScale = new Vector2(-0.79f, 0.79f);
                break;
            case 3:
                render.sprite = combatSprites[3];
                transform.localScale = new Vector2(-0.79f, 0.79f);
                break;
            case 4:
                render.sprite = combatSprites[0];
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(0.3f);
        render.sprite = combatSprites[0];
        transform.localScale = new Vector2(0.79f, 0.79f);
    }
}
