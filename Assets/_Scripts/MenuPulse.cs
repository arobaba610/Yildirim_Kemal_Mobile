using UnityEngine;

public class MenuPulse : MonoBehaviour
{
    private Vector3 baseScale;
    private float offset;
    private void Awake() { baseScale = transform.localScale; offset = Random.value * 6f; }
    private void Update()
    {
        transform.localScale = baseScale * (1f + 0.025f * Mathf.Sin(Time.unscaledTime * 2.8f + offset));
    }
}
