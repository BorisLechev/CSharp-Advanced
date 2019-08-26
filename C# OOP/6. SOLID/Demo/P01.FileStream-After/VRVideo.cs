using P01.FileStream_After.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.FileStream_After
{
    public class VRVideo : IStream
    {
        public int Length { get; set; }

        public int Sent { get; set; }

        public string ThreeDSpace { get; set; }
    }
}
