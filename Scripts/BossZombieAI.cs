using System.Collections;
using UnityEngine;

public class BossZombieAI : MonoBehaviour
{
    public float jumpForce = 10f;
    public float groundSmashForce = 20f;
    public float chargeForce = 25f;
    public float changeStateHealth = 50f;
    public float attackInterval = 3f;
    public Transform player;

    private Rigidbody rigidbody;
    private float currentHealth;
    private float lastAttackTime;
    private bool isCharging;
    private Vector3 chargeDirection;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        currentHealth = 100f;
        lastAttackTime = Time.time;
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        if (currentHealth <= changeStateHealth && !isCharging)
        {
            isCharging = true;
            chargeDirection = (player.position - transform.position).normalized;
        }

        if (Time.time - lastAttackTime > attackInterval)
        {
            lastAttackTime = Time.time;

            if (isCharging)
            {
                rigidbody.AddForce(chargeDirection * chargeForce, ForceMode.Impulse);
            }
            else
            {
                rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                StartCoroutine(GroundSmash());
            }
        }
    }

    private IEnumerator GroundSmash()
    {
        yield return new WaitForSeconds(1f);
        rigidbody.AddForce(Vector3.down * groundSmashForce, ForceMode.Impulse);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // Handle death
        }
    }
}
