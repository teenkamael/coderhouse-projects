using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IThrowable
{
    [SerializeField] float speed = 5f;
    public Vector3 direction;
    [SerializeField] bool dissapear = true;
    [SerializeField] float timeToRemove = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move(direction, speed);
        if (timeToRemove > 0f)
        {
            timeToRemove -= Time.deltaTime;
        }
        else if (dissapear)
            Destroy(this);
    }

    public void Move(Vector3 direction, float speed)
    {
        transform.Translate(speed * Time.deltaTime * direction);

    }
}
