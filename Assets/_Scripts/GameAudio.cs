using UnityEngine;

// One shared audio object keeps button effects playing during scene transitions.
public class GameAudio : MonoBehaviour
{
    public static GameAudio Instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectsSource;

    [Header("Sound Effects")]
    [SerializeField] private AudioClip button;
    [SerializeField] private AudioClip shoot;
    [SerializeField] private AudioClip damage;
    [SerializeField] private AudioClip pickup;
    [SerializeField] private AudioClip defeat;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }

    public void PlayMusic(AudioClip clip)
    {
        if (musicSource == null || musicSource.clip == clip) return;
        musicSource.clip = clip;
        if (clip == null) musicSource.Stop();
        else musicSource.Play();
    }

    private void PlayEffect(AudioClip clip)
    {
        if (effectsSource != null && clip != null) effectsSource.PlayOneShot(clip);
    }

    public static void PlayButton() { if (Instance != null) Instance.PlayEffect(Instance.button); }
    public static void PlayShoot() { if (Instance != null) Instance.PlayEffect(Instance.shoot); }
    public static void PlayDamage() { if (Instance != null) Instance.PlayEffect(Instance.damage); }
    public static void PlayPickup() { if (Instance != null) Instance.PlayEffect(Instance.pickup); }
    public static void PlayDefeat() { if (Instance != null) Instance.PlayEffect(Instance.defeat); }
}
