
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Move obstacle downward
        transform.Translate(
            Vector3.down * moveSpeed * Time.deltaTime,
            Space.World
        );

        // Calculate bottom of camera
        float cameraBottom =
            mainCamera.transform.position.y
            - mainCamera.orthographicSize;

        // Return obstacle to pool when outside screen
        if (transform.position.y < cameraBottom - 1f)
        {
            gameObject.SetActive(false);
        }
    }
}
