using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGraphics : MonoBehaviour
{
    public AIPath aiPath;
    public GameObject firePos;
    public GameObject healthBar;

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            firePos.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            healthBar.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

        }
        else if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            firePos.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            healthBar.transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
