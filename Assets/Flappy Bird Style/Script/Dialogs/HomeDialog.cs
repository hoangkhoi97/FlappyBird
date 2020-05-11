using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeDialog : MonoBehaviour
{
    [Header("GameUIEffect")]
    public Transform title;

    public Button btnPlay;
    public Image Loading;

    private void Start()
    {
        AwakeAnimation();
        btnPlay.onClick.AddListener(onClickStartGame);
    }

    private void onClickStartGame()
    {
        Loading.DOFade(1f, 0.5f).SetEase(Ease.InCubic).OnComplete(() => { SceneManager.LoadScene("GameScene"); });
    }

    private void AwakeAnimation()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(title.DOLocalMoveY(300f, 0.7f).SetEase(Ease.OutCubic));
        seq.Append(title.DOLocalMoveY(250f, 0.7f).SetEase(Ease.OutCubic));
       
        seq.SetLoops(-1, LoopType.Restart);
    }

}
