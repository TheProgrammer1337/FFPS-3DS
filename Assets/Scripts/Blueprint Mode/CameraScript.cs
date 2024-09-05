using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 xBounds = new Vector2(-67.6033f, 52.6033f);
    public Vector2 yBounds = new Vector2(-33.8871f, 27.7546f);

    void Update()
    {
        float moveX = UnityEngine.N3DS.GamePad.CirclePad.x * moveSpeed * Time.deltaTime;
        float moveY = UnityEngine.N3DS.GamePad.CirclePad.y * moveSpeed * Time.deltaTime;

        Vector3 newPosition = transform.position - new Vector3(moveX, moveY, 0);

        // Clamp the position within the specified bounds
        newPosition.x = Mathf.Clamp(newPosition.x, xBounds.x, xBounds.y);
        newPosition.y = Mathf.Clamp(newPosition.y, yBounds.x, yBounds.y);

        transform.position = newPosition;
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Keypad6))
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Keypad4))
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Keypad8))
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.Keypad2))
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
#endif
    }
}