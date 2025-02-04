using Invector.vCharacterController;
using UnityEngine;

public class Grappling : MonoBehaviour
{

    [Header("References")]
    public Transform cam;
    public Transform gunTip;
    public LayerMask whatIsGrappleable;
    public LineRenderer lr;

    [Header("Grappling")]
    public float maxGrappleDistance;
    public float grappleDelayTime;
    public float overshootYAxis;

    private Vector3 grapplePoint;

    [Header("Cooldown")]
    public float grapplingCd;
    private float grapplingCdTimer;

    [Header("Input")]
    public KeyCode grapplingKey = KeyCode.Mouse1;

    public bool grappling;

    private PlayerMovementGrappling pm;
    private ElementController elcontroller;
    private GameObject players;
    GameObject player;

    private int[] elements;
    private int elementSlot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pm = GetComponent<PlayerMovementGrappling>();
        players = GameObject.FindGameObjectWithTag("Players");
        elcontroller = players.GetComponent<ElementController>();
    }

    private void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (Input.GetKeyDown(grapplingKey)) StartGrapple();

        if (grapplingCdTimer > 0)
        {
            grapplingCdTimer -= Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        if (grappling)
        {
            lr.SetPosition(0, gunTip.position);
        }
    }

    private void StartGrapple()
    {
        
      
        if (grapplingCdTimer > 0 || !elcontroller.grappleFound || !elcontroller.grappleActive) return;

        player.GetComponent<Animator>().SetTrigger("Slash");
        

        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, maxGrappleDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;

            Invoke(nameof(ExecuteGrapple), grappleDelayTime);
        } else
        {
            grapplePoint = cam.position + cam.forward * maxGrappleDistance;

            Invoke(nameof(StopGrapple), grappleDelayTime + 1);
        }

        Invoke(nameof(DelaySring), grappleDelayTime);
        

    }

    private void ExecuteGrapple()
    {

        Vector3 lowestPoint = new Vector3 (transform.position.x, transform.position.y - 1f, transform.position.z);
        
        float grapplePointRelativeYPos = grapplePoint.y - lowestPoint.y;
        float highestPointOnArc = grapplePointRelativeYPos + overshootYAxis;

        if (grapplePointRelativeYPos < 0) highestPointOnArc = overshootYAxis;

        pm.JumpToPosition(grapplePoint, highestPointOnArc);

        Invoke(nameof(StopGrapple), 2f);
    }

    public void StopGrapple()
    {
        grappling = false;

        grapplingCdTimer = grapplingCd;

        lr.enabled = false;
    }

    private void DelaySring()
    {
        grappling = true;
        lr.enabled = true;
        lr.SetPosition(1, grapplePoint);
    }

}
