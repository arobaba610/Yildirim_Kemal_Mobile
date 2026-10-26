
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float trackingSpeed = 2f;

    [Header("AI Detection")]
    [SerializeField] private float detectionRadius = 4f;

    private Transform player;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        Vector3 movement = Vector3.down * moveSpeed;

        if (player != null)
        {
            float distance = Vector2.Distance(
                transform.position,
                player.position
            );

            if (distance <= detectionRadius)
            {
                float direction =
                    Mathf.Sign(player.position.x - transform.position.x);

                movement.x = direction * trackingSpeed;
            }
        }

        transform.position += movement * Time.deltaTime;

        float cameraBottom =
            mainCamera.transform.position.y
            - mainCamera.orthographicSize;

        if (transform.position.y < cameraBottom - 1f)
        {
            gameObject.SetActive(false);
        }
    }
}
