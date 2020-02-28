using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {
    // Start is called before the first frame update
    public Text gameOverScore;

    void Enable () {
        gameOverScore.text = "Your Score: " + GameStat.CURRENTSCORE;
    }

    public void loadMainMenu () {
        SceneManager.LoadScene ("MainMenu");
    }

    public void restartLevel () {
        SceneManager.LoadScene ("Game");
    }
    public void exitGame () {
        Application.Quit ();
    }

}