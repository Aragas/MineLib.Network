﻿using MineLib.Network.Classic.Enums;
using MineLib.Network.IO;

namespace MineLib.Network.Classic.Packets.Extension.Server
{
    public struct EnvSetColorPacket : IPacketWithSize
    {
        public EnvironmentalVariable Variable;
        public short Red;
        public short Green;
        public short Blue;

        public byte ID { get { return 0x19; } }
        public short Size { get { return 8; } }

        public IPacketWithSize ReadPacket(IMinecraftDataReader reader)
        {
            Variable = (EnvironmentalVariable) reader.ReadByte();
            Red = reader.ReadShort();
            Green = reader.ReadShort();
            Blue = reader.ReadShort();

            return this;
        }

        IPacket IPacket.ReadPacket(IMinecraftDataReader reader)
        {
            return ReadPacket(reader);
        }

        public IPacket WritePacket(IMinecraftStream stream)
        {
            stream.WriteByte(ID);
            stream.WriteByte((byte) Variable);
            stream.WriteShort(Red);
            stream.WriteShort(Green);
            stream.WriteShort(Blue);
            stream.Purge();

            return this;
        }
    }
}
