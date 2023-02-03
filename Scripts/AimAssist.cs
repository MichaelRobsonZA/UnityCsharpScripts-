using UnityEngine;

public class AimAssist : MonoBehaviour
{
    public float aimAssistSpeed = 5f;

    private Transform target;
    private Vector3 targetDirection;
    private float targetDistance;

    void Update()
    {
        if (target != null)
        {
            targetDirection = (target.position - transform.position).normalized;
            targetDistance = Vector3.Distance(transform.position, target.position);

            transform.forward = Vector3.Lerp(transform.forward, targetDirection, aimAssistSpeed * Time.deltaTime);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
