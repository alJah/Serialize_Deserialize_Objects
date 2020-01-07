using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Serializes, deserializes objects like Array, List <>, Dictionary <,>, Tuple, etc.
/// </summary>
public static class OpenSaveObject
{

    /// <summary>
    /// Save object to file.
    /// </summary>
    /// <param name="fName"></param>
    /// <param name="objToSerialize"></param>
    public static void Serialize(string fName, object objToSerialize)
    {
        try
        {
            using (FileStream fileStream = new FileStream(fName, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, objToSerialize);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
    }
    /// <summary>
    /// Open an object from a file.
    /// </summary>
    /// <returns></returns>
    public static object Deserializea(string fileName)
    {
        object myObject;

        using (FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            myObject = binaryFormatter.Deserialize(fileStream);
        }

        return myObject;
    }
}
