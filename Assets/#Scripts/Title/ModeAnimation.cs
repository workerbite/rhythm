using UnityEngine;

//튜토리얼은 여기 www.youtube.com/watch?v=3_xHu-JCkl4

public class ModeAnimation : MonoBehaviour
{
    private Vector3 initialPosition;
    public GameObject center;

    private void Awake()
    {
        initialPosition = transform.position;
    }


    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, center.gameObject.transform.position, 0.2f);
    }

    private void OnDisable()
    {
        transform.position = initialPosition;
    }
}
