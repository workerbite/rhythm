using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    public void StartClick(string sceneName)
    {
        //SceneManager.LoadScene(sceneName);
        //���������� �ŸŴ���.�ε��(string���̸�); ���� �ϰ����� 
        //�ε����� ��������Ƿ� ��� �ε��� �÷��̰� �ƴ� �ε��� �ε�Ϸ�� �÷����ϴ� �ε��� �Ŵ����� ����Ѵ�.
        LoadingSceneManager.LoadScene(sceneName);
    }
}
