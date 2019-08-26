using System;
using System.Collections.Generic;
using System.Text;

namespace P01.FileStream_After.Contracts
{
    public interface IStream
    {
        int Length { get; }

        int Sent { get; }
    }
}
