using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DragStriker : MonoBehaviour {
    float m_Speed;
    [SerializeField] private Button shoot;
    // [SerializeField] private Slider SliderDis;
    public Slider SliderDis;
    [SerializeField] private StrikerMovement _stricker;

    void Start () {
        m_Speed = 10.0f;
        SliderDis = SliderDis.GetComponent<Slider> ();
        // _stricker.resetStriker ();
        _stricker.SetPosition (SliderDis.value);
        // SliderDis.interactable = false;
        // private bool isStopped = _stricker.isStrikerIsStopped;
    }

    public void onMove () {
        SliderDis.minValue = -80;
        SliderDis.maxValue = 80;
        Debug.Log ("on move ");
        _stricker.SetPosition (SliderDis.value);
        _stricker.isPositionSetting = true;
        _stricker._isPlayerReady = false;
        _stricker._isChanceDone = false;

    }

    public void onPointerDown () {
        _stricker.isPositionSetting = true;
        _stricker._isPlayerReady = false;
    }

    public void onMoveStart () {
        Debug.Log ("on move START");
        // _stricker.resetStriker ();
        _stricker.isPositionSetting = true;
        _stricker._isPlayerReady = false;
        _stricker._isChanceDone = false;

    }

    public void onMoveEnd () {
        Debug.Log ("on move end");
        // _stricker.resetStriker ();
        _stricker.SetPosition (SliderDis.value);
        _stricker.isPositionSetting = false;
        _stricker._isPlayerReady = true;
        _stricker._isChanceDone = true;

    }

    void Update () {
        SliderDis.gameObject.SetActive (_stricker.isStrikerIsStopped ());
    }
}