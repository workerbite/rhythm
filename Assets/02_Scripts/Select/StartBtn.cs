using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void StartClick(string sceneName)
    {
        //SceneManager.LoadScene(sceneName);
        //예전같으면 신매니저.로드신(string씬이름); 으로 하겠지만 
        //로딩씬을 만들었으므로 모두 로드후 플레이가 아닌 로드중 로드완료로 플레이하는 로딩신 매니져를 사용한다.
        LoadingSceneManager.LoadScene(sceneName);
    }
}
