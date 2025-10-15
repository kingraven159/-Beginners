using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MapScrolling : MonoBehaviour
{
    [Header("스크롤 설정")]
    [SerializeField] private float scrollSpeed = 0.2f;   // 시작 속도
    [SerializeField] private float speedStep = 0.1f;     // 속도 증가 단위
    [SerializeField] private float stepInterval = 5f;    // 속도 증가 주기(초)

    [Header("맵 크기 (픽셀 단위)")]
    [SerializeField] private float mapWidth = 1280f;     // 맵 하나의 너비
    [SerializeField] private float mapHeight = 720f;     // 맵 하나의 높이 (지금은 참조용)

    private Renderer rend;
    private Vector2 offset;
    private float timer;

    void Start()
    {
        rend = GetComponent<Renderer>();  // SpriteRenderer나 MeshRenderer 자동 감지
        offset = Vector2.zero;
    }

    void Update()
    {
        UpdateSpeedByTime();
        ScrollTexture();
    }

    private void UpdateSpeedByTime()
    {
        timer += Time.deltaTime;
        if (timer >= stepInterval)
        {
            scrollSpeed += speedStep;
            timer = 0.0f;
        }
    }

    private void ScrollTexture()
    {
        offset.x += scrollSpeed * Time.deltaTime;
        rend.material.mainTextureOffset = offset;
    }
}
