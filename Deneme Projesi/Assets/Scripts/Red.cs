using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    public int counter = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "red")
        {
            counter++; //e�er collider'e de�erse counter'� 1 artt�r
            Debug.Log("Red Collider");

        }

        if (counter > 1) //counter 1'den b�y�k m�? =2
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("red");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy.transform.parent.gameObject); //counter 2 olunca silmek
            RandomCube.instance.AddPoint();
            Debug.Log("3 k�rm�z� k�p birbirine de�di");
        }
    }
}
