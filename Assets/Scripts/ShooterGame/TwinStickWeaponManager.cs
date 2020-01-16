using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinStickWeaponManager : MonoBehaviour
{
    [Header("Configuration")]
    public GameObject bulletPrefab;
    public int preWarmBulletPoolerAmount;
    public Transform bulletSpawnLocation;

    [Header("Gameplay Settings")]
    public float fireSpeed;
    [HideInInspector]
    float timer = 0;
    private List<GameObject> bulletPool;

    void Awake(){
        bulletPool = new List<GameObject>();
        //Create a bunch of bullets now.
        for(int i = 0;i<preWarmBulletPoolerAmount;i++){
            GameObject b = GameObject.Instantiate(bulletPrefab);
            b.SetActive(false);
            bulletPool.Add(b);
        }
    }
    void Update(){
        timer = timer+Time.deltaTime;//Counting in seconds. We could also increment by one and count in frames, but framerates are variable by default.
    }
    public void Fire()
    {
        if(timer > fireSpeed){
            //This has replaced our instantiate function
            SpawnBullet(bulletPrefab,bulletSpawnLocation.position,transform.rotation);
            //reset the timer so we cant fire immediately again.
            timer = 0;
        }//end if timer
    }//end fire()


    private GameObject SpawnBullet(GameObject prefab, Vector3 position, Quaternion rotation){
        for(int i = 0;i<bulletPool.Count;i++){
            if(!bulletPool[i].activeInHierarchy){
                GameObject bullet = bulletPool[i];
                bullet.transform.position = position;
                bullet.transform.rotation = rotation;
                bullet.SetActive(true);
                return bullet;//breaks the loop, but also ends the function. 
            }
        }
        
        //If there are no inactive objects in our list of all bullets.
        GameObject b = GameObject.Instantiate(prefab,position,rotation);
        bulletPool.Add(b);
        return b;
    }
    
}
