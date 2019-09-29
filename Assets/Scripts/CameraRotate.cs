using UnityEngine;

// Class used to move the camera around the game field in the menu...
public class CameraRotate : MonoBehaviour
{
    private void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, 15 * Time.deltaTime);
    }
}
