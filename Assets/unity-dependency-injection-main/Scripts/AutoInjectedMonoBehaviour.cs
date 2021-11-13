using UnityEngine;

namespace LongBunnyLabs.DependencyInjection
{
  public class AutoInjectedMonoBehaviour : MonoBehaviour
  {
    [Inject ("Other")] private GameObject _gameObject;
    virtual protected void Start()
    {
      Injector.Injecting(this);
    }
  }
}

