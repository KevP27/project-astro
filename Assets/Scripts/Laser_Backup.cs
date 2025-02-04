using UnityEngine;

public class Laser_Backup : MonoBehaviour
{
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer lineRender;
    Transform transform1;

    /*
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    */

    private void Awake()
    {
        transform1 = GetComponent<Transform>();
    }

    public void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if(Physics2D.Raycast(transform1.position, transform.right))
        {
            RaycastHit2D _hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            Draw2DRay(laserFirePoint.position, _hit.point);
        }

        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
        lineRender.SetPosition(0, startPos);
        lineRender.SetPosition(1, endPos);
    }
}
