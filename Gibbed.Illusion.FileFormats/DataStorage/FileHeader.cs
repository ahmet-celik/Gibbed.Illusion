﻿using System;
using System.IO;
using Gibbed.Helpers;

namespace Gibbed.Illusion.FileFormats.DataStorage
{
    public class FileHeader : ICloneable
    {
        public uint TypeId;
        public uint Size; // includes headers (such as the first 30 bytes)
        public ushort Version;
        public uint SlotRamRequired;
        public uint SlotVramRequired;
        public uint OtherRamRequired;
        public uint OtherVramRequired;

        public void Serialize(Stream output, bool littleEndian)
        {
            output.WriteValueU32(this.TypeId, littleEndian);
            output.WriteValueU32(this.Size, littleEndian);
            output.WriteValueU16(this.Version, littleEndian);
            output.WriteValueU32(this.SlotRamRequired, littleEndian);
            output.WriteValueU32(this.SlotVramRequired, littleEndian);
            output.WriteValueU32(this.OtherRamRequired, littleEndian);
            output.WriteValueU32(this.OtherVramRequired, littleEndian);
        }

        public void Deserialize(Stream input, bool littleEndian)
        {
            this.TypeId = input.ReadValueU32(littleEndian);
            this.Size = input.ReadValueU32(littleEndian);
            this.Version = input.ReadValueU16(littleEndian);
            this.SlotRamRequired = input.ReadValueU32(littleEndian);
            this.SlotVramRequired = input.ReadValueU32(littleEndian);
            this.OtherRamRequired = input.ReadValueU32(littleEndian);
            this.OtherVramRequired = input.ReadValueU32(littleEndian);
        }

        public object Clone()
        {
            return new FileHeader()
            {
                TypeId = this.TypeId,
                Size = this.Size,
                Version = this.Version,
                SlotRamRequired = this.SlotRamRequired,
                SlotVramRequired = this.SlotVramRequired,
                OtherRamRequired = this.OtherRamRequired,
                OtherVramRequired = this.OtherVramRequired,
            };
        }
    }
}
