﻿using P01.FileStream_After.Contracts;

namespace P01._FileStream_Before
{
    public class Music : IStream
    {
        public int Length { get; set; }

        public int Sent { get; set; }

        public string Artist { get; set; }

        public string Album { get; set; }
    }
}