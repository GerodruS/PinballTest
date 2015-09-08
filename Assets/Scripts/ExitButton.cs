using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }

    protected void Start()
    {
#if UNITY_WEBPLAYER || UNITY_IOS
        gameObject.SetActive(false);
#endif
    }
}