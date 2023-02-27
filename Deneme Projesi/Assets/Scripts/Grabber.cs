using UnityEngine;

public class Grabber : MonoBehaviour
{
    private GameObject selectedObject;
    void Update()
    {
        if(Input.GetMouseButton(0))//mouse'un sol düðmesine týklandýðýda
        {
            if(selectedObject==null)
            {
                RaycastHit hit = CastRay(); //raycasti çaðýr

                if (hit.collider != null)//collider'e deðdiðinde 
                {
                    if(!hit.collider.CompareTag("drag"))
                    {
                        return; //collider'a deðip deðmediðini sürekli kontrol ediyor
                    }

                    selectedObject = hit.collider.gameObject;
                }
            }
            else
            {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);//objeyi sürükleyeceðim yer için yeni bir vector3 oluþturdum
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position); //dünya konumuna eþitlendi
                selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0.01f); //z ekseni sabit x ve y'yi týkladýðýmýzda deðiþtirebilmeliyiz

                selectedObject = null;
            }
        }

        if(selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);//objeyi sürükleyeceðim yer için yeni bir vector3 oluþturdum
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position); //dünya konumuna eþitlendi
            selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0f); //z ekseni sabit x ve y'yi týkladýðýmýzda deðiþtirebilmeliyiz
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3( //uzaklýk ve yakýnlýk için vector 3 oluþturuyoruz
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);

        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar); //vektörleri dünya konumuna eþitledik
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit); //raycast hit

        return hit;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "poligon") //poligona deðdiðimizi kontrol etme
        {
            Debug.Log("Poligon Collider");
        }
    }
}
