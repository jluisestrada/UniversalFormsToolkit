using AutoGenerateForm.Uwp.Fluent;
using System;
using System.Collections.Generic;

namespace AutoGenerateForm.Uwp
{
    public class AutoGenerateFormService
    {

        private static AutoGenerateFormService _instance;
        private AutoGenerateFormService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AutoGenerateFormService();
                }

                return _instance;
            }
        }

        private Dictionary<Type, EntityBag> _entities;

        private AutoGenerateFormService()
        {
            _entities = new Dictionary<Type, EntityBag>();
        }

        public static EntityConfiguration<T> ForEntity<T>()
            where T : class, new()
        {
            var entity = TryAddEntity<T>();
            return entity;
        }

        private static EntityConfiguration<T> TryAddEntity<T>() where T : new()
        {
            var type = typeof(T);
            if (_instance._entities.ContainsKey(type))
            {
                throw new ArgumentException($"Entity { type.Name } is already defined.");
            }
            var bag = new EntityBag();

            _instance._entities.Add(type, bag);

            return new EntityConfiguration<T>(bag);
        }
    }
}
