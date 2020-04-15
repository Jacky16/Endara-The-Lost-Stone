using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Caja : MonoBehaviour
{
    [SerializeField] 
    GameObject prefabBoxDestroyed;

    [SerializeField]
    float _explosionForce;

    [SerializeField]
    AudioClip[] _audiosDestroyBox;

    [SerializeField]
    float _explosionRadius;

    AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cola"))
        {
            Explosion();
        }
    }
    void Explosion()
    {
        GameObject go = Instantiate(prefabBoxDestroyed, transform.position, transform.rotation) as GameObject;
        Rigidbody[] rb = go.GetComponentsInChildren<Rigidbody>();
        _audioSource.PlayOneShot(AudioClipRandom());
        _audioSource.DOFade(0, AudioClipRandom().length);
        Destroy(go, 2);
        foreach (Rigidbody r in rb)
        {
            r.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        Destroy(this.gameObject,1.5f);
    }
    AudioClip AudioClipRandom()
    {
        return _audiosDestroyBox[Random.Range(0, _audiosDestroyBox.Length)];
    }
}
