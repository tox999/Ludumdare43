using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harpoon : MonoBehaviour
{
    private Vector3 target;
    private float speed;
    private float damage;
    private bool canMove = false;
    float minDistance = 0.05f;
    [SerializeField] int fishLayer = 17;

	void Update()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            transform.right = target - transform.position;

            if (Vector2.Distance(transform.position, target) < minDistance)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetTargetSpeedDamage(Vector2 newTarget, float harpoonSpeed, float harpoonDamage)
    {
        target = newTarget;
        speed = harpoonSpeed;
        canMove = true;
        damage = harpoonDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == fishLayer)
        {
            GameObject hitFish = collision.gameObject;
            if (hitFish != null)
            {
                hitFish.GetComponent<FishAttack>().currentHP -= damage;
                GameObject damageParticle = Instantiate(hitFish.GetComponent<FishAttack>().fishDamageParticle, hitFish.transform.position, Quaternion.identity);
                Destroy(damageParticle, 3);
                if (hitFish.GetComponent<FishAttack>().currentHP <= 0)
                {
                    GameObject deathParticle = Instantiate(hitFish.GetComponent<FishAttack>().fishDeathParticle, hitFish.transform.position, Quaternion.identity);
                    Destroy(damageParticle, 3);
                    Destroy(hitFish.transform.parent.gameObject);
                }
            }
            Destroy(gameObject);
        }

    }
}
