using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCam : MonoBehaviour
{
    public GameObject player;
    private float cameraFollow = 3;

    void FixedUpdate()
    {
        this.transform.position = 
            new Vector3(Mathf.Lerp(this.transform.position.x, player.transform.position.x, Time.deltaTime * cameraFollow),
            Mathf.Lerp(this.transform.position.y, player.transform.position.y, Time.deltaTime * cameraFollow), -10);
    }
}
