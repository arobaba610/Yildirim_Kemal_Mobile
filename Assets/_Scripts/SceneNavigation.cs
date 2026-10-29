using UnityEngine;
using UnityEngine.SceneManagement;

// Button events are saved in each scene and share these destinations.
public class SceneNavigation : MonoBehaviour
{
    public void Play() => Load("PlayScene");
    public void Menu() => Load("MenuScene");
    public void Instructions() => Load("InstructionScene");

    private void Load(string scene)
    {
        GameAudio.PlayButton();
        SceneManager.LoadScene(scene);
    }
}
