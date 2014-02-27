using CWrapped;

namespace MineLib.Network.Packets.Client
{
    public struct KeepAlivePacket : IPacket
    {
        public int KeepAlive;

        public const byte PacketID = 0x00;
        public byte Id { get { return 0x00; } }

        public void ReadPacket(ref Wrapped stream)
        {
            KeepAlive = stream.ReadInt();
        }

        public void WritePacket(ref Wrapped stream)
        {
            stream.WriteVarInt(Id);
            stream.WriteInt(KeepAlive);
            stream.Purge();
        }
    }
}