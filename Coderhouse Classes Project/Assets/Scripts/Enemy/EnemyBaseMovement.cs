using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseMovement : MonoBehaviour
{
    [SerializeField] private BehaviorType behaviorType;
    [SerializeField] private Transform objective;

    [SerializeField] private float speedToRotate = 10f;
    [SerializeField] private float speed = 6f;
    private float minimumDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (behaviorType == BehaviorType.StaticLookPlayer)
        {
            LookPlayer();
        }
        if (behaviorType == BehaviorType.FollowPlayer)
        {
            FollowPlayer();
        }
    }

    private void LookPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation((objective.position - transform.position));
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speedToRotate * Time.deltaTime);
    }

    private void FollowPlayer()
    {
        Vector3 positionVector = objective.position - transform.position;
        Vector3 direction = positionVector.normalized;

        if (positionVector.magnitude >= minimumDistance)
        {
            transform.forward = Vector3.Lerp(transform.forward, direction, speedToRotate * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    enum BehaviorType
    {
        StaticLookPlayer,
        FollowPlayer
    }
}
