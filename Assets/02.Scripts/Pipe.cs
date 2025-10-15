using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed = 2f; //������ �̵��ӵ�

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        //ȭ�� ������ ������ 
        if(transform.position.x < -10 )
        {
            Destroy(gameObject); //������ ����
        }
    }
}
