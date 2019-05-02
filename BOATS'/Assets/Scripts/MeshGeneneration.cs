using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGeneneration : MonoBehaviour {

    public GameObject objectToFollow;
    public GameObject water;
    public List<GameObject> waterPieces;

    public int width = 10;
    public int height = 10;

	void Start ()
    {
        //create an idex of the grid to start at
        int index = 0;
        //need to make 9 tiles of the BG and create the grid
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                //add the piece to the list
                GameObject temp = Instantiate(water);
                waterPieces.Add(temp);

                //give out positions to form a 3x3 grid
                float xPlane = (i * temp.GetComponent<MeshRenderer>().bounds.size.z) + temp.transform.position.z;
                float zPlane = (j * temp.GetComponent<MeshRenderer>().bounds.size.x) + temp.transform.position.x;
                waterPieces[index].transform.position = new Vector3(xPlane, water.transform.position.y, zPlane);
                waterPieces[index].transform.parent = objectToFollow.transform;
                index++;
            }
        }
        water.SetActive(false);
    }
}
