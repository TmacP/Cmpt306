using UnityEngine;

public class ReticleController : MonoBehaviour
{
    public SkinSelectMenu skinSelectMenu; // Reference to the SkinSelectMenu script or object

    void Update()
    {
        if (!skinSelectMenu.skinselectmenu.activeSelf)
        {
            // Get the mouse position
            Vector2 mousePosition = Input.mousePosition;
            // Set the reticle position to the mouse position
            transform.position = mousePosition;
        }
    }
}
