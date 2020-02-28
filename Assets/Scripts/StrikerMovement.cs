using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrikerMovement : MonoBehaviour {

    public float thrust = 10.0f;
    private Rigidbody2D striker;
    public bool isPressed = false;
    public bool isPositionSetting = true;
    public bool _isPlayerReady = false;
    public bool _isChanceDone = false;
    public GameObject aimArrow;
    public Vector3 _direction; // = Vector3 (0, 0, 0);
    float _forceAmount = 2,
        appliedForce = 5f,
        rotateSpeed = 2f;
    [SerializeField] GameObject gui;

    void Start () {
        striker = transform.GetComponent<Rigidbody2D> ();
        gui.SetActive (false);
        aimArrow.SetActive (false);
    }

    public void SetPosition (float xValue) {
        xValue /= 100;
        xValue *= 1.55f;
        transform.position = new Vector3 (xValue, -1.6f, 0.0f);

    }

    public void hitStriker (Vector3 dir) {
        striker.AddForce (_forceAmount * _direction, ForceMode2D.Impulse);
    }

    public void resetStriker () {
        striker.gameObject.SetActive (true);
        striker.velocity = Vector2.zero;
        striker.angularVelocity = 0;
        transform.position = new Vector3 (0, -1.6f, 0.0f);
        striker.transform.eulerAngles = new Vector3 (0, 0, 0);
    }

    public bool isStrikerIsStopped () {

        if (striker.velocity.magnitude < 0.1f) {
            return true;
        } else
            return false;
    }

    public void manageAim () {
        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        Vector3 player_pos = aimArrow.transform.position - mouse_pos;
        _forceAmount = player_pos.magnitude * appliedForce;
        _direction = player_pos.normalized;
        float angle = Mathf.Atan2 (player_pos.y, player_pos.x) * Mathf.Rad2Deg;
        aimArrow.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
    }
    // Update is called once per frame
    void Update () {
        if (isPositionSetting) {
            isPressed = false;
            return;
        }
        if (isPressed) {

            gui.SetActive (isPressed);
            aimArrow.SetActive (isPressed);
            manageAim ();

            if (Input.GetMouseButtonUp (0)) {
                hitStriker (_direction);
                isPressed = false;
                _isPlayerReady = false;
                // isPositionSetting = true;
                isPositionSetting = false;
                gui.SetActive (isPressed);
                aimArrow.SetActive (isPressed);
            }
        }
        if (_isPlayerReady) {
            if (Input.GetMouseButton (0)) {
                isPressed = true;
            }
        }

        if (striker.velocity.magnitude > 0.05f && striker.velocity.magnitude < 0.2f) {
            resetStriker ();
            Debug.Log ("reset");
        }

    }
}