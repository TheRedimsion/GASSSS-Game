using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MobAI : MonoBehaviour
{
    public Transform target;

    public float kecepatan = 200f;
    public float nextWaypointDistance = 3f;

    public Transform ArahMob;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .1f);
        
    }

    void UpdatePath()
    {
        if(seeker.IsDone())
            //yang pertama titik awal, kedua titik akhir, ketiga fungsi ketika mencapai titik akhir
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
            return;
            
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * kecepatan * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if(rb.velocity.x >= 0.01f)
        {
            ArahMob.localScale = new Vector3(-1f, 1f, 1f);
        } else if(rb.velocity.x <= -0.01f)
        {
            ArahMob.localScale = new Vector3(1f, 1f, 1f);
        }

    }
}
