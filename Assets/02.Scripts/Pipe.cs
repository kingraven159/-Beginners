using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float moveSpeed = 2f; //파이프 이동속도

    void Update()
    {
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        //화면 밖으로 나가면 
        if(transform.position.x < -10 )
        {
            Destroy(gameObject); //스스로 삭제
        }
    }
}
