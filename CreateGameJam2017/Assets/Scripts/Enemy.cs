using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[System.Serializable]
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity {
    public Ragdoll ragdoll;
    NavMeshAgent pathfinder;
    Transform target;
    Transform enemy;


    // Use this for initialization
    protected override void Start()
    {
        base.Start();

        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemy = this.transform;

        StartCoroutine(UpdatePath());
    }

	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator UpdatePath()
    {
        float refreshRate = .25f;

        while (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, 0, target.position.z);
            if (!dead)
            {
                pathfinder.SetDestination(targetPosition);
            }
            yield return new WaitForSeconds(refreshRate);
        }
    }

    void OnDestroy()
    {
        Instantiate(ragdoll, transform.position, transform.rotation);
        Instantiate(ragdoll, transform.position, transform.rotation);
        print("Script was destroyed");
    }
}
