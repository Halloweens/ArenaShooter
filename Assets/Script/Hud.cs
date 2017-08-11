using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hud : MonoBehaviour {
    public static int scoring = 0;
    public static int life;


    // Use this for initialization
    void Start () {
        UpdateHudLife();
        UpdateHudScore();
    }

	// Update is called once per frame
	void Update () {
        UpdateHudLife();
        UpdateHudScore();
    }

    void UpdateHudLife()
    {
        Text[] textEditList = GetComponentsInChildren<Text>(true);
        foreach(Text textUi in textEditList)
        {
            if (textUi.name == "Life")
                textUi.text = "Life : " + life.ToString();
        }
    }

    void UpdateHudScore()
    {
        Text[] textEditList = GetComponentsInChildren<Text>(true);
        foreach (Text textUi in textEditList)
        {
            if (textUi.name == "Score")
                textUi.text = "Score : " + scoring.ToString();
        }
    }
}
