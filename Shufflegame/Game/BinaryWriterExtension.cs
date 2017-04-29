using System.IO;

namespace Game
{
    public static class BinaryWriterExtension
    {
        public static void WriteScore(this BinaryWriter bw,Score sc)
        {
            bw.Write(sc.Name);
            bw.Write(sc.Keystroce);
        }
    }
}
