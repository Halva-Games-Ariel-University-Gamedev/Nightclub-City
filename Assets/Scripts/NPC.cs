using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour
{
    public float minSpeed = 1f;
    public float maxSpeed = 3f;
    public float wanderRadius = 5f;

    private float speed;
    private Vector2 targetPos;
    private bool isIdle = false;
    private bool hasWalkedUp = false;

    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        StartCoroutine(WanderRoutine());
        StartCoroutine(SpendCashRoutine());
    }

    void Update()
    {
        if (isIdle) return;

        transform.position = Vector2.MoveTowards(
            transform.position,
            targetPos,
            speed * Time.deltaTime
        );
    }

    IEnumerator WanderRoutine()
    {
        while (true)
        {
            if (!hasWalkedUp)
            {
                targetPos = new Vector2(transform.position.x, transform.position.y + wanderRadius);
                hasWalkedUp = true;
            }
            else
            {
                PickNewTarget();
            }

            float walkTime = Random.Range(1f, 3f);
            yield return new WaitForSeconds(walkTime);

            isIdle = true;
            float idleTime = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(idleTime);
            isIdle = false;
        }
    }

    void PickNewTarget()
    {
        float randX = Random.Range(-wanderRadius, wanderRadius);
        float randY = Random.Range(-wanderRadius, wanderRadius);
        targetPos = new Vector2(transform.position.x + randX, transform.position.y + randY);
    }

    IEnumerator SpendCashRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(2f, 5f);
            yield return new WaitForSeconds(waitTime);

            int amount = Random.Range(5, 20);
            if (GameManager.instance != null)
            {
                GameManager.instance.AddMoney(amount);
            }

            // Spawn dollar animation above NPC
            if (GameManager.instance != null)
            {
                GameObject dollar = Instantiate(
                    GameManager.instance.dollarPrefab,
                    transform.position + new Vector3(0, 1f, 0),
                    Quaternion.identity
                );
            }
        }
    }

}
