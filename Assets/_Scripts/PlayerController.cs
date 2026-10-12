
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float screenPadding = 0.3f;
    



    private Camera mainCamera;
    private float targetX;




    void Start()
    {
        mainCamera = Camera.main;
        targetX = transform.position.x;
    }



    void Update()
    {
        // Mobile touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began ||
                touch.phase == TouchPhase.Moved ||
                touch.phase == TouchPhase.Stationary)
            {
                SetTargetPosition(touch.position);
            }
        }
        // Mouse input for testing in Unity Editor
        else if (Input.GetMouseButton(0))
        {
            SetTargetPosition(Input.mousePosition);
        }

        MovePlayer();
    }




    void SetTargetPosition(Vector2 screenPosition) //convert the screen position into world coordinates
    {
        Vector3 worldPosition =
            mainCamera.ScreenToWorldPoint(
                new Vector3(
                    screenPosition.x,
                    screenPosition.y,
                    -mainCamera.transform.position.z
                )
            );

        targetX = worldPosition.x;
    }

    void MovePlayer()
    {
        // camera boundaries
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        float minX = mainCamera.transform.position.x
                     - cameraWidth + screenPadding;

        float maxX = mainCamera.transform.position.x
                     + cameraWidth - screenPadding;

        // player inside screen
        targetX = Mathf.Clamp(targetX, minX, maxX);

        // Smooth movement
        Vector3 targetPosition = new Vector3(
            targetX,
            transform.position.y,
            transform.position.z
        );

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
    }
}
