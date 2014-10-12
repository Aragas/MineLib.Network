﻿using MineLib.Network.IO;

namespace MineLib.Network.Classic.Packets.Extension.Server
{
    public struct RemoveSelectionPacket : IPacketWithSize
    {
        public byte SelectionID;

        public byte ID { get { return 0x1B; } }
        public short Size { get { return 2; } }

        public void ReadPacket(PacketByteReader stream)
        {
            SelectionID = stream.ReadByte();
        }

        public void WritePacket(ref PacketStream stream)
        {
            stream.WriteByte(ID);
            stream.WriteByte(SelectionID);
            stream.Purge();
        }
    }
}