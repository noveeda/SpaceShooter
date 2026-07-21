using System;
using System.Collections;
using System.Net.NetworkInformation;
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

    [SerializeField]
    private float fireRate;
    private WaitForSeconds sec = new WaitForSeconds(.1f);
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        GameManager.Instance.player = this;
    }

    private void Start()
    {
        speed = 5f;
        StartCoroutine(CoShoot());
    }

    private void Update()
    {
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        rb.linearVelocity = dir * speed;

        // 토글 식으로 총알 발사
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.isShooting = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            GameManager.Instance.isShooting = false;
        }
    }

    private IEnumerator CoShoot()
    {
        while (true)
        {
            if (GameManager.Instance.isShooting) Shoot();
            yield return sec;
        }
    }

    private void Shoot()
    {
        GameObject obj = GameManager.Instance.GetFromPool();
        obj.transform.position = muzzleTransform.position;
        if (obj.TryGetComponent<Bullet>(out Bullet bullet))
        {
            bullet.Shoot();
        }
        GameManager.Instance.InputPool(obj);
    }
}
