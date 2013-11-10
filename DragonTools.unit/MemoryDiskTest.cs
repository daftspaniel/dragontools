﻿/*
Copyright (c) 2011-2013, Rolf Michelsen
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
using System.CodeDom;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RolfMichelsen.Dragon.DragonTools.IO.Disk;

namespace DragonTools.unit
{
    [TestClass]
    public class MemoryDiskTest
    {
        private MemoryDisk disk = null;

        private const int Heads = 1;
        private const int Tracks = 2;
        private const int Sectors = 2;
        private const int SectorSize = 10;

        [TestInitialize]
        public void ClassInitialize()
        {
            disk = new MemoryDisk(Heads, Tracks, Sectors, SectorSize);
        }



        [TestMethod]
        public void SectorEnumeratorNotInitialized()
        {
            var enumerator = ((IEnumerable<ISector>) disk).GetEnumerator();
            var sector = enumerator.Current;
            Assert.IsNull(sector);
        }


        [TestMethod]
        public void SectorEnumeratorReturnsAllSectors()
        {
            var enumerator = ((IEnumerable<ISector>) disk).GetEnumerator();
            int sectorCount = 0;
            while (enumerator.MoveNext())
            {
                sectorCount++;
            }
            Assert.AreEqual(Heads*Tracks*Sectors, sectorCount);
        }

    }
}
