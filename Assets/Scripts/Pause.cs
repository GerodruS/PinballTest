using System.Collections;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPause = false;

    public void SwitchState()
    {
        SetPause(!isPause);
    }

    public void SetPause(bool value)
    {
        isPause = value;

        gameObject.SetActive(value);
        if (value)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}