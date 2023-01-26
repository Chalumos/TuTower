using UnityEngine;
 
public class BuildManager : MonoBehaviour
{

    //On fait on singleton pour pas avoir bcp de reference avec tout les terrains
    #region Singleton
    private static BuildManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Un build manager existe déjà dans la scene");
            return;
        }
        instance = this;
    }
    #endregion

    //Tourelle de base
    public GameObject standardTurretPrefab;

    //Tourelle que on veut construire
    private GameObject turretToBuild;

    public GameObject getTurretToBuild()
    {
        return turretToBuild;
    }

    public static BuildManager getInstance()
    {
        return instance;
    }

    public void setTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

}
