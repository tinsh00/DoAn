using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
	[SerializeField]
	private LayerMask whatIsPlayer;
	[SerializeField]
	private Transform damagePosition;
    [SerializeField]
	private Transform damagePosition2;
    [SerializeField]
    private float damage;

    [SerializeField]
    private string playerHurt = "playerHurt";
    [SerializeField]
    private float damageRadius;
    [SerializeField]
    private float damageRadius2;


    private int leftOnPlayer=-1;

    private float timeRecover = 2f;
    private float timeRecoverStart;

    // Start is called before the first frame update
    void Start()
    {

        timeRecoverStart = Time.time;
		if (!damagePosition2)
		{
            Debug.Log("trap1");
		}
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(damagePosition.position, damageRadius, whatIsPlayer);
        foreach (Collider2D collider in detectedObjects)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();

            if (damageable != null)
            {
				if (Time.time >= timeRecoverStart + timeRecover)
				{
                    Debug.Log("trap");
                    damageable.Damage(damage);
                    timeRecoverStart = Time.time;
                    AudioManager.instance.PlaySound(playerHurt);
                }
               
            }

            IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();

            if (knockbackable != null)
            {
                knockbackable.Knockback(Vector2.one, 10f, leftOnPlayer);
            }
        }
        if (damagePosition2)
        {
            Collider2D[] detectedObjects2 = Physics2D.OverlapCircleAll(damagePosition2.position, damageRadius2, whatIsPlayer);
            foreach (Collider2D collider in detectedObjects)
            {
                IDamageable damageable = collider.GetComponent<IDamageable>();

                if (damageable != null)
                {
                    if (Time.time >= timeRecoverStart + timeRecover)
                    {
                        Debug.Log("trap2");
                        damageable.Damage(damage);
                        timeRecoverStart = Time.time;
                        AudioManager.instance.PlaySound(playerHurt);
                    }

                }

                IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();

                if (knockbackable != null)
                {
                    knockbackable.Knockback(Vector2.one, 10f, leftOnPlayer);
                }
            }
        }
    }
	private void OnDrawGizmos()
	{
        Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
        if(damagePosition2)
            Gizmos.DrawWireSphere(damagePosition2.position, damageRadius2);
	}
}
