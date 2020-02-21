﻿using System;
using FaceitAPI.Interfaces;

namespace FaceitAPI.Types
{
    public class Faceit : SimpleContainer<ApiBase>
    {
        public IAuthorizable Authorizable;

        public Faceit(IAuthorizable authorizable)
        {
            Authorizable = authorizable ?? throw new ArgumentException($"IAuthorizable authorizable on {GetType().FullName} cannot be null");
        }

        public T GetObject<T>() where T : ApiBase
        {
            if (Exist<T>()) return Get<T, T>();

            ApiBase instance = (ApiBase) Activator.CreateInstance(typeof(T), Authorizable);

            RegisterObject<T>(instance);
            return (T) instance;
        }

        public T GetObject<T>(IResponse response) where T : ApiBase
        {
            T obj = GetObject<T>();
            obj.Response = response;

            return obj;
        }

        public T GetObject<T>(IHttpClient http) where T : ApiBase
        {
            T obj = GetObject<T>();
            obj.HttpClient = http;

            return obj;
        }

        public T GetObject<T>(IResponse response = null, IHttpClient http = null, IJsonDeserializer deserializer = null) where T : ApiBase
        {
            if (Exist<T>()) UnregisterObject<T>();

            ApiBase api = GetObject<T>();

            if (response != null) api.Response = response;
            if (http != null) api.HttpClient = http;
            if (deserializer != null) api.Deserializer = deserializer;

            return (T) api;
        }

        public void Set<T>(T t) where T : ApiBase
        {
            base.Set<T>(t);
        }

        public void DestroyObject<T>()
        {
            UnregisterObject<T>();
        }
    }
}