using System;
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
    [SerializeField] float pushForce = 1;

    [HideInInspector]
    public Vector3 SpawnLocation;

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
                StartCoroutine(PushTarget(hitFish, hitFish.transform.position - SpawnLocation));
                //hitFish.GetComponent<SpriteSwitcher>().ChangeSprite("get_hit");
                hitFish.GetComponent<FishAttack>().currentHP -= damage;
                GameObject damageParticle = Instantiate(hitFish.GetComponent<FishAttack>().fishDamageParticle, hitFish.transform.position, Quaternion.identity);
                Destroy(damageParticle, 3);
                if (hitFish.GetComponent<FishAttack>().currentHP <= 0)
                {
                    GameObject deathParticle = Instantiate(hitFish.GetComponent<FishAttack>().fishDeathParticle, hitFish.transform.position, Quaternion.identity);
                    Destroy(deathParticle, 3);
                    Destroy(hitFish.transform.parent.gameObject);
                    //hitFish.GetComponent<SpriteSwitcher>().ChangeSprite("dead");
                }
            }
            Destroy(gameObject);
        }

    }

    IEnumerator PushTarget(GameObject target, Vector3 direction, float force=0.2f, float speed=0.1f)
    {
        //float t = 0;
        //float maxT = 1;
        Vector3 start = target.transform.position;
        Vector3 end = start + (direction.normalized * force);
        target.transform.position = end;

        yield return null;
        //while (t < maxT)
        //{
        //    target.transform.position = Vector3.Lerp(start, end, (t / maxT));
        //    t += Time.deltaTime;
        //    yield return null;
        //}

    }
}
