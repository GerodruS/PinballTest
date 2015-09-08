using UnityEngine;
using UnityEngine.UI;

public class NickChanger : MonoBehaviour
{
    public InputField fieldNick;

    public void ChangeNick()
    {
        Game.playerName = fieldNick.text;
    }

    protected void OnEnable()
    {
        fieldNick.text = Game.playerName;
    }
}