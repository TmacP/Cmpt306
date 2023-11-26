using UnityEngine;

public class ReticleController : MonoBehaviour
{
    // Adjust the speed of reticle movement

void Awake() 
{
    Cursor.visible = false;
}

void Update()
{
    // Get the mouse position
    Vector2 mousePosition = Input.mousePosition;
    // Set the reticle position to the mouse position
    transform.position = mousePosition;
}
}