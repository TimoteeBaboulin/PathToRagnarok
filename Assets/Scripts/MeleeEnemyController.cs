using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyController : MonoBehaviour{
    public float lookRadius;
    public Transform target;
    private NavMeshAgent _agent;

    private void Start(){
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update(){
        var distanceToTarget = Vector3.Distance(target.position, transform.position);
        if (distanceToTarget <= lookRadius){
            _agent.SetDestination(target.position);
            if (distanceToTarget <= _agent.stoppingDistance){
                Debug.Log("Attack !");
                FaceTarget();
            }
        }
    }

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    private void FaceTarget(){
        var direction = (target.position - transform.position).normalized;
        var lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}