using UnityEngine;

public class CameraController : MonoBehaviour
{
    // vitesse de la camera
    public float panSpeed = 30f;

    public float scrollSpeed = 5f;

    public float panBorder = 10f;

    private bool canMove = true;

    // limite zoom/dezoome camera
    public float minY = 10f;
    public float maxY = 80f;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            canMove = !canMove;
        }

        if (!canMove)
        {
            return;
        }

        // déplacement vers l'avant
        if (Input.GetKey(KeyCode.Z) || Input.mousePosition.y >= Screen.height - panBorder)
        {
            // Space.World pour se deplacer selon les axes x,y,z du monde et pas de la camera
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

        // déplacement vers l'arrière
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <=  panBorder)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        // déplacement vers la droite
        if (Input.GetKey(KeyCode.Q) || Input.mousePosition.x <=  panBorder)
        { 
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

        // déplacement vers la gauche
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorder)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 position = transform.position;
        // 1000 car pas assez sensible sinon
        position.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        position.y =  Mathf.Clamp(position.y, minY, maxY);
        transform.position = position;
    }
}
