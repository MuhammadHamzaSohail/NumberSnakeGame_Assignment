using UnityEngine;

public class NumberPickup : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<SnakeManager>().AddNumber(value);
            Destroy(gameObject);
        }
    }
}
