using System;
using System.Collections.Generic;
using System.Text;

namespace GDIC
{
    public class ServiceCollection
    {
        private readonly Dictionary<Type, ServiceModel> services;
        public ServiceCollection()
        {
            services = new Dictionary<Type, ServiceModel>();
        }

        //public void AddTransiant<TService>()
        //{
        //    services.Add(typeof(TService), new ServiceModel(ServiceType.Transiant, typeof(TService)));
        //}

        //public void AddTransiant<TService,TImplementation>()
        //{
        //    services.Add(typeof(TService), new ServiceModel(ServiceType.Transiant, typeof(TImplementation)));
        //}

        public void AddSingelton(object o)
        {
            services.Add(o.GetType(), new ServiceModel(o, ServiceType.Singeltone, o.GetType()));
        }

        public Tservice GetService<Tservice>() => (Tservice)services[typeof(Tservice)].Get;

    }
    enum ServiceType
    {
        Singeltone,
        Transiant,
        Binded
    }
    class ServiceModel
    {
        public object Get { get => Service; }
        readonly object Service;
        readonly ServiceType Type;
        readonly Type ServiceType;
        readonly object BindedObject;
        public ServiceModel(object service, ServiceType type, Type objType, object bind = null)
        {
            Service = service;
            Type = type;
            ServiceType = objType;
            BindedObject = bind;
        }
        public ServiceModel(ServiceType type, Type objType, object bind = null)
        {
            Service = null;
            Type = type;
            ServiceType = objType;
            BindedObject = bind;
        }
    }
}
