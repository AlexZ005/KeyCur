using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Net;

public static class StringExt
{
    public static string ToLiteral(this string input)
    {
        using (var writer = new StringWriter())
        {
            using (var provider = CodeDomProvider.CreateProvider("CSharp"))
            {
                provider.GenerateCodeFromExpression(new CodePrimitiveExpression(input), writer, null);
                return writer.ToString();
            }
        }
    }
}

public static class Util
{
    public static string HttpGetRequest(string url)
    {
        try
        {
            HttpWebRequest hreq = (HttpWebRequest)WebRequest.Create(url);
            hreq.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:21.0) Gecko/20100101 Firefox/21.0";
            hreq.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            hreq.Headers.Add("Accept-Language", "en-US,en;q=0.5");
            hreq.KeepAlive = true;
            hreq.Method = "GET";

            using (HttpWebResponse resp = (HttpWebResponse)hreq.GetResponse())
            {
                using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        catch (Exception)
        {
            return null;
        }
    }

    #region JSON Serializer & Deserializer

    /// <summary>
    /// Deserialize JSON string
    /// </summary>
    /// <typeparam name="T">Expected class Type</typeparam>
    /// <param name="json">JSON data</param>
    /// <returns>Instance of the deserialized class or null if unable to deserialize</returns>
    public static T DeserializeJSON<T>(string json)
    {
        try
        {
            //JSON deserializer takes a stream as input
            byte[] data = Encoding.Unicode.GetBytes(json);
            using (MemoryStream stream = new MemoryStream(data))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                //deserialize and return the object of type T
                return (T)serializer.ReadObject(stream);
            }
        }
        catch
        {
            //return the default T if deserialization fails
            return default(T);
        }
    }

    /// <summary>
    /// Serialize an object as JSON string
    /// </summary>
    /// <param name="instance">the object to be serialized</param>
    /// <returns>serialized JSON data</returns>
    public static string SerializeJSON(object instance)
    {
        //need a stream because json serializer requires a stream to write on
        using (MemoryStream stream = new MemoryStream())
        {
            //create an instance of json serializer
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(instance.GetType());
            //serialize the object and write json data to memory stream
            serializer.WriteObject(stream, instance);
            //move the stream read cursor to the begining
            stream.Position = 0;
            //create a stream reader to get the json data as string
            using (StreamReader reader = new StreamReader(stream))
            {
                //read and return json data
                return reader.ReadToEnd();
            }
        }
    }

    #endregion
}
