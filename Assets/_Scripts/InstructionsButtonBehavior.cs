
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsButtonBehavior : MonoBehaviour
{
    public void OnInstructionsButtonPressed()
    {
        SceneManager.LoadScene("Instructions");
    }
}
