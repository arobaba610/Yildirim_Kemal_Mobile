
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pickupPrefab;
    [SerializeField] private float spawnInterval = 5f;
    [SerializeField] private float horizontalPadding = 0.5f;

    private float timer;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnPickup();
            timer = spawnInterval;
        }
    }

    void SpawnPickup()
    {
        if (pickupPrefab == null || mainCamera == null)
            return;

        float halfWidth =
            mainCamera.orthographicSize * mainCamera.aspect;

        float minX =
            mainCamera.transform.position.x
            - halfWidth + horizontalPadding;

        float maxX =
            mainCamera.transform.position.x
            + halfWidth - horizontalPadding;

        float x = Random.Range(minX, maxX);

        float y =
            mainCamera.transform.position.y
            + mainCamera.orthographicSize + 1f;

        Instantiate(
            pickupPrefab,
            new Vector3(x, y, 0f),
            Quaternion.identity
        );
    }
}
