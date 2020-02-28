using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {
    public GameController _game;
    void Start () {
        // _game = gameObject.AddComponent<GameController> () as GameController;
    }

    void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == Tags.WHITE) {
            Debug.Log ("White " + Tags.WHITE);
            Destroy (col.gameObject);
            GameStat.CURRENTSCORE += DiscStat.WHITESCORE;

        }
        if (col.gameObject.tag == Tags.RED) {
            Debug.Log ("Red " + Tags.RED);
            Destroy (col.gameObject);
            GameStat.CURRENTSCORE += DiscStat.REDSCORE;
        }
        if (col.gameObject.tag == Tags.BLACK) {
            Debug.Log ("black " + Tags.BLACK);
            Destroy (col.gameObject);
            GameStat.CURRENTSCORE += DiscStat.BLACKSCORE;
        }
        if (col.gameObject.tag == Tags.STRIKER) {
            Debug.Log ("striker " + Tags.STRIKER);
            GameStat.CURRENTSCORE += DiscStat.STRIKERSCORE;
            col.gameObject.GetComponent<StrikerMovement> ().resetStriker ();
            // col.gameObject.resetStriker ();
        }
        _game.updateScore ();
        if (GameStat.CURRENTSCORE >= GameStat.TARGETSCORE) {
            Debug.Log ("You Won");
            _game.setGameOverUI ();
        }
    }

}