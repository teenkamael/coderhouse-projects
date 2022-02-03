using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IThrowable
{
    #region SerializedFields
    [SerializeField] float speed = 20f;
    public Vector3 direction;
    [SerializeField] bool dissapear = false;

    [SerializeField] float timeToRemove = 5f;
    private float timer = 0f;
    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeToRemove > 0f)
        {
            timeToRemove += Time.deltaTime;
        }
        else
            dissapear = true;
        if (dissapear)
            Destroy(this);
        Move(direction, speed);
    }

    public void Move(Vector3 direction, float speed)
    {
        transform.Translate(speed * Time.deltaTime * direction);

    }
}
