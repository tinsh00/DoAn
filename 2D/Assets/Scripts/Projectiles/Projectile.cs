using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //private AttackDetails attackDetails;

    private float speed;
    private float damage;
    private float travelDistance;
    private float xStartPos;

    private float timeExist = 2f;
    private float timeStartExit;

    [SerializeField]
    private float gravity;
    [SerializeField]
    private float damageRadius;

    private Rigidbody2D rb;

    private bool isGravityOn;
    private bool hasHitGround;
    private int leftOnPlayer;

    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private LayerMask whatIsPlayer;
    [SerializeField]
    private LayerMask whatIsShield;

    [SerializeField]
    private Transform damagePosition;


	private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.gravityScale = 0.0f;
        rb.velocity = transform.right * speed;

        isGravityOn = false;
        hasHitGround = false;

        xStartPos = transform.position.x;
        if(xStartPos > damagePosition.position.x)
		{
            leftOnPlayer = -1;
        }else
		{
            leftOnPlayer = 1;

        }
    }

    private void Update()
    {
        if (!hasHitGround)
        {
            //attackDetails.position = transform.position;
            //damagePosition.position = transform.position;

            if (isGravityOn)
            {
                float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }  
        }
        
    }

    private void FixedUpdate()
    {
        if (!hasHitGround)
        {
            //Collider2D damageHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsPlayer);
            Collider2D groundHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsGround);
            Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(damagePosition.position, damageRadius,whatIsPlayer);
            Collider2D ShieldHit = Physics2D.OverlapCircle(damagePosition.position, damageRadius, whatIsShield);


            //         if (damageHit)
            //         {
            //	Debug.Log("dame");
            //	IDamageable damageable = damageHit.GetComponent<IDamageable>();
            //	if (damageable != null)
            //	{
            //		//damageable.Damage(15f);
            //		Debug.Log("dame -15");

            //		damageable.Damage(damage);
            //		Destroy(gameObject);
            //	}
            //	//damageHit.transform.SendMessage("Damage", attackDetails);
            //}

            foreach (Collider2D collider in detectedObjects)
                {
                    IDamageable damageable = collider.GetComponent<IDamageable>();

                    if (damageable != null)
                    {
                        damageable.Damage(15f);
                         Destroy(gameObject);
                    }

				IKnockbackable knockbackable = collider.GetComponent<IKnockbackable>();

				if (knockbackable != null)
				{
					knockbackable.Knockback(Vector2.one, 10f, leftOnPlayer);
				}
			}

			if (ShieldHit)
			{
                Destroy(gameObject);
            }

            if (groundHit)
            {
                hasHitGround = true;
                rb.gravityScale = 0f;
                rb.velocity = Vector2.zero;
                timeStartExit = Time.time;
            }


            if (Mathf.Abs(xStartPos - transform.position.x) >= travelDistance && !isGravityOn)
            {
                isGravityOn = true;
                rb.gravityScale = gravity;
            }
           

        }
        if (hasHitGround && Time.time >= timeStartExit + timeExist)
        {
            Destroy(gameObject);
        }
    }

    public void FireProjectile(float speed, float travelDistance, float damage)
    {
        this.speed = speed;
        this.travelDistance = travelDistance;
        //attackDetails.damageAmount = damage;
        this.damage = damage;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(damagePosition.position, damageRadius);
        //Gizmos.DrawWireSphere(damagePosition.position,12f);
    }

	
}
