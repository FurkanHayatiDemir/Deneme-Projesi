using UnityEngine;

public class Grabber : MonoBehaviour
{
    private GameObject selectedObject;
    void Update()
    {
        if(Input.GetMouseButton(0))//mouse'un sol d��mesine t�kland���da
        {
            if(selectedObject==null)
            {
                RaycastHit hit = CastRay(); //raycasti �a��r

                if (hit.collider != null)//collider'e de�di�inde 
                {
                    if(!hit.collider.CompareTag("drag"))
                    {
                        return; //collider'a de�ip de�medi�ini s�rekli kontrol ediyor
                    }

                    selectedObject = hit.collider.gameObject;
                }
            }
            else
            {
                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);//objeyi s�r�kleyece�im yer i�in yeni bir vector3 olu�turdum
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position); //d�nya konumuna e�itlendi
                selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0.01f); //z ekseni sabit x ve y'yi t�klad���m�zda de�i�tirebilmeliyiz

                selectedObject = null;
            }
        }

        if(selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);//objeyi s�r�kleyece�im yer i�in yeni bir vector3 olu�turdum
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position); //d�nya konumuna e�itlendi
            selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0f); //z ekseni sabit x ve y'yi t�klad���m�zda de�i�tirebilmeliyiz
        }
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3( //uzakl�k ve yak�nl�k i�in vector 3 olu�turuyoruz
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);

        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar); //vekt�rleri d�nya konumuna e�itledik
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit); //raycast hit

        return hit;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "poligon") //poligona de�di�imizi kontrol etme
        {
            Debug.Log("Poligon Collider");
        }
    }
}
