using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// THIS IS JUST SO THE INVISIBLE WALLS ARE NOT INVISIBLE IN THE EDITOR --Steven
/// </summary>
public class MakeInvisible : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
}
