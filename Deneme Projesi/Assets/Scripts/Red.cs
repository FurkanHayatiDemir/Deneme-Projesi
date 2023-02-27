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
            counter++; //eðer collider'e deðerse counter'ý 1 arttýr
            Debug.Log("Red Collider");

        }

        if (counter > 1) //counter 1'den büyük mü? =2
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("red");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy.transform.parent.gameObject); //counter 2 olunca silmek
            RandomCube.instance.AddPoint();
            Debug.Log("3 kýrmýzý küp birbirine deðdi");
        }
    }
}
