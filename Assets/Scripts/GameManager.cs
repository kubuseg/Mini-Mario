using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int ActiveSceneBuildIndex;

    public static void GameOver(int activeSceneBuildIndex)
    {
        ActiveSceneBuildIndex = activeSceneBuildIndex;
        SceneManager.LoadScene("Lost Scene");
    }

    public void CompleteLevel()
    {
        
    }
}
