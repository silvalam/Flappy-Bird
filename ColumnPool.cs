using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public int columnPoolSize = 5;
    public GameObject colPrefab;
    public float spawnRate = 4f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;

    private Vector2 objPoolPos = new Vector2(-15f, -25f);
    private GameObject[] columns;
    private float timeSinceLastSpawn;
    private float spawnXPosition = 10f;
    private int currentColumn = 0;

    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for(int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(colPrefab, objPoolPos, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(GameControl.instance.gameOver == false && timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn++].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            if(currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
