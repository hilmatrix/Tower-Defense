using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private float _scale;
    private float _alpha;
    private SpriteRenderer image;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    public float change = 0.1f;
    public float size = 1f;

    // Start is called before the first frame update
    void Start()
    {
        ResetExplosion();
        image = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time > nextActionTime) && (_alpha > 0)) {
            transform.localScale = new Vector3(Mathf.Sqrt(_scale), Mathf.Sqrt(_scale), Mathf.Sqrt(_scale));
            image.color = new Color(1, 1, 1, Mathf.Sqrt(_alpha));
            _scale += change*size;
            _alpha -= change;

            nextActionTime = Time.time + period;
        }
        else if (_alpha <= 0) {
            gameObject.SetActive(false);
        }
    }

    public void ResetExplosion() {
        _scale = 0;
        _alpha = 1f;
    }
}
