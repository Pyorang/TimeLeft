using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] private string nextScene;
    [SerializeField] private Button[] buttonList;

    [SerializeField] private GameObject howToPlay;
    [SerializeField] private GameObject credit;

    public void OnStartBtnClicked() { SceneManager.LoadScene(nextScene); }
    public void OnHowToPlayBtnClicked() { howToPlay.SetActive(true); }
    public void OnHowToPlayCloseBtnClicked() { howToPlay.SetActive(false); }
    public void OnCreditBtnClicked() { credit.SetActive(true); }
    public void OnCreditCloseBtnClicked() { credit.SetActive(false); }
    public void OnExitBtnClicked() { Application.Quit(); }
}
