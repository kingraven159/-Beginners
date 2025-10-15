using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //이동관련 전역변수
    private Rigidbody2D rigid;
    [SerializeField] private float wingForce = 1.0f;
    private float maxTilt = 30f;
    private float tiltSpeed = 5.0f;


    //에니메이션 전역변수
    private Animator anima;
    private static readonly int wingHash = Animator.StringToHash("Wing");

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>(); 
    }
       
    void Update()
    {
        Wing();
        Tilt();
    }


    private void Wing()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            anima.SetBool(wingHash, true);
            rigid.velocity = Vector2.up * wingForce;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anima.SetBool(wingHash, false);
        }
    }
    private void Tilt()
    {
        float angle = Mathf.Clamp(rigid.velocity.y * 5f, -maxTilt, maxTilt);
        float currentAngle = transform.eulerAngles.z;
        if (currentAngle > 180f) currentAngle -= 360f;
        float smoothAngle = Mathf.Lerp(currentAngle, angle, Time.deltaTime * tiltSpeed);
        transform.rotation = Quaternion.Euler(0, 0, smoothAngle);
    }
}
