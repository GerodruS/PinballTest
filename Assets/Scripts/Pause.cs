using System.Collections;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPause = true;

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

    protected void Start()
    {
        SetPause(false);
    }
}