using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour {

    public int speed;

    private Rect bounds;

    private void Start() {
        initBounds();
    }

    // Update is called once per frame
    void Update () {
        Move();
	}

    void Move() {
        Vector3 movement = Vector3.zero;
        movement += Input.GetAxisRaw("Horizontal") * Vector3.right;
        movement += Input.GetAxisRaw("Vertical") * Vector3.up;
        transform.Translate(movement * speed * Time.deltaTime);
        ClampPosition();
    }

    void initBounds(){
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ScreenToWorldPoint(Vector3.zero);
        bottomLeft += new Vector3(1, 1, 0);
        Vector3 topRight = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        topRight -= new Vector3(1, 1, 0);
        bounds = new Rect(bottomLeft, topRight - bottomLeft);
    }

    //Verify if spaceship is in camera view border
    private void ClampPosition(){
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, bounds.xMin, bounds.xMax);
        pos.y = Mathf.Clamp(pos.y, bounds.yMin, bounds.yMax);
        transform.position = pos;
    }

    private void OnDrawGizmos() {
        GizmoUtils.DrawRect(bounds, Color.green);
    }
}
