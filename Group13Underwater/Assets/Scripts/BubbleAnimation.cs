using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//MAKE AN OBJECT FLOAT UP, DRIFT WITH THE WATER, AND EVENTUALLY FADE AWAY
//OBJECT WILL BE DESTROYED AFTER IT FADES AWAY
//-Steven
public class BubbleAnimation : MonoBehaviour
{
    Transform tf;
    SpriteRenderer spriteRenderer;

    private float YSpeed = 0.1f;
    private float maximumXSpeed = 0.2f;

    private float xMomentum;
    private int changeMomentumTimer;
    private int momentumChangeInterval = 25;

    private int fadeTimer;
    private int fadeInterval = 25;

    void Awake()
    {
        tf = gameObject.transform;
        tf.transform.eulerAngles = new Vector3(0,0, Random.Range(0, 360));
    
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        tf.position = new Vector3(tf.position.x + xMomentum, tf.position.y + YSpeed, 0);

        if (changeMomentumTimer > momentumChangeInterval ) { 
            changeMomentumTimer = 0;
            xMomentum += Random.Range(-0.1f, 0.1f);
            Mathf.Clamp(xMomentum, -maximumXSpeed, maximumXSpeed);
        }
        changeMomentumTimer++;




        if (fadeTimer > fadeInterval) {
            fadeTimer = 0;
            Color32 temp = spriteRenderer.color;
            temp.a -= 1;
            if (temp.a == 0) { Destroy(gameObject); }
            spriteRenderer.color = new Color32(temp.r, temp.g, temp.b, temp.a);
        }
        fadeTimer++;
    }
}
