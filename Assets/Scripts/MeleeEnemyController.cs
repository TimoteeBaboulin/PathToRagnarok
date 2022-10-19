using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyController : MonoBehaviour
{
	public float lookRadius;
	public Transform target;
	private NavMeshAgent _agent;
    void Start()
    {
	    _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
	    float distanceToTarget = Vector3.Distance(target.position, transform.position);
	    if (distanceToTarget <= lookRadius)
	    {
		    _agent.SetDestination(target.position);
		    if (distanceToTarget <= _agent.stoppingDistance)
		    {
			    Debug.Log("Attack !");
			    FaceTarget();
		    }
	    }
    }
    
    void OnDrawGizmosSelected ()
    	{
    		Gizmos.color = Color.red;
    		Gizmos.DrawWireSphere(transform.position, lookRadius);
    	}
    void FaceTarget ()
    {
	    Vector3 direction = (target.position - transform.position).normalized;
	    Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
	    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

}
