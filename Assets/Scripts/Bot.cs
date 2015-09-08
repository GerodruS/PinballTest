using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bot : MonoBehaviour
{
    [Header("UI")]
    public SliderStarter sliderStarter;
    public TriggerBall triggerBall;
    public BallDestructor ballDestructor;
    public Gate gateLeft;
    public Gate gateRight;

    [Header("Settings")]
    public bool isRandomly = true;
    public float forceStart = 1.0f;
    public float forceStep = -0.1f;
    public int stepCount = 10;

    private float force = 1.0f;
    private int stepCountCurrent = 0;
    private Coroutine coroutineGateActivity;

    private enum State
    {
        None,
        Start,
        WaitForResult
    }

    private State state = State.None;

    public void OnBallReady()
    {
        if (State.None == state)
        {
            StartCoroutine(StartBall());
        }
        else if (State.WaitForResult == state)
        {
            Debug.LogWarning("OnBallReady with state=" + state);
            StartCoroutine(StartBall());
        }
        else
        {
            Debug.LogWarning("OnBallReady with state=" + state);
        }
    }

    public void OnBallDestruct()
    {
        if (State.WaitForResult == state)
        {
            state = State.None;
        }
        else
        {
            Debug.LogWarning("OnBallDestruct with state=" + state);
        }
    }

    public void SetIsBotRandomly(bool value)
    {
        isRandomly = value;
        if (!isRandomly)
        {
            force = forceStart;
            stepCountCurrent = 0;
        }
    }

    protected void Start()
    {
        triggerBall.OnBallReady += OnBallReady;
        ballDestructor.OnBallDestruct += OnBallDestruct;
        SetIsBotRandomly(isRandomly);
    }

    protected IEnumerator StartBall()
    {
        state = State.Start;
        float f = force;
        if (isRandomly)
        {
            f = Random.Range(0.2f, 1.0f);
        }
        else
        {
            ++stepCountCurrent;
            if (stepCount <= stepCountCurrent)
            {
                stepCountCurrent = 0;
                force = forceStart;
            }
            else
            {
                force += forceStep;
            }
        }
        Debug.Log("StartBall with force=" + f.ToString());
        yield return new WaitForSeconds(1.0f);
        var slider = sliderStarter.GetComponent<Slider>();
        slider.value = f;
        yield return new WaitForSeconds(1.0f);
        sliderStarter.OnPointerUp(null);
        state = State.WaitForResult;
        StartGateActivity();
    }

    protected void StartGateActivity()
    {
        if (coroutineGateActivity != null)
        {
            StopCoroutine(coroutineGateActivity);
        }
        StartCoroutine(GateActivity());
    }

    protected IEnumerator GateActivity()
    {
        while (State.WaitForResult == state)
        {
            if (0.5f < Random.value)
            {
                gateLeft.SetHit();
            }
            else
            {
                gateRight.SetHit();
            }
            yield return new WaitForSeconds(Random.Range(0.0f, 1.0f));
        }
        coroutineGateActivity = null;
    }
}