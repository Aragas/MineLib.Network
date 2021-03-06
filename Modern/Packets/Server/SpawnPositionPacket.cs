using MineLib.Network.Data;
using MineLib.Network.IO;

namespace MineLib.Network.Modern.Packets.Server
{
    public struct SpawnPositionPacket : IPacket
    {
        public Position Location;

        public byte ID { get { return 0x05; } }

        public IPacket ReadPacket(IMinecraftDataReader reader)
        {
            Location = Position.FromReaderLong(reader);

            return this;
        }

        public IPacket WritePacket(IMinecraftStream stream)
        {
            stream.WriteVarInt(ID);
            Location.ToStreamLong(stream);
            stream.Purge();

            return this;
        }
    }
}