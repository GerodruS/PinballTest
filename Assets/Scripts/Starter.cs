using UnityEngine;

public class Starter : MonoBehaviour
{
    public Rigidbody ball;
    public Transform positionReset;
    public string buttonNamePause = "Pause";
    public Pause pause;

    [Header("Field from AssetsBundle")]
    public string pathLevel;
    public string nameLevel;

    public void Reset()
    {
        ball.rotation = Quaternion.identity;
        ball.velocity = Vector3.zero;
        ball.transform.position = positionReset.position;

        Game.SaveScore(ScoreViewer.GetScore());
        ScoreViewer.ResetScore();
    }

    protected void Start()
    {
        LoadField(pathLevel, nameLevel);
    }

    protected void LoadField(string pathLvl, string nameLvl)
    {
        if (!string.IsNullOrEmpty(pathLvl) &&
            !string.IsNullOrEmpty(nameLvl))
        {
            var path = Application.dataPath + pathLvl;
            var assetBundleField = AssetBundle.CreateFromFile(path);

            var obj1 = assetBundleField.LoadAsset(nameLvl, typeof(GameObject)) as GameObject;
            var obj = Instantiate(obj1);
            obj.transform.parent = transform;
        }
    }

    protected void Update()
    {
        if (Input.GetButtonDown(buttonNamePause))
        {
            pause.SwitchState();
        }
    }
}