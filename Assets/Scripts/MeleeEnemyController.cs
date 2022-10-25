using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyController : EnemyBase
{
	public float attackDelay;
	public float attackSpeed;
	private NavMeshAgent _agent;
	private float _attackCountdown = 0f;

	public override void Attack()
	{
		Debug.Log("Attack !");
	}

	void Start()
    {
	    _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
	    _attackCountdown -= Time.deltaTime;
	    float distanceToTarget = Vector3.Distance(target.position, transform.position);
	    if (distanceToTarget <= lookRadius)
	    {
		    _agent.SetDestination(target.position);
		    if (distanceToTarget <= _agent.stoppingDistance)
		    {
			    if (_attackCountdown <= 0f)
			    {
				    _attackCountdown = 1f / attackSpeed;
				    StartCoroutine(DoDamage(attackDelay));
				    FaceTarget();
			    }
		    }
	    }
	    else
	    {
		    _agent.SetDestination(transform.position);
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

    IEnumerator DoDamage(float delay)
    {
	    yield return new WaitForSeconds(delay);
	    Attack();
    }
}
