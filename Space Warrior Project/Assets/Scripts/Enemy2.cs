using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour {

    [SerializeField] private MoveObject _bulletPattern;

    [SerializeField] private float[] delays;
    [SerializeField] private int iterationsAmount;
    [SerializeField] private float mainDelay;

    [SerializeField] private Transform spawnPosition;

    [SerializeField] private Vector2 moveDirection;
    [SerializeField] private float bulletMoveSpeed;
    [SerializeField] private float bulletDestroyTime;

    private void Start()
    {
        StartCoroutine(Spawner());   
    }

    private IEnumerator Spawner()
    {
        while(true)
        {
            for(int i = 0; i < iterationsAmount; i++)
            {
                MoveObject bullet = Instantiate(_bulletPattern, spawnPosition.position, Quaternion.identity);
                bullet.Setup(bulletMoveSpeed, moveDirection);
                Destroy(bullet.gameObject, bulletDestroyTime);
                yield return new WaitForSeconds(delays[i]);
            }
            yield return new WaitForSeconds(mainDelay);
        }
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
