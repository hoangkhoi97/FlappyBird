using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class bird : MonoBehaviour
{
    // public float speed = 2f;
    //  public Button btnFly;
    public static bird instance;

    public float force = 50f;

    private bool isDead = false ;
    private Rigidbody2D rb2D;

    private Animator anim;
    //  private SpriteRenderer sprite;
    public Transform motherBird;
    public AudioClip audioHit;
    public AudioClip audioFly;
    private AudioSource sourceAudio;
    private bool oneShow = true;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        //  btnFly.onClick.AddListener(BirdFly);
     //   sprite = gameObject.GetComponent<SpriteRenderer>();
        sourceAudio = GetComponent<AudioSource>();
   
        //this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }

  
    public void BirdFly()
    {
        if (isDead == false)
        {
            motherBird.DOKill();
            motherBird.DORotate(new Vector3(0, 0, 20f), 0.15f);
     
            sourceAudio.PlayOneShot(audioFly,0.7f);
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0);
            rb2D.AddForce(new Vector2(0, force)); 
        }
    }

    public void FlyDown()
    {
        motherBird.DOKill();
        motherBird.DORotate(new Vector3(0, 0, -90f), 2f).SetEase(Ease.OutBounce); 
    }

    private float yPerFrame= 0;
    void Update()
    {
        if(GameController.instance.isPause ==true)
        {
            rb2D.constraints = RigidbodyConstraints2D.FreezeAll;
            motherBird.DOKill();
        }
        else
        {
            rb2D.constraints = RigidbodyConstraints2D.None;
            if(yPerFrame > 0 && rb2D.velocity.y < 0 )
            {
                FlyDown();
            }

            yPerFrame = rb2D.velocity.y;
        }

    }

 

    void OnCollisionEnter2D(Collision2D col)
    {
        if(oneShow)
        {
            sourceAudio.PlayOneShot(audioHit, 0.6f);
            rb2D.velocity = Vector2.zero;
            rb2D.gravityScale = 5f;
            isDead = true;
            //  anim.SetTrigger("Die");
            motherBird.gameObject.GetComponent<Animator>().enabled = false;
            GameController.instance.BirdDied();
            oneShow = false;
        }
    }
}
