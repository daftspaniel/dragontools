﻿/*
Copyright (c) 2011-2012, Rolf Michelsen
All rights reserved.

Redistribution and use in source and binary forms, with or without 
modification, are permitted provided that the following conditions are met:

    * Redistributions of source code must retain the above copyright 
      notice, this list of conditions and the following disclaimer.
    * Redistributions in binary form must reproduce the above copyright 
      notice, this list of conditions and the following disclaimer in the 
      documentation and/or other materials provided with the distribution.
    * Neither the name of Rolf Michelsen nor the 
      names of other contributors may be used to endorse or promote products 
      derived from this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY 
EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE 
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY 
DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES 
(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; 
LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY 
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, 
EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/


using System;

namespace RolfMichelsen.Dragon.DragonTools.IO.Filesystem.DragonTape
{
    /// <summary>
    /// Represents a data tape block
    /// </summary>
    public sealed class DragonTapeDataBlock : DragonTapeBlock
    {

        /// <summary>
        /// Create a file data block.
        /// </summary>
        /// <param name="data">Memory area containing block data payload.</param>
        /// <param name="offset">Offset into memory area of first byte of block payload.</param>
        /// <param name="length">Length of block payload.</param>
        /// <exception cref="ArgumentOutOfRangeException">The payload size exceeds <see cref="MaxPayloadLength">MaxPayloadLength</see>.</exception>
        public DragonTapeDataBlock(byte[] data, int offset, int length) : base(DragonTapeBlockType.Data)
        {
            if (length > MaxPayloadLength) throw new ArgumentOutOfRangeException("length", length, String.Format("Block payload size cannot exceed {0} bytes", MaxPayloadLength));
            SetData(data, offset, length);
            Checksum = ComputeChecksum();
        }


        /// <summary>
        /// Create a file data block.
        /// </summary>
        /// <param name="data">Data block payload.</param>
        /// <exception cref="ArgumentOutOfRangeException">The payload size exceeds <see cref="MaxPayloadLength">MaxPayloadLength</see>.</exception>
        public DragonTapeDataBlock(byte[] data) : this(data, 0, (data == null) ? 0 : data.Length) { }


        /// <summary>
        /// Create a file data block.
        /// </summary>
        /// <param name="data">Memory area containing block data payload.</param>
        /// <param name="offset">Offset into memory area of first byte of block payload.</param>
        /// <param name="length">Length of block payload.</param>
        /// <param name="checksum">Block checksum.</param>
        internal DragonTapeDataBlock(byte[] data, int offset, int length, int checksum)
            : base(DragonTapeBlockType.Data)
        {
            SetData(data, offset, length);
            Checksum = checksum;
        }


        public override string ToString()
        {
            return String.Format("Block: Type={0} (Data) Length={1} Checksum={2} ({3})", (int)BlockType, Length, Checksum, (IsChecksumValid() ? "Valid" : "Invalid"));
        }
    }
}
