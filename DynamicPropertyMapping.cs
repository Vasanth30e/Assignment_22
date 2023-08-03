using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_22
{
    public class DynamicPropertyMapping
    {
        public void MapProperties(Source source, Destination destination)
        {
            Type sourceType = source.GetType();
            Type destinationType = destination.GetType();

            PropertyInfo[] sourcePropertyInfo = sourceType.GetProperties();
            PropertyInfo[] destinationPropertyInfos = destinationType.GetProperties();

            foreach(PropertyInfo sourceProp in sourcePropertyInfo)
            {
                PropertyInfo destinationProp = Array.Find(destinationPropertyInfos, prop => prop.Name == sourceProp.Name);
                if(destinationProp != null && destinationProp.PropertyType == sourceProp.PropertyType)
                {
                    destinationProp.SetValue(destination, sourceProp.GetValue(source));
                }
            }
        }


    }
}
