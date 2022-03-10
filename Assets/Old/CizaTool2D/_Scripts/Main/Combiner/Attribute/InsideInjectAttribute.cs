using System;

namespace CizaTool2D.Combiner
{
    public class InsideInjectAttribute : Attribute
    {
        public string GameObjectName { get; }

        public InsideInjectAttribute(string gameObjectName) {
            GameObjectName = gameObjectName;
        }
    }
}
