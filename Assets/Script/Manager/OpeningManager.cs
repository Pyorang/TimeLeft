using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class OpeningVideoManager : MonoBehaviour
{
    [SerializeField] private GameObject buttons;

    [SerializeField] private VideoClip[] openings;
    [SerializeField] private VideoPlayer backGround;

    private int currentVideoIndex = 0;

    private void Start()
    {
        buttons.SetActive(false);

        if (openings.Length > 0 && backGround != null)
        {
            PlayVideo(currentVideoIndex);
        }
    }

    private void PlayVideo(int index)
    {
        if (index < openings.Length)
        {
            backGround.clip = openings[index];
            backGround.Play();
            if(index == openings.Length - 1)
                backGround.isLooping = true;

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
            buttons.SetActive(true);
            backGround.loopPointReached -= OnVideoFinished;
        }
    }
}
