using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject follow;
    public Transform[] camLocations;
    public int locationIndicator = 0;

    [Range(0, 1)] public float smoothTime = 0.5f;

    public float rotatespeed = 10;

    void FixedUpdate(){
        transform.position = camLocations[locationIndicator].position * (1 - smoothTime) + transform.position * smoothTime;
        //transform.LookAt(follow.transform);

        Vector3 targetDir = follow.transform.position - transform.position;
        targetDir.y = 0;
        float step = rotatespeed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
        //Debug.DrawRay(transform.position, newDir, Color.red);

        transform.rotation = Quaternion.LookRotation(newDir);
    }
}
