using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            ParticleSystem ps = GetComponentInChildren<ParticleSystem>(true);
            if (ps != null)
            {
                ps.gameObject.SetActive(true);
                ps.Play();
            }

            Invoke(nameof(StopGameDelay), 0.5f);

        }
    }

// Stop game after Some Delay
    private void StopGameDelay()
    {
        GameManager.Instance.StopGame();

    }
}
