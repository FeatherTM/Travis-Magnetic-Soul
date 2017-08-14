using UnityEngine;

public class quickImp : MonoBehaviour {
        //Values for the explosion force will have to be severaly changed
        public float force = 10f;
        [Header("Radius center")]
        public GameObject mobj;
        [Space]
        public Camera Cam;
        [SerializeField]
        float range = 10f;
        public float radius = 20f;
        public float Up = 0.00001f;
        Vector3 explosion;
        RaycastHit hit;

        private void FixedUpdate() {
        Empuje();
        Debug.DrawRay(Cam.transform.position, Cam.transform.forward * range, Color.red);
        
        }

        void Empuje() { //The origin of the explosion is going to be the position of another game object (Invisible and aligned with the ray and the camera view)
        explosion = Cam.transform.position;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range)) {
                Rigidbody Rig = hit.rigidbody;
            
            if (Input.GetKey(KeyCode.R) && hit.collider.tag == "Pene") {
                    Rig.AddExplosionForce(force, explosion, radius, Up, ForceMode.Impulse);
                }
            }
        }
    }
