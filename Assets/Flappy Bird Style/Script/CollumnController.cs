using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollumnController : MonoBehaviour
{
    public GameObject column;

    private GameObject[] columns;
    private int currentColumn = 0;
    public int columnTotal = 5;

    public float columnMin = -1f, columnMax = 3f;

    private Vector2 objectPosition = new Vector2(-15f, -35f);
    private float spawnXPosition = 5f;

    private float timeLastSpawn;
    public float spawnRate = 2f;

    void Start()
    {
        timeLastSpawn = 0f;

        columns = new GameObject[columnTotal];

        for(int i = 0; i<columnTotal;i++)
        {
            columns[i] = (GameObject)Instantiate(column, objectPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        if(GameController.instance.isPause == true)
        {

        }
        else
        {
            timeLastSpawn += Time.deltaTime;
            if (GameController.instance.gameOver == false && timeLastSpawn >= spawnRate)
            {
                timeLastSpawn = 0;

                float spawnYPosition = Random.Range(columnMin, columnMax);
                Debug.Log(spawnYPosition);

                columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

                currentColumn++;

                if (currentColumn >= columnTotal)
                {
                    currentColumn = 0;
                }

            }
        }
      
    }
}
