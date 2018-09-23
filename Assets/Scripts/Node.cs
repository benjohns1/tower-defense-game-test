using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color errorColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer rend;
    private Color originalColor;

    private BuildManager buildManager;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("Can't build");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        if (turretToBuild == null)
        {
            return;
        }
        turret = Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (buildManager.GetTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = turret ? errorColor : hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = originalColor;
    }
}
