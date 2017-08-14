using UnityEngine;
/// Permite sujetar un objeto presionando el boton derecho del mouse
public class MouseGrab : MonoBehaviour {

#region
    [SerializeField]
    private GameObject Cam;
    [SerializeField]
    private bool carrying;
    [Header ("Object that we're gonna move")]
    public GameObject carriedObject;
    [SerializeField]
    private float range = 10f;
    public float smooth = 6f;
    [SerializeField]
    private float distance = 5f;
    #endregion
    private void Start() {
        Cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    private void FixedUpdate() {
        
        if (carrying) {
            Carry(carriedObject);
            ZMove();
            Drop();
        }
        else {
            Pickup();
        }
        Force();
        
    }
    void Carry(GameObject obj) {

        obj.GetComponent<Rigidbody>().useGravity = false;
        Rigidbody rig = obj.GetComponent<Rigidbody>();
        
        obj.transform.position = Vector3.Lerp(obj.transform.position, Cam.transform.position + Cam.transform.forward * distance, Time.fixedDeltaTime * smooth);
    }
    void Pickup() {
        if (Input.GetMouseButtonDown(1)) {
            #region
            int x = Screen.width / 2;
            int y = Screen.height / 2;
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(x, y));
            RaycastHit hit;
#endregion
            if (Physics.Raycast(ray, out hit, range)) {
                if (hit.collider.tag == "Pene") {
                    carrying = true;
                    carriedObject = hit.collider.gameObject;
                }
            }
        }
    }
    void Drop() {
        if (Input.GetMouseButtonUp(1)) {
            carrying = false;
            distance = 5f;
            carriedObject.GetComponent<Rigidbody>().useGravity = true;
            carriedObject = null;
        }
    }
    void Force() {
        if (carrying == true && Input.GetMouseButtonDown(0)) {
            float expforce = 102f; float upforce = 3f;
            carriedObject.GetComponent<Rigidbody>().AddExplosionForce(expforce, Cam.transform.position, expforce -= 4, upforce, ForceMode.Impulse);
            distance = 5f;
            carriedObject.GetComponent<Rigidbody>().useGravity = true;
            carriedObject = null;
            carrying = false;
        }
    }
    void ZMove() {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            distance += 0.2f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            distance -= 0.2f;
        }

    }
}
