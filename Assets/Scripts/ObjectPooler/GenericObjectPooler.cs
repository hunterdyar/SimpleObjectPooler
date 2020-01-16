using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectPooler : MonoBehaviour
{
    public static GenericObjectPooler instance;
    public GameObject objectToPool;
    public int startingPoolSize;
    public bool canGrow;
    List<GameObject> pool;
    void Awake(){//So we may not even want to use a singleton here? Singleton means only one pooler.
        //But one of the reasons to use this script is to let a bunch of enemies all use it for one bullet type, and then another instance of this class for another object type
        instance = this;
    }
    void Start()
    {
        //Instantiate list.
        pool = new List<GameObject>();
        //Create the list of inactive objects.
        for(int i = 0;i<startingPoolSize;i++){
            GameObject tempObject = GameObject.Instantiate(objectToPool);
            tempObject.SetActive(false);
            pool.Add(tempObject);
        }
    }

    //This is a simple example so lets just let whomever needs this function active the object themselves, and set its position and rotation itself.
    public GameObject GetObject(){
        for(int i = 0;i < pool.Count;i++){//This loop sounds slow but its not, its much faster than moving objects out of a list and into another list.
            if(!pool[i].activeInHierarchy){
                return pool[i];
            }
        }
        //dynamically resize if we need more?
        if(canGrow){
            GameObject tempObject = GameObject.Instantiate(objectToPool);
            pool.Add(tempObject);
            return tempObject;
        }
        //uh, no available bullet in our pooling system was found or created. sorry.
        return null;
    }
}
