using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private float backGroundSpeed = 1000.0f;
    [SerializeField] private float imageWidth = 5847f;

    [SerializeField] private RectTransform[] backGround_Transform;

    [SerializeField] private TextMeshProUGUI lifeCountText;
    [SerializeField] private Button pauseMenuButton;

    [SerializeField] private Button[] attackButtons;

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private string mainScene;

    private void Start()
    {
        PlayerStatus.OnLifeCountChanged += UpdateLifeCountText;
    }

    private void Update()
    {
        MovingBackGround();
    }

    private void MovingBackGround()
    {
        foreach(var imageRectT in backGround_Transform)
        {
            imageRectT.anchoredPosition -= new Vector2(backGroundSpeed * Time.deltaTime, 0);

            if (imageRectT.anchoredPosition.x < -imageWidth)
            {
                imageRectT.anchoredPosition += new Vector2(imageWidth * backGround_Transform.Length, 0);
            }
        }
    }

    public void ProcessingPauseMenu(bool isPaused) { pauseMenu.SetActive(isPaused);}

    private void UpdateLifeCountText(int lifeCount) { lifeCountText.text = lifeCount.ToString(); }

    public void SetAttackBtns(bool isAvailable)
    {
        foreach(var attackButton in  attackButtons)
        {
            attackButton.gameObject.SetActive(isAvailable);
        }
    }

    public void OnPauseMenuBtnClicked() { GameManager.OnMenuButtonClicked?.Invoke(); }
    public void OnResumeMenuBtnClicked() { GameManager.OnMenuButtonClicked?.Invoke(); }
    public void OnExitMenuBtnClicked() { SceneManager.LoadScene(mainScene); }
}
