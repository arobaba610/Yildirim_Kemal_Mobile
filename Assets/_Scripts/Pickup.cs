
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private int pointValue = 50;

    void Update()
    {
        transform.Translate(
            Vector3.down * moveSpeed * Time.deltaTime,
            Space.World
        );

        Camera cam = Camera.main;

        if (cam != null &&
            transform.position.y <
            cam.transform.position.y - cam.orthographicSize - 1f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddScore(pointValue);

            Destroy(gameObject);
        }
    }
}
