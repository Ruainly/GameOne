using DG.Tweening;
using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step0_StartVideo : MonoBehaviour
{
    GameObject VideoPlayer;
    Transform Canvas;
    CanvasGroup BlackScreen;
    // Start is called before the first frame update
    void Start()
    {
        Canvas=transform.Find("Canvas");
        VideoPlayer = Canvas.Find("Video").gameObject;
        BlackScreen = Canvas.Find("BlackScreen").GetComponent<CanvasGroup>();
        Cursor.visible = false;
    }

    public void OnVideoEvent(MediaPlayer mp, MediaPlayerEvent.EventType et, ErrorCode er)
    {
        switch (et)
        {
            case MediaPlayerEvent.EventType.ReadyToPlay:
                break;
            case MediaPlayerEvent.EventType.FirstFrameReady:
                break;
            case MediaPlayerEvent.EventType.FinishedPlaying:
                {
                    VideoPlayer.SetActive(false);
                    DOTween.To(() => BlackScreen.alpha, x => BlackScreen.alpha = x, 0, 1);
                    this.enabled = false;
                    transform.Find("Player").GetComponent<Step1_CollectProPerTry_lanterns>().enabled = true;
                    transform.Find("Player").GetComponent<CharacterControl>().enabled = true;
                }
                break;
            default:
                break;
        }
    }
}
