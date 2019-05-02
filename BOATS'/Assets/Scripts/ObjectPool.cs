using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPool : MonoBehaviour
{
    //make a reference for this. 
    public GameObject gameObj;

    public List<GameObject> AvailableObjects;
    public List<GameObject> ActiveObjects;
    int MaxNumObjects = 0;
    int growthFactor = 10;

    void Start()
    {
        AvailableObjects = new List<GameObject>();
        ActiveObjects = new List<GameObject>();
    }

    public GameObject GetAvailableObject()
    {
        //if theres not enough to get an additional gameobject, make more. 
        //check the max num objects available
        for (int i = 0; i < AvailableObjects.Count - 1; i++)
        {
            if (AvailableObjects[i] != null)
            {
                GameObject temp = AvailableObjects[i];
                temp.SetActive(true);
                if(temp.GetComponent<Rigidbody>() == true)
                {
                    temp.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                ActiveObjects.Add(temp);
                AvailableObjects.Remove(temp);
                return temp;
            }
        }
        //if there is none available, this code will activate
        AllocateMoreGameObjects();

        //then try  to get an available one again
        return GetAvailableObject();
    }

    public void DeactivateObject(GameObject obj)
    {
        //if there's room to add an object to the pool, add it back to available.
        if(AvailableObjects.Count < MaxNumObjects)
        {
            if (obj.GetComponent<Rigidbody>() == true)
            {
                obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            obj.SetActive(false);
            AvailableObjects.Add(obj);
            ActiveObjects.Remove(obj);
        }
    }

    public void AllocateMoreGameObjects()
    {
        MaxNumObjects += growthFactor;
        for(int i = 0; i<growthFactor - 1; i++)
        {
            GameObject temp;
            temp = Instantiate(gameObj);
            if (temp.GetComponent<Rigidbody>() == true)
            {
                temp.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            temp.SetActive(false);
            AvailableObjects.Add(temp);
        }
    }
}
