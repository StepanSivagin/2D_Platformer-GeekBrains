using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HitPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveDamage(int damage)
    {
        HitPoint -= damage;
        if (HitPoint <= 75) gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 200, 200);
        if (HitPoint <= 65) gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 150, 150);
        if (HitPoint <= 35) gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 70, 70);
        if (HitPoint <= 0) Destroy(gameObject);
    }
}
