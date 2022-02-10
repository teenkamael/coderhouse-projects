using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public GameObject[] cameras;
    void Start()
    {
        if (cameras == null)
            Debug.LogWarning("Please specify a camera on array!");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            EnableCamera(0);
        if (Input.GetKeyDown(KeyCode.F2))
            EnableCamera(1);
        if (Input.GetKeyDown(KeyCode.F3))
            EnableCamera(2);
        if (Input.GetKeyDown(KeyCode.F4))
            EnableCamera(3);

    }

    private void EnableCamera(int position)
    {
        foreach (GameObject camera in cameras)
            camera.SetActive(cameras[position] == camera);

    }
}
