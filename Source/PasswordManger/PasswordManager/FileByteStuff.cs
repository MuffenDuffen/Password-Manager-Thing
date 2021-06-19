using System.IO;

namespace PasswordManger
{
    public class FileByteStuff
    {
        private static byte[] fileToByteArray(string path)
        {
            var stream = File.OpenRead(path);
            var fileBytes = new byte[stream.Length];

            stream.Read(fileBytes, 0, fileBytes.Length);
            stream.Close();

            return fileBytes;
        }

        private static void writeByteArrayToFile(string filePath, byte[] bytes)
        {
            File.Create(filePath).Dispose();

            using (Stream file = File.OpenWrite(filePath))
            {
                file.Write(bytes, 0, bytes.Length);
            }
        }


        public static void encryptFile(string path)
        {
            var bytes = fileToByteArray(path);
            var encryptedFilePath = Directory.GetCurrentDirectory() + @"\data.jpg";

            for (var i = 0; i < bytes.Length; i++) bytes[i] += (byte) 'L';

            File.Delete(path);

            writeByteArrayToFile(encryptedFilePath, bytes);
        }

        public static void decryptFile(string path)
        {
            var bytes = fileToByteArray(path);
            var decryptedFilePath = Directory.GetCurrentDirectory() + @"\data.txt";

            for (var i = 0; i < bytes.Length; i++) bytes[i] -= (byte) 'L';

            File.Delete(path);

            writeByteArrayToFile(decryptedFilePath, bytes);
        }
    }
}
