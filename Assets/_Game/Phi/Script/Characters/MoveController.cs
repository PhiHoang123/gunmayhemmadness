using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    public void Move(Vector2 direction)
    {
        rb.velocity = direction;
    }

    //Turn the body direction
    public void RotateBodyWithMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(GameManager.Instance.InputController.MouseInput);
        if (mousePos.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180f, transform.position.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0f, transform.position.z);
        }
    }
}
