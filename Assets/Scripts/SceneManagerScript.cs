using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void OnSceneChanged()
    {
        int buildInd = SceneManager.GetActiveScene().buildIndex + 1;
        if (buildInd >= SceneManager.sceneCountInBuildSettings) buildInd = 0;

        SceneManager.LoadScene(buildInd);
    }
}
