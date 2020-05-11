using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameReadyDialog : MonoBehaviour
{
    public static GameReadyDialog instance;

    [Header("GameUIEffect")]
    public Transform title;
 //   public Transform imageBird;
 //   public GameObject goBird;

    public Button btnPlay;
    public Button btnPause;
    public Image Loading;
    

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Loading.DOFade(0f, 0.5f).SetEase(Ease.OutCubic).OnComplete(()=> { Destroy(Loading.gameObject); });
    }

    private void Start()
    {
        btnPlay.onClick.AddListener(onClickStart);
    }

    private void onClickStart()
    {
     //   goBird.SetActive(true);
        
        this.title.gameObject.SetActive(false);
     //   this.imageBird.gameObject.SetActive(false);
        GameController.instance.isPause = false;
      
        btnPlay.gameObject.SetActive(false);
        btnPause.gameObject.SetActive(true);

        bird.instance.BirdFly();

    }

    public void onShowUI()
    {
        //btnPlay.onClick.AddListener(onClickStart);
        this.title.gameObject.SetActive(true);
     //   this.imageBird.gameObject.SetActive(true);
        AwakeAnimation();

    }

    private void AwakeAnimation()
    {
        Sequence seq = DOTween.Sequence();
        //seq.Append(title.DOLocalMoveY(0,0f).SetEase(Ease.OutCubic));
        seq.Append(title.DOLocalMoveY(-100f, 1f).SetEase(Ease.OutCubic));
        seq.Append(title.DOLocalMoveY(-150, 1f).SetEase(Ease.InCubic));
        seq.SetLoops(-1,LoopType.Restart);
    }

    public void onCloseUI()
    {

    }
}
