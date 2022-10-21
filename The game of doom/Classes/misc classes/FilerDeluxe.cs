using System.Runtime.Serialization.Formatters.Binary;
using NativeFileDialogSharp;
using The_game_of_doom.Classes.Game_classes;

#pragma warning disable SYSLIB0011

namespace The_game_of_doom.Classes.misc_classes
{
    /// <summary>
    /// Functions for performing common binary Serialization operations.
    /// <para>All properties and variables will be serialized.</para>
    /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
    /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
    /// </summary>
    internal static class BinarySerialization
    {
        /// <summary>
        /// Writes the given object instance to a binary file.
        /// <para>Object type (and all child types) must be decorated with the [Serializable] attribute.</para>
        /// <para>To prevent a variable from being serialized, decorate it with the [NonSerialized] attribute; cannot be applied to properties.</para>
        /// </summary>
        /// <typeparam name="T">The type of object being written to the BinaryFile file.</typeparam>
        /// <param name="filePath">The file path to write the object instance to.</param>
        /// <param name="objectToWrite">The object instance to write to the XML file.</param>
        /// <param name="append">If false the file will be overwritten if it already exists. If true the contents will be appended to the file.</param>
        private static void WriteToBinaryFile<T>(string filePath, T objectToWrite, bool append = false)
        {
            using Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create);
            BinaryFormatter binaryFormatter = new();
            binaryFormatter.Serialize(stream, objectToWrite!);
        }

        /// <summary>
        /// Reads an object instance from a binary file.
        /// </summary>
        /// <typeparam name="T">The type of object to read from the Binary file.</typeparam>
        /// <param name="filePath">The file path to read the object instance from.</param>
        /// <returns>Returns a new instance of the object read from the Binary file.</returns>
        private static T ReadFromBinaryFile<T>(string filePath)
        {
            using Stream stream = File.Open(filePath, FileMode.Open);
            BinaryFormatter binaryFormatter = new();
            return (T)binaryFormatter.Deserialize(stream);
        }

        public static void SaveGame(Game? game)
        {
            string fileName = Asker.ForceInput(
                "Enter a name for the save file: ");

            BinarySerialization.WriteToBinaryFile(Directory.GetCurrentDirectory() + "\\saves\\" + fileName + ".yes", game);
        }

        public static Game LoadGame()
        {
            DialogResult dialogResult;

            do
                dialogResult = Dialog.FileOpen(null, Directory.GetCurrentDirectory() + "\\saves");
            while (dialogResult.IsCancelled);

            string filePath = dialogResult.Path!;
            Game game = BinarySerialization.ReadFromBinaryFile<Game>(filePath);

            return game;
        }
    }
}