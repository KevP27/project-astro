using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;
    public float distanceBetweenX;

    private float platformWidth;

    public float distanceMin;
    public float distanceMax;


    public float distanceMinX;
    public float distanceMaxX;

    // Start is called before the first frame update
    void Start()
    {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.y;
    }

    // Update is called once per frame
    void Update()
    {
        distanceBetween = Random.Range(distanceMin, distanceMax);

        distanceBetweenX = Random.Range(distanceMinX, distanceMaxX);

        if (transform.position.y < generationPoint.position.y)
        {
            transform.position = new Vector3(transform.position.x + distanceBetweenX, transform.position.y + platformWidth + distanceBetween, transform.position.z);

            Instantiate(thePlatform, transform.position, transform.rotation);
        }
    }
}
