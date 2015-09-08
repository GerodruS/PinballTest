using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour
{
    private static ScoreViewer instance;

    private Text label;
    private int score;

    public static void ScoreChange(int value)
    {
        instance.ScoreChangeLocal(value);
    }

    public static void ResetScore()
    {
        instance.ResetScoreLocal();
    }

    public static int GetScore()
    {
        return instance.GetScoreLocal();
    }

    protected void Start()
    {
        if (instance != null)
        {
            Debug.LogError("ScoreViewer instance != null");
        }
        else
        {
            instance = this;
            label = GetComponent<Text>();
            ResetScoreLocal();
        }
    }

    protected void OnDestroy()
    {
        if (GetComponent<Text>() == instance)
        {
            instance = null;
        }
    }

    protected void ScoreChangeLocal(int value)
    {
        score += value;
        if (score < 999)
        {
            label.text = score.ToString("000");
        }
        else
        {
            label.text = "+999";
        }
    }

    protected void ResetScoreLocal()
    {
        score = 0;
        ScoreChangeLocal(0);
    }

    protected int GetScoreLocal()
    {
        return score;
    }
}