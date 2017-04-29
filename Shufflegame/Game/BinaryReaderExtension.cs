using System.IO;

namespace Game
{
    public static class BinaryReaderExtension
    {
        public static Score ReadScore(this BinaryReader br)
        {
            Score sc = new Score();
            sc.Name = br.ReadString();
            sc.Keystroce = br.ReadInt32();
            return sc;
        }
    }
}
