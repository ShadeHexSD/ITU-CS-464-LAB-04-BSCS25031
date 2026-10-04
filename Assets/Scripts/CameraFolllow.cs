using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset = new Vector3(0, 4, -7);
    [SerializeField] float smoothSpeed = 5f;

    float lastLeftPress = -1f;
    float lastRightPress = -1f;

    [SerializeField] float doublePressTime = 0.3f;

    void LateUpdate()
    {
        // LEFT
        if (Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Was left pressed recently?
            if (Time.time - lastLeftPress <= doublePressTime)
            {
                offset.x = 0f;
            }
            else
            {
                offset.x = 15f;
            }

            lastLeftPress = Time.time;
        }

        // RIGHT
        if (Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Was right pressed recently?
            if (Time.time - lastRightPress <= doublePressTime)
            {
                offset.x = 0f;
            }
            else
            {
                offset.x = -15f;
            }

            lastRightPress = Time.time;
        }

        // W also resets camera
        if (Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.UpArrow))
        {
            offset.x = 0f;
        }

        Vector3 wanted = target.position + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            wanted,
            smoothSpeed * Time.deltaTime
        );

        transform.LookAt(target);
    }
}