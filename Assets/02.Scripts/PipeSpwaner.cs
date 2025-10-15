using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpwaner : MonoBehaviour
{
    public GameObject pipePrefab;                      //������ ������
    [SerializeField] private float spawnRate = 3.0f;   //������ ���� ������
    [SerializeField] private float heighOffset = 1.0f; //������ ���� ������

    private float timer = 0f;

    void Start()
    {
        SpawnPipe();
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnPipe();
            timer = 0f;
        }
    }

    void SpawnPipe()
    {
        float pipePosY = Random.Range(-heighOffset, heighOffset);
        Vector2 spawnPosiotn = new Vector2(transform.position.x, pipePosY);
        Instantiate(pipePrefab, spawnPosiotn, Quaternion.identity);
    }
}
