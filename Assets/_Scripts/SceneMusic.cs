using UnityEngine;

// Choose the music for this scene in the Inspector.
public class SceneMusic : MonoBehaviour
{
    [SerializeField] private AudioClip music;

    private void Start()
    {
        if (GameAudio.Instance != null) GameAudio.Instance.PlayMusic(music);
        else Debug.LogError("GameAudio is missing from this scene.", this);
    }
}
