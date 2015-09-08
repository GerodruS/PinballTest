using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public struct Score
    {
        public string nick;
        public int value;
    }

    public static string playerName;
    public static string playerNameDefault = "XXX";

    public static string keyNicks = "ScoreTableNicks";
    public static string keyScores = "ScoreTableScores";

    public Text inputTextPlayerName;

    public static void SaveScore(int score)
    {
        var nick = string.IsNullOrEmpty(playerName) ?
                   playerNameDefault :
                   playerName;
        var scores = Game.LoadScores();
        if (null == scores)
        {
            scores = new Score[0];
        }
        int count = scores.Length;

        var nicks = new string[count + 1];
        var values = new int[count + 1];
        for (int i = 0, j = 0; i < count + 1; ++i)
        {
            if (count == j || scores[j].value < score)
            {
                nicks[i] = nick;
                values[i] = score;
            }
            else
            {
                nicks[i] = scores[j].nick;
                values[i] = scores[j].value;
                ++j;
            }
        }

        PlayerPrefsX.SetStringArray(keyNicks, nicks);
        PlayerPrefsX.SetIntArray(keyScores, values);
    }

    public static Score[] LoadScores()
    {
        string[] nicks = PlayerPrefsX.GetStringArray(keyNicks);
        int[] values = PlayerPrefsX.GetIntArray(keyScores);

        if (nicks.Length != values.Length)
        {
            Debug.LogError("Diff count of nicks and scores in saved data");
        }
        else
        {
            int count = nicks.Length;
            var scores = new Score[count];
            for (int i = 0; i < count; ++i)
            {
                scores[i].nick = nicks[i];
                scores[i].value = values[i];
            }

            return scores;
        }

        return null;
    }

    public void LoadLevel(int value)
    {
        playerName = inputTextPlayerName.text;
        Application.LoadLevel(value);
    }
}