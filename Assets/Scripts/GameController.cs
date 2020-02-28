using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public Text score;
    public Text target;
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start () {
        GameStat.CURRENTSCORE = 0;
        score.text = "Score: " + GameStat.CURRENTSCORE;
        target.text = "Target: " + GameStat.TARGETSCORE;
        gameOverUI.SetActive (false);
    }

    public void setGameOverUI () {
        gameOverUI.SetActive (true);
    }

    public void updateScore () {
        score.text = "Score: " + GameStat.CURRENTSCORE;

    }

    // Update is called once per frame
    void Update () { }
}