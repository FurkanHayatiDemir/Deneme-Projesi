using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Blue : MonoBehaviour
{
    public int counter = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "blue")
        {
            counter++;
            Debug.Log("Blue Collider");

        }

        if (counter > 1)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("blue");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy.transform.parent.gameObject);
            RandomCube.instance.AddPoint();
            Debug.Log("3 mavi küp birbirine deðdi");
        }
    }
}
