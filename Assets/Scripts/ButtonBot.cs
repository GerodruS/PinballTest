using UnityEngine;
using UnityEngine.UI;

public class ButtonBot : MonoBehaviour
{
    public Text textButton;
    public Bot bot;

    protected enum State
    {
        None,
        Random,
        Ordered
    }

    private State state = State.None;

    public void SwitchState()
    {
        switch (state)
        {
            case State.None:
                SetState(State.Random);
                break;

            case State.Random:
                SetState(State.Ordered);
                break;

            case State.Ordered:
                SetState(State.None);
                break;
        }
    }

    protected void Start()
    {
        SetState(State.None);
    }

    protected void SetState(State value)
    {
        state = value;

        switch (state)
        {
            case State.None:
                {
                    textButton.text = "Bot Off";
                    bot.enabled = false;
                }
                break;

            case State.Random:
                {
                    textButton.text = "Bot Random";
                    bot.enabled = true;
                    bot.isRandomly = true;
                }
                break;

            case State.Ordered:
                {
                    textButton.text = "Bot Ordered";
                    bot.enabled = true;
                    bot.isRandomly = false;
                }
                break;
        }
    }
}