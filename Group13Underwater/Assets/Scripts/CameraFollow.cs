using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float followSpeed = 5f;

    // LateUpdate is called after all Update functions have been called
    void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the target position
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

            // Use Lerp to smoothly interpolate between the current and target position
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
