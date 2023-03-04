using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ArahMob : MonoBehaviour
{
    public AIPath jalanMob;

    // Update is called once per frame
    void Update()
    {
        if(jalanMob.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if(jalanMob.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }
}
