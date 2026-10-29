using UnityEngine;

// Pooled enemies reset on activation. Only a weapon kill awards points.
public class EnemyHealth : MonoBehaviour
{
    [SerializeField, Min(1)] private int maxHealth = 1;
    [SerializeField, Min(0)] private int scoreValue = 100;
    private int health;
    private bool defeated;

    private void OnEnable() { health = maxHealth; defeated = false; }

    public bool TakeDamage(int damage)
    {
        if (defeated || damage <= 0 || !gameObject.activeInHierarchy) return false;
        health -= damage;
        if (health <= 0)
        {
            defeated = true;
            ScoreManager.Instance?.AddScore(scoreValue);
            GameAudio.PlayDefeat();
            gameObject.SetActive(false);
        }
        return true;
    }
}
