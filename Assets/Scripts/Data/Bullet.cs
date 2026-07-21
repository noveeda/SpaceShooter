using System.Net.Sockets;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 origin;
    private Vector2 direction;
    private Rigidbody2D rb;
    private float speed;
    

    public virtual void Shoot()
    {
        rb.linearVelocity = this.transform.up * speed;
    }

}
