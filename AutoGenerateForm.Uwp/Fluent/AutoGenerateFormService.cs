using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private AutoGenerateFormService()
        {

        }

        public static EntityConfiguration<T> ForEntity<T>()
            where T : class, new()
        {
            var entity = new EntityConfiguration<T>();
            return entity;
        }

        
    }
}
