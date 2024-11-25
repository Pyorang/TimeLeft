using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainUIManager : MonoBehaviour
{
    [SerializeField] private string gameScene;

    [SerializeField] private GameObject mainBtnProtection;
    [SerializeField] private GameObject howToPlay;
    [SerializeField] private GameObject credit;

    public void OnStartBtnClicked() { SceneManager.LoadScene(gameScene); }
    
    public void OnHowToPlayBtnClicked() 
    {
        mainBtnProtection.SetActive(true);
        howToPlay.SetActive(true); 
    }

    public void OnHowToPlayCloseBtnClicked() 
    {
        mainBtnProtection.SetActive(false);
        howToPlay.SetActive(false); 
    }
    
    public void OnCreditBtnClicked() 
    {
        mainBtnProtection.SetActive(true);
        credit.SetActive(true); 
    }
    
    public void OnCreditCloseBtnClicked() 
    { 
        mainBtnProtection.SetActive(false);
        credit.SetActive(false); 
    }
    
    public void OnExitBtnClicked() { Application.Quit(); }
}
