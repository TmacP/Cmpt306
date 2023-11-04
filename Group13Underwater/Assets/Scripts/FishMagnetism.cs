using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FishMagnetism : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;

    /*private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && other.GetComponent<JacobTEMPPlayer>().hasMagnetBuff)
        {
            //transform.position = Vector3.MoveTowards(transform.position, other.transform.position, moveSpeed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, other.transform.position, moveSpeed * Time.deltaTime);
        }
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" && collision.GetComponent<PlayerBuff>().hasMagnetBuff)
        {
            //transform.position = Vector3.MoveTowards(transform.position, other.transform.position, moveSpeed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, collision.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}
