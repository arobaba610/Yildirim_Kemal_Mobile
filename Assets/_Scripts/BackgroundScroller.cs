
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    [SerializeField] private Transform background1;
    [SerializeField] private Transform background2;
    [SerializeField] private float scrollSpeed = 2f;

    private float backgroundHeight;

    void Start()
    {
        // height of the first background sprite
        SpriteRenderer spriteRenderer = background1.GetComponent<SpriteRenderer>();

        backgroundHeight = spriteRenderer.bounds.size.y;

        // vertically
        background1.position = new Vector3(0f, 0f, 0f );

        background2.position = new Vector3( 0f, backgroundHeight, 0f);
    }

    void Update()
    {
        // Move both backgrounds downward
        Vector3 movement =
            Vector3.down * scrollSpeed * Time.deltaTime;

        background1.position += movement;
        background2.position += movement;

        // Reposition backgrounds when they exit
        if (background1.position.y <= -backgroundHeight)
        {
            background1.position = new Vector3(
                background1.position.x,
                background2.position.y + backgroundHeight,
                background1.position.z
            );
        }

        if (background2.position.y <= -backgroundHeight)
        {
            background2.position = new Vector3(
                background2.position.x,
                background1.position.y + backgroundHeight,
                background2.position.z
            );
        }
    }
}
