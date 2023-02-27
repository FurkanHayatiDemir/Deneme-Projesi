using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Green : MonoBehaviour
{
    public int counter=0;

    private void OnTriggerEnter2D(Collider2D collision)
    {

         if (collision.gameObject.tag == "green")
         {
            counter++;
            Debug.Log("Green Collider");
 
         }

        if (counter > 1)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("green");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy.transform.parent.gameObject);
            RandomCube.instance.AddPoint();
            Debug.Log("3 yeþil küp birbirine deðdi");
        }
    }
}
