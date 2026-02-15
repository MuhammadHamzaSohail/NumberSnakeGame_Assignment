using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float horizontalSpeed = 10f;
    public float horizontalLimit = 3f;
    [SerializeField] private bool canMove;

    private Vector2 startTouch;
    private float targetX;

    void Update()
    {
        if (GameManager.Instance.isGameActive)
        {
            MoveForward();
            HandleSwipe();
            MoveHorizontal();
        }
    }

// Player Automatic Forward Movement
    void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

// Player Swipe Input
    void HandleSwipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startTouch = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 currentTouch = Input.mousePosition;
            float delta = (currentTouch.x - startTouch.x) / Screen.width;
            targetX += delta * horizontalSpeed;
            startTouch = currentTouch;
        }
    }

// Horizontal Movement with limiting side to side movement
    void MoveHorizontal()
    {
        targetX = Mathf.Clamp(targetX, -horizontalLimit, horizontalLimit);
        Vector3 pos = transform.position;
        pos.x = Mathf.Lerp(pos.x, targetX, Time.deltaTime * 10f);
        transform.position = pos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && other.CompareTag("FinishLine"))
        {
            StopMotion();
        }
    }

    /*private void onCollisionEnter(Collision collision)
    {
        if (collision.other.gameObject.CompareTag("Obstacle") && collision.other.gameObject.CompareTag("FinishLine"))
        {
            StopMotion();
            Debug.Log("Game Over");
        }
    }*/

    void OnCollisionEnter(Collision collision)
    {
        // Stop movement upon collision
        canMove = false;
        Debug.Log("Hit: " + collision.gameObject.name);
    }

    void StopMotion()
    {
        transform.Translate(Vector3.forward * 0 * Time.deltaTime);
    }

}
