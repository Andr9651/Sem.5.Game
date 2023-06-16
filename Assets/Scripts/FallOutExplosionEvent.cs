using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
class FallOutExplosionEvent : FallOutStrategy
{
    public ParticleSystem Explosion;
    public float Delay = 2;
    public UnityEvent Event;
    public override IEnumerator HandleFallout(GameObject gameObject)
    {
        var explosion = Instantiate(Explosion, gameObject.transform.position, Quaternion.identity);
        explosion.Play();
        Destroy(explosion.gameObject, Delay);
        
        gameObject.SetActive(false);
        var mainCamera = gameObject.GetComponentInChildren<Camera>().gameObject;
        var tempCamera = Instantiate(mainCamera, mainCamera.transform.position, mainCamera.transform.rotation);
        
        yield return new WaitForSeconds(Delay);
        Event.Invoke();
    }
}