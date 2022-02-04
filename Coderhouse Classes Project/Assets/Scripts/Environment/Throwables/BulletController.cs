using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IThrowable
{
    #region SerializedFields
    [SerializeField] float speed = 20f;
    public Vector3 direction;

    [SerializeField] float timeToRemove = 50f;
    private float timer = 0f;
    [SerializeField] private bool canResizeMoreThanOnce = false;    
    private bool canResize = true;
    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < timeToRemove)
            timer += Time.deltaTime;
        else
        {
            timer = 0f;
            Destroy(gameObject);
        }
        Move(direction, speed);
        if(Input.GetKeyDown(KeyCode.Space) && canResize)
        {
            Resize();
            canResize = canResizeMoreThanOnce;
        }
    }

    public void Move(Vector3 direction, float speed)
    {
        transform.Translate(speed * Time.deltaTime * direction);

    }

    public void Resize(){ 
        transform.localScale = new Vector3(transform.localScale.x * 2, transform.localScale.y * 2, transform.localScale.z * 2);
    }
}
