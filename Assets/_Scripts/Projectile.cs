
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        transform.Translate(
            Vector3.up * speed * Time.deltaTime,
            Space.World
        );

        float cameraTop =
            mainCamera.transform.position.y
            + mainCamera.orthographicSize;

        if (transform.position.y > cameraTop + 1f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
