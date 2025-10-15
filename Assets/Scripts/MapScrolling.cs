using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MapScrolling : MonoBehaviour
{
    [Header("��ũ�� ����")]
    [SerializeField] private float scrollSpeed = 0.2f;   // ���� �ӵ�
    [SerializeField] private float speedStep = 0.1f;     // �ӵ� ���� ����
    [SerializeField] private float stepInterval = 5f;    // �ӵ� ���� �ֱ�(��)

    [Header("�� ũ�� (�ȼ� ����)")]
    [SerializeField] private float mapWidth = 1280f;     // �� �ϳ��� �ʺ�
    [SerializeField] private float mapHeight = 720f;     // �� �ϳ��� ���� (������ ������)

    private Renderer rend;
    private Vector2 offset;
    private float timer;

    void Start()
    {
        rend = GetComponent<Renderer>();  // SpriteRenderer�� MeshRenderer �ڵ� ����
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
