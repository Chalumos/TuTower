using UnityEngine;
using UnityEngine.EventSystems;

public class terrain : MonoBehaviour
{
    //Couleur de base du terrain
    private Color startColor;

    //Couleur lors du passage sur le terrain
    public Color hoverColor;

    //Tourelle sur le terrain
    private GameObject turret;

    //Compensation pour bonne affichage tourelle en y
    public Vector3 positionOffset;

    // moteur de rendu 3d
    private Renderer rend;

    private BuildManager buildManager;



    private void Start()
    {
        rend = GetComponent<Renderer>();

        //On recupere la couleur de base du terrain
        startColor = rend.material.color;

        buildManager = BuildManager.getInstance();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.getTurretToBuild() == null)
        {
            return;
        }

        if (turret != null)
        {
            Debug.Log("Impossible de construire une tourelle ici, il y'en a déjà une");
            return;
        }

        //Construction tourelle
        GameObject turretToBuild = buildManager.getTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    //Changer la couleur lors du passage de la souris
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (buildManager.getTurretToBuild() == null)
        {
            return;
        }

        rend.material.color = hoverColor;
    }

    //Revenir couleur par defaut apres plus souris su terrain
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
