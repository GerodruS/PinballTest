using UnityEngine;
using UnityEngine.UI;

public class ScoreTable : MonoBehaviour
{
    public Text[] labelsNick;
    public Text[] labelsScore;

    private int rowCount = 0;

    public void Clear()
    {
        for (int i = 0; i < rowCount; ++i)
        {
            labelsNick[i].text = "---";
            labelsScore[i].text = "000";
        }
    }

    public void Refresh()
    {
        Clear();
        var scores = Game.LoadScores();
        if (scores != null)
        {
            int count = Mathf.Min(scores.Length, rowCount);
            for (int i = 0; i < count; ++i)
            {
                if (!string.IsNullOrEmpty(scores[i].nick) &&
                    0 < scores[i].value)
                {
                    labelsNick[i].text = scores[i].nick;
                    labelsScore[i].text = scores[i].value.ToString();
                }
            }
        }
    }

    protected void Start()
    {
        if (labelsNick.Length != labelsScore.Length)
        {
            Debug.LogError("Diff count of nicks and scores labels");
        }
        else
        {
            rowCount = labelsScore.Length;
            Refresh();
        }
    }
}