using System.IO;

namespace PasswordManger
{
    internal static class FileByteStuff
    {
        private static byte[] FileToByteArray(string path)
        {
            var stream = File.OpenRead(path);
            var fileBytes = new byte[stream.Length];

            stream.Read(fileBytes, 0, fileBytes.Length);
            stream.Close();

            return fileBytes;
        }

        private static void WriteByteArrayToFile(string filePath, byte[] bytes)
        {
            File.Create(filePath).Dispose();

            using Stream file = File.OpenWrite(filePath);
            file.Write(bytes, 0, bytes.Length);
        }


        public static void EncryptFile(string path)
        {
            var bytes = FileToByteArray(path);
            var encryptedFilePath = Directory.GetCurrentDirectory() + @"\data.jpg";

            for (var i = 0; i < bytes.Length; i++) bytes[i] += (byte) 'L';

            File.Delete(path);

            WriteByteArrayToFile(encryptedFilePath, bytes);
        }

        internal static void DecryptFile(string path)
        {
            var bytes = FileToByteArray(path);
            var decryptedFilePath = Directory.GetCurrentDirectory() + @"\data.txt";

            for (var i = 0; i < bytes.Length; i++) bytes[i] -= (byte) 'L';

            File.Delete(path);

            WriteByteArrayToFile(decryptedFilePath, bytes);
        }
    }
}
