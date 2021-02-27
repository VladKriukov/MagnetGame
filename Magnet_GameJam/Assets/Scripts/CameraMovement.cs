using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float rotationXRange;
    [SerializeField] float rotationYRange;

    [SerializeField] Vector3 cameraRotation;

    void Update()
    {
        cameraRotation.x = -rotationYRange * (2 * (Input.mousePosition.y / Screen.height) - 1);
        cameraRotation.y = rotationXRange * (2 * (Input.mousePosition.x / Screen.width) - 1);
        cameraRotation.z = 0;
        transform.localEulerAngles = cameraRotation;
    }

}
