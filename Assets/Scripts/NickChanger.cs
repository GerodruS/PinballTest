using UnityEngine;
using UnityEngine.UI;

public class NickChanger : MonoBehaviour
{
    public InputField fieldNick;

    public void ChangeNick()
    {
        Game.PlayerName = fieldNick.text;
    }

    protected void OnEnable()
    {
        fieldNick.text = Game.PlayerName;
    }
}