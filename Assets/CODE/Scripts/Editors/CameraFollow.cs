using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    public float followSpeed = 5f;
    public float horizontalFollowSpeed = 8f;

    public Vector3 offset = new Vector3(0, 10, -10);

    void Start()
    {
         // Target position behind player
        Vector3 targetPosition = new Vector3(player.position.x,player.position.y,player.position.z) + offset;
        transform.position = targetPosition;
    }

    void LateUpdate()
    {
        if (!player) return;

        // Target position behind player
        Vector3 targetPosition = new Vector3(player.position.x,player.position.y,player.position.z) + offset;

        // Smooth follow
        transform.position = Vector3.Lerp(transform.position,targetPosition,followSpeed * Time.deltaTime);

        // Optional: Look at player
        transform.LookAt(player.position);
    }
}
