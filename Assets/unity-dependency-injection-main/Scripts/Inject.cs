using System;

namespace LongBunnyLabs.DependencyInjection
{
  [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
  public class Inject : Attribute
  {
    public string GameObjectName { get; } = "";

    public Inject(string gameObjectName = "")
    {
      GameObjectName = gameObjectName;
    }
  }
}

