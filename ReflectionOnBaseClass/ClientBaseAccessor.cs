using System;
using System.Collections.Generic;
using System.Text;

namespace ReflectionOnBaseClass
{
    public abstract class ClientBaseAccessor
    {
        public static ClientBaseAccessor CreateAccessor<TClient>(TClient client)
        {
            var clientBaseType = GetClientBaseType(typeof(TClient));

            if (clientBaseType == null)
            {
                throw new InvalidOperationException($"{typeof(TClient)} does not inherit from ClientBase<T>.");
            }

            var interfaceType = clientBaseType.GenericTypeArguments[0];
            var accessorTypeGeneric = typeof(ClientBaseAccessor<,>);
            var accessType = accessorTypeGeneric.MakeGenericType(typeof(TClient), interfaceType);

            return (ClientBaseAccessor)Activator.CreateInstance(accessType, client);
        }


        static Type GetClientBaseType(Type clientType)
        {
            var baseType = clientType.BaseType;
            while (baseType != null && baseType != typeof(object))
            {
                if (baseType.IsGenericType && baseType.IsConstructedGenericType)
                {
                    var typeDefinition = baseType.GetGenericTypeDefinition();
                    if (typeDefinition == typeof(ClientBase<>))
                    {
                        break;
                    }
                }

                baseType = baseType.BaseType;
            }

            return baseType;
        }


        public string EndPointA => GetEndpointA();

        public string EndPointB => GetEndPointB();

        protected abstract string GetEndpointA();

        protected abstract string GetEndPointB();
    }


    public class ClientBaseAccessor<TClient, TInterface> : ClientBaseAccessor where TClient : ClientBase<TInterface>
    {
        public ClientBaseAccessor(TClient client)
        {
            _client = client;
        }

        protected override string GetEndpointA()
        {
            return _client.EndPointA;
        }

        protected override string GetEndPointB()
        {
            return _client.EndPointB;
        }

        TClient _client;

    }
}
