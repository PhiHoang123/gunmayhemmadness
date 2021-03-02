using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolBullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public LayerMask whatisSolid;

    private void Start()
    {
        Destroybullet();
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
       
    }

    void Destroybullet()
    {
        Destroy(gameObject, lifetime);
    }

}
