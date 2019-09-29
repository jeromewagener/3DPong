using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float accelerationFactor = 0.3f;
    public string horizontalAxisId = "Player1Horizontal";
    public string verticalAxisId = "Player1Vertical";
    
    private void Update()
    {
        var moveHorizontal = Input.GetAxis(horizontalAxisId);
        var moveVertical = Input.GetAxis(verticalAxisId);

        var newY = transform.position.y + moveVertical * accelerationFactor;
        if (newY > 4)
        {
            newY = 4;
        } else if (newY < -4)
        {
            newY = -4;
        }

        var newZ = transform.position.z - moveHorizontal * accelerationFactor;
        if (newZ > 9)
        {
            newZ = 9;
        } else if (newZ < -9)
        {
            newZ = -9;
        }
        
        transform.position = new Vector3(transform.position.x, newY, newZ);
    }
}
