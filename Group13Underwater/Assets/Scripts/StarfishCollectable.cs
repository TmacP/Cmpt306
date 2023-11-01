using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarfishCollectable : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        Debug.Log("COLLECTABLE DESTROYED!!!!");
    }

}
