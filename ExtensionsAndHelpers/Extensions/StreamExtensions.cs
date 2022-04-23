namespace ExtensionsAndHelpers
{
    public static class StreamExtensions
    {
        /// <summary>
        /// Converts the elements of a stream into a byte[]
        /// </summary>
        public static byte[] ConvertToByteArray(this Stream stream)
        {
            var streamLength = Convert.ToInt32(stream.Length);

            byte[] data = new byte[streamLength + 1];

            stream.Read(data, 0, streamLength);
            stream.Close();

            return data;
        }
    }
}
