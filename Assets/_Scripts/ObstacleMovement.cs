
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
        float nextX = transform.position.x;

        if (player != null)
        {
            float distance = Vector2.Distance(
                transform.position,
                player.position
            );

            if (distance <= detectionRadius)
            {
                nextX = Mathf.MoveTowards(
                    transform.position.x,
                    player.position.x,
                    trackingSpeed * Time.deltaTime
                );
            }
        }

        float nextY =
            transform.position.y - moveSpeed * Time.deltaTime;

        transform.position = new Vector3(
            nextX,
            nextY,
            transform.position.z
        );

        float cameraBottom =
            mainCamera.transform.position.y
            - mainCamera.orthographicSize;

        if (transform.position.y < cameraBottom - 1f)
        {
            gameObject.SetActive(false);
        }
    }

}
