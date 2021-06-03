using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FortnoxNET.Utils
{
    // NOTE(Oskar): We are working this class away. It will become obsolete in future versions.
    public class CustomJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            try
            {
                var jo = new JObject();
                
                foreach (var prop in value.GetType().GetProperties())
                {
                    if (prop.CanRead)
                    {
                        var propValue = prop.GetValue(value);
                        
                        if (propValue != null)
                        {
                            var propertyTypeAttributes = prop.PropertyType.GetCustomAttributes(true);
                            var addedProperty = false;
                            
                            if (propertyTypeAttributes.Length > 0)
                            {
                                foreach (var attr in propertyTypeAttributes)
                                {
                                    if (!(attr is JsonPropertyClassAttribute authAttr))
                                    {
                                        continue;
                                    }

                                    jo.Add(authAttr.JsonPropertyName, JToken.FromObject(propValue, serializer));
                                    addedProperty = true;
                                }
                            }
                            
                            var attrs = prop.GetCustomAttributes(true);
                            var ignoreProperty = false;
                                
                            foreach (var attr in attrs)
                            {
                                if (!(attr is JsonReadOnlyAttribute))
                                {
                                    continue;
                                }

                                ignoreProperty = true;
                            }
                            
                            if (addedProperty == false && ignoreProperty == false)
                            {
                                jo.Add(prop.Name, JToken.FromObject(propValue, serializer));
                            }
                        }
                    }
                }
                
                jo.WriteTo(writer);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var instance = Activator.CreateInstance(objectType);
            var props = objectType.GetTypeInfo().GetAllProperties().ToList();
            var jo = JObject.Load(reader);
            
            foreach (var jp in jo.Properties())
            {
                var prop = props.FirstOrDefault(pi => pi.CanWrite && pi.Name == jp.Name);

                if (prop != null)
                {
                    prop?.SetValue(instance, jp.Value.ToObject(prop.PropertyType, serializer));
                }
                
                prop = props.FirstOrDefault(pi => pi.CanWrite && pi.Name == "Data");
                var args = prop?.PropertyType.GetGenericArguments();

                if (args != null && args.Any())
                {
                    var type = args[0];
                    
                    var attrs = type.GetCustomAttributes(true);
                
                    if (attrs.Length > 0)
                    {
                        foreach (var attr in attrs)
                        {
                            if (!(attr is JsonPropertyClassAttribute authAttr) || jp.Name != authAttr.JsonPropertyName)
                            {
                                continue;
                            }

                            prop?.SetValue(instance, jp.Value.ToObject(prop.PropertyType, serializer));
                        }
                    }
                }
                else
                {
                    prop?.SetValue(instance, jp.Value.ToObject(prop.PropertyType, serializer));
                }
            }
            
            return instance;
        }
        
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetTypeInfo().IsClass;
        }
    }
}