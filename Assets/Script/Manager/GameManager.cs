using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static PlayerStatus;

public class GameManager : MonoBehaviour
{
    private bool isPaused = false;

    public delegate void IsPausedChanged();
    public static UnityEvent OnMenuButtonClicked = new UnityEvent();

    [SerializeField] private UIManager uiManager;

    public bool IsPaused
    {
        get { return isPaused; }
        set
        {
            if (value) { Time.timeScale = 0f; }
            else { Time.timeScale = 1f; }

            isPaused = value;
            uiManager.ProcessingPauseMenu(value);
        }
    }

    private void Start()
    {
        OnMenuButtonClicked.AddListener(()=>ChangeIsPaused());
    }

    private void Update()
    {
        WaitEscPressed();
    }

    private void WaitEscPressed() { if(Input.GetKeyDown(KeyCode.Escape)) { IsPaused = !IsPaused; } }
    private void ChangeIsPaused() { IsPaused = !IsPaused; }
}
