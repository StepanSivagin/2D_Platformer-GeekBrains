using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public int HitPoint = 100;
    public float Speed = 0.1f;

    public float JumpForce;
    public int JumpCount = 2;
    public int _jumps;

    public Transform GroundCheck;
    public float GroundCheckRadius;
    public LayerMask WhatIsGround;
    private bool _isGrounded;

    private float Direction;

    private SpriteRenderer _sprite;
    private Rigidbody2D _rigidbody2D;

    public GameObject Bullet;
    public int Magazine;
    private int _bulletCount;
    public Transform BulletSpawnRight;
    public Transform BulletSpawnLeft;


    // Start is called before the first frame update
    void Start()
    {
        _bulletCount = Magazine;
        _jumps = JumpCount;
        _sprite = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        _isGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);
        if (_isGrounded == true) _jumps = JumpCount;
        if (Input.GetKeyDown(KeyCode.Space) && _jumps > 0) Jump(JumpForce);
            
        
        if (Input.GetMouseButtonDown(0) && _bulletCount > 0) Shoot();
        if (Input.GetKeyDown(KeyCode.R)) Reload();
        

    }

    void FixedUpdate()
    {

        Direction = Input.GetAxis("Horizontal");
        if (Direction > 0.002f || Direction < -0.002f) Move(Direction);
        
    }

    private void Move(float _direction)
    {
        if (_direction < 0) _sprite.flipX = true;
        else _sprite.flipX = false;
        transform.position += new Vector3(_direction * Speed, 0, 0);
    }

    private void Jump(float JumpForce)
    {
        if (!_isGrounded && _jumps == 0) return;
        
        _rigidbody2D.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        _jumps--;
    }

    private void Shoot()
    {
        _bulletCount--;
        if (_sprite.flipX == false) Instantiate(Bullet, BulletSpawnRight.position, BulletSpawnRight.rotation);
        else Instantiate(Bullet, BulletSpawnLeft.position, BulletSpawnLeft.rotation);
    }

    private void Reload()
    {
        _bulletCount = Magazine;
    }

}
