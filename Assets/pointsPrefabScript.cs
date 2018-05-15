using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointsPrefabScript : MonoBehaviour {

    public float lifeTime;
    public float speed;

    private float timer;

    private void Update()
    {
        if (timer >= lifeTime)
            Destroy(this.gameObject);

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y + speed * Time.deltaTime, transform.localPosition.z);

        transform.LookAt(Camera.main.transform);

        timer += Time.deltaTime;
    }
}
