using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Storage
{
    private string _filePath;
    private BinaryFormatter _formatter;

    public Storage()
    {
        var directory = Application.persistentDataPath + "/saves";

        if (!Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        _filePath = directory + "/GameSave.save";
        InitializeBinaryFormatter();
    }

    public object Load(object saveDataByDefault)
    {
        if (!File.Exists(_filePath))
        {
            if (saveDataByDefault != null)
            {
                Save(saveDataByDefault);
            }
            return saveDataByDefault;
        }

        var file = File.Open(_filePath, FileMode.Open);
        var savedData = _formatter.Deserialize(file);
        file.Close();

        return savedData;
    }

    public void Save(object saveData)
    {
        var file = File.Create(_filePath);
        _formatter.Serialize(file, saveData);
        file.Close();
    }    

    private void InitializeBinaryFormatter()
    {
        _formatter = new BinaryFormatter();
        var selector = new SurrogateSelector();

        //here Serialization Surrogates init 

        //here Serialization Surrogates add to selector

        _formatter.SurrogateSelector = selector;
    }
}