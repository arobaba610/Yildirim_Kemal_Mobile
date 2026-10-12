
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [Header("Pool Settings")]
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private int poolSize = 10;

    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private float horizontalPadding = 0.5f;

    private GameObject[] obstacles;
    private Camera mainCamera;
    private float spawnTimer;



    void Awake()
    {
        if (obstaclePrefab == null || poolSize <= 0)
        {
            Debug.LogError("Invalid pool settings.");
            enabled = false;
            return;
        }

        obstacles = new GameObject[poolSize];

        for (int i = 0; i < poolSize; i++)
        {
            obstacles[i] = Instantiate(
                obstaclePrefab,
                transform
            );

            obstacles[i].SetActive(false);
        }
    }



    void Start()
    {
        if (!enabled)
            return;

        mainCamera = Camera.main;

        if (mainCamera == null || spawnInterval <= 0f)
        {
            Debug.LogError("Invalid spawn settings.");
            enabled = false;
            return;
        }

        spawnTimer = spawnInterval;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer >= 0f)
            return;

        SpawnObstacle();

        spawnTimer = spawnInterval;
    }


    GameObject GetObstacle()
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (!obstacles[i].activeSelf)
            {
                return obstacles[i];
            }
        }

        return null;
    }

    void SpawnObstacle()
    {
        GameObject obstacle = GetObstacle();

        if (obstacle == null)
            return;

        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        float minX = mainCamera.transform.position.x
                     - cameraWidth + horizontalPadding;

        float maxX = mainCamera.transform.position.x
                     + cameraWidth - horizontalPadding;

        if (minX > maxX)
            return;

        float randomX = Random.Range(minX, maxX);

        float spawnY = mainCamera.transform.position.y
                       + cameraHeight + 1f;

        obstacle.transform.position = new Vector3(
            randomX,
            spawnY,
            0f
        );

        obstacle.SetActive(true);
    }
}
