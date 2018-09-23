using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTurret()
    {
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SetTurretToBuild(buildManager.missileLauncherPrefab);
    }
}
