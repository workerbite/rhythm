using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaBtn : MonoBehaviour
{
    public Character character;
    public void StartClick(string sceneName)
    {
        LoadingSceneManager.LoadScene(sceneName);    
    }
}
