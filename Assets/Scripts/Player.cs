using System;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class Player : MonoBehaviour
{
    // 인스펙터에서 보이게 하기 위함.
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    [SerializeField]
    private Transform muzzleTransform;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager.Instance.player = this;
    }

    private void Start()
    {
        speed = 5f;
    }

    private void Update()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        rb.linearVelocity = dir * speed;
    }

    private void Shoot()
    {
        GameObject obj = GameManager.Instance.GetFromPool();
        obj.transform.position = muzzleTransform.position;
        if (obj.TryGetComponent<Bullet>(out Bullet bullet))
        {
            bullet.Shoot();
        }
    }
}
