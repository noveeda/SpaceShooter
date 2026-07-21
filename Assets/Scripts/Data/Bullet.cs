using System.Net.Sockets;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 origin;
    private Vector2 direction;
    private Rigidbody2D rb;
    [SerializeField]
    private float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Shoot()
    {
        rb.linearVelocity = this.transform.up * speed;
    }

}
