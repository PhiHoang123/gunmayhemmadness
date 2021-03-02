using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bullet;

    private float timebtwShoot;
    public float startTimebtwShoot;

    public virtual void Fire()
    {

            if (timebtwShoot <= 0)
            {
                    Instantiate(bullet, shootPoint.position, shootPoint.rotation);
                    timebtwShoot = startTimebtwShoot;
            }
            else
            {
                timebtwShoot -= Time.deltaTime;
            }
    }

    //Rotate gun with mouse
    public virtual void Rotate()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(GameManager.Instance.InputController.MouseInput) - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //Nếu vị trí chuột bằng - , thì xoay súng lại hướng trái (không sẽ bị ngược súng) và ngược lại.
        if (Camera.main.ScreenToWorldPoint(GameManager.Instance.InputController.MouseInput).x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(180f, 0, -angle));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
