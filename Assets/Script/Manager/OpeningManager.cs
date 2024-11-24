using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class OpeningVideoManager : MonoBehaviour
{
    [SerializeField] private Button skipButton;
    [SerializeField] private GameObject buttons;

    [SerializeField] private VideoClip[] openings;
    [SerializeField] private VideoPlayer backGround;

    private bool firstOpening = true;
    private int currentVideoIndex = 0;

    private void Start()
    {
        //GameManager에게 firstOpening 정보 받아오기
        
        currentVideoIndex = 1;

        if (firstOpening) ProcessFirstOpening();

        if (openings.Length > 0 && backGround != null)
        {
            PlayVideo(currentVideoIndex);
        }
    }

    private void ProcessFirstOpening()
    {
        firstOpening = false;
        currentVideoIndex = 0;
        buttons.SetActive(false);
    }

    private void PlayVideo(int index)
    {
        if (index < openings.Length)
        {
            backGround.clip = openings[index];
            backGround.Play();
            if(index == openings.Length - 1)
            {
                backGround.isLooping = true;
            }

            backGround.loopPointReached += OnVideoFinished;
        }
    }

    private void OnVideoFinished(VideoPlayer source)
    {
        currentVideoIndex++;

        if (currentVideoIndex < openings.Length)
        {
            PlayVideo(currentVideoIndex);
        }
        else
        {
            skipButton.gameObject.SetActive(false);
            buttons.SetActive(true);
            backGround.loopPointReached -= OnVideoFinished;
        }
    }

    public void OnClickedSkipButton()
    {
        if (backGround.isPlaying == true) backGround.Stop();

        skipButton.gameObject.SetActive(false);
        buttons.SetActive(true);

        PlayVideo(openings.Length - 1);
    }
}
