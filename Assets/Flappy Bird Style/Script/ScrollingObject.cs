using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;


    private BoxCollider2D groundCol;
    private float groundHorizontalLength;
    public float scrollSpeed = -1.5f;

    public bool isFirstScene = false;

    void Awake()
    {
        groundCol = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCol.size.x;
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(scrollSpeed, 0);
    }

    void Update()
    {
        if (GameController.instance.isPause == true && !isFirstScene)
        {
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            rb2d.velocity = new Vector2(scrollSpeed, 0);
            if (GameController.instance.gameOver == true)
            {
                rb2d.velocity = Vector2.zero;
            }

            // Nếu chiều dài x < - size x thì lặp lại (không lấy cột)
            if (this.transform.position.x < -groundHorizontalLength && this.GetComponent<ColumnScore>() == null)
            {
                RepositionBG();
            }
        }
       
    }

    // Công thêm gấp đôi chiều dài để bg lên trước
    private void RepositionBG()
    {
        Vector2 ground = new Vector2(groundHorizontalLength * 2f, 0);

        transform.position = (Vector2)transform.position + ground;
    }
}
