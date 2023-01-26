using UnityEngine;

public class Shop : MonoBehaviour
{
    private BuildManager buildManager;

    public void Start()
    {
        buildManager = BuildManager.getInstance();
    }
    public void PurchasseStandardTurret()
    {
        buildManager.setTurretToBuild(buildManager.standardTurretPrefab);
    }
}
