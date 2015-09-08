using UnityEngine;
using UnityEngine.UI;

public class NickChanger : MonoBehaviour
{
    public Text labelNick;

    public void ChangeNick()
    {
        Game.playerName = labelNick.text;
    }

    protected void Start()
    {
        labelNick.text = Game.playerName;
    }
}