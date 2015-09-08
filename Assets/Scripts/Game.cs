#define LOG_TABLE

using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public struct Score
    {
        public string nick;
        public int value;
    }

    public static string PlayerName
    {
        get
        {
            if (null == playerName)
            {
                playerName = playerNameDefault;
            }
            return playerName;
        }
        set
        {
            playerName = value;
        }
    }

    public static string playerNameDefault = "XXX";

    public static string keyNicks = "ScoreTableNicks";
    public static string keyScores = "ScoreTableScores";

    public Text inputTextPlayerName;

    private static string playerName;

    public static void SaveScore(int score)
    {
        var nick = PlayerName;

#if LOG_TABLE
        Debug.Log("Add: " + nick + " : " + score);
#endif

        var scores = Game.LoadScores();
        if (null == scores)
        {
            scores = new Score[0];
        }
        else if (1 == scores.Length)
        {
            if (0 == scores[0].value)
            {
                scores = new Score[0];
            }
        }
        int count = scores.Length;
        int countNew = Mathf.Min(count + 1, 5);

        var nicks = new string[countNew];
        var values = new int[countNew];
#if LOG_TABLE
        Debug.Log("save table start");
#endif
        for (int i = 0, j = 0; i < countNew; ++i)
        {
            if (count <= j || scores[j].value <= score)
            {
                nicks[i] = nick;
                values[i] = score;
                score = -1;
            }
            else
            {
                nicks[i] = scores[j].nick;
                values[i] = scores[j].value;
                ++j;
            }
#if LOG_TABLE
            Debug.Log(nicks[i] + " : " + values[i].ToString());
#endif
        }
#if LOG_TABLE
        Debug.Log("table end");
#endif

        PlayerPrefsX.SetStringArray(keyNicks, nicks);
        PlayerPrefsX.SetIntArray(keyScores, values);
    }

    public static void RemoveScores()
    {
        PlayerPrefsX.SetStringArray(keyNicks, new string[] { "AAA" });
        PlayerPrefsX.SetIntArray(keyScores, new int[] { 0 });
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
            int count = Mathf.Min(nicks.Length, 5);

            for (int i = 0; i < count; ++i)
            {
                if (values[i] <= 0)
                {
                    //--count;
                }
            }

            var scores = new Score[count];

#if LOG_TABLE
            Debug.Log("load table start");
#endif
            for (int i = 0; i < count; ++i)
            {
                scores[i].nick = nicks[i];
                scores[i].value = values[i];
#if LOG_TABLE
                Debug.Log(nicks[i] + " : " + values[i].ToString());
#endif
            }
#if LOG_TABLE
            Debug.Log("table end");
#endif

            return scores;
        }

        return null;
    }

    public void LoadLevel(int value)
    {
        playerName = string.IsNullOrEmpty(inputTextPlayerName.text) ?
                     playerNameDefault :
                     inputTextPlayerName.text;
        Application.LoadLevel(value);
    }
}